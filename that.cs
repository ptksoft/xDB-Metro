using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.Sockets;

using PTKSOFT.Utils2;
using ZiCure.Log;
using Newtonsoft.Json;

namespace xDB2013
{
    public class that
    {
        public static bool IsQuit = false;
        public static ptkConfig Config = null;
        public static ptkConfig Filter = null;
        public static string pathConfig = ptkGeneral.ThisProgramPath() + Path.DirectorySeparatorChar + "CONFIGs";
        public static string fileConfig = pathConfig + Path.DirectorySeparatorChar + "MAIN.ini";
        public static string fileFilter = pathConfig + Path.DirectorySeparatorChar + "FILTER.ini";

        public static UdpClient udpCheckInstant;

        public static string ProgramNameAndVersion()
        {
            return ("xDB (version " + VersionOnly() + ")");
        }
        public static string VersionOnly()
        {
            return (Assembly.GetEntryAssembly().GetName().Version.ToString());
        }
        public static bool CheckProgramUpdate()
        {
            if (!that.Config.Contains(KW.UrlCheckUpdate))
            {
                that.DebugAndLog("Not found KEY [" + KW.UrlCheckUpdate + "] in Configuration file");
                that.Config[KW.UrlCheckUpdate] = "http://web.pitak.info/xdb/";
                if (that.Config.Save()) {
                    that.DebugAndLog("Finish Init value [" + that.Config[KW.UrlCheckUpdate] + "] to key [" + KW.UrlCheckUpdate + "]");
                }
                else {
                    that.DebugAndLog("Fail to Init value !!!");
                    return(false);
                }
            }
            string curTime = DateTime.Now.ToString("ddHH");
            if (that.Config[KW.TimeCheckUpdate] == curTime)
            {
                that.DebugAndLog("LastCheck Time is same HOUR, do Nothing");
                return (false);
            }
            else
            {
                that.DebugAndLog("Found difference LastCheck Time @" + curTime + ", Start checking version");
                that.Config[KW.TimeCheckUpdate] = curTime;
                that.Config.Save();
                frmCheckAndUpdateProgram frm = new frmCheckAndUpdateProgram();
                return (frm.ShowDialog() == DialogResult.OK);
            }
        }
        public static bool CheckRunningInstant_UseUdpBind()
        {
            try
            {
                udpCheckInstant = new UdpClient();
                udpCheckInstant.Client.Bind(new IPEndPoint(IPAddress.Loopback, 6970));
                return(true);
            }
            catch
            {
                return (false);
            }
        }
        public static void CloseRunningInstant_UseUdpBind()
        {
            if (udpCheckInstant == null) return;
            try
            {
                udpCheckInstant.Client.Close();
                udpCheckInstant.Close();
            }
            catch { }
        }

        public static Queue queDebugMessage = Queue.Synchronized(new Queue());
        public static void DebugAndLog(string msg)
        {
            lock (queDebugMessage.SyncRoot)
            {
                queDebugMessage.Enqueue(DateTime.Now.ToString("[HHmmss.ffffff] ") + msg);
                zLog.Write(msg);
            }
        }
        
        public static bool InitConfig()
        {
            zLog.Write("that.InitConfig Begin");
            if (!Directory.Exists(pathConfig))
            {
                zLog.Write("Create new config folder [" + pathConfig + "]");
                try { Directory.CreateDirectory(pathConfig); }
                catch (Exception ex)
                {
                    zLog.Write("Error create config [" + pathConfig + "]");
                    zLog.Write(ex.Message);
                    return (false);
                }
            }

            zLog.Write("Begin Load config file [" + fileConfig + "]");
            Config = new ptkConfig();
            if (!Config.LoadFromFile(fileConfig))
            {
                zLog.Write("Error in load config file [" + fileConfig + "]");
                zLog.Write("Try created new");
                Config = new ptkConfig();
                Config[KW.CreatedTime] = ptkConvert.DateTimeToSqlFormatWithMSec(DateTime.Now);
                if (!Config.SaveToFile(fileConfig))
                {
                    zLog.WriteCritical("Error in save Config File! " + Config.LastError);
                    return (false);
                }
            }
            else
            {
                zLog.Write("Load config data success, Total " + Config.Count.ToString() + " elements");
            }

            zLog.Write("Begin Load filter file [" + fileFilter + "]");
            Filter = new ptkConfig();
            if (!Filter.LoadFromFile(fileFilter))
            {
                zLog.Write("Error in load filter file[" + fileFilter + "]");
                zLog.Write("Try created new");
                Filter = new ptkConfig();
                Filter[KW.CreatedTime] = ptkConvert.DateTimeToSqlFormatWithMSec(DateTime.Now);
                if (!Filter.SaveToFile(fileFilter))
                {
                    zLog.WriteCritical("Error in save Filter File! " + Config.LastError);
                    return (false);
                }
            }
            else
            {
                zLog.Write("Load filter data success, Total " + Filter.Count.ToString() + " elements");
            }

            //-- Clear & Predefine some config
            that.Config[KW.ProfileTop] = "0";       // First Time Must top-left = 0, Prevent Screen Resolution Mode
            that.Config[KW.ProfileLeft] = "0";

            //-- Predefine some Configuration
            if (!that.Config.Contains(KW.AutoBuildHashIfEmpty)) that.Config[KW.AutoBuildHashIfEmpty] = KW.YES;


            // Everything OK
            return (true);
        }
        public static bool SaveConfig()
        {
            if (Config == null) return (false);
            Config["MODIFY_TIME"] = ptkConvert.DateTimeToSqlFormatWithMSec(DateTime.Now);
            return (Config.Save());
        }
        
        public static string GetNewOrReplaceFilterName()
        {
            frmManageFilter frm = new frmManageFilter();
            frm.param_IsModeSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                return (frm.return_FilterName);
            }
            else
                return ("");
        }

        public static void ShowWin_ImportMovieFromFile(string FilePath)
        {
            MovieProfile newProfile = new MovieProfile(FilePath);
            frmMovieProfile frm = new frmMovieProfile();
            frm.param_MovieProfile = newProfile;
            frm.param_isRefreshAllMovieAfterClose = true;
            frm.param_isNewImport = true;
            frm.Show();
        }
        public static void ShowWin_ParseProfileFromDirectory(string dirName)
        {
            string[] listFile = Directory.GetFiles(dirName, "*.*");
            int FileInFolder = 0;
            int FileMovieWithHash = 0;
            int FileMovieHadProfile = 0;
            int FileMovieNewProfile = 0;
            for (int i = 0; i < listFile.Length; i++)
            {
                if (!File.Exists(listFile[i])) continue;
                FileInFolder++;
                MovieProfile profile = new MovieProfile(listFile[i]);
                if (profile.Hash.Length.Equals(32))
                {
                    FileMovieWithHash++;
                    if (MovieDB.hMovie.ContainsKey(profile.Hash))
                    {
                        FileMovieHadProfile++;

                        // Add and Replase existing profile 's filePath with new import
                        MovieProfile existingProfile = (MovieProfile)MovieDB.hMovie[profile.Hash];
                        existingProfile.FilePath = profile.FilePath;
                        if (MovieDB.SaveMovieProfile(existingProfile))
                        {
                            that.DebugAndLog("Update existing Profile [" + existingProfile.Hash + "] to MovieDB success");
                        }
                    }
                    else
                    {
                        FileMovieNewProfile++;
                        if (MovieDB.SaveMovieProfile(profile))
                        {
                            that.DebugAndLog("Save new Profile [" + profile.Hash + "] to MovieDB success");
                        }
                    }
                }
            }
            MessageBox.Show(
                "Finish Import MovieProfile from Folder:" + "\r\n" +
                "Total File in Folder = " + FileInFolder.ToString() + "\r\n" +
                "File Movie with Hash = " + FileMovieWithHash.ToString() + "\r\n" +
                "File Movie had Profile = " + FileMovieHadProfile.ToString() + "\r\n" +
                "File Movie new Profile = " + FileMovieNewProfile.ToString()
                );
        }
        public static void ShowWin_MovieProfile(MovieProfile mProfile)
        {
            frmMovieProfile frm = new frmMovieProfile();
            frm.param_MovieProfile = mProfile;
            frm.Show();
        }
        public static void ShowWin_StatWindows()
        {
            frmMovieStat frm = new frmMovieStat();
            that.DebugAndLog("Show STAT window...");
            frm.Show();
            frm = null;
        }
        public static void ShowWin_ManageFilter()
        {
            frmManageFilter frm = new frmManageFilter();
            frm.param_IsModeSelect = false;
            frm.Show();
        }
        public static void ShowWin_ListPeerProfile()
        {
            frmNetworkPeerToPeer frm = new frmNetworkPeerToPeer();
            that.DebugAndLog("Show Network Peer2Peer windows...");
            frm.Show();
            frm = null;
        }

        public static void ShowTab_AllMovie()
        {
            if (FRM.Main == null) return;

            ucMovieList movieList = new ucMovieList();
            movieList.Dock = DockStyle.Fill;
            movieList.Location = new Point(0, 0);
            movieList.OnDoubleClickMovieList += new WhenDoubleClickMovieList(movieList_OnDoubleClickMovieList);
            movieList.OnKeyUpMovieList += new WhenKeyUpMovieList(movieList_OnKeyUpMovieList);

            TabPage newTabPage = new TabPage();
            newTabPage.Tag = new string[] { 
                "all_movies", 
                "All Movies @ " + ptkGeneral.GetTodayDateTimeSqlFormat()
            };
            newTabPage.Controls.Add(movieList);
            
            FRM.Main.tabMain.TabPages.Add(newTabPage);
            FRM.Main.tabMain.SelectedTab = newTabPage;
            FRM.Main.generateTabFunctionKey();

            movieList.RefreshMovieList(MovieDB.GetMovieList(), "All Movie");
        }
        public static void ShowTab_FilterMovie(string filterKey)
        {
            if (FRM.Main == null) return;
            if (!that.Filter.Contains(filterKey)) return;
            MovieFilter filter = null;
            try
            {
                filter = JsonConvert.DeserializeObject<MovieFilter>(that.Filter[filterKey]);
                that.DebugAndLog("ShowFilterMovie()->Decode filter name [" + filterKey + "] Success");
            }
            catch (Exception ex) {
                that.DebugAndLog("ShowFilterMovie()->Decode filter name [" + filterKey + "] Fail");
                that.DebugAndLog("Exception: " + ex.Message);
                return;
            }
            if (filter == null) return;     // Second Trap for SAFE :P

            ucMovieList movieList = new ucMovieList();
            movieList.Dock = DockStyle.Fill;
            movieList.Location = new Point(0, 0);
            movieList.OnDoubleClickMovieList += new WhenDoubleClickMovieList(movieList_OnDoubleClickMovieList);
            movieList.OnKeyUpMovieList += new WhenKeyUpMovieList(movieList_OnKeyUpMovieList);
            

            TabPage newTabPage = new TabPage();
            newTabPage.Tag = new string[] { 
                "filter_movie", 
                "Filter Movie"
            };
            newTabPage.Controls.Add(movieList);
            
            FRM.Main.tabMain.TabPages.Add(newTabPage);
            FRM.Main.tabMain.SelectedTab = newTabPage;
            FRM.Main.generateTabFunctionKey();

            movieList.RefreshMovieList(MovieDB.GetMovieList(filter), "Filter Movie by [" + filterKey + "]");
        }
        public static void ShowTab_HelpInformation()
        {
            if (FRM.Main == null) return;

            TextBox progInfo = new TextBox();
            progInfo.Dock = DockStyle.Fill;
            progInfo.Multiline = true;
            progInfo.ScrollBars = ScrollBars.Vertical;
            progInfo.ForeColor = Color.Blue;
            progInfo.ReadOnly = true;
            progInfo.BackColor = Color.WhiteSmoke;
            progInfo.BorderStyle = BorderStyle.None;
            
            string fileReadGu = ptkGeneral.ThisProgramPath() + Path.DirectorySeparatorChar + "ReadGu.TXT";
            string[] lines;
            if (!File.Exists(fileReadGu))
            {
                progInfo.Text = "Information not available\n\nFile ReadGu.TXT not found!";
            }
            else if (!ptkTextFile.ReadStringArray(fileReadGu, out lines))
            {
                progInfo.Text = "Information not available\n\nRead ERROR on ReadGu.TXT!";
            }
            else
            {
                progInfo.Text = string.Join("\r\n   ", lines);
            }

            TabPage newTabPage = new TabPage();
            newTabPage.Tag = new string[] { 
                "help_about", 
                "Help About"
            };
            newTabPage.Controls.Add(progInfo);
            progInfo.SelectionStart = 0;
            progInfo.SelectionLength = 0;

            FRM.Main.tabMain.TabPages.Add(newTabPage);
            FRM.Main.tabMain.SelectedTab = newTabPage;
            FRM.Main.generateTabFunctionKey();
        }

        public static void movieList_OnKeyUpMovieList(object sender, KeyEventArgs e)
        {
			ListView lv = (ListView)sender;
			if (lv.SelectedItems.Count < 1) return;
			
			if (e.KeyCode == Keys.Enter) {
				if (e.Shift) {
					MovieProfile mProfile = (MovieProfile)lv.SelectedItems[0].Tag;
					frmMovieProfile frm = new frmMovieProfile();
					frm.param_MovieProfile = mProfile;
					frm.param_MovieList = (ucMovieList)lv.Parent;
					frm.Show();								
				}
				else {
					movieList_OnDoubleClickMovieList(sender, new EventArgs());
				}
			}
        }
        public static void movieList_OnDoubleClickMovieList(object sender, EventArgs s)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItems.Count > 0)
            {
				MovieProfile mProfile = (MovieProfile)lv.SelectedItems[0].Tag;
				frmProfileViewer frm = new frmProfileViewer();
				frm.param_MovieProfile = mProfile;
				frm.Show();                
            }
        }

        public static void BatchDeleteLastFilePathInCurrentTab(TabPage tabToDelete)
        {
            ucMovieList movieList = null;
            foreach (Control ctl in tabToDelete.Controls)
                if (ctl is ucMovieList)
                {
                    movieList = (ucMovieList)ctl;
                    break;
                }
            if (movieList == null) return;

            // Begin Delete Last File Path
            List<MovieProfile> listMovie = movieList.GetListMovie();
            if (listMovie.Count > 0)
                if (MessageBox.Show(
                        "Are you sure to delete " + listMovie.Count.ToString() + " movie File Path!!",
                        " Confirm?", MessageBoxButtons.OKCancel
                    ) != DialogResult.OK ) return;

            // After Confirm Begin Real Delete
            int countSuccess = 0;
            for (int i = 0; i < listMovie.Count; i++)
            {
                MovieProfile profile = (MovieProfile)listMovie[i];

                //--------------------------------------------------
                string filePath2Delete = profile.FilePath;
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
                profile.FilePath = "";      // Delete from Object
                profile.CheckFileConnect();
                //--------------------------------------------------

                if (!MovieDB.SaveMovieProfile(profile))
                {
                    that.DebugAndLog("Error in MovieDB.SaveMovieProfile() ... Cannot Remove Last FilePath");
                }
                else
                {
                    that.DebugAndLog("Delete last File path from Movie{" + profile.Hash + "} Success");
                    countSuccess++;
                }
            }
            MessageBox.Show("Success delete " + countSuccess.ToString() + " LastFile Path from " + listMovie.Count.ToString() + " profile");
        }
    }
}
