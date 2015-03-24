using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xDB2013
{
    public partial class frmSelectOrAddList : Form
    {
        public List<string> paramList = null;
        public List<string> selectList = new List<string>();
        private bool _ReadyToSaveSize = false;

        private int _idxSuggest = -1;
        private List<string> _listSuggest = new List<string>();

        public frmSelectOrAddList()
        {
            InitializeComponent();
            _ReadyToSaveSize = false;
        }
        private void frmSelectOrAddList_Load(object sender, EventArgs e)
        {
            _ReadyToSaveSize = false;
        }        
        private void frmSelectOrAddList_Resize(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;
            if (!this._ReadyToSaveSize) return;
            if (this.WindowState != FormWindowState.Normal) return;            

            that.Config[KW.WinSelectWidth] = this.Width.ToString();
            that.Config[KW.WinSelectHeight] = this.Height.ToString();
            that.Config.Save();
        }
        private void frmSelectOrAddList_Shown(object sender, EventArgs e)
        {
            if (paramList == null) return;

            // Prepare last windows Size if possible
            if (that.Config.Contains(KW.WinSelectWidth))
                this.Width = that.Config.GetInt(KW.WinSelectWidth);
            if (that.Config.Contains(KW.WinSelectHeight))
                this.Height = that.Config.GetInt(KW.WinSelectHeight);
            _ReadyToSaveSize = true;

            // Prepare Item to choose
            lvwMain.Items.Clear();
            for (int i = 0; i < paramList.Count; i++)
            {
                lvwMain.Items.Add(paramList[i]);
            }

            txtNewItem.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!btnOK.Visible) return;
            if (!btnOK.Enabled) return;

            for (int i = 0; i < lvwMain.Items.Count; i++)
            {
                if (lvwMain.Items[i].Checked)
                    selectList.Add(lvwMain.Items[i].Text);
            }
            if (_listSuggest.Count > 0 && _idxSuggest > -1 && txtNewItem.Text.Length > 0)
                selectList.Add(txtNewItem.Text.Trim());

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        private void btnAddSelectItem_Click(object sender, EventArgs e)
        {
            string newItem = txtNewItem.Text.Trim();
            if (newItem.Length.Equals(0)) return;
            if (!paramList.Contains(newItem))
            {
                paramList.Add(newItem);
                lvwMain.Items.Insert(0, newItem);
            }
            for (int i = 0; i < lvwMain.Items.Count; i++)
            {
                if (lvwMain.Items[i].Text == newItem)
                {
                    lvwMain.Items[i].Checked = true;
                    break;
                }
            }
            _listSuggest.Clear();
            _idxSuggest = -1;
            txtNewItem.Text = "";
            txtNewItem.Focus();
        }
        private void txtNewItem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!btnAddSelectItem.Enabled) return;
                btnAddSelectItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Down)
            {
                _DoSuggess(1);
            }
            else if (e.KeyCode == Keys.Up)
            {
                _DoSuggess(-1);
            }
            else
            {
                _listSuggest.Clear();
            }
        }
        private void _DoSuggess(int iDirection)
        {
            if (_listSuggest.Count > 0) // Already have suggest List
            {                
                _idxSuggest += iDirection;
                if (_idxSuggest >= _listSuggest.Count)
                {
                    _idxSuggest = _listSuggest.Count - 1;
                }
                else if (_idxSuggest < 0)
                {
                    _idxSuggest = 0;
                }
            }
            else
            {
                string keyword = txtNewItem.Text.Trim().ToUpper();
                if (keyword.Length.Equals(0)) return;
                for (int i = 0; i < lvwMain.Items.Count; i++)
                {
                    if (lvwMain.Items[i].Text.ToUpper().Contains(keyword))
                        _listSuggest.Add(lvwMain.Items[i].Text);
                }
                _idxSuggest = 0;
            }

            if (_listSuggest.Count > 0)
            {
                txtNewItem.Text = _listSuggest[_idxSuggest];
                txtNewItem.SelectAll();
            }
        }

        private void frmSelectOrAddList_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;

            _DoProcessIfFunctionKey(sender, e);
        }
        private void _DoProcessIfFunctionKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    txtNewItem.Focus();
                    txtNewItem.SelectAll();
                    break;
                case Keys.F2:
                    btnAddSelectItem_Click(sender, new EventArgs());
                    break;
                case Keys.F9:
                    btnOK_Click(sender, new EventArgs());
                    break;
            }
        }

    }
}
