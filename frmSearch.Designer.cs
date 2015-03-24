namespace xDB2013
{
    partial class frmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.chkNoTag = new System.Windows.Forms.CheckBox();
            this.chkNoActress = new System.Windows.Forms.CheckBox();
            this.chkNoFilePath = new System.Windows.Forms.CheckBox();
            this.checkListFileConnect = new System.Windows.Forms.CheckedListBox();
            this.checkListCountry = new System.Windows.Forms.CheckedListBox();
            this.checkListRating = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkListType = new System.Windows.Forms.CheckedListBox();
            this.txtStory = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtMaxCountPlay = new System.Windows.Forms.TextBox();
            this.txtMinCountPlay = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkStoryEmpty = new System.Windows.Forms.CheckBox();
            this.chkTitleEmpty = new System.Windows.Forms.CheckBox();
            this.chkCodeEmpty = new System.Windows.Forms.CheckBox();
            this.tabActress = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.txtActress = new System.Windows.Forms.TextBox();
            this.checkListActress = new System.Windows.Forms.CheckedListBox();
            this.tabTag = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.checkListTag = new System.Windows.Forms.CheckedListBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSaveFilter = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabActress.SuspendLayout();
            this.tabTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabGeneral);
            this.tabMain.Controls.Add(this.tabActress);
            this.tabMain.Controls.Add(this.tabTag);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(758, 323);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.label12);
            this.tabGeneral.Controls.Add(this.txtFilePath);
            this.tabGeneral.Controls.Add(this.chkNoTag);
            this.tabGeneral.Controls.Add(this.chkNoActress);
            this.tabGeneral.Controls.Add(this.chkNoFilePath);
            this.tabGeneral.Controls.Add(this.checkListFileConnect);
            this.tabGeneral.Controls.Add(this.checkListCountry);
            this.tabGeneral.Controls.Add(this.checkListRating);
            this.tabGeneral.Controls.Add(this.label6);
            this.tabGeneral.Controls.Add(this.label5);
            this.tabGeneral.Controls.Add(this.label4);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.checkListType);
            this.tabGeneral.Controls.Add(this.txtStory);
            this.tabGeneral.Controls.Add(this.txtTitle);
            this.tabGeneral.Controls.Add(this.txtMaxCountPlay);
            this.tabGeneral.Controls.Add(this.txtMinCountPlay);
            this.tabGeneral.Controls.Add(this.txtCode);
            this.tabGeneral.Controls.Add(this.label1);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Controls.Add(this.label9);
            this.tabGeneral.Controls.Add(this.label8);
            this.tabGeneral.Controls.Add(this.label7);
            this.tabGeneral.Controls.Add(this.lblTitle);
            this.tabGeneral.Controls.Add(this.chkStoryEmpty);
            this.tabGeneral.Controls.Add(this.chkTitleEmpty);
            this.tabGeneral.Controls.Add(this.chkCodeEmpty);
            this.tabGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(750, 294);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "F1 - General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "File Path";
            // 
            // txtFilePath
            // 
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilePath.ForeColor = System.Drawing.Color.Blue;
            this.txtFilePath.Location = new System.Drawing.Point(81, 259);
            this.txtFilePath.MaxLength = 50;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(290, 22);
            this.txtFilePath.TabIndex = 5;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            this.txtFilePath.Enter += new System.EventHandler(this.txtFilePath_Enter);
            // 
            // chkNoTag
            // 
            this.chkNoTag.AutoSize = true;
            this.chkNoTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkNoTag.ForeColor = System.Drawing.Color.Maroon;
            this.chkNoTag.Location = new System.Drawing.Point(195, 234);
            this.chkNoTag.Name = "chkNoTag";
            this.chkNoTag.Size = new System.Drawing.Size(73, 20);
            this.chkNoTag.TabIndex = 12;
            this.chkNoTag.TabStop = false;
            this.chkNoTag.Text = "No Tag";
            this.chkNoTag.UseVisualStyleBackColor = true;
            this.chkNoTag.CheckedChanged += new System.EventHandler(this.chkNoTag_CheckedChanged);
            // 
            // chkNoActress
            // 
            this.chkNoActress.AutoSize = true;
            this.chkNoActress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkNoActress.ForeColor = System.Drawing.Color.Maroon;
            this.chkNoActress.Location = new System.Drawing.Point(195, 208);
            this.chkNoActress.Name = "chkNoActress";
            this.chkNoActress.Size = new System.Drawing.Size(93, 20);
            this.chkNoActress.TabIndex = 11;
            this.chkNoActress.TabStop = false;
            this.chkNoActress.Text = "No Actress";
            this.chkNoActress.UseVisualStyleBackColor = true;
            this.chkNoActress.CheckedChanged += new System.EventHandler(this.chkNoActress_CheckedChanged);
            // 
            // chkNoFilePath
            // 
            this.chkNoFilePath.AutoSize = true;
            this.chkNoFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkNoFilePath.ForeColor = System.Drawing.Color.Maroon;
            this.chkNoFilePath.Location = new System.Drawing.Point(195, 182);
            this.chkNoFilePath.Name = "chkNoFilePath";
            this.chkNoFilePath.Size = new System.Drawing.Size(97, 20);
            this.chkNoFilePath.TabIndex = 10;
            this.chkNoFilePath.TabStop = false;
            this.chkNoFilePath.Text = "No FilePath";
            this.chkNoFilePath.UseVisualStyleBackColor = true;
            this.chkNoFilePath.CheckedChanged += new System.EventHandler(this.chkNoFilePath_CheckedChanged);
            // 
            // checkListFileConnect
            // 
            this.checkListFileConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkListFileConnect.CheckOnClick = true;
            this.checkListFileConnect.ForeColor = System.Drawing.Color.Blue;
            this.checkListFileConnect.FormattingEnabled = true;
            this.checkListFileConnect.Items.AddRange(new object[] {
            "Y",
            "N",
            "G",
            "?"});
            this.checkListFileConnect.Location = new System.Drawing.Point(654, 33);
            this.checkListFileConnect.MultiColumn = true;
            this.checkListFileConnect.Name = "checkListFileConnect";
            this.checkListFileConnect.Size = new System.Drawing.Size(76, 140);
            this.checkListFileConnect.TabIndex = 9;
            this.checkListFileConnect.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListFileConnect_ItemCheck);
            // 
            // checkListCountry
            // 
            this.checkListCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkListCountry.CheckOnClick = true;
            this.checkListCountry.ForeColor = System.Drawing.Color.Blue;
            this.checkListCountry.FormattingEnabled = true;
            this.checkListCountry.Location = new System.Drawing.Point(382, 33);
            this.checkListCountry.MultiColumn = true;
            this.checkListCountry.Name = "checkListCountry";
            this.checkListCountry.Size = new System.Drawing.Size(260, 157);
            this.checkListCountry.Sorted = true;
            this.checkListCountry.TabIndex = 8;
            this.checkListCountry.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListCountry_ItemCheck);
            // 
            // checkListRating
            // 
            this.checkListRating.CheckOnClick = true;
            this.checkListRating.ForeColor = System.Drawing.Color.Blue;
            this.checkListRating.FormattingEnabled = true;
            this.checkListRating.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.checkListRating.Location = new System.Drawing.Point(279, 33);
            this.checkListRating.Name = "checkListRating";
            this.checkListRating.Size = new System.Drawing.Size(92, 140);
            this.checkListRating.TabIndex = 7;
            this.checkListRating.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListRating_ItemCheck);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(651, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "FileConnect";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Country";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rating";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Type";
            // 
            // checkListType
            // 
            this.checkListType.CheckOnClick = true;
            this.checkListType.ForeColor = System.Drawing.Color.Blue;
            this.checkListType.FormattingEnabled = true;
            this.checkListType.Items.AddRange(new object[] {
            "X",
            "C",
            "R",
            "U"});
            this.checkListType.Location = new System.Drawing.Point(195, 33);
            this.checkListType.Name = "checkListType";
            this.checkListType.Size = new System.Drawing.Size(73, 140);
            this.checkListType.TabIndex = 6;
            this.checkListType.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListType_ItemCheck);
            // 
            // txtStory
            // 
            this.txtStory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStory.ForeColor = System.Drawing.Color.Blue;
            this.txtStory.Location = new System.Drawing.Point(15, 136);
            this.txtStory.MaxLength = 50;
            this.txtStory.Name = "txtStory";
            this.txtStory.Size = new System.Drawing.Size(159, 22);
            this.txtStory.TabIndex = 2;
            this.txtStory.TextChanged += new System.EventHandler(this.txtStory_TextChanged);
            this.txtStory.Enter += new System.EventHandler(this.txtStory_Enter);
            // 
            // txtTitle
            // 
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.ForeColor = System.Drawing.Color.Blue;
            this.txtTitle.Location = new System.Drawing.Point(13, 86);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(161, 22);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            this.txtTitle.Enter += new System.EventHandler(this.txtTitle_Enter);
            // 
            // txtMaxCountPlay
            // 
            this.txtMaxCountPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxCountPlay.ForeColor = System.Drawing.Color.Blue;
            this.txtMaxCountPlay.Location = new System.Drawing.Point(64, 222);
            this.txtMaxCountPlay.MaxLength = 4;
            this.txtMaxCountPlay.Name = "txtMaxCountPlay";
            this.txtMaxCountPlay.Size = new System.Drawing.Size(50, 22);
            this.txtMaxCountPlay.TabIndex = 4;
            this.txtMaxCountPlay.TextChanged += new System.EventHandler(this.txtMaxCountPlay_TextChanged);
            this.txtMaxCountPlay.Enter += new System.EventHandler(this.txtMaxCountPlay_Enter);
            // 
            // txtMinCountPlay
            // 
            this.txtMinCountPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinCountPlay.ForeColor = System.Drawing.Color.Blue;
            this.txtMinCountPlay.Location = new System.Drawing.Point(64, 194);
            this.txtMinCountPlay.MaxLength = 4;
            this.txtMinCountPlay.Name = "txtMinCountPlay";
            this.txtMinCountPlay.Size = new System.Drawing.Size(50, 22);
            this.txtMinCountPlay.TabIndex = 3;
            this.txtMinCountPlay.TextChanged += new System.EventHandler(this.txtMinCountPlay_TextChanged);
            this.txtMinCountPlay.Enter += new System.EventHandler(this.txtMinCountPlay_Enter);
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.ForeColor = System.Drawing.Color.Blue;
            this.txtCode.Location = new System.Drawing.Point(13, 35);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(161, 22);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.Enter += new System.EventHandler(this.txtCode_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Story";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Max";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Playing Counter";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(10, 65);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(34, 16);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // chkStoryEmpty
            // 
            this.chkStoryEmpty.AutoSize = true;
            this.chkStoryEmpty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkStoryEmpty.ForeColor = System.Drawing.Color.Maroon;
            this.chkStoryEmpty.Location = new System.Drawing.Point(64, 114);
            this.chkStoryEmpty.Name = "chkStoryEmpty";
            this.chkStoryEmpty.Size = new System.Drawing.Size(65, 20);
            this.chkStoryEmpty.TabIndex = 10;
            this.chkStoryEmpty.TabStop = false;
            this.chkStoryEmpty.Text = "Empty";
            this.chkStoryEmpty.UseVisualStyleBackColor = true;
            this.chkStoryEmpty.CheckedChanged += new System.EventHandler(this.chkStoryEmpty_CheckedChanged);
            // 
            // chkTitleEmpty
            // 
            this.chkTitleEmpty.AutoSize = true;
            this.chkTitleEmpty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkTitleEmpty.ForeColor = System.Drawing.Color.Maroon;
            this.chkTitleEmpty.Location = new System.Drawing.Point(64, 64);
            this.chkTitleEmpty.Name = "chkTitleEmpty";
            this.chkTitleEmpty.Size = new System.Drawing.Size(65, 20);
            this.chkTitleEmpty.TabIndex = 9;
            this.chkTitleEmpty.TabStop = false;
            this.chkTitleEmpty.Text = "Empty";
            this.chkTitleEmpty.UseVisualStyleBackColor = true;
            this.chkTitleEmpty.CheckedChanged += new System.EventHandler(this.chkTitleEmpty_CheckedChanged);
            // 
            // chkCodeEmpty
            // 
            this.chkCodeEmpty.AutoSize = true;
            this.chkCodeEmpty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkCodeEmpty.ForeColor = System.Drawing.Color.Maroon;
            this.chkCodeEmpty.Location = new System.Drawing.Point(64, 13);
            this.chkCodeEmpty.Name = "chkCodeEmpty";
            this.chkCodeEmpty.Size = new System.Drawing.Size(65, 20);
            this.chkCodeEmpty.TabIndex = 8;
            this.chkCodeEmpty.TabStop = false;
            this.chkCodeEmpty.Text = "Empty";
            this.chkCodeEmpty.UseVisualStyleBackColor = true;
            this.chkCodeEmpty.CheckedChanged += new System.EventHandler(this.chkCodeEmpty_CheckedChanged);
            // 
            // tabActress
            // 
            this.tabActress.Controls.Add(this.label10);
            this.tabActress.Controls.Add(this.txtActress);
            this.tabActress.Controls.Add(this.checkListActress);
            this.tabActress.Location = new System.Drawing.Point(4, 25);
            this.tabActress.Name = "tabActress";
            this.tabActress.Padding = new System.Windows.Forms.Padding(3);
            this.tabActress.Size = new System.Drawing.Size(750, 294);
            this.tabActress.TabIndex = 1;
            this.tabActress.Text = "F2 - Actress";
            this.tabActress.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Search Actress";
            // 
            // txtActress
            // 
            this.txtActress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActress.ForeColor = System.Drawing.Color.Blue;
            this.txtActress.Location = new System.Drawing.Point(111, 9);
            this.txtActress.MaxLength = 60;
            this.txtActress.Name = "txtActress";
            this.txtActress.Size = new System.Drawing.Size(182, 22);
            this.txtActress.TabIndex = 1;
            this.txtActress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtActress_KeyUp);
            // 
            // checkListActress
            // 
            this.checkListActress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkListActress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkListActress.CheckOnClick = true;
            this.checkListActress.ForeColor = System.Drawing.Color.Blue;
            this.checkListActress.FormattingEnabled = true;
            this.checkListActress.Location = new System.Drawing.Point(3, 37);
            this.checkListActress.MultiColumn = true;
            this.checkListActress.Name = "checkListActress";
            this.checkListActress.Size = new System.Drawing.Size(744, 255);
            this.checkListActress.Sorted = true;
            this.checkListActress.TabIndex = 0;
            this.checkListActress.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListActress_ItemCheck);
            // 
            // tabTag
            // 
            this.tabTag.Controls.Add(this.label11);
            this.tabTag.Controls.Add(this.txtTag);
            this.tabTag.Controls.Add(this.checkListTag);
            this.tabTag.Location = new System.Drawing.Point(4, 25);
            this.tabTag.Name = "tabTag";
            this.tabTag.Padding = new System.Windows.Forms.Padding(3);
            this.tabTag.Size = new System.Drawing.Size(750, 294);
            this.tabTag.TabIndex = 2;
            this.tabTag.Text = "F3 - Tag";
            this.tabTag.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Search Tag";
            // 
            // txtTag
            // 
            this.txtTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTag.ForeColor = System.Drawing.Color.Blue;
            this.txtTag.Location = new System.Drawing.Point(91, 9);
            this.txtTag.MaxLength = 60;
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(182, 22);
            this.txtTag.TabIndex = 2;
            this.txtTag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTag_KeyUp);
            // 
            // checkListTag
            // 
            this.checkListTag.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkListTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkListTag.CheckOnClick = true;
            this.checkListTag.ForeColor = System.Drawing.Color.Blue;
            this.checkListTag.FormattingEnabled = true;
            this.checkListTag.Location = new System.Drawing.Point(3, 37);
            this.checkListTag.MultiColumn = true;
            this.checkListTag.Name = "checkListTag";
            this.checkListTag.Size = new System.Drawing.Size(744, 221);
            this.checkListTag.Sorted = true;
            this.checkListTag.TabIndex = 0;
            this.checkListTag.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListTag_ItemCheck);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(259, 340);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(104, 31);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "F5 - Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(552, 341);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 31);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "F9 - OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(662, 341);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 31);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.Location = new System.Drawing.Point(12, 341);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(104, 31);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "F4 - Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSaveFilter
            // 
            this.btnSaveFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFilter.Enabled = false;
            this.btnSaveFilter.Location = new System.Drawing.Point(369, 341);
            this.btnSaveFilter.Name = "btnSaveFilter";
            this.btnSaveFilter.Size = new System.Drawing.Size(177, 31);
            this.btnSaveFilter.TabIndex = 2;
            this.btnSaveFilter.Text = "F8 - Save As Filter...";
            this.btnSaveFilter.UseVisualStyleBackColor = true;
            this.btnSaveFilter.Click += new System.EventHandler(this.btnSaveFilter_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(783, 383);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSaveFilter);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Search & Filter";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.Shown += new System.EventHandler(this.frmSearch_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmSearch_KeyUp);
            this.Resize += new System.EventHandler(this.frmSearch_Resize);
            this.tabMain.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabActress.ResumeLayout(false);
            this.tabActress.PerformLayout();
            this.tabTag.ResumeLayout(false);
            this.tabTag.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabActress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TabPage tabTag;
        private System.Windows.Forms.TextBox txtStory;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckedListBox checkListType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox checkListRating;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkListActress;
        private System.Windows.Forms.CheckedListBox checkListTag;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox checkListCountry;
        private System.Windows.Forms.CheckBox chkNoFilePath;
        private System.Windows.Forms.CheckedListBox checkListFileConnect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkStoryEmpty;
        private System.Windows.Forms.CheckBox chkTitleEmpty;
        private System.Windows.Forms.CheckBox chkCodeEmpty;
        private System.Windows.Forms.CheckBox chkNoTag;
        private System.Windows.Forms.CheckBox chkNoActress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaxCountPlay;
        private System.Windows.Forms.TextBox txtMinCountPlay;
        private System.Windows.Forms.Button btnSaveFilter;
        private System.Windows.Forms.TextBox txtActress;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label12;

    }
}