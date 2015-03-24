using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PTKSOFT.Utils2;
using ZiCure.Log;
using Newtonsoft.Json;

namespace xDB2013
{
    public partial class frmManageFilter : Form
    {
        public bool param_IsModeSelect = true;
        public string return_FilterName = "";

        public frmManageFilter()
        {
            InitializeComponent();
            txtNewFilter.Text = "";
        }       
        private void frmManageFilter_Shown(object sender, EventArgs e)
        {
            lstFilter.Items.Clear();
            foreach (string k in that.Filter.Keys)
            {
                if (k == KW.CreatedTime) continue;
                MovieFilter itemFilter = null;
                try
                {
                    itemFilter = JsonConvert.DeserializeObject<MovieFilter>(that.Filter[k]);
                }
                catch {
                    itemFilter = null;
                }
                if (itemFilter != null)
                {
                    lstFilter.Items.Add(k);
                }
            }
            if (param_IsModeSelect)
            {
                btnAdd.Text = "Select";
                that.DebugAndLog("frmManageFilter open in mode SELECT");
                txtNewFilter.Focus();
            }
            else
            {
                btnAdd.Text = "Rename";
                that.DebugAndLog("frmManageFilter open in mode MANAGE");
                lstFilter.Focus();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;

            DoAddOrRename();
        }
        private void DoAddOrRename()
        {
            string nameFilter = txtNewFilter.Text.Trim().Replace("=", "");
            if (nameFilter.Length > 0)
            {
                return_FilterName = nameFilter;
                if (param_IsModeSelect)
                {   // Mode Selection
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {   // Mode Manage
                    if (lstFilter.SelectedIndex >= 0)
                    {
                        string old_key = (string)lstFilter.Items[lstFilter.SelectedIndex];
                        that.Filter[nameFilter] = that.Filter[old_key];
                        that.Filter.Remove(old_key);
                        that.Filter.Save();
                        lstFilter.Items[lstFilter.SelectedIndex] = nameFilter;
                        txtNewFilter.Text = "";
                        txtNewFilter.Focus();
                        FRM.Main.RefreshFilterList();
                        that.DebugAndLog("frmManageFilter->Rename(" + old_key + ") -> (" + nameFilter + ")");
                    }
                    else
                    {
                        MessageBox.Show("Please select item in List to be RENAME?");
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid FilterName !");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!btnRemove.Visible) return;
            if (!btnRemove.Enabled) return;

            DoRemoveFilter();
        }
        private void DoRemoveFilter()
        {
            if (lstFilter.Items.Count < 1) return;
            if (lstFilter.SelectedIndex < 0) return;
            string filter2Remove = (string)lstFilter.Items[lstFilter.SelectedIndex];
            that.Filter.Remove(filter2Remove);
            that.Filter.Save();
            lstFilter.Items.RemoveAt(lstFilter.SelectedIndex);
            FRM.Main.RefreshFilterList();
            that.DebugAndLog("frmManageFilter->RemoveFilter(" + filter2Remove + ") Success");
        }

        private void lstFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFilter.Items.Count < 1) return;
            if (lstFilter.SelectedIndex < 0) return;

            txtNewFilter.Text = (string)lstFilter.Items[lstFilter.SelectedIndex];
            txtNewFilter.SelectAll();
            txtNewFilter.Focus();
        }
        private void txtNewFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(sender, new EventArgs());
            }
        }
        private void txtNewFilter_TextChanged(object sender, EventArgs e)
        {
            if (param_IsModeSelect)
            {
                btnAdd.Enabled = (txtNewFilter.Text.Trim().Length > 0);
            }
            else
            {
                btnAdd.Enabled =
                    (txtNewFilter.Text.Trim().Length > 0) &&
                    (lstFilter.SelectedIndex >= 0);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!btnClose.Visible) return;
            if (!btnClose.Enabled) return;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }        
    }
}
