namespace xDB2013
{
    partial class frmMovieStat
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovieStat));
			this.lstTopic = new System.Windows.Forms.ListBox();
			this.lvwDetail = new System.Windows.Forms.ListView();
			this.theProgress = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// lstTopic
			// 
			this.lstTopic.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstTopic.Dock = System.Windows.Forms.DockStyle.Left;
			this.lstTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lstTopic.ForeColor = System.Drawing.Color.Blue;
			this.lstTopic.FormattingEnabled = true;
			this.lstTopic.ItemHeight = 24;
			this.lstTopic.Location = new System.Drawing.Point(0, 0);
			this.lstTopic.Name = "lstTopic";
			this.lstTopic.ScrollAlwaysVisible = true;
			this.lstTopic.Size = new System.Drawing.Size(166, 456);
			this.lstTopic.TabIndex = 0;
			this.lstTopic.SelectedIndexChanged += new System.EventHandler(this.lstTopic_SelectedIndexChanged);
			// 
			// lvwDetail
			// 
			this.lvwDetail.BackColor = System.Drawing.Color.WhiteSmoke;
			this.lvwDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lvwDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lvwDetail.ForeColor = System.Drawing.Color.Blue;
			this.lvwDetail.Location = new System.Drawing.Point(166, 0);
			this.lvwDetail.Name = "lvwDetail";
			this.lvwDetail.Size = new System.Drawing.Size(476, 462);
			this.lvwDetail.TabIndex = 1;
			this.lvwDetail.UseCompatibleStateImageBehavior = false;
			this.lvwDetail.View = System.Windows.Forms.View.Details;
			this.lvwDetail.DoubleClick += new System.EventHandler(this.lvwDetail_DoubleClick);
			this.lvwDetail.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwDetail_ColumnClick);
			// 
			// theProgress
			// 
			this.theProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.theProgress.Location = new System.Drawing.Point(12, 426);
			this.theProgress.Name = "theProgress";
			this.theProgress.Size = new System.Drawing.Size(618, 24);
			this.theProgress.TabIndex = 2;
			this.theProgress.Visible = false;
			// 
			// frmMovieStat
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(642, 462);
			this.Controls.Add(this.theProgress);
			this.Controls.Add(this.lvwDetail);
			this.Controls.Add(this.lstTopic);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmMovieStat";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = " Movies Statistic";
			this.Load += new System.EventHandler(this.frmMovieStat_Load);
			this.Shown += new System.EventHandler(this.frmMovieStat_Shown);
			this.Resize += new System.EventHandler(this.frmMovieStat_Resize);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTopic;
        private System.Windows.Forms.ListView lvwDetail;
        private System.Windows.Forms.ProgressBar theProgress;
    }
}