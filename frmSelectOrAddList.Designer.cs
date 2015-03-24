namespace xDB2013
{
    partial class frmSelectOrAddList
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lvwMain = new System.Windows.Forms.ListView();
            this.txtNewItem = new System.Windows.Forms.TextBox();
            this.btnAddSelectItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(220, 268);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(99, 268);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 36);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "F9 - OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lvwMain
            // 
            this.lvwMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMain.BackColor = System.Drawing.Color.White;
            this.lvwMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwMain.CheckBoxes = true;
            this.lvwMain.ForeColor = System.Drawing.Color.Blue;
            this.lvwMain.FullRowSelect = true;
            this.lvwMain.GridLines = true;
            this.lvwMain.HideSelection = false;
            this.lvwMain.Location = new System.Drawing.Point(13, 68);
            this.lvwMain.MultiSelect = false;
            this.lvwMain.Name = "lvwMain";
            this.lvwMain.Size = new System.Drawing.Size(330, 181);
            this.lvwMain.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwMain.TabIndex = 2;
            this.lvwMain.UseCompatibleStateImageBehavior = false;
            this.lvwMain.View = System.Windows.Forms.View.List;
            // 
            // txtNewItem
            // 
            this.txtNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewItem.ForeColor = System.Drawing.Color.Blue;
            this.txtNewItem.Location = new System.Drawing.Point(46, 21);
            this.txtNewItem.Name = "txtNewItem";
            this.txtNewItem.Size = new System.Drawing.Size(166, 23);
            this.txtNewItem.TabIndex = 0;
            this.txtNewItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNewItem_KeyUp);
            // 
            // btnAddSelectItem
            // 
            this.btnAddSelectItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSelectItem.Location = new System.Drawing.Point(220, 15);
            this.btnAddSelectItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSelectItem.Name = "btnAddSelectItem";
            this.btnAddSelectItem.Size = new System.Drawing.Size(122, 32);
            this.btnAddSelectItem.TabIndex = 1;
            this.btnAddSelectItem.Text = "F2 - Add New";
            this.btnAddSelectItem.UseVisualStyleBackColor = true;
            this.btnAddSelectItem.Click += new System.EventHandler(this.btnAddSelectItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "F1 -";
            // 
            // frmSelectOrAddList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(355, 317);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddSelectItem);
            this.Controls.Add(this.txtNewItem);
            this.Controls.Add(this.lvwMain);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSelectOrAddList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " SELECT or ADD iTems";
            this.Load += new System.EventHandler(this.frmSelectOrAddList_Load);
            this.Shown += new System.EventHandler(this.frmSelectOrAddList_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmSelectOrAddList_KeyUp);
            this.Resize += new System.EventHandler(this.frmSelectOrAddList_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView lvwMain;
        private System.Windows.Forms.TextBox txtNewItem;
        private System.Windows.Forms.Button btnAddSelectItem;
        private System.Windows.Forms.Label label1;
    }
}