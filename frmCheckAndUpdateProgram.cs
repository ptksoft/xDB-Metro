using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Net;
using System.IO;
using System.Windows.Forms;


using PTKSOFT.Utils2;
using ZiCure.Log;

namespace xDB2013
{
    public partial class frmCheckAndUpdateProgram : Form
    {
        private bool isCheckVersionFinish = false;
        private bool isNeedDownLoadLastVersion = false;
        private bool isDownLoadFinish = false;
        private string fileNewVersion = "";

        public frmCheckAndUpdateProgram()
        {
            InitializeComponent();
        }

        private void frmCheckAndUpdateProgram_Shown(object sender, EventArgs e)
        {
            tmrCheckVersion.Start();
            bgworkCheckVersion.RunWorkerAsync();            
        }

        private void tmrCheckVersion_Tick(object sender, EventArgs e)
        {
            if (!isCheckVersionFinish)
            {

                if (pgbarCheckVersion.Value >= pgbarCheckVersion.Maximum)
                    pgbarCheckVersion.Value = pgbarCheckVersion.Minimum;
                
                pgbarCheckVersion.Value++;
                this.Refresh();
            }
            else
            {
                tmrCheckVersion.Stop(); // NOT RUN ANY MORE

                that.DebugAndLog("frmCheckAndUpdateProgram:: CheckVersionFinish");
                pgbarCheckVersion.Value = pgbarCheckVersion.Maximum;
                if (!isNeedDownLoadLastVersion)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    that.DebugAndLog("Need Download Last Version");
                    lblDownloadNew.Text += (" [" + fileNewVersion + "]");
                    this.Refresh();
                    tmrDownloadVersion.Start();
                    bgworkDownloadLastVersion.RunWorkerAsync();
                }
            }
        }
        private void tmrDownloadVersion_Tick(object sender, EventArgs e)
        {
            if (!isDownLoadFinish)
            {
                if (pgbarDownloadLastVersion.Value >= pgbarDownloadLastVersion.Maximum)
                    pgbarDownloadLastVersion.Value = pgbarDownloadLastVersion.Minimum;

                pgbarDownloadLastVersion.Value++;
                this.Refresh();
            }
            else
            {
                tmrDownloadVersion.Stop();  // NOT RUN ANY MORE

                that.DebugAndLog("frmCheckAndUpdateProgram:: DownloadVersion Finish");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void bgworkCheckVersion_DoWork(object sender, DoWorkEventArgs e)
        {            
            string urlQueryVersion = that.Config[KW.UrlCheckUpdate] + "?" + ptkGeneral.GenerateRandomMd5String();
            WebClient web = new WebClient();
            try
            {
                string str = web.DownloadString(urlQueryVersion);
                string[] lines = str.Split(new string[] { "\n" }, StringSplitOptions.None);
                if (lines.Length < 1)
                {
                    that.DebugAndLog("line data cannot split!");
                    isCheckVersionFinish = true;
                    return;
                }
                that.DebugAndLog("Get version message = " + lines[0]);
                if (_versionServerIsNewer(lines[0]))
                {
                    fileNewVersion = "xDB-" + lines[0] + ".7z";
                    isNeedDownLoadLastVersion = true;
                }

                // Everything OK
                isCheckVersionFinish = true;
                return;
            }
            catch (Exception ex)
            {
                that.DebugAndLog("Error! in check version: " + ex.Message);
                isCheckVersionFinish = true;
                return;
            }
        }
        private bool _versionServerIsNewer(string versionOnServer)
        {
            that.DebugAndLog("_versionServerIsNewer->Compare Local(" + that.VersionOnly() + ") Server(" + versionOnServer + ")");
            string[] local_version = that.VersionOnly().Split(new string[] { "." }, StringSplitOptions.None);
            if (local_version.Length != 4)
            {
                that.DebugAndLog("Error! local_version part after split <> 4");
                return (false);
            }
            string[] server_version = versionOnServer.Split(new string[] { "." }, StringSplitOptions.None);
            if (server_version.Length != 4)
            {
                that.DebugAndLog("Error server_version part after split <> 4");
                return (false);
            }

            /* Try Parse local version number */
            int[] n_local_version = new int[4];
            try
            {
                for (int i = 0; i < n_local_version.Length; i++)
                    n_local_version[i] = int.Parse(local_version[i]);
            }
            catch (Exception ex)
            {
                that.DebugAndLog("Error! Convert n_local_version. " + ex.Message);
                return (false);
            }

            /* Try Parse server version number */
            int[] n_server_version = new int[4];
            try
            {
                for (int i = 0; i < n_server_version.Length; i++)
                    n_server_version[i] = int.Parse(server_version[i]);
            }
            catch (Exception ex)
            {
                that.DebugAndLog("Error! Convert n_server_version. " + ex.Message);
                return (false);
            }

            // Compare local & server
            for (int i = 0; i < 4; i++)
            {
                if (n_server_version[i] == n_local_version[i]) continue;
                return (n_server_version[i] > n_local_version[i]);
            }

            return (false);
        }
        private void bgworkDownloadLastVersion_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient web = new WebClient();
            string urlDownloadFile = that.Config[KW.UrlCheckUpdate] + fileNewVersion;
            string localFile = ptkGeneral.ThisProgramPath() + Path.DirectorySeparatorChar + fileNewVersion;
            try
            {
                web.DownloadFile(urlDownloadFile, localFile);

                string file7za = ptkGeneral.ThisProgramPath() + Path.DirectorySeparatorChar + "7za.exe";
                string fileUpdateBat = ptkGeneral.ThisProgramPath() + Path.DirectorySeparatorChar + "update.bat";

                // Try Clear old existing BATCH file
                if (File.Exists(fileUpdateBat))
                {
                    try { File.Delete(fileUpdateBat); }
                    catch { that.DebugAndLog("found Existing update.bat BUT! cannot remove"); }
                }

                // Begin Normal Cycle
                if (!File.Exists(localFile))
                {
                    that.DebugAndLog("localFile that download NOT FOUND! [" + localFile + "]");
                }
                else if (!_prepareUpdateBat(localFile, fileUpdateBat))
                {
                    that.DebugAndLog("error in parepareUpdateBath! [" + fileUpdateBat + "]");
                }
                else if (!File.Exists(fileUpdateBat))
                {
                    that.DebugAndLog("fileUpdateBath NOT FUND! [" + fileUpdateBat + "]");
                }
                else if (File.Exists(localFile))
                {
                    that.DebugAndLog("Download [" + urlDownloadFile + "] Complete, Begin Update");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    ptkGeneral.ExecuteProcess(fileUpdateBat, "", false, true);
                }
            }
            catch (Exception ex)
            {
                that.DebugAndLog("Error in download file [" + urlDownloadFile + "] -> [" + localFile + "]");
                that.DebugAndLog("Error Desc: " + ex.Message);
            }

            // Every JOBs is done
            isDownLoadFinish = true;
        }
        private bool _prepareUpdateBat(string localFile, string batchName)
        {
            List<string> cmdLine = new List<string>();

            cmdLine.Add("@echo off");
            cmdLine.Add("echo Prepare Extracting tool...");
            cmdLine.Add("del /f /q 7za.exe > NUL");
            cmdLine.Add("ren 7za.xxx 7za.exe");
            cmdLine.Add("echo Delay time to start...");
            cmdLine.Add("ping 127.0.0.1 -n 7");

            cmdLine.Add("7za.exe e -y " + localFile);
            cmdLine.Add("echo Delay time to stop ...");
            cmdLine.Add("ping 127.0.0.1 -n 5");

            cmdLine.Add("del /F 7za.xxx > NUL");
            cmdLine.Add("ren 7za.exe 7za.xxx > NUL");
            cmdLine.Add("mkdir BAKs");
            cmdLine.Add("move " + localFile + " " + "BAKs");
            
            cmdLine.Add("echo Starting new version...");
            cmdLine.Add("echo Delay time to Restart Program ...");
            cmdLine.Add("ping 127.0.0.1 -n 5");
            string exeFile = ptkGeneral.ThisProgramPath() + Path.DirectorySeparatorChar + "xDB2013.exe";            
            cmdLine.Add("start " + exeFile);
            cmdLine.Add("ping 127.0.0.1 -n 5");

            return (ptkTextFile.WriteStringArray(batchName, cmdLine.ToArray()));            
        }
    }
}
