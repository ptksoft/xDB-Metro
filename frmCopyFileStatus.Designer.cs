namespace xDB2013
{
	partial class frmCopyFileStatus
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopyFileStatus));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFrom = new System.Windows.Forms.TextBox();
			this.txtTo = new System.Windows.Forms.TextBox();
			this.pgBar = new System.Windows.Forms.ProgressBar();
			this.label3 = new System.Windows.Forms.Label();
			this.lblTotalCopies = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "From";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(27, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "To";
			// 
			// txtFrom
			// 
			this.txtFrom.ForeColor = System.Drawing.Color.Blue;
			this.txtFrom.Location = new System.Drawing.Point(64, 15);
			this.txtFrom.Name = "txtFrom";
			this.txtFrom.Size = new System.Drawing.Size(457, 26);
			this.txtFrom.TabIndex = 2;
			this.txtFrom.Text = "Source File";
			// 
			// txtTo
			// 
			this.txtTo.ForeColor = System.Drawing.Color.Green;
			this.txtTo.Location = new System.Drawing.Point(64, 46);
			this.txtTo.Name = "txtTo";
			this.txtTo.Size = new System.Drawing.Size(457, 26);
			this.txtTo.TabIndex = 3;
			this.txtTo.Text = "Source File";
			// 
			// pgBar
			// 
			this.pgBar.Location = new System.Drawing.Point(16, 117);
			this.pgBar.Name = "pgBar";
			this.pgBar.Size = new System.Drawing.Size(505, 26);
			this.pgBar.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(126, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "Total File Copies";
			// 
			// lblTotalCopies
			// 
			this.lblTotalCopies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.lblTotalCopies.Location = new System.Drawing.Point(359, 94);
			this.lblTotalCopies.Name = "lblTotalCopies";
			this.lblTotalCopies.Size = new System.Drawing.Size(162, 20);
			this.lblTotalCopies.TabIndex = 6;
			this.lblTotalCopies.Text = "0/0";
			this.lblTotalCopies.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(415, 157);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(106, 34);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tmrUpdate
			// 
			this.tmrUpdate.Enabled = true;
			this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
			// 
			// frmCopyFileStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(533, 205);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblTotalCopies);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pgBar);
			this.Controls.Add(this.txtTo);
			this.Controls.Add(this.txtFrom);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "frmCopyFileStatus";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Copy File Status";
			this.Shown += new System.EventHandler(this.frmCopyFileStatus_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFrom;
		private System.Windows.Forms.TextBox txtTo;
		private System.Windows.Forms.ProgressBar pgBar;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblTotalCopies;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Timer tmrUpdate;
	}
}