namespace xDB2013
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileImportMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovie = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieManageFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieFind = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovieStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfileImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProfileImportParseFromFileInDir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBatch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBatchDeleteLastFilePath = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionAutoBuildHash = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionDeleteSourcePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptionAllSaveOfflineProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNetworkPeerToPeer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTab = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab5 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab6 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab7 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab8 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab9 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab10 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab11 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTabGoTab12 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolBar = new System.Windows.Forms.ToolStrip();
            this.toolImportMovie = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAllFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolExitProgram = new System.Windows.Forms.ToolStripButton();
            this.toolCloseTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStat = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPeer2Peer = new System.Windows.Forms.ToolStripButton();
            this.iml32x32 = new System.Windows.Forms.ImageList(this.components);
            this.tabMain = new System.Windows.Forms.TabControl();
            this.lstDebug = new System.Windows.Forms.ListBox();
            this.tmrDebug = new System.Windows.Forms.Timer(this.components);
            this.menuMain.SuspendLayout();
            this.mainToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuMovie,
            this.menuProfile,
            this.mnuBatch,
            this.menuOption,
            this.menuNetwork,
            this.menuTab,
            this.menuHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(7, 4, 0, 4);
            this.menuMain.Size = new System.Drawing.Size(784, 27);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileImportMovie,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 19);
            this.menuFile.Text = "&File";
            // 
            // menuFileImportMovie
            // 
            this.menuFileImportMovie.Name = "menuFileImportMovie";
            this.menuFileImportMovie.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.menuFileImportMovie.Size = new System.Drawing.Size(183, 22);
            this.menuFileImportMovie.Text = "Import &Movie";
            this.menuFileImportMovie.Click += new System.EventHandler(this.menuFileImportMovie_Click);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.menuFileExit.Size = new System.Drawing.Size(183, 22);
            this.menuFileExit.Text = "&Exit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuMovie
            // 
            this.menuMovie.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMovieAll,
            this.menuMovieManageFilter,
            this.menuMovieFind,
            this.menuMovieStatistics});
            this.menuMovie.Name = "menuMovie";
            this.menuMovie.Size = new System.Drawing.Size(52, 19);
            this.menuMovie.Text = "&Movie";
            // 
            // menuMovieAll
            // 
            this.menuMovieAll.Name = "menuMovieAll";
            this.menuMovieAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.menuMovieAll.Size = new System.Drawing.Size(171, 22);
            this.menuMovieAll.Text = "&All Movies";
            this.menuMovieAll.Click += new System.EventHandler(this.menuMovieAll_Click);
            // 
            // menuMovieManageFilter
            // 
            this.menuMovieManageFilter.Name = "menuMovieManageFilter";
            this.menuMovieManageFilter.Size = new System.Drawing.Size(171, 22);
            this.menuMovieManageFilter.Text = "Manage Filter...";
            this.menuMovieManageFilter.Click += new System.EventHandler(this.menuMovieManageFilter_Click);
            // 
            // menuMovieFind
            // 
            this.menuMovieFind.Name = "menuMovieFind";
            this.menuMovieFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.menuMovieFind.Size = new System.Drawing.Size(171, 22);
            this.menuMovieFind.Text = "&Find";
            this.menuMovieFind.Click += new System.EventHandler(this.menuMovieFind_Click);
            // 
            // menuMovieStatistics
            // 
            this.menuMovieStatistics.Name = "menuMovieStatistics";
            this.menuMovieStatistics.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuMovieStatistics.Size = new System.Drawing.Size(171, 22);
            this.menuMovieStatistics.Text = "S&tatistics";
            this.menuMovieStatistics.Click += new System.EventHandler(this.menuMovieStatistics_Click);
            // 
            // menuProfile
            // 
            this.menuProfile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProfileImport});
            this.menuProfile.Name = "menuProfile";
            this.menuProfile.Size = new System.Drawing.Size(53, 19);
            this.menuProfile.Text = "&Profile";
            // 
            // menuProfileImport
            // 
            this.menuProfileImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProfileImportParseFromFileInDir});
            this.menuProfileImport.Name = "menuProfileImport";
            this.menuProfileImport.Size = new System.Drawing.Size(110, 22);
            this.menuProfileImport.Text = "&Import";
            // 
            // menuProfileImportParseFromFileInDir
            // 
            this.menuProfileImportParseFromFileInDir.Name = "menuProfileImportParseFromFileInDir";
            this.menuProfileImportParseFromFileInDir.Size = new System.Drawing.Size(230, 22);
            this.menuProfileImportParseFromFileInDir.Text = "Parse from FILE in directory ...";
            this.menuProfileImportParseFromFileInDir.Click += new System.EventHandler(this.menuProfileImportParseFromFileInDir_Click);
            // 
            // mnuBatch
            // 
            this.mnuBatch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBatchDeleteLastFilePath});
            this.mnuBatch.Name = "mnuBatch";
            this.mnuBatch.Size = new System.Drawing.Size(49, 19);
            this.mnuBatch.Text = "&Batch";
            // 
            // menuBatchDeleteLastFilePath
            // 
            this.menuBatchDeleteLastFilePath.Name = "menuBatchDeleteLastFilePath";
            this.menuBatchDeleteLastFilePath.Size = new System.Drawing.Size(188, 22);
            this.menuBatchDeleteLastFilePath.Text = "Delete Last File Path !!";
            this.menuBatchDeleteLastFilePath.Click += new System.EventHandler(this.menuBatchDeleteLastFilePath_Click);
            // 
            // menuOption
            // 
            this.menuOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptionAutoBuildHash,
            this.menuOptionDeleteSourcePicture,
            this.menuOptionAllSaveOfflineProfile});
            this.menuOption.Name = "menuOption";
            this.menuOption.Size = new System.Drawing.Size(56, 19);
            this.menuOption.Text = "&Option";
            // 
            // menuOptionAutoBuildHash
            // 
            this.menuOptionAutoBuildHash.CheckOnClick = true;
            this.menuOptionAutoBuildHash.Name = "menuOptionAutoBuildHash";
            this.menuOptionAutoBuildHash.Size = new System.Drawing.Size(349, 22);
            this.menuOptionAutoBuildHash.Text = "Auto Build HASH If Empty";
            this.menuOptionAutoBuildHash.Click += new System.EventHandler(this.menuOptionAutoBuildHash_Click);
            // 
            // menuOptionDeleteSourcePicture
            // 
            this.menuOptionDeleteSourcePicture.CheckOnClick = true;
            this.menuOptionDeleteSourcePicture.Name = "menuOptionDeleteSourcePicture";
            this.menuOptionDeleteSourcePicture.Size = new System.Drawing.Size(349, 22);
            this.menuOptionDeleteSourcePicture.Text = "Delete Source Picture When Set Cover or ScreenShot";
            this.menuOptionDeleteSourcePicture.Click += new System.EventHandler(this.menuOptionDeleteSourcePicture_Click);
            // 
            // menuOptionAllSaveOfflineProfile
            // 
            this.menuOptionAllSaveOfflineProfile.CheckOnClick = true;
            this.menuOptionAllSaveOfflineProfile.Name = "menuOptionAllSaveOfflineProfile";
            this.menuOptionAllSaveOfflineProfile.Size = new System.Drawing.Size(349, 22);
            this.menuOptionAllSaveOfflineProfile.Text = "Allow Save Offline Profile";
            this.menuOptionAllSaveOfflineProfile.Click += new System.EventHandler(this.menuOptionAllSaveOfflineProfile_Click);
            // 
            // menuNetwork
            // 
            this.menuNetwork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNetworkPeerToPeer});
            this.menuNetwork.Name = "menuNetwork";
            this.menuNetwork.Size = new System.Drawing.Size(64, 19);
            this.menuNetwork.Text = "&Network";
            // 
            // menuNetworkPeerToPeer
            // 
            this.menuNetworkPeerToPeer.Enabled = false;
            this.menuNetworkPeerToPeer.Name = "menuNetworkPeerToPeer";
            this.menuNetworkPeerToPeer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuNetworkPeerToPeer.Size = new System.Drawing.Size(181, 22);
            this.menuNetworkPeerToPeer.Text = "&Peer To Peer";
            this.menuNetworkPeerToPeer.Click += new System.EventHandler(this.menuNetworkPeerToPeer_Click);
            // 
            // menuTab
            // 
            this.menuTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTabClose,
            this.menuTabGoTab1,
            this.menuTabGoTab2,
            this.menuTabGoTab3,
            this.menuTabGoTab4,
            this.menuTabGoTab5,
            this.menuTabGoTab6,
            this.menuTabGoTab7,
            this.menuTabGoTab8,
            this.menuTabGoTab9,
            this.menuTabGoTab10,
            this.menuTabGoTab11,
            this.menuTabGoTab12});
            this.menuTab.Name = "menuTab";
            this.menuTab.Size = new System.Drawing.Size(39, 19);
            this.menuTab.Text = "Tab";
            // 
            // menuTabClose
            // 
            this.menuTabClose.Name = "menuTabClose";
            this.menuTabClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.menuTabClose.Size = new System.Drawing.Size(152, 22);
            this.menuTabClose.Text = "Close";
            this.menuTabClose.Click += new System.EventHandler(this.menuTabClose_Click);
            // 
            // menuTabGoTab1
            // 
            this.menuTabGoTab1.Name = "menuTabGoTab1";
            this.menuTabGoTab1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuTabGoTab1.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab1.Tag = "1";
            this.menuTabGoTab1.Text = "Go Tab 1";
            this.menuTabGoTab1.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuTabGoTab2
            // 
            this.menuTabGoTab2.Name = "menuTabGoTab2";
            this.menuTabGoTab2.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menuTabGoTab2.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab2.Tag = "2";
            this.menuTabGoTab2.Text = "Go Tab 2";
            this.menuTabGoTab2.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuTabGoTab3
            // 
            this.menuTabGoTab3.Name = "menuTabGoTab3";
            this.menuTabGoTab3.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menuTabGoTab3.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab3.Tag = "3";
            this.menuTabGoTab3.Text = "Go Tab 3";
            this.menuTabGoTab3.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuTabGoTab4
            // 
            this.menuTabGoTab4.Name = "menuTabGoTab4";
            this.menuTabGoTab4.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.menuTabGoTab4.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab4.Tag = "4";
            this.menuTabGoTab4.Text = "Go Tab 4";
            this.menuTabGoTab4.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuTabGoTab5
            // 
            this.menuTabGoTab5.Name = "menuTabGoTab5";
            this.menuTabGoTab5.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuTabGoTab5.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab5.Tag = "5";
            this.menuTabGoTab5.Text = "Go Tab 5";
            this.menuTabGoTab5.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuTabGoTab6
            // 
            this.menuTabGoTab6.Name = "menuTabGoTab6";
            this.menuTabGoTab6.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.menuTabGoTab6.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab6.Tag = "6";
            this.menuTabGoTab6.Text = "Go Tab 6";
            this.menuTabGoTab6.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuTabGoTab7
            // 
            this.menuTabGoTab7.Name = "menuTabGoTab7";
            this.menuTabGoTab7.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.menuTabGoTab7.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab7.Tag = "7";
            this.menuTabGoTab7.Text = "Go Tab 7";
            this.menuTabGoTab7.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuTabGoTab8
            // 
            this.menuTabGoTab8.Name = "menuTabGoTab8";
            this.menuTabGoTab8.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.menuTabGoTab8.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab8.Tag = "8";
            this.menuTabGoTab8.Text = "Go Tab 8";
            this.menuTabGoTab8.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuTabGoTab9
            // 
            this.menuTabGoTab9.Name = "menuTabGoTab9";
            this.menuTabGoTab9.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.menuTabGoTab9.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab9.Tag = "9";
            this.menuTabGoTab9.Text = "Go Tab 9";
            this.menuTabGoTab9.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuTabGoTab10
            // 
            this.menuTabGoTab10.Name = "menuTabGoTab10";
            this.menuTabGoTab10.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.menuTabGoTab10.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab10.Tag = "10";
            this.menuTabGoTab10.Text = "Go Tab 10";
            this.menuTabGoTab10.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuTabGoTab11
            // 
            this.menuTabGoTab11.Name = "menuTabGoTab11";
            this.menuTabGoTab11.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.menuTabGoTab11.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab11.Tag = "11";
            this.menuTabGoTab11.Text = "Go Tab 11";
            this.menuTabGoTab11.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuTabGoTab12
            // 
            this.menuTabGoTab12.Name = "menuTabGoTab12";
            this.menuTabGoTab12.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.menuTabGoTab12.Size = new System.Drawing.Size(152, 22);
            this.menuTabGoTab12.Tag = "12";
            this.menuTabGoTab12.Text = "Go Tab 12";
            this.menuTabGoTab12.Click += new System.EventHandler(this.go2Tab);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout,
            this.menuHelpCheckUpdate});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 19);
            this.menuHelp.Text = "&Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(148, 22);
            this.menuHelpAbout.Text = "&About";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // menuHelpCheckUpdate
            // 
            this.menuHelpCheckUpdate.Name = "menuHelpCheckUpdate";
            this.menuHelpCheckUpdate.Size = new System.Drawing.Size(148, 22);
            this.menuHelpCheckUpdate.Text = "Check &Update";
            this.menuHelpCheckUpdate.Click += new System.EventHandler(this.menuHelpCheckUpdate_Click);
            // 
            // mainToolBar
            // 
            this.mainToolBar.AutoSize = false;
            this.mainToolBar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mainToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainToolBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainToolBar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolImportMovie,
            this.toolStripSeparator1,
            this.toolAllFiles,
            this.toolStripSeparator3,
            this.toolFilter,
            this.toolStripSeparator5,
            this.toolSearch,
            this.toolExitProgram,
            this.toolCloseTab,
            this.toolStripSeparator4,
            this.toolStripSeparator2,
            this.toolStat,
            this.toolStripSeparator6,
            this.toolPeer2Peer});
            this.mainToolBar.Location = new System.Drawing.Point(0, 343);
            this.mainToolBar.Name = "mainToolBar";
            this.mainToolBar.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.mainToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainToolBar.Size = new System.Drawing.Size(784, 65);
            this.mainToolBar.TabIndex = 0;
            this.mainToolBar.Text = "toolStrip1";
            // 
            // toolImportMovie
            // 
            this.toolImportMovie.Image = ((System.Drawing.Image)(resources.GetObject("toolImportMovie.Image")));
            this.toolImportMovie.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolImportMovie.ImageTransparentColor = System.Drawing.Color.White;
            this.toolImportMovie.Name = "toolImportMovie";
            this.toolImportMovie.Size = new System.Drawing.Size(97, 62);
            this.toolImportMovie.Text = " Import File ";
            this.toolImportMovie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolImportMovie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolImportMovie.Click += new System.EventHandler(this.toolImportMovie_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 65);
            // 
            // toolAllFiles
            // 
            this.toolAllFiles.Image = ((System.Drawing.Image)(resources.GetObject("toolAllFiles.Image")));
            this.toolAllFiles.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAllFiles.ImageTransparentColor = System.Drawing.Color.White;
            this.toolAllFiles.Name = "toolAllFiles";
            this.toolAllFiles.Size = new System.Drawing.Size(86, 62);
            this.toolAllFiles.Text = "All Movies";
            this.toolAllFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolAllFiles.Click += new System.EventHandler(this.toolAllFiles_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 65);
            // 
            // toolFilter
            // 
            this.toolFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolFilter.Image")));
            this.toolFilter.ImageTransparentColor = System.Drawing.Color.White;
            this.toolFilter.Name = "toolFilter";
            this.toolFilter.Size = new System.Drawing.Size(65, 62);
            this.toolFilter.Text = "Filters";
            this.toolFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 65);
            // 
            // toolSearch
            // 
            this.toolSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolSearch.Image")));
            this.toolSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.White;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(64, 62);
            this.toolSearch.Text = "  Find   ";
            this.toolSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolSearch.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // toolExitProgram
            // 
            this.toolExitProgram.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolExitProgram.Image = ((System.Drawing.Image)(resources.GetObject("toolExitProgram.Image")));
            this.toolExitProgram.ImageTransparentColor = System.Drawing.Color.White;
            this.toolExitProgram.Name = "toolExitProgram";
            this.toolExitProgram.Size = new System.Drawing.Size(103, 62);
            this.toolExitProgram.Text = "Exit Program";
            this.toolExitProgram.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolExitProgram.Visible = false;
            this.toolExitProgram.Click += new System.EventHandler(this.toolExitProgram_Click);
            // 
            // toolCloseTab
            // 
            this.toolCloseTab.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolCloseTab.Image = ((System.Drawing.Image)(resources.GetObject("toolCloseTab.Image")));
            this.toolCloseTab.ImageTransparentColor = System.Drawing.Color.White;
            this.toolCloseTab.Name = "toolCloseTab";
            this.toolCloseTab.Size = new System.Drawing.Size(81, 62);
            this.toolCloseTab.Text = "Close Tab";
            this.toolCloseTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolCloseTab.Click += new System.EventHandler(this.toolCloseTab_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 65);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 65);
            // 
            // toolStat
            // 
            this.toolStat.Image = ((System.Drawing.Image)(resources.GetObject("toolStat.Image")));
            this.toolStat.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStat.Name = "toolStat";
            this.toolStat.Size = new System.Drawing.Size(65, 62);
            this.toolStat.Text = "   Stat   ";
            this.toolStat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStat.Click += new System.EventHandler(this.toolStat_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 65);
            // 
            // toolPeer2Peer
            // 
            this.toolPeer2Peer.Image = ((System.Drawing.Image)(resources.GetObject("toolPeer2Peer.Image")));
            this.toolPeer2Peer.ImageTransparentColor = System.Drawing.Color.White;
            this.toolPeer2Peer.Name = "toolPeer2Peer";
            this.toolPeer2Peer.Size = new System.Drawing.Size(85, 62);
            this.toolPeer2Peer.Text = "Peer2Peer";
            this.toolPeer2Peer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolPeer2Peer.ToolTipText = "Comunication with Friends in Local Network";
            this.toolPeer2Peer.Visible = false;
            this.toolPeer2Peer.Click += new System.EventHandler(this.toolPeer2Peer_Click);
            // 
            // iml32x32
            // 
            this.iml32x32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml32x32.ImageStream")));
            this.iml32x32.TransparentColor = System.Drawing.Color.Transparent;
            this.iml32x32.Images.SetKeyName(0, "download");
            this.iml32x32.Images.SetKeyName(1, "search");
            // 
            // tabMain
            // 
            this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabMain.Location = new System.Drawing.Point(13, 43);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(527, 277);
            this.tabMain.TabIndex = 3;
            this.tabMain.Visible = false;
            // 
            // lstDebug
            // 
            this.lstDebug.BackColor = System.Drawing.Color.Black;
            this.lstDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lstDebug.ForeColor = System.Drawing.Color.Lime;
            this.lstDebug.FormattingEnabled = true;
            this.lstDebug.Location = new System.Drawing.Point(539, 43);
            this.lstDebug.Margin = new System.Windows.Forms.Padding(6);
            this.lstDebug.Name = "lstDebug";
            this.lstDebug.Size = new System.Drawing.Size(230, 277);
            this.lstDebug.TabIndex = 4;
            // 
            // tmrDebug
            // 
            this.tmrDebug.Enabled = true;
            this.tmrDebug.Interval = 200;
            this.tmrDebug.Tick += new System.EventHandler(this.tmrDebug_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 408);
            this.Controls.Add(this.lstDebug);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.mainToolBar);
            this.Controls.Add(this.menuMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "xDB";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Move += new System.EventHandler(this.frmMain_Move);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.mainToolBar.ResumeLayout(false);
            this.mainToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuTab;
        private System.Windows.Forms.ToolStripMenuItem menuTabClose;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab1;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab2;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab3;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab4;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab5;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab6;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab7;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab8;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab9;
        private System.Windows.Forms.ToolStripMenuItem menuFileImportMovie;
        private System.Windows.Forms.ToolStripMenuItem menuMovie;
        private System.Windows.Forms.ToolStripMenuItem menuMovieAll;
        private System.Windows.Forms.ToolStripMenuItem menuMovieFind;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab10;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab11;
        private System.Windows.Forms.ToolStripMenuItem menuTabGoTab12;
        private System.Windows.Forms.ToolStrip mainToolBar;
        private System.Windows.Forms.ToolStripButton toolImportMovie;
        private System.Windows.Forms.ImageList iml32x32;
        public System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.ListBox lstDebug;
        private System.Windows.Forms.ToolStripButton toolAllFiles;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.ToolStripButton toolExitProgram;
        private System.Windows.Forms.ToolStripButton toolCloseTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Timer tmrDebug;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuHelpCheckUpdate;
        private System.Windows.Forms.ToolStripDropDownButton toolFilter;
        private System.Windows.Forms.ToolStripMenuItem menuMovieManageFilter;
        private System.Windows.Forms.ToolStripButton toolStat;
        private System.Windows.Forms.ToolStripButton toolPeer2Peer;
        private System.Windows.Forms.ToolStripMenuItem menuMovieStatistics;
        private System.Windows.Forms.ToolStripMenuItem menuNetwork;
        private System.Windows.Forms.ToolStripMenuItem menuNetworkPeerToPeer;
        private System.Windows.Forms.ToolStripMenuItem menuOption;
        private System.Windows.Forms.ToolStripMenuItem menuOptionAutoBuildHash;
        private System.Windows.Forms.ToolStripMenuItem menuOptionDeleteSourcePicture;
        private System.Windows.Forms.ToolStripMenuItem menuOptionAllSaveOfflineProfile;
        private System.Windows.Forms.ToolStripMenuItem menuProfile;
        private System.Windows.Forms.ToolStripMenuItem menuProfileImport;
        private System.Windows.Forms.ToolStripMenuItem menuProfileImportParseFromFileInDir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuBatch;
        private System.Windows.Forms.ToolStripMenuItem menuBatchDeleteLastFilePath;
    }
}

