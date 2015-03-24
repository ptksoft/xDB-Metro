using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using PTKSOFT.Utils2;
using ZiCure.Log;
using Newtonsoft.Json;

namespace xDB2013
{
    public partial class frmSearch : Form
    {
        private bool isReadyToRememberSize = false;
        private ucMovieList movieList = null;
        private TabPage tabSearchResult = null;
        private List<string> _listActress = new List<string>();
        private List<string> _listTag = new List<string>();
        private int _idxActress = -1;
        private int _idxTag = -1;

        public frmSearch()
        {
            InitializeComponent();


            // Prepare last save Size
            if (that.Config.Contains(KW.WinSearchWidth))
                this.Width = that.Config.GetInt(KW.WinSearchWidth);
            if (that.Config.Contains(KW.WinSearchHeight))
                this.Height = that.Config.GetInt(KW.WinSearchHeight);
        }
        private void frmSearch_Load(object sender, EventArgs e)
        {
            _InitSelectionValue();
        }
        private void _InitSelectionValue()
        {
            // Rating List
            checkListRating.Items.Clear();
            for (int i = 0; i < MovieProfile.ListRating.Count; i++)
                checkListRating.Items.Add(MovieProfile.ListRating[i]);

            // Country List
            checkListCountry.Items.Clear();
            for (int i = 0; i < MovieProfile.ListCountry.Count; i++) 
                checkListCountry.Items.Add(MovieProfile.ListCountry[i]);

            // Actress List
            checkListActress.Items.Clear();
            for (int i=0; i < MovieProfile.ListActress.Count; i++)
                checkListActress.Items.Add(MovieProfile.ListActress[i]);

            // Tag List
            checkListTag.Items.Clear();
            for (int i = 0; i < MovieProfile.ListTag.Count; i++)
                checkListTag.Items.Add(MovieProfile.ListTag[i]);
        }
        private void frmSearch_Shown(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 0;
            txtCode.Focus();

            // Ready to Remember Size
            isReadyToRememberSize = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;
            _ResetSearchCondition();
        }
        private void _ResetSearchCondition()
        {
            txtCode.Text = "";
            txtTitle.Text = "";
            txtStory.Text = "";
            txtMinCountPlay.Text = "";
            txtMaxCountPlay.Text = "";
            for (int i = 0; i < checkListType.Items.Count; i++)
                checkListType.SetItemChecked(i, false);
            for (int i = 0; i < checkListRating.Items.Count; i++)
                checkListRating.SetItemChecked(i, false);
            for (int i = 0; i < checkListCountry.Items.Count; i++)
                checkListCountry.SetItemChecked(i, false);
            for (int i = 0; i < checkListActress.Items.Count; i++)
                checkListActress.SetItemChecked(i, false);
            for (int i = 0; i < checkListTag.Items.Count; i++)
                checkListTag.SetItemChecked(i, false);
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!btnApply.Enabled) return;
            btnApply.Enabled = false;
            DoApplySearchResult();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!btnOK.Visible) return;
            if (!btnOK.Enabled) return;

            if (btnApply.Enabled) 
                btnApply_Click(sender, e);
            
            btnClose_Click(sender, e);
        }        
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!btnClose.Visible) return;
            if (!btnClose.Enabled) return;

            this.Hide();
            this.Close();
            this.Dispose();
        }
        private void btnSaveFilter_Click(object sender, EventArgs e)
        {
            if (!btnSaveFilter.Visible) return;
            if (!btnSaveFilter.Enabled) return;

            if (DoSaveSearchFilter()) 
                btnSaveFilter.Enabled = false;
        }

        private void frmSearch_Resize(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;
            if (this.WindowState != FormWindowState.Normal) return;
            if (!this.isReadyToRememberSize) return;

            that.Config[KW.WinSearchHeight] = this.Height.ToString();
            that.Config[KW.WinSearchWidth] = this.Width.ToString();
            that.Config.Save();
        }
        private void frmSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;

            _CheckFunctionKeyAndActive(sender, e);
        }
        private void _CheckFunctionKeyAndActive(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:       // Select Tab General
                    {
                        tabMain.SelectedIndex = 0;
                        break;
                    }
                case Keys.F2:       // Select Tab Actress
                    {
                        tabMain.SelectedIndex = 1;
                        break;
                    }
                case Keys.F3:       // Select Tab Tag
                    {
                        tabMain.SelectedIndex = 2;
                        break;
                    }
                case Keys.F4:       // Reset all condition
                    {
                        btnReset_Click(sender, new EventArgs());
                        break;
                    }
                case Keys.F5:       // Apply Conditon
                    {
                        btnApply_Click(sender, new EventArgs());
                        break;
                    }
                case Keys.F9:       // Apply Condtion and Close
                    {
                        btnOK_Click(sender, new EventArgs());
                        break;
                    }
            }
        }

        private bool DoSaveSearchFilter()
        {
            that.DebugAndLog("frmSearch -> DoSaveSearchFilter()");
            MovieFilter filter = _BuildMovieFilter();
            string nameFilter = that.GetNewOrReplaceFilterName();
            if (nameFilter.Length < 1) return (false);

            that.Filter[nameFilter] = JsonConvert.SerializeObject(filter);
            return (that.Filter.Save());
        }
        private void DoApplySearchResult()
        {
            that.DebugAndLog("frmSearch -> DoApplySearchResult()");
            MovieFilter filter = _BuildMovieFilter();
            List<MovieProfile> movieList = MovieDB.GetMovieList(filter);
            that.DebugAndLog("Total movie got from MovieDB = " + movieList.Count.ToString());

            string descMovie = "Filter: "
                + ((filter.NeedCheckCode()) ? ("Code, ") : (""))
                + ((filter.NeedCheckTitle()) ? ("Title, ") : (""))
                + ((filter.NeedCheckStory()) ? ("Story, ") : (""))
                + ((filter.NeedCheckType()) ? ("Type, ") : (""))
                + ((filter.NeedCheckRating()) ? ("Rating, ") : (""))
                + ((filter.NeedCheckCountry()) ? ("Country, ") : (""))
                + ((filter.NeedCheckFileConnect()) ? ("FileConnect, ") : (""))
                + ((filter.NeedCheckActress()) ? ("Actress, ") : (""))
                + ((filter.NeedCheckTag()) ? ("Tag, ") : (""))
                + ((filter.NeedCheckCountPlay()) ? ("CountPlay, "):(""))
                + ((filter.NeedCheckFilePath()) ? ("FilePath, ") : (""))
                ;

            _RefreshSearchResult(movieList, descMovie);
        }        
        private MovieFilter _BuildMovieFilter()
        {
            MovieFilter filter = new MovieFilter();
            
            // CODE
            filter.IsEmptyCode = chkCodeEmpty.Checked;
            if (!filter.IsEmptyCode) filter.Code = txtCode.Text.Trim().ToUpper();

            // TITLE
            filter.IsEmptyTitle = chkTitleEmpty.Checked;
            if (!filter.IsEmptyTitle) filter.Title = txtTitle.Text.Trim();

            // STORY
            filter.IsEmptyStory = chkStoryEmpty.Checked;
            if (!filter.IsEmptyStory) filter.Story = txtStory.Text.Trim();

            // TYPE
            filter.Type = new List<string>();
            foreach (object obj in checkListType.CheckedItems)
                filter.Type.Add((string)obj);

            // RATING
            filter.Rating = new List<int>();
            foreach (object obj in checkListRating.CheckedItems)
                filter.Rating.Add(int.Parse((string)obj));

            // COUNTRY            
            filter.Country = new List<string>();
            foreach (object obj in checkListCountry.CheckedItems)
                filter.Country.Add((string)obj);

            // ACTRESS
            filter.Actress = new List<string>();
            filter.IsNoActress = (chkNoActress.Checked);
            if (!filter.IsNoActress)
            {
                foreach (object obj in checkListActress.CheckedItems)
                    filter.Actress.Add((string)obj);
            }

            // TAG
            filter.Tag = new List<string>();
            filter.IsNoTag = (chkNoTag.Checked);
            if (!filter.IsNoTag)
            {
                foreach (object obj in checkListTag.CheckedItems)
                    filter.Tag.Add((string)obj);
            }

            // FileConnect
            filter.FileConnect = new List<string>();
            foreach (object obj in checkListFileConnect.CheckedItems)
                filter.FileConnect.Add((string)obj);

            // NoFilePath
            filter.IsNoFilePath = chkNoFilePath.Checked;

            // CountPlay
            if (txtMinCountPlay.Text.Trim().Length > 0)
            {
                try
                {
                    long minPlay = long.Parse(txtMinCountPlay.Text);
                    if (minPlay >= 0) filter.MinCountPlay = minPlay.ToString();
                }
                catch { filter.MinCountPlay = ""; }
            }
            if (txtMaxCountPlay.Text.Trim().Length > 0)
            {
                try
                {
                    long maxPlay = long.Parse(txtMaxCountPlay.Text);
                    if (maxPlay >= 0) filter.MaxCountPlay = maxPlay.ToString();
                }
                catch { filter.MaxCountPlay = ""; }
            }
            
            // FilePath
            if (txtFilePath.Text.Trim().Length > 0)
                filter.FilePath = txtFilePath.Text.Trim();
                

            /////// Everything OK /////////////
            return (filter);
        }
        private void _RefreshSearchResult(List<MovieProfile> listResult, string descMovie)
        {
            if (movieList == null)
            {
                movieList = new ucMovieList();
                movieList.Dock = DockStyle.Fill;
                movieList.Location = new Point(0, 0);
                movieList.OnDoubleClickMovieList += new WhenDoubleClickMovieList(that.movieList_OnDoubleClickMovieList);
                movieList.OnKeyUpMovieList += new WhenKeyUpMovieList(that.movieList_OnKeyUpMovieList);

                tabSearchResult = new TabPage();
                tabSearchResult.Tag = new string[] { "search_result", "Search Result" };
                tabSearchResult.Controls.Add(movieList);

                FRM.Main.tabMain.TabPages.Add(tabSearchResult);
                FRM.Main.tabMain.SelectedTab = tabSearchResult;
                FRM.Main.generateTabFunctionKey();
            }
            movieList.RefreshMovieList(listResult, descMovie);
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabMain.SelectedIndex)
            {
                case 0:
                    {
                        txtCode.Focus();
                        txtCode.SelectAll();
                        break;
                    }
                case 1:
                    {
                        txtActress.Focus();
                        txtActress.SelectAll();
                        break;
                    }
                case 2:
                    {
                        txtTag.Focus();
                        txtTag.SelectAll();
                        break;
                    }
            }
        }

        private void chkCodeEmpty_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void chkTitleEmpty_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void chkStoryEmpty_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void chkNoFilePath_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void chkNoActress_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void chkNoTag_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void txtStory_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void checkListType_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void checkListRating_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void checkListCountry_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void checkListFileConnect_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void checkListActress_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void checkListTag_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void txtMinCountPlay_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void txtMaxCountPlay_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }
        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
            btnSaveFilter.Enabled = true;
        }        

        private void txtCode_Enter(object sender, EventArgs e)
        {
            txtCode.SelectAll();
        }
        private void txtTitle_Enter(object sender, EventArgs e)
        {
            txtTitle.SelectAll();
        }
        private void txtStory_Enter(object sender, EventArgs e)
        {
            txtStory.SelectAll();
        }
        private void txtMinCountPlay_Enter(object sender, EventArgs e)
        {
            txtMinCountPlay.SelectAll();
        }
        private void txtMaxCountPlay_Enter(object sender, EventArgs e)
        {
            txtMaxCountPlay.SelectAll();
        }
        private void txtFilePath_Enter(object sender, EventArgs e)
        {
            txtFilePath.SelectAll();
        }
        private void txtActress_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _DoCheck(txtActress, ref checkListActress);
            }
            else if (e.KeyCode == Keys.Down)
            {
                _DoSuggess(1, ref _listActress, ref _idxActress, txtActress, checkListActress, true);
            }
            else if (e.KeyCode == Keys.Up)
            {
                _DoSuggess(-1, ref _listActress, ref _idxActress, txtActress, checkListActress, true);
            }
            else
            {
                _listActress.Clear();
            }
        }
        private void txtTag_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _DoCheck(txtTag, ref checkListTag);
            }
            else if (e.KeyCode == Keys.Down)
            {
                _DoSuggess(1, ref _listTag, ref _idxTag, txtTag, checkListTag, false);
            }
            else if (e.KeyCode == Keys.Up)
            {
                _DoSuggess(-1, ref _listTag, ref _idxTag, txtTag, checkListTag, false);
            }
            else
            {
                _listTag.Clear();
            }

        }

        private void _DoCheck(TextBox txtNewItem, ref CheckedListBox listItem)
        {
            int countCheck = 0;
            for (int i = 0; i < listItem.Items.Count; i++)
            {
                if (((string)listItem.Items[i]).Equals(txtNewItem.Text.Trim()))
                {
                    listItem.SetItemChecked(i, true);
                    countCheck++;
                }
            }
            if (countCheck > 0)
            {
                txtNewItem.Text = "";
            }
            else
            {
                txtNewItem.SelectAll();
            }
        }
        private void _DoSuggess(
            int iDirection, ref List<string> _listSuggest,
            ref int _idxSuggest, TextBox txtNewItem,
            CheckedListBox listItem,
            bool isUpper
        )
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
                string keyword = 
                                (isUpper) ? 
                                (txtNewItem.Text.Trim().ToUpper()) : 
                                (txtNewItem.Text.Trim().ToLower());
                if (keyword.Length.Equals(0)) return;
                for (int i = 0; i < listItem.Items.Count; i++)
                {
                    if (((string)listItem.Items[i]).Contains(keyword))
                        _listSuggest.Add((string)listItem.Items[i]);
                }
                _idxSuggest = 0;
            }

            if (_listSuggest.Count > 0)
            {
                txtNewItem.Text = _listSuggest[_idxSuggest];
                txtNewItem.SelectAll();
            }
        }        
        
    }
}
