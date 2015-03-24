using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using PTKSOFT.Utils2;
using ZiCure.Log;
using Newtonsoft.Json;

namespace xDB2013
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            FRM.Main = this;
            
            /* Init Normal Windows Component */
            zLog.Write("Begin InitializeComponent() for frmMain");
            InitializeComponent();
            zLog.Write("End InitializeComponent() of frmMain");

            /* Load windows 's size config from last save */
            if (that.Config.Contains(KW.WindowsWidth))
                this.Width = that.Config.GetInt(KW.WindowsWidth);
            if (that.Config.Contains(KW.WindowsHeight))
                this.Height = that.Config.GetInt(KW.WindowsHeight);
            if (that.Config.Contains(KW.WindowsTop))
                this.Top = that.Config.GetInt(KW.WindowsTop);
            if (that.Config.Contains(KW.WindowsLeft))
                this.Left = that.Config.GetInt(KW.WindowsLeft);
            if (that.Config[KW.WindowsState].Equals("MAX"))
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

            menuMain.Visible = false;
            lstDebug.Visible = false;
            tabMain.Location = new Point(0, mainToolBar.Top + mainToolBar.Height);
            tabMain.Visible = false;
            for (int i = 0; i < mainToolBar.Items.Count; i++) mainToolBar.Items[i].Enabled = false;
        }        
        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.Text = that.ProgramNameAndVersion();

            that.DebugAndLog("Begin lstDebug...");
            lstDebug.Dock = DockStyle.Fill;
            lstDebug.Visible = true;
            this.Refresh();

            /* Check Version Update */
            if (that.CheckProgramUpdate())
            {
                that.DebugAndLog("Program has been UPDATE new version, Need to Restart");
                //P2P.UDP.Terminate();
                Application.Exit();
                Environment.Exit(0);
                return;
            }
            else
            {
                that.DebugAndLog("CheckProgramUpdate() return FALSE, No need to restart");
            }

            that.DebugAndLog("Prepare MovieDB...");
            if (!MovieDB.CheckAndPrepareDbFolder())
            {
                that.DebugAndLog("Error in Parepare MovieDB!");
                MessageBox.Show("Error Cannot Prepare MovieDB");
                Application.Exit();
                return;
            }
            else
            {
                that.DebugAndLog("Prepare MovieDB Success");
            }

            that.DebugAndLog("Prepare MovieIMG...");
            if (!MovieDB.CheckAndPrepareImgFolder())
            {
                that.DebugAndLog("Error in Prepare MovieIMG!");
                MessageBox.Show("Error Cannot Prepare MovieDB");
                Application.Exit();
                return;
            }
            else
            {
                that.DebugAndLog("Prepare MovieIMG Success");
            }

            that.DebugAndLog("Load MovieDB from Disk");
            if (!MovieDB.LoadMovieProfileFromDisk())
            {
                that.DebugAndLog("Error in Load MovieDB from Disk!!");
                MessageBox.Show("Error Cannot Load MovieDB from Disk!!");
                Application.Exit();
                return;
            }

            that.DebugAndLog("Begin menuMain...");
            menuMain.Visible = true;
            menuOptionAutoBuildHash.Checked = that.Config[KW.AutoBuildHashIfEmpty].ToUpper().Equals(KW.YES);
            menuOptionDeleteSourcePicture.Checked = that.Config[KW.DeleteSourcePicture].ToUpper().Equals(KW.YES);
            menuOptionAllSaveOfflineProfile.Checked = that.Config[KW.AllowEditOfflineProfile].ToUpper().Equals(KW.YES);
            this.Refresh();

            that.DebugAndLog("Begin mainToolBar...");
            for (int i = 0; i < mainToolBar.Items.Count; i++)
            {
                mainToolBar.Items[i].Enabled = true;
            }
            this.Refresh();

            that.DebugAndLog("Begin refresh list filter...");
            RefreshFilterList();

            that.DebugAndLog("Begin tabMain...");
            lstDebug.Visible = false;
            tabMain.Dock = DockStyle.Fill;
            TabPage movieListTemplate = tabMain.TabPages["tabMovieList"];
            tabMain.TabPages.Clear();
            tabMain.Visible = true;
            this.Refresh();

            generateTabFunctionKey();
        }
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (!this.Visible) return;

            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    that.Config[KW.WindowsState] = "MAX";
                    that.SaveConfig();
                    break;

                case FormWindowState.Normal:
                    that.Config[KW.WindowsState] = "NOR";
                    that.Config[KW.WindowsHeight] = this.Height.ToString();
                    that.Config[KW.WindowsWidth] = this.Width.ToString();
                    that.SaveConfig();
                    break;
            }
        }
        private void frmMain_Move(object sender, EventArgs e)
        {
            if (
                (this.Visible)
                && (this.WindowState != FormWindowState.Maximized)
                && (this.WindowState != FormWindowState.Minimized))
            {
                that.Config[KW.WindowsLeft] = this.Left.ToString();
                that.Config[KW.WindowsTop] = this.Top.ToString();
                that.Config.Save();
            }
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //P2P.Terminate();
            that.CloseRunningInstant_UseUdpBind();
        }
       
        private void menuFileExit_Click(object sender, EventArgs e)
        {
            if (!menuFile.Visible) return;
            if (!menuFile.Enabled) return;
            
            Application.Exit();
        }
        private void menuFileImportMovie_Click(object sender, EventArgs e)
        {
            if (!menuFile.Visible) return;
            if (!menuFile.Enabled) return;

            OpenFileDialog file2Open = new OpenFileDialog();
            if (file2Open.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            that.ShowWin_ImportMovieFromFile(file2Open.FileName);
        }

        private void menuMovieAll_Click(object sender, EventArgs e)
        {
            if (!menuMovie.Visible) return;
            if (!menuMovie.Enabled) return;

            that.ShowTab_AllMovie();
        }
        private void menuMovieManageFilter_Click(object sender, EventArgs e)
        {
            if (!menuMovie.Visible) return;
            if (!menuMovie.Enabled) return;

            that.ShowWin_ManageFilter();
        }        
        private void menuMovieFind_Click(object sender, EventArgs e)
        {
            if (!menuMovie.Visible) return;
            if (!menuMovie.Enabled) return;

            frmSearch frm = new frmSearch();
            frm.Show();
        }
        private void menuMovieStatistics_Click(object sender, EventArgs e)
        {
            if (!menuMovie.Visible) return;
            if (!menuMovie.Enabled) return;

            that.ShowWin_StatWindows();
        }

        private void menuOptionAutoBuildHash_Click(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;

            that.Config[KW.AutoBuildHashIfEmpty] = (
                (menuOptionAutoBuildHash.Checked == true) ?
                ("YES") :
                ("NO")
            );
            that.Config.Save();
        }
        private void menuOptionDeleteSourcePicture_Click(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;

            that.Config[KW.DeleteSourcePicture] = (
                (menuOptionDeleteSourcePicture.Checked == true) ?
                ("YES") :
                ("NO")
            );
            that.Config.Save();
        }
        private void menuOptionAllSaveOfflineProfile_Click(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;

            that.Config[KW.AllowEditOfflineProfile] = (
                (menuOptionAllSaveOfflineProfile.Checked == true) ?
                ("YES") :
                ("NO")
            );
            that.Config.Save();
        }                

        private void menuNetworkPeerToPeer_Click(object sender, EventArgs e)
        {
            if (!this.menuNetwork.Visible) return;
            if (!this.menuNetwork.Enabled) return;

            that.ShowWin_ListPeerProfile();
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            if (!menuHelp.Visible) return;
            if (!menuHelp.Enabled) return;

            that.ShowTab_HelpInformation();
        }        
        private void menuHelpCheckUpdate_Click(object sender, EventArgs e)
        {
            if (!menuHelp.Visible) return;
            if (!menuHelp.Enabled) return;

            that.Config[KW.TimeCheckUpdate] = "";
            if (that.CheckProgramUpdate())
            {
                this.Close();
                Application.Exit();
                Environment.Exit(0);
            }
        }

        public void generateTabFunctionKey()
        {
            tabMain.Visible = (tabMain.TabPages.Count > 0);
            lstDebug.Visible = !tabMain.Visible;
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                TabPage tpNow = tabMain.TabPages[i];
                string fKey = "";
                if (i < 12) fKey = "F" + (i + 1).ToString() + " - ";
                tpNow.Text = fKey + ((string[])tpNow.Tag)[1];
            }
            toolCloseTab.Enabled = (tabMain.TabPages.Count > 0);
            this.Refresh();
        }
        private void menuTabClose_Click(object sender, EventArgs e)
        {
            if (!menuTab.Visible) return;
            if (!menuTab.Enabled) return;

            if (tabMain.SelectedTab == null) return;
            tabMain.TabPages.Remove(tabMain.SelectedTab);
            this.generateTabFunctionKey();
        }
        private void go2Tab(object sender, EventArgs e)
        {
            if (!menuTab.Visible) return;
            if (!menuTab.Enabled) return;

            string sTag = "";
            try { sTag = ((ToolStripMenuItem)sender).Tag.ToString(); } catch {}
            int numTab;
            try { numTab = int.Parse(sTag); } catch { numTab = -1; }
            if (numTab >= 1 && numTab <= tabMain.TabPages.Count)
            {
                zLog.Write("Set current TAB to #" + numTab.ToString());
                tabMain.SelectedIndex = numTab - 1;
            }
        }
        
        public void RefreshAllMovieTab()
        {
            if (this.tabMain.TabPages.Count < 1) return;
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                TabPage tab = tabMain.TabPages[i];
                if (!(tab.Tag is string[])) continue;
                if (((string[])tab.Tag)[0] != "all_movies") continue;
                foreach (Control ctl in tab.Controls)
                {
                    if (!(ctl is ucMovieList)) continue;
                    ((ucMovieList)ctl).RefreshMovieList(MovieDB.GetMovieList(), "All Movie");
                    break;
                }
            }
        }
        public void RefreshFilterList()
        {
            toolFilter.DropDownItems.Clear();
            foreach (string k in that.Filter.Keys)
            {
                try
                {
                    MovieFilter testFilter = JsonConvert.DeserializeObject<MovieFilter>(that.Filter[k]);
                    toolFilter.DropDownItems.Add(k, null, new EventHandler(toolToolFilter_Click));
                }
                catch { }
            }
            toolFilter.Enabled = (toolFilter.DropDownItems.Count > 0);
        }
        public void toolToolFilter_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            string k = tsi.Text;
            that.ShowTab_FilterMovie(k);
        }

        private void toolImportMovie_Click(object sender, EventArgs e)
        {
            menuFileImportMovie_Click(sender, e);
        }
        private void toolAllFiles_Click(object sender, EventArgs e)
        {
            menuMovieAll_Click(sender, e);
        }
        private void toolSearch_Click(object sender, EventArgs e)
        {
            menuMovieFind_Click(sender, e);
        }
        private void toolStat_Click(object sender, EventArgs e)
        {
            if (!toolStat.Visible) return;
            if (!toolStat.Enabled) return;
            if (!this.Visible) return;
            if (!this.Enabled) return;

            menuMovieStatistics_Click(sender, e);
        }
        private void toolPeer2Peer_Click(object sender, EventArgs e)
        {
            menuNetworkPeerToPeer_Click(sender, e);
        }
        private void toolCloseTab_Click(object sender, EventArgs e)
        {
            menuTabClose_Click(sender, e);
        }
        private void toolExitProgram_Click(object sender, EventArgs e)
        {
            menuFileExit_Click(sender, e);
        }

        private void tmrDebug_Tick(object sender, EventArgs e)
        {
            tmrDebug.Enabled = false;

            while (true)
            {
                lock (that.queDebugMessage.SyncRoot)
                {
                    // Jump is que EMPTY
                    if (that.queDebugMessage.Count == 0) break;
                }

                // Process and Clear Queue
                while (that.queDebugMessage.Count > 0)
                {
                    lock (that.queDebugMessage.SyncRoot)
                    {
                        lstDebug.Items.Add((string)that.queDebugMessage.Dequeue());
                    }
                    // Reduce item retain history at 300 Lines
                    while (lstDebug.Items.Count > 300) lstDebug.Items.RemoveAt(0);
                    lstDebug.SelectedIndex = lstDebug.Items.Count - 1;
                    if (lstDebug.Visible) lstDebug.Refresh();
                }

                // Default break;
                break;
            }

            tmrDebug.Enabled = true;
        }

        private void menuProfileImportParseFromFileInDir_Click(object sender, EventArgs e)
        {
            if (!menuProfile.Visible) return;
            if (!menuProfile.Enabled) return;

            FolderBrowserDialog dir2open = new FolderBrowserDialog();
            if (dir2open.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            that.ShowWin_ParseProfileFromDirectory(dir2open.SelectedPath);            
        }

    }
}
