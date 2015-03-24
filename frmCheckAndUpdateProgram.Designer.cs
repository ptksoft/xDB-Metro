namespace xDB2013
{
    partial class frmCheckAndUpdateProgram
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
            this.pgbarCheckVersion = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDownloadNew = new System.Windows.Forms.Label();
            this.pgbarDownloadLastVersion = new System.Windows.Forms.ProgressBar();
            this.tmrCheckVersion = new System.Windows.Forms.Timer(this.components);
            this.tmrDownloadVersion = new System.Windows.Forms.Timer(this.components);
            this.bgworkCheckVersion = new System.ComponentModel.BackgroundWorker();
            this.bgworkDownloadLastVersion = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // pgbarCheckVersion
            // 
            this.pgbarCheckVersion.Location = new System.Drawing.Point(33, 52);
            this.pgbarCheckVersion.Margin = new System.Windows.Forms.Padding(4);
            this.pgbarCheckVersion.Maximum = 50;
            this.pgbarCheckVersion.Name = "pgbarCheckVersion";
            this.pgbarCheckVersion.Size = new System.Drawing.Size(464, 21);
            this.pgbarCheckVersion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Check Version On Server";
            // 
            // lblDownloadNew
            // 
            this.lblDownloadNew.AutoSize = true;
            this.lblDownloadNew.Location = new System.Drawing.Point(30, 104);
            this.lblDownloadNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDownloadNew.Name = "lblDownloadNew";
            this.lblDownloadNew.Size = new System.Drawing.Size(162, 16);
            this.lblDownloadNew.TabIndex = 1;
            this.lblDownloadNew.Text = "Download Lasted Version";
            // 
            // pgbarDownloadLastVersion
            // 
            this.pgbarDownloadLastVersion.Location = new System.Drawing.Point(33, 124);
            this.pgbarDownloadLastVersion.Margin = new System.Windows.Forms.Padding(4);
            this.pgbarDownloadLastVersion.Name = "pgbarDownloadLastVersion";
            this.pgbarDownloadLastVersion.Size = new System.Drawing.Size(464, 21);
            this.pgbarDownloadLastVersion.TabIndex = 0;
            // 
            // tmrCheckVersion
            // 
            this.tmrCheckVersion.Interval = 50;
            this.tmrCheckVersion.Tick += new System.EventHandler(this.tmrCheckVersion_Tick);
            // 
            // tmrDownloadVersion
            // 
            this.tmrDownloadVersion.Interval = 200;
            this.tmrDownloadVersion.Tick += new System.EventHandler(this.tmrDownloadVersion_Tick);
            // 
            // bgworkCheckVersion
            // 
            this.bgworkCheckVersion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkCheckVersion_DoWork);
            // 
            // bgworkDownloadLastVersion
            // 
            this.bgworkDownloadLastVersion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkDownloadLastVersion_DoWork);
            // 
            // frmCheckAndUpdateProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 196);
            this.ControlBox = false;
            this.Controls.Add(this.lblDownloadNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pgbarDownloadLastVersion);
            this.Controls.Add(this.pgbarCheckVersion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCheckAndUpdateProgram";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check and Update Program";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.frmCheckAndUpdateProgram_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbarCheckVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDownloadNew;
        private System.Windows.Forms.ProgressBar pgbarDownloadLastVersion;
        private System.Windows.Forms.Timer tmrCheckVersion;
        private System.Windows.Forms.Timer tmrDownloadVersion;
        private System.ComponentModel.BackgroundWorker bgworkCheckVersion;
        private System.ComponentModel.BackgroundWorker bgworkDownloadLastVersion;
    }
}