namespace xDB2013
{
    partial class frmMovieProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovieProfile));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.lblAdvanceTab = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtHash = new System.Windows.Forms.TextBox();
            this.lblSearchFunctionKey = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCountPlay = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblPlay = new System.Windows.Forms.Label();
            this.lblBuildHash = new System.Windows.Forms.Label();
            this.lstActress = new System.Windows.Forms.ListBox();
            this.txtStory = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboRating = new System.Windows.Forms.ComboBox();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAddTag = new System.Windows.Forms.Label();
            this.lblAddActress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pgbBuildHash = new System.Windows.Forms.ProgressBar();
            this.lstTag = new System.Windows.Forms.ListBox();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.btnAddScreenShot2 = new System.Windows.Forms.Button();
            this.btnAddScreenShot1 = new System.Windows.Forms.Button();
            this.btnAddBackCover = new System.Windows.Forms.Button();
            this.btnAddFrontCover = new System.Windows.Forms.Button();
            this.btnDeleteFilePath = new System.Windows.Forms.Button();
            this.lblViewTime = new System.Windows.Forms.Label();
            this.lblModifiedTime = new System.Windows.Forms.Label();
            this.lblCreatedTime = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabFrontCover = new System.Windows.Forms.TabPage();
            this.tabBackCover = new System.Windows.Forms.TabPage();
            this.tabScreenShot1 = new System.Windows.Forms.TabPage();
            this.tabScreenShot2 = new System.Windows.Forms.TabPage();
            this.tabFoundDuplicate = new System.Windows.Forms.TabPage();
            this.btnUseThisFile = new System.Windows.Forms.Button();
            this.btnDeleteThisFile = new System.Windows.Forms.Button();
            this.btnViewProfile = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tmrBuildHash = new System.Windows.Forms.Timer(this.components);
            this.bgWorking = new System.ComponentModel.BackgroundWorker();
            this.tabMain.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.tabAdvanced.SuspendLayout();
            this.tabFoundDuplicate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabProfile);
            this.tabMain.Controls.Add(this.tabAdvanced);
            this.tabMain.Controls.Add(this.tabFrontCover);
            this.tabMain.Controls.Add(this.tabBackCover);
            this.tabMain.Controls.Add(this.tabScreenShot1);
            this.tabMain.Controls.Add(this.tabScreenShot2);
            this.tabMain.Controls.Add(this.tabFoundDuplicate);
            this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tabMain.ItemSize = new System.Drawing.Size(100, 80);
            this.tabMain.Location = new System.Drawing.Point(15, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(803, 546);
            this.tabMain.TabIndex = 0;
            // 
            // tabProfile
            // 
            this.tabProfile.BackColor = System.Drawing.Color.Transparent;
            this.tabProfile.Controls.Add(this.lblAdvanceTab);
            this.tabProfile.Controls.Add(this.label17);
            this.tabProfile.Controls.Add(this.txtHash);
            this.tabProfile.Controls.Add(this.lblSearchFunctionKey);
            this.tabProfile.Controls.Add(this.label16);
            this.tabProfile.Controls.Add(this.label15);
            this.tabProfile.Controls.Add(this.label14);
            this.tabProfile.Controls.Add(this.lblCountPlay);
            this.tabProfile.Controls.Add(this.lblSearch);
            this.tabProfile.Controls.Add(this.lblPlay);
            this.tabProfile.Controls.Add(this.lblBuildHash);
            this.tabProfile.Controls.Add(this.lstActress);
            this.tabProfile.Controls.Add(this.txtStory);
            this.tabProfile.Controls.Add(this.label7);
            this.tabProfile.Controls.Add(this.cboRating);
            this.tabProfile.Controls.Add(this.cboCountry);
            this.tabProfile.Controls.Add(this.cboType);
            this.tabProfile.Controls.Add(this.txtTitle);
            this.tabProfile.Controls.Add(this.txtCode);
            this.tabProfile.Controls.Add(this.label6);
            this.tabProfile.Controls.Add(this.label12);
            this.tabProfile.Controls.Add(this.label8);
            this.tabProfile.Controls.Add(this.lblAddTag);
            this.tabProfile.Controls.Add(this.lblAddActress);
            this.tabProfile.Controls.Add(this.label5);
            this.tabProfile.Controls.Add(this.label4);
            this.tabProfile.Controls.Add(this.label3);
            this.tabProfile.Controls.Add(this.label2);
            this.tabProfile.Controls.Add(this.label1);
            this.tabProfile.Controls.Add(this.pgbBuildHash);
            this.tabProfile.Controls.Add(this.lstTag);
            this.tabProfile.Location = new System.Drawing.Point(4, 4);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(795, 458);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "   Profile  ";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // lblAdvanceTab
            // 
            this.lblAdvanceTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdvanceTab.AutoSize = true;
            this.lblAdvanceTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAdvanceTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblAdvanceTab.ForeColor = System.Drawing.Color.Green;
            this.lblAdvanceTab.Location = new System.Drawing.Point(609, 410);
            this.lblAdvanceTab.Name = "lblAdvanceTab";
            this.lblAdvanceTab.Size = new System.Drawing.Size(161, 24);
            this.lblAdvanceTab.TabIndex = 34;
            this.lblAdvanceTab.Text = "Advanced Tab >>";
            this.lblAdvanceTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAdvanceTab.Click += new System.EventHandler(this.lblAdvanceTab_Click);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 373);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 24);
            this.label17.TabIndex = 33;
            this.label17.Text = "Counter";
            // 
            // txtHash
            // 
            this.txtHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHash.BackColor = System.Drawing.SystemColors.Control;
            this.txtHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHash.ForeColor = System.Drawing.Color.DimGray;
            this.txtHash.Location = new System.Drawing.Point(92, 335);
            this.txtHash.Name = "txtHash";
            this.txtHash.ReadOnly = true;
            this.txtHash.Size = new System.Drawing.Size(246, 22);
            this.txtHash.TabIndex = 32;
            this.txtHash.TabStop = false;
            this.txtHash.Text = "12345678901234567890123456789012";
            this.txtHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSearchFunctionKey
            // 
            this.lblSearchFunctionKey.AutoSize = true;
            this.lblSearchFunctionKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSearchFunctionKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSearchFunctionKey.ForeColor = System.Drawing.Color.Silver;
            this.lblSearchFunctionKey.Location = new System.Drawing.Point(445, 57);
            this.lblSearchFunctionKey.Name = "lblSearchFunctionKey";
            this.lblSearchFunctionKey.Size = new System.Drawing.Size(34, 16);
            this.lblSearchFunctionKey.TabIndex = 31;
            this.lblSearchFunctionKey.Text = "- F3";
            this.lblSearchFunctionKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label16.ForeColor = System.Drawing.Color.Silver;
            this.label16.Location = new System.Drawing.Point(204, 375);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 16);
            this.label16.TabIndex = 30;
            this.label16.Text = "- F5";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.ForeColor = System.Drawing.Color.Silver;
            this.label15.Location = new System.Drawing.Point(736, 344);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 16);
            this.label15.TabIndex = 29;
            this.label15.Text = "- F4";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.ForeColor = System.Drawing.Color.Silver;
            this.label14.Location = new System.Drawing.Point(427, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "- F1";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCountPlay
            // 
            this.lblCountPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCountPlay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCountPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCountPlay.ForeColor = System.Drawing.Color.DimGray;
            this.lblCountPlay.Location = new System.Drawing.Point(92, 365);
            this.lblCountPlay.Name = "lblCountPlay";
            this.lblCountPlay.Size = new System.Drawing.Size(65, 36);
            this.lblCountPlay.TabIndex = 25;
            this.lblCountPlay.Text = "0000";
            this.lblCountPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSearch.ForeColor = System.Drawing.Color.Green;
            this.lblSearch.Location = new System.Drawing.Point(388, 57);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(51, 16);
            this.lblSearch.TabIndex = 24;
            this.lblSearch.Text = "Search";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // lblPlay
            // 
            this.lblPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPlay.AutoSize = true;
            this.lblPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlay.ForeColor = System.Drawing.Color.Green;
            this.lblPlay.Location = new System.Drawing.Point(169, 375);
            this.lblPlay.Name = "lblPlay";
            this.lblPlay.Size = new System.Drawing.Size(35, 16);
            this.lblPlay.TabIndex = 21;
            this.lblPlay.Text = "Play";
            this.lblPlay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPlay.Click += new System.EventHandler(this.lblPlay_Click);
            // 
            // lblBuildHash
            // 
            this.lblBuildHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBuildHash.AutoSize = true;
            this.lblBuildHash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBuildHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBuildHash.ForeColor = System.Drawing.Color.Green;
            this.lblBuildHash.Location = new System.Drawing.Point(347, 338);
            this.lblBuildHash.Name = "lblBuildHash";
            this.lblBuildHash.Size = new System.Drawing.Size(73, 16);
            this.lblBuildHash.TabIndex = 17;
            this.lblBuildHash.Text = "Build Hash";
            this.lblBuildHash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBuildHash.Click += new System.EventHandler(this.lblBuildHash_Click);
            // 
            // lstActress
            // 
            this.lstActress.BackColor = System.Drawing.SystemColors.Control;
            this.lstActress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lstActress.ForeColor = System.Drawing.Color.Navy;
            this.lstActress.FormattingEnabled = true;
            this.lstActress.ItemHeight = 24;
            this.lstActress.Items.AddRange(new object[] {
            "JENNY TAINSUWAN",
            "HITOMI YAKUSAWA",
            "NAKAYA ISSUYANA"});
            this.lstActress.Location = new System.Drawing.Point(92, 86);
            this.lstActress.Name = "lstActress";
            this.lstActress.ScrollAlwaysVisible = true;
            this.lstActress.Size = new System.Drawing.Size(286, 76);
            this.lstActress.TabIndex = 2;
            this.lstActress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstActress_KeyUp);
            // 
            // txtStory
            // 
            this.txtStory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(200)))));
            this.txtStory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtStory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtStory.Location = new System.Drawing.Point(92, 169);
            this.txtStory.Multiline = true;
            this.txtStory.Name = "txtStory";
            this.txtStory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStory.Size = new System.Drawing.Size(506, 159);
            this.txtStory.TabIndex = 6;
            this.txtStory.Text = "เนื้อเรื่องมันมีอยู่ว่า\r\nเมื่อนานมาแล้ว  นะครับ\r\n\r\n";
            this.txtStory.TextChanged += new System.EventHandler(this.txtStory_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(632, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tag";
            // 
            // cboRating
            // 
            this.cboRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRating.BackColor = System.Drawing.SystemColors.Control;
            this.cboRating.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboRating.ForeColor = System.Drawing.Color.Red;
            this.cboRating.FormattingEnabled = true;
            this.cboRating.Location = new System.Drawing.Point(718, 132);
            this.cboRating.MaxLength = 1;
            this.cboRating.Name = "cboRating";
            this.cboRating.Size = new System.Drawing.Size(52, 39);
            this.cboRating.TabIndex = 5;
            this.cboRating.Text = "5";
            this.cboRating.TextChanged += new System.EventHandler(this.cboRating_TextChanged);
            // 
            // cboCountry
            // 
            this.cboCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCountry.BackColor = System.Drawing.SystemColors.Control;
            this.cboCountry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboCountry.ForeColor = System.Drawing.Color.Blue;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(718, 96);
            this.cboCountry.MaxLength = 2;
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(52, 32);
            this.cboCountry.TabIndex = 4;
            this.cboCountry.Text = "TH";
            this.cboCountry.TextChanged += new System.EventHandler(this.cboCountry_TextChanged);
            // 
            // cboType
            // 
            this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboType.BackColor = System.Drawing.SystemColors.Control;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(718, 52);
            this.cboType.MaxLength = 1;
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(52, 39);
            this.cboType.TabIndex = 3;
            this.cboType.Text = "X";
            this.cboType.TextChanged += new System.EventHandler(this.cboType_TextChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(200)))));
            this.txtTitle.ForeColor = System.Drawing.Color.Blue;
            this.txtTitle.Location = new System.Drawing.Point(92, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(678, 29);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "Teacher is not see me";
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(200)))));
            this.txtCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtCode.Location = new System.Drawing.Point(92, 51);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(286, 29);
            this.txtCode.TabIndex = 1;
            this.txtCode.Text = "XXX-005";
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Code";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Purple;
            this.label12.Location = new System.Drawing.Point(18, 336);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 24);
            this.label12.TabIndex = 4;
            this.label12.Text = "Hash";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 24);
            this.label8.TabIndex = 4;
            this.label8.Text = "Story";
            // 
            // lblAddTag
            // 
            this.lblAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddTag.AutoSize = true;
            this.lblAddTag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAddTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblAddTag.ForeColor = System.Drawing.Color.Green;
            this.lblAddTag.Location = new System.Drawing.Point(705, 343);
            this.lblAddTag.Name = "lblAddTag";
            this.lblAddTag.Size = new System.Drawing.Size(33, 16);
            this.lblAddTag.TabIndex = 4;
            this.lblAddTag.Text = "Add";
            this.lblAddTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddTag.Click += new System.EventHandler(this.lblAddTag_Click);
            // 
            // lblAddActress
            // 
            this.lblAddActress.AutoSize = true;
            this.lblAddActress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAddActress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblAddActress.ForeColor = System.Drawing.Color.Green;
            this.lblAddActress.Location = new System.Drawing.Point(388, 92);
            this.lblAddActress.Name = "lblAddActress";
            this.lblAddActress.Size = new System.Drawing.Size(33, 16);
            this.lblAddActress.TabIndex = 4;
            this.lblAddActress.Text = "Add";
            this.lblAddActress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddActress.Click += new System.EventHandler(this.lblAddActress_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Actress";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Title";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rating +";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(633, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(633, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Country";
            // 
            // pgbBuildHash
            // 
            this.pgbBuildHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbBuildHash.Location = new System.Drawing.Point(92, 337);
            this.pgbBuildHash.Name = "pgbBuildHash";
            this.pgbBuildHash.Size = new System.Drawing.Size(504, 18);
            this.pgbBuildHash.TabIndex = 20;
            this.pgbBuildHash.Visible = false;
            // 
            // lstTag
            // 
            this.lstTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTag.BackColor = System.Drawing.SystemColors.Control;
            this.lstTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lstTag.ForeColor = System.Drawing.Color.Navy;
            this.lstTag.FormattingEnabled = true;
            this.lstTag.ItemHeight = 24;
            this.lstTag.Items.AddRange(new object[] {
            "rape",
            "lover",
            "incest",
            "hidden",
            "clip"});
            this.lstTag.Location = new System.Drawing.Point(638, 198);
            this.lstTag.Name = "lstTag";
            this.lstTag.ScrollAlwaysVisible = true;
            this.lstTag.Size = new System.Drawing.Size(132, 124);
            this.lstTag.TabIndex = 7;
            this.lstTag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstTag_KeyUp);
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.BackColor = System.Drawing.Color.Transparent;
            this.tabAdvanced.Controls.Add(this.btnAddScreenShot2);
            this.tabAdvanced.Controls.Add(this.btnAddScreenShot1);
            this.tabAdvanced.Controls.Add(this.btnAddBackCover);
            this.tabAdvanced.Controls.Add(this.btnAddFrontCover);
            this.tabAdvanced.Controls.Add(this.btnDeleteFilePath);
            this.tabAdvanced.Controls.Add(this.lblViewTime);
            this.tabAdvanced.Controls.Add(this.lblModifiedTime);
            this.tabAdvanced.Controls.Add(this.lblCreatedTime);
            this.tabAdvanced.Controls.Add(this.label13);
            this.tabAdvanced.Controls.Add(this.label10);
            this.tabAdvanced.Controls.Add(this.label9);
            this.tabAdvanced.Controls.Add(this.txtFilePath);
            this.tabAdvanced.Controls.Add(this.label11);
            this.tabAdvanced.Location = new System.Drawing.Point(4, 4);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdvanced.Size = new System.Drawing.Size(795, 488);
            this.tabAdvanced.TabIndex = 5;
            this.tabAdvanced.Text = "  Advanced  ";
            this.tabAdvanced.UseVisualStyleBackColor = true;
            // 
            // btnAddScreenShot2
            // 
            this.btnAddScreenShot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAddScreenShot2.Location = new System.Drawing.Point(612, 224);
            this.btnAddScreenShot2.Name = "btnAddScreenShot2";
            this.btnAddScreenShot2.Size = new System.Drawing.Size(143, 57);
            this.btnAddScreenShot2.TabIndex = 29;
            this.btnAddScreenShot2.TabStop = false;
            this.btnAddScreenShot2.Text = "SS2";
            this.btnAddScreenShot2.UseVisualStyleBackColor = true;
            this.btnAddScreenShot2.Click += new System.EventHandler(this.btnAddScreenShot2_Click);
            // 
            // btnAddScreenShot1
            // 
            this.btnAddScreenShot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAddScreenShot1.Location = new System.Drawing.Point(441, 224);
            this.btnAddScreenShot1.Name = "btnAddScreenShot1";
            this.btnAddScreenShot1.Size = new System.Drawing.Size(143, 57);
            this.btnAddScreenShot1.TabIndex = 30;
            this.btnAddScreenShot1.TabStop = false;
            this.btnAddScreenShot1.Text = "SS1";
            this.btnAddScreenShot1.UseVisualStyleBackColor = true;
            this.btnAddScreenShot1.Click += new System.EventHandler(this.btnAddScreenShot1_Click);
            // 
            // btnAddBackCover
            // 
            this.btnAddBackCover.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAddBackCover.Location = new System.Drawing.Point(269, 224);
            this.btnAddBackCover.Name = "btnAddBackCover";
            this.btnAddBackCover.Size = new System.Drawing.Size(143, 57);
            this.btnAddBackCover.TabIndex = 27;
            this.btnAddBackCover.TabStop = false;
            this.btnAddBackCover.Text = "Back Cover";
            this.btnAddBackCover.UseVisualStyleBackColor = true;
            this.btnAddBackCover.Click += new System.EventHandler(this.btnAddBackCover_Click);
            // 
            // btnAddFrontCover
            // 
            this.btnAddFrontCover.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAddFrontCover.Location = new System.Drawing.Point(100, 224);
            this.btnAddFrontCover.Name = "btnAddFrontCover";
            this.btnAddFrontCover.Size = new System.Drawing.Size(143, 57);
            this.btnAddFrontCover.TabIndex = 28;
            this.btnAddFrontCover.TabStop = false;
            this.btnAddFrontCover.Text = "Front Cover";
            this.btnAddFrontCover.UseVisualStyleBackColor = true;
            this.btnAddFrontCover.Click += new System.EventHandler(this.btnAddFrontCover_Click);
            // 
            // btnDeleteFilePath
            // 
            this.btnDeleteFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDeleteFilePath.Location = new System.Drawing.Point(103, 53);
            this.btnDeleteFilePath.Name = "btnDeleteFilePath";
            this.btnDeleteFilePath.Size = new System.Drawing.Size(348, 48);
            this.btnDeleteFilePath.TabIndex = 26;
            this.btnDeleteFilePath.TabStop = false;
            this.btnDeleteFilePath.Text = "Delete File Path and Real File in Disk !!";
            this.btnDeleteFilePath.UseVisualStyleBackColor = true;
            this.btnDeleteFilePath.Click += new System.EventHandler(this.btnDeleteFilePath_Click);
            // 
            // lblViewTime
            // 
            this.lblViewTime.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblViewTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblViewTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblViewTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblViewTime.Location = new System.Drawing.Point(103, 182);
            this.lblViewTime.Name = "lblViewTime";
            this.lblViewTime.Size = new System.Drawing.Size(348, 25);
            this.lblViewTime.TabIndex = 23;
            this.lblViewTime.Text = "2013-06-14 15:03:07 (2 Month Ago)";
            // 
            // lblModifiedTime
            // 
            this.lblModifiedTime.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblModifiedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblModifiedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblModifiedTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblModifiedTime.Location = new System.Drawing.Point(103, 151);
            this.lblModifiedTime.Name = "lblModifiedTime";
            this.lblModifiedTime.Size = new System.Drawing.Size(348, 24);
            this.lblModifiedTime.TabIndex = 24;
            this.lblModifiedTime.Text = "2013-06-14 15:03:07 (2 Month Ago)";
            // 
            // lblCreatedTime
            // 
            this.lblCreatedTime.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblCreatedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCreatedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCreatedTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCreatedTime.Location = new System.Drawing.Point(103, 121);
            this.lblCreatedTime.Name = "lblCreatedTime";
            this.lblCreatedTime.Size = new System.Drawing.Size(348, 25);
            this.lblCreatedTime.TabIndex = 25;
            this.lblCreatedTime.Text = "2013-06-14 15:03:07 (2 Month Ago)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 24);
            this.label13.TabIndex = 21;
            this.label13.Text = "View";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 24);
            this.label10.TabIndex = 20;
            this.label10.Text = "Modified";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 24);
            this.label9.TabIndex = 22;
            this.label9.Text = "Created";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFilePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFilePath.Location = new System.Drawing.Point(103, 18);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(671, 29);
            this.txtFilePath.TabIndex = 9;
            this.txtFilePath.TabStop = false;
            this.txtFilePath.Text = "M:\\Movies.R\\Movie-Rate-R-China\\Jin-pin-mei.iso";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 24);
            this.label11.TabIndex = 7;
            this.label11.Text = "File Path";
            // 
            // tabFrontCover
            // 
            this.tabFrontCover.Location = new System.Drawing.Point(4, 4);
            this.tabFrontCover.Name = "tabFrontCover";
            this.tabFrontCover.Padding = new System.Windows.Forms.Padding(3);
            this.tabFrontCover.Size = new System.Drawing.Size(795, 488);
            this.tabFrontCover.TabIndex = 1;
            this.tabFrontCover.Text = "Front Cover";
            this.tabFrontCover.UseVisualStyleBackColor = true;
            // 
            // tabBackCover
            // 
            this.tabBackCover.Location = new System.Drawing.Point(4, 4);
            this.tabBackCover.Name = "tabBackCover";
            this.tabBackCover.Padding = new System.Windows.Forms.Padding(3);
            this.tabBackCover.Size = new System.Drawing.Size(795, 488);
            this.tabBackCover.TabIndex = 2;
            this.tabBackCover.Text = "Back Cover";
            this.tabBackCover.UseVisualStyleBackColor = true;
            // 
            // tabScreenShot1
            // 
            this.tabScreenShot1.Location = new System.Drawing.Point(4, 4);
            this.tabScreenShot1.Name = "tabScreenShot1";
            this.tabScreenShot1.Padding = new System.Windows.Forms.Padding(3);
            this.tabScreenShot1.Size = new System.Drawing.Size(795, 488);
            this.tabScreenShot1.TabIndex = 3;
            this.tabScreenShot1.Text = "Screen Shot 1";
            this.tabScreenShot1.UseVisualStyleBackColor = true;
            // 
            // tabScreenShot2
            // 
            this.tabScreenShot2.Location = new System.Drawing.Point(4, 4);
            this.tabScreenShot2.Name = "tabScreenShot2";
            this.tabScreenShot2.Padding = new System.Windows.Forms.Padding(3);
            this.tabScreenShot2.Size = new System.Drawing.Size(795, 488);
            this.tabScreenShot2.TabIndex = 4;
            this.tabScreenShot2.Text = "Screen Shot 2";
            this.tabScreenShot2.UseVisualStyleBackColor = true;
            // 
            // tabFoundDuplicate
            // 
            this.tabFoundDuplicate.BackColor = System.Drawing.Color.Red;
            this.tabFoundDuplicate.Controls.Add(this.btnUseThisFile);
            this.tabFoundDuplicate.Controls.Add(this.btnDeleteThisFile);
            this.tabFoundDuplicate.Controls.Add(this.btnViewProfile);
            this.tabFoundDuplicate.Controls.Add(this.label19);
            this.tabFoundDuplicate.Controls.Add(this.label18);
            this.tabFoundDuplicate.Location = new System.Drawing.Point(4, 4);
            this.tabFoundDuplicate.Name = "tabFoundDuplicate";
            this.tabFoundDuplicate.Padding = new System.Windows.Forms.Padding(3);
            this.tabFoundDuplicate.Size = new System.Drawing.Size(795, 488);
            this.tabFoundDuplicate.TabIndex = 6;
            this.tabFoundDuplicate.Text = "Found Duplicate";
            this.tabFoundDuplicate.UseVisualStyleBackColor = true;
            // 
            // btnUseThisFile
            // 
            this.btnUseThisFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnUseThisFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUseThisFile.Location = new System.Drawing.Point(70, 338);
            this.btnUseThisFile.Name = "btnUseThisFile";
            this.btnUseThisFile.Size = new System.Drawing.Size(248, 74);
            this.btnUseThisFile.TabIndex = 2;
            this.btnUseThisFile.Text = "Use This File **";
            this.btnUseThisFile.UseVisualStyleBackColor = true;
            this.btnUseThisFile.Click += new System.EventHandler(this.btnUseThisFile_Click);
            // 
            // btnDeleteThisFile
            // 
            this.btnDeleteThisFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDeleteThisFile.ForeColor = System.Drawing.Color.Maroon;
            this.btnDeleteThisFile.Location = new System.Drawing.Point(70, 235);
            this.btnDeleteThisFile.Name = "btnDeleteThisFile";
            this.btnDeleteThisFile.Size = new System.Drawing.Size(248, 74);
            this.btnDeleteThisFile.TabIndex = 38;
            this.btnDeleteThisFile.Text = "Delete This File !";
            this.btnDeleteThisFile.UseVisualStyleBackColor = true;
            this.btnDeleteThisFile.Click += new System.EventHandler(this.btnDeleteThisFile_Click);
            // 
            // btnViewProfile
            // 
            this.btnViewProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnViewProfile.ForeColor = System.Drawing.Color.Green;
            this.btnViewProfile.Location = new System.Drawing.Point(70, 132);
            this.btnViewProfile.Name = "btnViewProfile";
            this.btnViewProfile.Size = new System.Drawing.Size(248, 74);
            this.btnViewProfile.TabIndex = 37;
            this.btnViewProfile.Text = "View Existing Profile";
            this.btnViewProfile.UseVisualStyleBackColor = true;
            this.btnViewProfile.Click += new System.EventHandler(this.btnViewProfile_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(65, 74);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(253, 25);
            this.label19.TabIndex = 35;
            this.label19.Text = "What Do you want to do?";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(18, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(439, 31);
            this.label18.TabIndex = 35;
            this.label18.Text = "Found Duplicate Movie Profile !!!";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.Location = new System.Drawing.Point(517, 586);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 64);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "F9 - Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnClose.Location = new System.Drawing.Point(698, 586);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 64);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tmrBuildHash
            // 
            this.tmrBuildHash.Tick += new System.EventHandler(this.tmrBuildHash_Tick);
            // 
            // bgWorking
            // 
            this.bgWorking.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorking_DoWork);
            // 
            // frmMovieProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(837, 662);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMovieProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " Movie Profile";
            this.Load += new System.EventHandler(this.frmMovieProfile_Load);
            this.Shown += new System.EventHandler(this.frmMovieProfile_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMovieProfile_KeyUp);
            this.Move += new System.EventHandler(this.frmMovieProfile_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMovieProfile_FormClosing);
            this.Resize += new System.EventHandler(this.frmMovieProfile_Resize);
            this.tabMain.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            this.tabAdvanced.ResumeLayout(false);
            this.tabAdvanced.PerformLayout();
            this.tabFoundDuplicate.ResumeLayout(false);
            this.tabFoundDuplicate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabFrontCover;
        private System.Windows.Forms.TabPage tabBackCover;
        private System.Windows.Forms.TabPage tabScreenShot1;
        private System.Windows.Forms.TabPage tabScreenShot2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.ComboBox cboRating;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lstActress;
        private System.Windows.Forms.Label lblAddActress;
        private System.Windows.Forms.Label lblAddTag;
        private System.Windows.Forms.ListBox lstTag;
        private System.Windows.Forms.Label lblBuildHash;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer tmrBuildHash;
        private System.Windows.Forms.ProgressBar pgbBuildHash;
        private System.ComponentModel.BackgroundWorker bgWorking;
        private System.Windows.Forms.Label lblPlay;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblCountPlay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblSearchFunctionKey;
        private System.Windows.Forms.TabPage tabAdvanced;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label lblViewTime;
        private System.Windows.Forms.Label lblModifiedTime;
        private System.Windows.Forms.Label lblCreatedTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHash;
        private System.Windows.Forms.TabPage tabFoundDuplicate;
        private System.Windows.Forms.Button btnUseThisFile;
        private System.Windows.Forms.Button btnDeleteThisFile;
        private System.Windows.Forms.Button btnViewProfile;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnDeleteFilePath;
        private System.Windows.Forms.Label lblAdvanceTab;
        private System.Windows.Forms.Button btnAddScreenShot2;
        private System.Windows.Forms.Button btnAddScreenShot1;
        private System.Windows.Forms.Button btnAddBackCover;
        private System.Windows.Forms.Button btnAddFrontCover;
    }
}