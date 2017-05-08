namespace xDB2013
{
    partial class ucMovieList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.TheStatus = new System.Windows.Forms.StatusStrip();
			this.statusTotalMovie = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusDescription = new System.Windows.Forms.ToolStripStatusLabel();
			this.TheList = new System.Windows.Forms.ListView();
			this.colFileConnect = new System.Windows.Forms.ColumnHeader();
			this.colCode = new System.Windows.Forms.ColumnHeader();
			this.colCountry = new System.Windows.Forms.ColumnHeader();
			this.colRating = new System.Windows.Forms.ColumnHeader();
			this.colType = new System.Windows.Forms.ColumnHeader();
			this.colTitle = new System.Windows.Forms.ColumnHeader();
			this.colActress = new System.Windows.Forms.ColumnHeader();
			this.colTag = new System.Windows.Forms.ColumnHeader();
			this.TheStatus.SuspendLayout();
			this.SuspendLayout();
			// 
			// TheStatus
			// 
			this.TheStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TheStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTotalMovie,
            this.statusDescription});
			this.TheStatus.Location = new System.Drawing.Point(0, 300);
			this.TheStatus.Name = "TheStatus";
			this.TheStatus.Size = new System.Drawing.Size(372, 25);
			this.TheStatus.TabIndex = 3;
			this.TheStatus.Text = "statusStrip1";
			// 
			// statusTotalMovie
			// 
			this.statusTotalMovie.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
			this.statusTotalMovie.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
			this.statusTotalMovie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.statusTotalMovie.Name = "statusTotalMovie";
			this.statusTotalMovie.Size = new System.Drawing.Size(98, 20);
			this.statusTotalMovie.Text = "Total xx Movie";
			// 
			// statusDescription
			// 
			this.statusDescription.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
			this.statusDescription.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.statusDescription.Name = "statusDescription";
			this.statusDescription.Size = new System.Drawing.Size(76, 20);
			this.statusDescription.Text = "Description";
			// 
			// TheList
			// 
			this.TheList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TheList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileConnect,
            this.colCode,
            this.colCountry,
            this.colRating,
            this.colType,
            this.colTitle,
            this.colActress,
            this.colTag});
			this.TheList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TheList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.TheList.FullRowSelect = true;
			this.TheList.GridLines = true;
			this.TheList.Location = new System.Drawing.Point(0, 0);
			this.TheList.MultiSelect = false;
			this.TheList.Name = "TheList";
			this.TheList.Size = new System.Drawing.Size(372, 325);
			this.TheList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.TheList.TabIndex = 2;
			this.TheList.UseCompatibleStateImageBehavior = false;
			this.TheList.View = System.Windows.Forms.View.Details;
			this.TheList.DoubleClick += new System.EventHandler(this.TheList_DoubleClick);
			this.TheList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.TheList_ColumnClick);
			this.TheList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TheList_KeyUp);
			// 
			// colFileConnect
			// 
			this.colFileConnect.Text = "C";
			this.colFileConnect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colFileConnect.Width = 23;
			// 
			// colCode
			// 
			this.colCode.Text = "Code";
			// 
			// colCountry
			// 
			this.colCountry.Text = "Country";
			this.colCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// colRating
			// 
			this.colRating.Text = "Rating";
			this.colRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// colType
			// 
			this.colType.Text = "Type";
			this.colType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.colType.Width = 50;
			// 
			// colTitle
			// 
			this.colTitle.Text = "Title";
			this.colTitle.Width = 100;
			// 
			// colActress
			// 
			this.colActress.Text = "Actress";
			this.colActress.Width = 80;
			// 
			// colTag
			// 
			this.colTag.Text = "Tag";
			// 
			// ucMovieList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TheStatus);
			this.Controls.Add(this.TheList);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "ucMovieList";
			this.Size = new System.Drawing.Size(372, 325);
			this.TheStatus.ResumeLayout(false);
			this.TheStatus.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip TheStatus;
        private System.Windows.Forms.ToolStripStatusLabel statusTotalMovie;
        private System.Windows.Forms.ToolStripStatusLabel statusDescription;
        private System.Windows.Forms.ListView TheList;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colCountry;
        private System.Windows.Forms.ColumnHeader colRating;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colActress;
        private System.Windows.Forms.ColumnHeader colTag;
        private System.Windows.Forms.ColumnHeader colFileConnect;
    }
}
