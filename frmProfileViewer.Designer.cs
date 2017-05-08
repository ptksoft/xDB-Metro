namespace xDB2013
{
	partial class frmProfileViewer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfileViewer));
			this.tabScreenShot2 = new System.Windows.Forms.TabPage();
			this.tabScreenShot1 = new System.Windows.Forms.TabPage();
			this.tabBackCover = new System.Windows.Forms.TabPage();
			this.tabFrontCover = new System.Windows.Forms.TabPage();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.lblCode = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.flowActress = new System.Windows.Forms.FlowLayoutPanel();
			this.flowTag = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnPlay = new System.Windows.Forms.Button();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.tabMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabScreenShot2
			// 
			this.tabScreenShot2.Location = new System.Drawing.Point(4, 4);
			this.tabScreenShot2.Name = "tabScreenShot2";
			this.tabScreenShot2.Padding = new System.Windows.Forms.Padding(3);
			this.tabScreenShot2.Size = new System.Drawing.Size(683, 439);
			this.tabScreenShot2.TabIndex = 4;
			this.tabScreenShot2.Text = "Screen Shot 2";
			this.tabScreenShot2.UseVisualStyleBackColor = true;
			// 
			// tabScreenShot1
			// 
			this.tabScreenShot1.Location = new System.Drawing.Point(4, 4);
			this.tabScreenShot1.Name = "tabScreenShot1";
			this.tabScreenShot1.Padding = new System.Windows.Forms.Padding(3);
			this.tabScreenShot1.Size = new System.Drawing.Size(683, 439);
			this.tabScreenShot1.TabIndex = 3;
			this.tabScreenShot1.Text = "Screen Shot 1";
			this.tabScreenShot1.UseVisualStyleBackColor = true;
			// 
			// tabBackCover
			// 
			this.tabBackCover.Location = new System.Drawing.Point(4, 4);
			this.tabBackCover.Name = "tabBackCover";
			this.tabBackCover.Padding = new System.Windows.Forms.Padding(3);
			this.tabBackCover.Size = new System.Drawing.Size(683, 439);
			this.tabBackCover.TabIndex = 2;
			this.tabBackCover.Text = "Back Cover";
			this.tabBackCover.UseVisualStyleBackColor = true;
			// 
			// tabFrontCover
			// 
			this.tabFrontCover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
			this.tabFrontCover.Location = new System.Drawing.Point(4, 4);
			this.tabFrontCover.Name = "tabFrontCover";
			this.tabFrontCover.Padding = new System.Windows.Forms.Padding(3);
			this.tabFrontCover.Size = new System.Drawing.Size(683, 439);
			this.tabFrontCover.TabIndex = 1;
			this.tabFrontCover.Text = "Front Cover";
			// 
			// tabMain
			// 
			this.tabMain.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabFrontCover);
			this.tabMain.Controls.Add(this.tabBackCover);
			this.tabMain.Controls.Add(this.tabScreenShot1);
			this.tabMain.Controls.Add(this.tabScreenShot2);
			this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.tabMain.ItemSize = new System.Drawing.Size(100, 80);
			this.tabMain.Location = new System.Drawing.Point(0, 0);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(691, 527);
			this.tabMain.TabIndex = 1;
			this.tabMain.TabStop = false;
			// 
			// lblCode
			// 
			this.lblCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.lblCode.Location = new System.Drawing.Point(691, 2);
			this.lblCode.Name = "lblCode";
			this.lblCode.Size = new System.Drawing.Size(292, 39);
			this.lblCode.TabIndex = 2;
			this.lblCode.Text = "XXX-001";
			this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTitle
			// 
			this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lblTitle.ForeColor = System.Drawing.Color.Black;
			this.lblTitle.Location = new System.Drawing.Point(691, 41);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(292, 65);
			this.lblTitle.TabIndex = 6;
			this.lblTitle.Text = "This is the title of moveis do you belive this or not what is the matrix and what" +
				" is your name";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowActress
			// 
			this.flowActress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flowActress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
			this.flowActress.ForeColor = System.Drawing.Color.Green;
			this.flowActress.Location = new System.Drawing.Point(693, 134);
			this.flowActress.Name = "flowActress";
			this.flowActress.Size = new System.Drawing.Size(290, 131);
			this.flowActress.TabIndex = 7;
			// 
			// flowTag
			// 
			this.flowTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flowTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
			this.flowTag.ForeColor = System.Drawing.Color.Purple;
			this.flowTag.Location = new System.Drawing.Point(693, 294);
			this.flowTag.Name = "flowTag";
			this.flowTag.Size = new System.Drawing.Size(290, 149);
			this.flowTag.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.label1.ForeColor = System.Drawing.Color.Silver;
			this.label1.Location = new System.Drawing.Point(690, 115);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Staring";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.label2.ForeColor = System.Drawing.Color.Silver;
			this.label2.Location = new System.Drawing.Point(692, 275);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 10;
			this.label2.Text = "Tags";
			// 
			// btnPlay
			// 
			this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPlay.FlatAppearance.BorderSize = 0;
			this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
			this.btnPlay.Location = new System.Drawing.Point(803, 448);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(69, 70);
			this.btnPlay.TabIndex = 11;
			this.btnPlay.TabStop = false;
			this.btnPlay.UseVisualStyleBackColor = true;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnPrevious
			// 
			this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrevious.FlatAppearance.BorderSize = 0;
			this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
			this.btnPrevious.Location = new System.Drawing.Point(695, 449);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(68, 69);
			this.btnPrevious.TabIndex = 12;
			this.btnPrevious.TabStop = false;
			this.btnPrevious.UseVisualStyleBackColor = true;
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.FlatAppearance.BorderSize = 0;
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
			this.btnNext.Location = new System.Drawing.Point(912, 449);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(68, 69);
			this.btnNext.TabIndex = 13;
			this.btnNext.TabStop = false;
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// frmProfileViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(984, 526);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrevious);
			this.Controls.Add(this.btnPlay);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.flowTag);
			this.Controls.Add(this.flowActress);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.lblCode);
			this.Controls.Add(this.tabMain);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "frmProfileViewer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "ABX-258";
			this.Load += new System.EventHandler(this.frmProfileViewer_Load);
			this.Shown += new System.EventHandler(this.frmProfileViewer_Shown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmProfileViewer_KeyUp);
			this.ResizeEnd += new System.EventHandler(this.frmProfileViewer_ResizeEnd);
			this.tabMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tabScreenShot2;
		private System.Windows.Forms.TabPage tabScreenShot1;
		private System.Windows.Forms.TabPage tabBackCover;
		private System.Windows.Forms.TabPage tabFrontCover;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.Label lblCode;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.FlowLayoutPanel flowActress;
		private System.Windows.Forms.FlowLayoutPanel flowTag;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.Button btnNext;
	}
}