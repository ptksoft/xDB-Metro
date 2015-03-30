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
    public partial class frmMovieProfile : Form
    {
        public MovieProfile param_MovieProfile = null;
        public ucMovieList param_MovieList = null;
        public bool param_isRefreshAllMovieAfterClose = false;
        public bool param_isNewImport = false;
        protected bool IsBuildingHash = false;
        private bool isEnableSavePosition = false;
        private int percentCompleteHashing = 0;

        public frmMovieProfile()
        {
            InitializeComponent();
        }
        
        private void frmMovieProfile_Load(object sender, EventArgs e)
        {
            zLog.Write("Form MovieProfile Load..");
            txtCode.Text = "";
            
            cboType.Items.Clear();
            cboType.Text = "";
            cboType.Items.AddRange(MovieProfile.ListType.ToArray());

            cboCountry.Items.Clear();
            cboCountry.Text = "";
            cboCountry.Items.AddRange(MovieProfile.ListCountry.ToArray());

            cboRating.Items.Clear();
            cboRating.Text = "";
            cboRating.Items.AddRange(MovieProfile.ListRating.ToArray());

            txtTitle.Text = "";
            lstActress.Items.Clear();
            lstTag.Items.Clear();
            txtStory.Text = "";
            lblCreatedTime.Text = "";
            lblModifiedTime.Text = "";
            lblViewTime.Text = "";
            txtFilePath.Text = "";
            txtHash.Text = "";
            pgbBuildHash.Visible = false;
            lblBuildHash.Visible = false;                        
            btnSave.Enabled = false;

            tabMain.TabPages.Remove(tabFrontCover);
            tabMain.TabPages.Remove(tabBackCover);
            tabMain.TabPages.Remove(tabScreenShot1);
            tabMain.TabPages.Remove(tabScreenShot2);
            tabMain.TabPages.Remove(tabFoundDuplicate);
            tabMain.TabPages.Remove(tabAdvanced);

            _Do_LoadPositionOfProfileWindows();
        }
        private void frmMovieProfile_Shown(object sender, EventArgs e)
        {
            zLog.Write(
                "Form MovieProfile Shown: Movie->FilePath(" 
                + param_MovieProfile.FilePath 
                + ") Hash={" 
                + param_MovieProfile.Hash + "}");
            
            refreshDataFromParam(); // Movie Profile Data
            RefreshTabMovieImage(0); // Check file all MovieImage if existing
            __CheckAddImageState(); // Check Add Cover&SS Button state

            this.isEnableSavePosition = true;   // Enable Save MovePosition Of Windows
        }
        private void frmMovieProfile_Move(object sender, EventArgs e)
        {
            if (this == null) return;
            if (!this.Visible) return;
            if (!this.Enabled) return;
            if (this.WindowState != FormWindowState.Normal) return;

            _Do_SavePositionOfProfileWindows();
        }
        private void frmMovieProfile_Resize(object sender, EventArgs e)
        {
            if (this == null) return;
            if (!this.Visible) return;
            if (!this.Enabled) return;
            if (this.WindowState != FormWindowState.Normal) return;

            _Do_SavePositionOfProfileWindows();
        }        

        private void refreshDataFromParam()
        {
            if (param_MovieProfile == null) return;

            if (!param_MovieProfile.Code.Equals(""))
            {
                txtCode.Text = param_MovieProfile.Code;
                this.Text = param_MovieProfile.Code;
            }

            cboType.Text = param_MovieProfile.Type;
            cboCountry.Text = param_MovieProfile.Country;
            cboRating.Text = param_MovieProfile.Rating.ToString();
            txtTitle.Text = param_MovieProfile.Title;
            if (txtTitle.Text.Length.Equals(0) && param_isNewImport)
                txtTitle.Text = Path.GetFileNameWithoutExtension(param_MovieProfile.FilePath);

            lstActress.Items.Clear();
            string[] arrActress = param_MovieProfile.Actress.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrActress.Length; i++) lstActress.Items.Add(arrActress[i]);

            lstTag.Items.Clear();
            string[] arrTag = param_MovieProfile.Tag.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrTag.Length; i++) lstTag.Items.Add(arrTag[i]);

            txtStory.Text = param_MovieProfile.Story;
            if (!param_MovieProfile.CreatedTime.Equals(DateTime.MinValue))
            {
                lblCreatedTime.Text = ptkConvert.DateTimeToSqlFormat(param_MovieProfile.CreatedTime);
            }
            if (!param_MovieProfile.ModifiedTime.Equals(DateTime.MinValue))
            {
                lblModifiedTime.Text = ptkConvert.DateTimeToSqlFormat(param_MovieProfile.ModifiedTime);
            }
            if (!param_MovieProfile.ViewTime.Equals(DateTime.MinValue))
            {
                lblViewTime.Text = ptkConvert.DateTimeToSqlFormat(param_MovieProfile.ViewTime);
            }
            lblCountPlay.Text = param_MovieProfile.CountPlay.ToString();

            txtFilePath.Text = param_MovieProfile.FilePath;
            if (!param_MovieProfile.Hash.Equals(""))
            {
                // Existing HASH Key
                if (param_isNewImport)
                {
                    // New Import with Complete HASH Key in file Name
                    _CheckExisting_MovieDB();
                }
                else
                {
                    // Open existing in MovieDB
                    txtHash.Text = param_MovieProfile.Hash;
                    lblBuildHash.Visible = false;
                }
            }
            else
            {
                // New Import with NO HASH Key
                lblBuildHash.Visible = true;

                if (that.Config[KW.AutoBuildHashIfEmpty].ToUpper().Equals("YES"))
                {
                    that.DebugAndLog("Auto Build Hash on file " + param_MovieProfile.FilePath);
                    Begin_BuildHash();
                }
            }            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _Do_CloseForm();
        }
        private void frmMovieProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.IsBuildingHash)
            {
                zLog.Write("User try to close form while BuildingHash, Cancelled");
                e.Cancel = true;
            }
            else
            {
                zLog.Write(
                "Form MovieProfile Closing: Movie->FilePath("
                + param_MovieProfile.FilePath
                + ") Hash={"
                + param_MovieProfile.Hash + "}");
            }
        }
        private void frmMovieProfile_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;

            _DoCheckKeyFunction(sender, e);
        }
        private void _DoCheckKeyFunction(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: _Do_AddActress(); break;
                case Keys.F3: _Do_Search(); break;
                case Keys.F4: _Do_AddTag(); break;
                case Keys.F5: _Do_PlayMovie(); break;
                case Keys.F9: btnSave_Click(sender, new EventArgs()); break;
            }
        }

        private void lblBuildHash_Click(object sender, EventArgs e)
        {
            if (!lblBuildHash.Visible) return;
            if (this.IsBuildingHash) return;

            Begin_BuildHash();
        }

        private void Begin_BuildHash()
        {
            lblBuildHash.Visible = false;
            txtHash.Visible = false;

            btnAddFrontCover.Enabled = false;
            btnAddBackCover.Enabled = false;
            btnAddScreenShot1.Enabled = false;
            btnAddScreenShot2.Enabled = false;
            btnSave.Enabled = false;
            btnClose.Enabled = false;
            
            pgbBuildHash.Visible = true;
            
            this.Refresh();                        
            tmrBuildHash.Start();

            // Call Building Hash from File
            bgWorking.RunWorkerAsync();
        }
        private void bgWorking_DoWork(object sender, DoWorkEventArgs e)
        {
            zLog.Write("Begin bgWorking: Build hash MD5 File(" + param_MovieProfile.FilePath + ")");

            this.IsBuildingHash = true;
            //param_MovieProfile.Hash = ptkConvert.Md5File(param_MovieProfile.FilePath);
            ptkHashingFileWithProgress hashMD5 = new ptkHashingFileWithProgress(param_MovieProfile.FilePath);
            if (hashMD5.StartHashingThread())
            {
                zLog.Write("Start ptkHashingFileWithProgress: Success");
                while ((!hashMD5.IsFinish) && (!hashMD5.IsError))
                {
                    if (that.IsQuit)
                    {
                        hashMD5.IsCancel = true;
                        zLog.Write("Cancel ptkHashingFileWithProgress ... Detected that.IsQuit!");
                        break;
                    }
                    this.percentCompleteHashing = hashMD5.PercentComplete;
                    Thread.Sleep(1);
                }
                if (hashMD5.IsError)
                {
                    zLog.Write("Error in building Hash by ptkHashFileWithProgress");
                }
                if (hashMD5.IsFinish && hashMD5.PercentComplete == 100)
                {
                    param_MovieProfile.Hash = hashMD5.HashResult;
                    zLog.Write("Success building hash by ptkHashFileWithProgress: " + hashMD5.HashResult);
                }
            }
            this.IsBuildingHash = false;

            zLog.Write("Finish bgWorking: Build hash MD5 File(" + param_MovieProfile.FilePath + ")");
        }
        private void tmrBuildHash_Tick(object sender, EventArgs e)
        {
            if (!this.IsBuildingHash)
            {
                // Finish Building Has
                tmrBuildHash.Stop();
                _End_BuildHash();
            }
            else
            {
                // During Build Hash -- Show Progress
                if (pgbBuildHash.Value >= pgbBuildHash.Maximum) pgbBuildHash.Value = 0;

                pgbBuildHash.Value = this.percentCompleteHashing;
                this.Refresh();
            }
        }
        private void _End_BuildHash()
        {
            txtHash.Text = param_MovieProfile.Hash;
            txtHash.Visible = true;
            pgbBuildHash.Visible = false;
            btnClose.Enabled = true;

            __CheckAddImageState();
            __CheckCanSave();
            this.Refresh();

            _CheckExisting_MovieDB();   // Check If Already Existing
        }
        private void _CheckExisting_MovieDB()
        {
            if (! param_MovieProfile.Hash.Length.Equals(32)) return;

            if (MovieDB.hMovie.Contains(param_MovieProfile.Hash))
            {
                MessageBox.Show("This File is already Existing in MovieDB", "File Duplicate!", MessageBoxButtons.OK);
                this.Left = this.Left - 50;
                this.Top = this.Top - 50;
                
                // If existing SAVE Profile is Impossible
                btnSave.Visible = false;

                tabMain.TabPages.Insert(0, tabFoundDuplicate);
                tabMain.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!btnSave.Visible) return;
            if (!btnSave.Enabled) return;
            if (IsBuildingHash) return;
            btnSave.Enabled = false;
            btnClose.Enabled = false;

            if (_Do_SaveMovieProfile())
            {   //-- Auto Close MovieProfile windows if Save Success
                btnClose_Click(sender, e);
                return;
            }

            // Have some Error
            btnSave.Enabled = true;
            btnClose.Enabled = true;
        }        
        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            __CheckCanSave();
            if (this.Visible && txtCode.Enabled)
            {
                lblSearch.Visible = (txtCode.Text.Trim().Length > 0);
                lblSearchFunctionKey.Visible = lblSearch.Visible;
            }
        }
        private void cboType_TextChanged(object sender, EventArgs e)
        {
            __CheckCanSave();
        }
        private void cboCountry_TextChanged(object sender, EventArgs e)
        {
            __CheckCanSave();
        }
        private void cboRating_TextChanged(object sender, EventArgs e)
        {
            __CheckCanSave();
        }
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            __CheckCanSave();
        }
        private void txtStory_TextChanged(object sender, EventArgs e)
        {
            __CheckCanSave();
        }

        private void lblAddActress_Click(object sender, EventArgs e)
        {
            _Do_AddActress();
        }        
        private void lblAddTag_Click(object sender, EventArgs e)
        {
            _Do_AddTag();
        }        
        private void lblPlay_Click(object sender, EventArgs e)
        {
            _Do_PlayMovie();
        }        
        private void lblSearch_Click(object sender, EventArgs e)
        {
            _Do_Search();
        }
        private void lblAdvanceTab_Click(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;

            lblAdvanceTab.Visible = false;
            _Do_ShowAdvanceTab();
        }
        
        private void btnAddFrontCover_Click(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;
            if (!btnAddFrontCover.Visible) return;
            if (!btnAddFrontCover.Enabled) return;

            _Do_SelectAdd_FrontCover();
        }
        private void btnAddBackCover_Click(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;
            if (!btnAddBackCover.Visible) return;
            if (!btnAddBackCover.Enabled) return;

            _Do_SelectAdd_BackCover();
        }
        private void btnAddScreenShot1_Click(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;
            if (!btnAddScreenShot1.Visible) return;
            if (!btnAddScreenShot1.Enabled) return;

            _Do_SelectAdd_ScreenShot1();
        }
        private void btnAddScreenShot2_Click(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;
            if (!btnAddScreenShot2.Visible) return;
            if (!btnAddScreenShot2.Enabled) return;

            _Do_SelectAdd_ScreenShot2();
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            _Do_ViewDuplicateProfile();
        }
        private void btnDeleteThisFile_Click(object sender, EventArgs e)
        {
            _Do_DeleteThisFile();
        }
        private void btnUseThisFile_Click(object sender, EventArgs e)
        {
            _Do_UseThisFile();
        }
        private void btnDeleteFilePath_Click(object sender, EventArgs e)
        {
            _Do_DeleteLastFilePath();
        }
        
        private void lstTag_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete: _Do_RemoveTag(); break;
            }
        }        
        private void lstActress_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete: _Do_RemoveActress(); break;
            }
        }

        private void RefreshTabMovieImage(int idx)
        {
            if (idx == 1 || idx == 0)
                _Do_LoadImageAndDisplayTab(
                    MovieDB.GetFilePath_MovieImage_FrontCover(this.param_MovieProfile),
                    tabFrontCover);

            if (idx == 2 || idx == 0)
            _Do_LoadImageAndDisplayTab(
                MovieDB.GetFilePath_MovieImage_BackCover(this.param_MovieProfile),
                tabBackCover);

            if (idx == 3 || idx == 0)
            _Do_LoadImageAndDisplayTab(
                MovieDB.GetFilePath_MovieImage_ScreenShot1(this.param_MovieProfile),
                tabScreenShot1);

            if (idx == 4 || idx == 0)
            _Do_LoadImageAndDisplayTab(
                MovieDB.GetFilePath_MovieImage_ScreenShot2(this.param_MovieProfile),
                tabScreenShot2);
        }        
        private void _Do_LoadImageAndDisplayTab(string fileImg, TabPage tab)
        {
            if (fileImg.Length < 1) return;

            // Remove any control in tab if tab is alread add to tabMain.Tabpages
            if (tabMain.TabPages.Contains(tab))
            {
                foreach (Control ctl in tab.Controls)
                    tab.Controls.Remove(ctl);
            }
            else
            {
                tabMain.TabPages.Add(tab);
            }

            // Create new picture box to load Image into tab
            tab.Tag = fileImg;
            PictureBox pcb = new PictureBox();
            pcb.Parent = tab;
            pcb.Dock = DockStyle.Fill;
            pcb.SizeMode = PictureBoxSizeMode.Zoom;
            pcb.Load(fileImg);            
        }
        private bool _Do_SaveMovieProfile()
        {
            //-- Flush data in edit control to Object
            __FlushProfileAttributeToObjectMovieProfile();

            //-- Check Hash Key
            if (!param_MovieProfile.Hash.Length.Equals(32))
            {
                MessageBox.Show(
                    "Please build HASH of first first\nMovieProfile use HASH as key-index",
                    "Need Hash!", MessageBoxButtons.OK);
                btnSave.Enabled = true;
                btnClose.Enabled = true;
                that.DebugAndLog("User try to save MovieProfile while HASH is empty!");
                return (false);
            }

            //-- Try RenameFileToAttribute
            if (!__TryRenameFileToAttribute()) return (false);

            //--- Try SaveMovieProfile
            if (MovieDB.SaveMovieProfile(param_MovieProfile))
            {
                zLog.Write("frmMovieProfile->btnSave_Click(): Save Success");
                if (param_MovieList != null)
                {
                    // update data in MovieList
                    param_MovieList._UpdateMovieProfileInList(param_MovieProfile);
                }
                return (true); // No need to process any more
            }
            else
            {
                that.DebugAndLog("Error in SaveMovieProfile()");
                MessageBox.Show("Error in MovieDB.SaveMovieProfile()!");
                return (false);
            }
        }
        private void __FlushProfileAttributeToObjectMovieProfile()
        {
            param_MovieProfile.Code = txtCode.Text;
            param_MovieProfile.Type = cboType.Text;
            param_MovieProfile.Country = cboCountry.Text;
            try { param_MovieProfile.Rating = int.Parse(cboRating.Text); }
            catch { param_MovieProfile.Rating = 0; }
            param_MovieProfile.Title = txtTitle.Text;
            // param_MovieProfile.Actress
            // param_MovieProfile.Tag
            param_MovieProfile.Story = txtStory.Text;
            param_MovieProfile.ModifiedTime = DateTime.Now;
        }
        private bool __TryRenameFileToAttribute()
        {
            if (param_MovieProfile.FilePath.Length > 0)
            {
                //-- Have FilePath                
                param_MovieProfile.CheckFileConnect();
                if (param_MovieProfile.FileConnect.Equals("Y"))
                {
                    //-- File Is OnLine
                    if (!param_MovieProfile.RenameFileToAttribute())
                    {
                        that.DebugAndLog(
                            "Error in MovieProfile{"
                            + param_MovieProfile.Hash
                            + "}->RenameFileToAttribute"
                            );
                        MessageBox.Show(
                            "Error in RenameFileToAttribte()!\r\n"
                            + "Please check that file is Accessible",
                            "Error Rename", MessageBoxButtons.OK
                            );
                        return (false);
                    }
                }
                else
                {
                    //-- File Is OffLine
                    if (!that.Config[KW.AllowEditOfflineProfile].Equals("YES"))
                    {
                        that.DebugAndLog("User try Edit Offline Profile, while !Enable in Option");
                        MessageBox.Show(
                            "Current Profile is OFFLine! Cannot EDIT\r\n"
                            + "Please enable this action at menu Option",
                            "Cannot Edit", MessageBoxButtons.OK
                            );
                        return (false);
                    }
                }
            }
            else
            {
                //-- File Disconnect, Profile is Offline
                that.DebugAndLog("MovieProfile is GlobalProfile, not have FilePath");
            }

            // Everything OK
            return (true);
        }

        private void _Do_CloseForm()
        {
            this.Hide();
            if (param_isRefreshAllMovieAfterClose) FRM.Main.RefreshAllMovieTab();

            this.Close();
            this.Dispose();
        }
        private void _Do_Search()
        {
            if (!this.Visible) return;
            if (txtCode.Text.Trim().ToUpper().Length.Equals(0)) return;

            // Start shell process file for run media with your favorite player
            string urlSearchGoogle = "https://www.google.co.th/search?q=" + txtCode.Text.Trim().ToUpper();
            System.Diagnostics.Process.Start(urlSearchGoogle);
        }
        private void _Do_PlayMovie()
        {
            param_MovieProfile.CheckFileConnect();
            if (!param_MovieProfile.FileConnect.Equals("Y"))
            {
                that.DebugAndLog("Movie: {" + param_MovieProfile.Hash + "} is not connecting");
                that.DebugAndLog("File: " + param_MovieProfile.FilePath + " is not existing");
                MessageBox.Show("This file is not Connecting to System", "File !Connect", MessageBoxButtons.OK);
                return;
            }

            // Update Last Played time
            param_MovieProfile.ViewTime = DateTime.Now;

            // Start shell process file for run media with your favorite player
            System.Diagnostics.Process.Start(param_MovieProfile.FilePath);
            param_MovieProfile.CountPlay++;
            lblCountPlay.Text = param_MovieProfile.CountPlay.ToString("0000");

            // Update Count Play if NOT FirstImport
            string hKey = param_MovieProfile.Hash;
            if (hKey.Length.Equals(32))
            {
                if (!param_isNewImport)
                {
                    if (MovieDB.hMovie.Contains(hKey))
                    {
                        MovieDB.SaveMovieProfile(param_MovieProfile);
                        zLog.Write("Save CountPlay to MovieProfile {" + hKey + "}");
                    }
                }
            }
        }
        
        private void _Do_AddActress()
        {
            frmSelectOrAddList frm = new frmSelectOrAddList();
            List<string> actressList = ptkGeneral.CloneObject(MovieProfile.ListActress);
            actressList.Sort();
            frm.paramList = actressList;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < frm.selectList.Count; i++)
                {
                    string actress = frm.selectList[i].Trim();
                    this.param_MovieProfile.AddActress(actress);
                    if (!lstActress.Items.Contains(actress)) lstActress.Items.Add(actress);
                    __CheckCanSave();
                }
            }
            frm.Dispose();
        }
        private void _Do_AddTag()
        {
            frmSelectOrAddList frm = new frmSelectOrAddList();
            List<string> tagList = ptkGeneral.CloneObject(MovieProfile.ListTag);
            tagList.Sort();
            frm.paramList = tagList;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < frm.selectList.Count; i++)
                {
                    string tag = frm.selectList[i].Trim();
                    this.param_MovieProfile.AddTag(tag);
                    if (!lstTag.Items.Contains(tag)) lstTag.Items.Add(tag);
                    __CheckCanSave();
                }
            }
            frm.Dispose();
        }
        private void _Do_RemoveTag()
        {
            if ((lstTag.Items.Count > 0) && (lstTag.SelectedIndex >= 0))
            {
                int idx = lstTag.SelectedIndex;
                string tag = (string)lstTag.Items[idx];
                lstTag.Items.RemoveAt(idx);
                param_MovieProfile.RemoveTag(tag);
                __CheckCanSave();
            }
        }
        private void _Do_RemoveActress()
        {
            if ((lstActress.Items.Count > 0) && (lstActress.SelectedIndex >= 0))
            {
                int idx = lstActress.SelectedIndex;
                string actress = (string)lstActress.Items[idx];
                lstActress.Items.RemoveAt(idx);
                param_MovieProfile.RemoveActress(actress);
                __CheckCanSave();
            }
        }
        
        private void _Do_SelectAdd_FrontCover()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.Filter = "Image File (*.jpg, *.jpeg)|*.jpg;*.jpeg";
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MovieDB.SaveMovieImage_FrontCover(openFile.FileName, this.param_MovieProfile))
                {
                    RefreshTabMovieImage(1);
                    __TryDeletePictureFileIfConfig(openFile.FileName);
                }
            }
        }
        private void _Do_SelectAdd_BackCover()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.Filter = "Image File (*.jpg, *.jpeg)|*.jpg;*.jpeg";
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MovieDB.SaveMovieImage_BackCover(openFile.FileName, this.param_MovieProfile))
                {
                    RefreshTabMovieImage(2);
                    __TryDeletePictureFileIfConfig(openFile.FileName);
                }
            }
        }
        private void _Do_SelectAdd_ScreenShot1()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.Filter = "Image File (*.jpg, *.jpeg)|*.jpg;*.jpeg";
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MovieDB.SaveMovieImage_ScreenShot1(openFile.FileName, this.param_MovieProfile))
                {
                    RefreshTabMovieImage(3);
                    __TryDeletePictureFileIfConfig(openFile.FileName);
                }
            }
        }
        private void _Do_SelectAdd_ScreenShot2()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.Filter = "Image File (*.jpg, *.jpeg)|*.jpg;*.jpeg";
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MovieDB.SaveMovieImage_ScreenShot2(openFile.FileName, this.param_MovieProfile))
                {
                    RefreshTabMovieImage(4);
                    __TryDeletePictureFileIfConfig(openFile.FileName);
                }
            }
        }
        private void __TryDeletePictureFileIfConfig(string fileName)
        {
            if (that.Config[KW.DeleteSourcePicture].Equals("YES"))
            {
                try
                {
                    File.Delete(fileName);
                    zLog.Write("Delete Picture File [" + fileName + "] Because Config Set!");
                }
                catch (Exception ex)
                {
                    zLog.Write("Error! in Try Delete Picture File [" + fileName + "]" + ex.Message);
                }
            }
        }
        
        private void _Do_ViewDuplicateProfile()
        {
            if (MovieDB.hMovie.Contains(param_MovieProfile.Hash))
            {
                MovieProfile mProfile = (MovieProfile)MovieDB.hMovie[param_MovieProfile.Hash];
                that.ShowWin_MovieProfile(mProfile);
            }
        }
        private void _Do_DeleteThisFile()
        {
            if (
                MessageBox.Show(
                "Are you sure to Delete File\n"
                + param_MovieProfile.FilePath,
                "Confirm Delete?", MessageBoxButtons.YesNo)
                == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    File.Delete(param_MovieProfile.FilePath);
                    _Do_CloseForm();
                }
                catch (Exception ex)
                {
                    zLog.Write("Error in Delete File: " + param_MovieProfile.FilePath);
                    zLog.Write("Exception: " + ex.Message);
                    MessageBox.Show(
                        "Error in Try to Delete FILE!!!\r\nMaybe File is Locking/No-Permission",
                        " Error Delete!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
                }                
            }
        }
        private void _Do_UseThisFile()
        {
            if (MovieDB.hMovie.Contains(param_MovieProfile.Hash))
            {
                that.DebugAndLog("Update MovieProfile{" + param_MovieProfile.Hash + "} with Path=" + param_MovieProfile.FilePath);
                MovieProfile mProfile = (MovieProfile)MovieDB.hMovie[param_MovieProfile.Hash];
                mProfile.FilePath = param_MovieProfile.FilePath;
                if (!mProfile.RenameFileToAttribute())
                {
                    that.DebugAndLog("Error in Remame file to Attribute: " + param_MovieProfile.FilePath + ")");
                    MessageBox.Show("Error in Remame file to Attribute\r\nMaybe file is in-use?", "Error!", MessageBoxButtons.OK);
                    return;
                }
                MovieDB.SaveMovieProfile(mProfile);

                that.ShowWin_MovieProfile(mProfile);
                _Do_CloseForm();
            }
        }
        private void _Do_DeleteLastFilePath()
        {
            if (this.param_isNewImport)
            {
                MessageBox.Show("Cannot use this function with New Import File");
                return;
            }
            if (this.param_MovieProfile.Hash.Length != 32)
            {
                MessageBox.Show("Please Build HASH first...");
                return;
            }
            string hKey = this.param_MovieProfile.Hash;
            bool isContain = false;
            lock (MovieDB.hMovie.SyncRoot) { isContain = MovieDB.hMovie.Contains(hKey); }
            if (! isContain) 
            {
                MessageBox.Show("This Profile is not existing in MovieDB...");
                return;
            }

            if (this.param_MovieProfile.FilePath.Trim().Length.Equals(0))
            {
                txtFilePath.Text = this.param_MovieProfile.FilePath;
                MessageBox.Show("This FilePath was Empty...");
                return;
            }

            //---- Last Confirm
            if (
                MessageBox.Show(
                "Do You want to Delete Last FilePath?",
                "Confirm?",
                MessageBoxButtons.YesNo) !=
                System.Windows.Forms.DialogResult.Yes
            ) return;

            //--------------------------------------------------
            string filePath2Delete = this.param_MovieProfile.FilePath;
            if (File.Exists(filePath2Delete))
            {
                try 
                { 
                    File.Delete(filePath2Delete);
                    that.DebugAndLog("Delete RealFileInDisk [" + filePath2Delete + "] Success");
                }
                catch (Exception ex) 
                {
                    that.DebugAndLog("Error in delete RealFileInDisk [" + filePath2Delete + "] " + ex.Message);
                }
            }
            this.param_MovieProfile.FilePath = "";
            txtFilePath.Text = this.param_MovieProfile.FilePath;
            this.param_MovieProfile.CheckFileConnect();
            //--------------------------------------------------

            if (!MovieDB.SaveMovieProfile(this.param_MovieProfile))
            {
                that.DebugAndLog("Error in MovieDB.SaveMovieProfile() ... Cannot Remove Last FilePath");
                MessageBox.Show(
                    "Error in MovieDB::SaveMovieProfile()\r\nMaybe Disk write proteced",
                    "Error Save",
                    MessageBoxButtons.OK
                );
                return;
            }
            else
            {
                that.DebugAndLog("Delete last File path from Movie{" + this.param_MovieProfile.Hash + "} Success");
                return;
            }
        }
        private void _Do_ShowAdvanceTab()
        {
            tabMain.TabPages.Insert(1, tabAdvanced);
            tabMain.SelectedIndex = 1;
        }
        private void _Do_SavePositionOfProfileWindows()
        {
            if (this.WindowState != FormWindowState.Normal) return;
            if (!this.isEnableSavePosition) return;

            that.Config[KW.ProfileLeft] = this.Left.ToString();
            that.Config[KW.ProfileTop] = this.Top.ToString();
            that.Config[KW.ProfileWidth] = this.Width.ToString();
            that.Config[KW.ProfileHeight] = this.Height.ToString();

            that.Config.Save();
        }
        private void _Do_LoadPositionOfProfileWindows()
        {
            //-- Load Width & Height if value is reasonable
            if (
                (that.Config.GetInt(KW.ProfileWidth) > 400) &&
                (that.Config.GetInt(KW.ProfileHeight) > 200)
            )
            {
                this.Width = that.Config.GetInt(KW.ProfileWidth);
                this.Height = that.Config.GetInt(KW.ProfileHeight);
            }

            this.Left = that.Config.GetInt(KW.ProfileLeft);
            this.Top = that.Config.GetInt(KW.ProfileTop);
        }

        private void __CheckAddImageState()
        {
            btnAddFrontCover.Enabled = this.param_MovieProfile.Hash.Length.Equals(32);
            btnAddBackCover.Enabled = this.param_MovieProfile.Hash.Length.Equals(32);
            btnAddScreenShot1.Enabled = this.param_MovieProfile.Hash.Length.Equals(32);
            btnAddScreenShot2.Enabled = this.param_MovieProfile.Hash.Length.Equals(32);
        }
        private void __CheckCanSave()
        {
            if (!this.Visible) return;
            if (!btnSave.Visible) return;
            if (IsBuildingHash) return;
            if (this.param_MovieProfile.Hash.Length != 32) return;

            btnSave.Enabled = true;
        }
                
    }
}
