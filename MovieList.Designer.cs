namespace xDB2013
{
    partial class MovieList
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.TheStatus = new System.Windows.Forms.StatusStrip();
            this.statusTotalMovie = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDescription = new System.Windows.Forms.ToolStripStatusLabel();
            this.colCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCountry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colActress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TheStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colCountry,
            this.colRating,
            this.colType,
            this.colTitle,
            this.colActress,
            this.colTag});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(592, 397);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // TheStatus
            // 
            this.TheStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TheStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTotalMovie,
            this.statusDescription});
            this.TheStatus.Location = new System.Drawing.Point(0, 372);
            this.TheStatus.Name = "TheStatus";
            this.TheStatus.Size = new System.Drawing.Size(592, 25);
            this.TheStatus.TabIndex = 1;
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
            // MovieList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.TheStatus);
            this.Controls.Add(this.listView1);
            this.Name = "MovieList";
            this.Size = new System.Drawing.Size(592, 397);
            this.TheStatus.ResumeLayout(false);
            this.TheStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.StatusStrip TheStatus;
        private System.Windows.Forms.ToolStripStatusLabel statusTotalMovie;
        private System.Windows.Forms.ToolStripStatusLabel statusDescription;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colCountry;
        private System.Windows.Forms.ColumnHeader colRating;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colActress;
        private System.Windows.Forms.ColumnHeader colTag;

    }
}
