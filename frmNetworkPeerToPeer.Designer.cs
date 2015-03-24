namespace xDB2013
{
    partial class frmNetworkPeerToPeer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNetworkPeerToPeer));
            this.lvwPeerProfile = new System.Windows.Forms.ListView();
            this.colHostName = new System.Windows.Forms.ColumnHeader();
            this.colIpAddress = new System.Windows.Forms.ColumnHeader();
            this.colVersion = new System.Windows.Forms.ColumnHeader();
            this.colMovieProfile = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwPeerProfile
            // 
            this.lvwPeerProfile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvwPeerProfile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwPeerProfile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHostName,
            this.colIpAddress,
            this.colVersion,
            this.colMovieProfile});
            this.lvwPeerProfile.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvwPeerProfile.ForeColor = System.Drawing.Color.Blue;
            this.lvwPeerProfile.Location = new System.Drawing.Point(0, 0);
            this.lvwPeerProfile.Name = "lvwPeerProfile";
            this.lvwPeerProfile.Size = new System.Drawing.Size(459, 430);
            this.lvwPeerProfile.TabIndex = 0;
            this.lvwPeerProfile.UseCompatibleStateImageBehavior = false;
            this.lvwPeerProfile.View = System.Windows.Forms.View.Details;
            // 
            // colHostName
            // 
            this.colHostName.Text = "Host Name";
            // 
            // colIpAddress
            // 
            this.colIpAddress.Text = "IP Address";
            // 
            // colVersion
            // 
            this.colVersion.Text = "Version";
            // 
            // colMovieProfile
            // 
            this.colMovieProfile.Text = "Movie Profile";
            // 
            // frmNetworkPeerToPeer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 430);
            this.Controls.Add(this.lvwPeerProfile);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNetworkPeerToPeer";
            this.Text = " Network Peer To Peer";
            this.Load += new System.EventHandler(this.frmNetworkPeerToPeer_Load);
            this.Shown += new System.EventHandler(this.frmNetworkPeerToPeer_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwPeerProfile;
        private System.Windows.Forms.ColumnHeader colHostName;
        private System.Windows.Forms.ColumnHeader colIpAddress;
        private System.Windows.Forms.ColumnHeader colVersion;
        private System.Windows.Forms.ColumnHeader colMovieProfile;
    }
}