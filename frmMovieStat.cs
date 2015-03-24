using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using PTKSOFT.Utils2;
using ZiCure.Log;

namespace xDB2013
{
    public partial class frmMovieStat : Form
    {
        private bool IsReadyToRememberSize = false;
        private Hashtable hTopic = new Hashtable();
        private ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
        private ucMovieList movieList = null;
        private TabPage tabSearchResult = null;
        private string CurrentTopic = "";

        const string kwTotalMovieProfile = "0) total movie profile";
        const string kwLocalProfile = "1) -- local profile";
        const string kwFileOnLine = "1.1) --- file online";
        const string kwFileOffLine = "1.2) --- file offline";
        const string kwFileUnknow = "1.3) --- file unknow";
        const string kwGlobalProfile = "2) -- global profile";

        public frmMovieStat()
        {
            InitializeComponent();

            if (that.Config.Contains(KW.WinStatWidth)) this.Width = that.Config.GetInt(KW.WinStatWidth);
            if (that.Config.Contains(KW.WinStatHeight)) this.Height = that.Config.GetInt(KW.WinStatHeight);

            lvwDetail.ListViewItemSorter = lvwColumnSorter;
        }        
        
        private void frmMovieStat_Load(object sender, EventArgs e)
        {
        }
        private void frmMovieStat_Resize(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;
            if (!(this.WindowState == FormWindowState.Normal)) return;

            if (!IsReadyToRememberSize) return;
            that.Config[KW.WinStatWidth] = this.Width.ToString();
            that.Config[KW.WinStatHeight] = this.Height.ToString();
            that.Config.Save();
        }
        private void frmMovieStat_Shown(object sender, EventArgs e)
        {
            _InitStatTopic();

            // Everything OK
            IsReadyToRememberSize = true;
        }
        private void _InitStatTopic()
        {
            lstTopic.Items.Clear();
            string[] arrTopic = new string[] {
                "General",
                "Type",
                "Country",
                "Rating",
                "Actress",
                "Tag",
                "FilePath",
                "CountPlay",
            };
            for (int i = 0; i < arrTopic.Length; i++)
            {
                lstTopic.Items.Add(arrTopic[i]);
                hTopic[arrTopic[i]] = new ptkConfig();
            }
            lstTopic.Enabled = false;
            lstTopic.Visible = false;
            this.__RebuildStat();
            lstTopic.Visible = true;
            lstTopic.Enabled = true;
            lstTopic.Focus();
            lstTopic.SelectedIndex = 0;            
        }
        private void __RebuildStat()
        {
            ptkConfig statGeneral = (ptkConfig)hTopic["General"];
            {
                statGeneral[kwFileOffLine] = "0";
                statGeneral[kwFileOnLine] = "0";
                statGeneral[kwFileUnknow] = "0";
                statGeneral[kwGlobalProfile] = "0";
                statGeneral[kwLocalProfile] = "0";
                statGeneral[kwTotalMovieProfile] = "0";
            }
            ptkConfig statType = (ptkConfig)hTopic["Type"];
            ptkConfig statCountry = (ptkConfig)hTopic["Country"];
            ptkConfig statRating = (ptkConfig)hTopic["Rating"];
            ptkConfig statActress = (ptkConfig)hTopic["Actress"];
            ptkConfig statTag = (ptkConfig)hTopic["Tag"];
            ptkConfig statFilePath = (ptkConfig)hTopic["FilePath"];
            ptkConfig statCountPlay = (ptkConfig)hTopic["CountPlay"];

            theProgress.Visible = true;
            theProgress.Minimum = 0;
            theProgress.Value = 0;
            theProgress.Maximum = MovieDB.hMovie.Count;

            string[] arrK = new string[MovieDB.hMovie.Count];
            MovieDB.hMovie.Keys.CopyTo(arrK, 0);
            MovieProfile profile = null;
            for (int k = 0; k < arrK.Length; k++)
            {
                lock (MovieDB.hMovie.SyncRoot)
                {
                    if (!MovieDB.hMovie.Contains(arrK[k])) continue;
                    // Cloning profile for Safety in build state Process
                    profile = ptkGeneral.CloneObject<MovieProfile>((MovieProfile)MovieDB.hMovie[arrK[k]]);
                }

                ___CalculateStat_General(statGeneral, profile);
                ___CalculateStat_Type(statType, profile);
                ___CalculateStat_Country(statCountry, profile);
                ___CalculateStat_Rating(statRating, profile);
                ___CalculateStat_Actress(statActress, profile);
                ___CalculateStat_Tag(statTag, profile);
                ___CalculateStat_FilePath(statFilePath, profile);
                ___CalculateStat_CountPlay(statCountPlay, profile);

                profile = null;     // After finish Calculate stat Disponse cloning profile

                theProgress.Value++;
                this.Refresh();
            }

            theProgress.Visible = false;
        }
        private void ___CalculateStat_General(ptkConfig stat, MovieProfile profile)
        {
            stat[kwTotalMovieProfile] = (stat.GetInt(kwTotalMovieProfile) + 1).ToString();
            if (profile.FilePath.Length > 0)
            {
                stat[kwLocalProfile] = (stat.GetInt(kwLocalProfile) + 1).ToString();
                switch (profile.FileConnect)
                {
                    case "Y":
                        stat[kwFileOnLine] = (stat.GetInt(kwFileOnLine) + 1).ToString();
                        break;
                    case "N":
                        stat[kwFileOffLine] = (stat.GetInt(kwFileOffLine) + 1).ToString();
                        break;
                    case "?":
                        stat[kwFileUnknow] = (stat.GetInt(kwFileUnknow) + 1).ToString();
                        break;
                }
            }
            else
            {
                stat[kwGlobalProfile] = (stat.GetInt(kwGlobalProfile) + 1).ToString();
            }
        }
        private void ___CalculateStat_Type(ptkConfig stat, MovieProfile profile)
        {
            string cType = profile.Type;
            stat[cType] = (stat.GetInt(cType) + 1).ToString();
        }
        private void ___CalculateStat_Country(ptkConfig stat, MovieProfile profile)
        {
            string sCountry = profile.Country;
            stat[sCountry] = (stat.GetInt(sCountry) + 1).ToString();
        }
        private void ___CalculateStat_Rating(ptkConfig stat, MovieProfile profile)
        {
            string cRating = "+" + profile.Rating.ToString();
            stat[cRating] = (stat.GetInt(cRating) + 1).ToString();
        }
        private void ___CalculateStat_Actress(ptkConfig stat, MovieProfile profile)
        {
            if (profile.Actress.Length.Equals(0)) return;

            string[] arrActress = profile.Actress.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrActress.Length; i++)
                stat[arrActress[i]] = (stat.GetInt(arrActress[i]) + 1).ToString();
        }
        private void ___CalculateStat_Tag(ptkConfig stat, MovieProfile profile)
        {
            if (profile.Tag.Length.Equals(0)) return;

            string[] arrTag = profile.Tag.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrTag.Length; i++)
                stat[arrTag[i]] = (stat.GetInt(arrTag[i]) + 1).ToString();
        }
        private void ___CalculateStat_FilePath(ptkConfig stat, MovieProfile profile)
        {
            if (profile.FilePath.Length.Equals(0)) return;

            string strPath = Path.GetDirectoryName(profile.FilePath);
            stat[strPath] = (stat.GetInt(strPath) + 1).ToString();
        }
        private void ___CalculateStat_CountPlay(ptkConfig stat, MovieProfile profile)
        {
            string sCount = profile.CountPlay.ToString();
            stat[sCount] = (stat.GetInt(sCount) + 1).ToString();
        }
        
        private void lvwDetail_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            lvwDetail.Sort();
        }
        
        private void lstTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!this.Enabled) return;
            if (!lstTopic.Visible) return;
            if (!lstTopic.Enabled) return;

            string topic = (string)lstTopic.Items[lstTopic.SelectedIndex];
            that.DebugAndLog("Begin show data stat on topic = " + topic);
            DoShowDetailByTopic(topic);
            CurrentTopic = topic;
        }
        private void DoShowDetailByTopic(string topic)
        {
            lvwDetail.SuspendLayout();
            //------------------------

            _ClearDetailList(topic);
            if (!hTopic.Contains(topic))
            {
                that.DebugAndLog("Not found topic [" + topic + "] in hTopic !!!");
                return;
            }
            ptkConfig stat = (ptkConfig)hTopic[topic];

            string[] arrK = new string[stat.Keys.Count];
            foreach (string k in stat.Keys)
            {
                string stat_value = stat[k].PadLeft(12, ' ');
                lvwDetail.Items.Add(new ListViewItem(new string[] { k, stat_value }));
            }
            for (int i = 0; i < lvwDetail.Columns.Count; i++)
            {
                lvwDetail.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                if (lvwDetail.Columns[i].Width < int.Parse((string)lvwDetail.Columns[i].Tag))
                    lvwDetail.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            lvwColumnSorter.SortColumn = -1;
            lvwDetail_ColumnClick(lvwDetail, new ColumnClickEventArgs(0));
            
            //------------------------
            lvwDetail.ResumeLayout();
        }
        private void _ClearDetailList(string topic)
        {            
            lvwDetail.Clear();
            lvwDetail.View = View.Details;
            lvwDetail.GridLines = true;
            lvwDetail.FullRowSelect = true;
            
            lvwDetail.Columns.Clear();
            lvwDetail.Columns.Add(topic, 100, HorizontalAlignment.Left);
            lvwDetail.Columns.Add("Total Profile", 100, HorizontalAlignment.Right);
            lvwDetail.Columns.Add(" ");
            for (int i = 0; i < lvwDetail.Columns.Count; i++)
            {
                lvwDetail.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
                lvwDetail.Columns[i].Tag = lvwDetail.Columns[i].Width.ToString();
            }
        }

        private void lvwDetail_DoubleClick(object sender, EventArgs e)
        {
            if (CurrentTopic == "") return;
            if (lvwDetail.SelectedItems.Count < 1) return;
            if (lvwDetail.SelectedItems.Count > 1) return;
            
            DoSearchMovieByDetail();
        }        
        private void DoSearchMovieByDetail()
        {
            that.DebugAndLog("Do SearchMovieByTopic: [" + CurrentTopic + "] Detail: [" + lvwDetail.SelectedItems[0].Text + "]");
            
            MovieFilter mFilter = new MovieFilter();
            string KeyWord1 = lvwDetail.SelectedItems[0].Text;
            string KeyWord2 = lvwDetail.SelectedItems[0].SubItems[0].Text;

            switch (CurrentTopic)
            {
                case "General":
                    switch (KeyWord1.ToLower())
                    {
                        case kwTotalMovieProfile:               // No Filter
                                break;
                        case kwLocalProfile:                    // Have FilePath!
                                mFilter.FileConnect.Add("Y"); 
                                mFilter.FileConnect.Add("N"); 
                                break;
                        case kwFileOnLine:                      // File Can Acess
                                mFilter.FileConnect.Add("Y"); 
                                break;
                        case kwFileOffLine:                     // File Cannot Access
                                mFilter.FileConnect.Add("N");
                                break;
                        case kwFileUnknow:                      // New Add File Unknow Status
                                mFilter.FileConnect.Add("?");
                                break;
                        case kwGlobalProfile:                   // No FilePath! So GlobalProfile
                                mFilter.FileConnect.Add("G");
                                break;
                        default:
                                that.DebugAndLog("Nothing Math for KeyWord1=[" + KeyWord1 + "]");
                                break;
                    }
                    break;

                case "Type": mFilter.Type.Add(KeyWord1);    break;
                case "Country": mFilter.Country.Add(KeyWord1); break;
                case "Rating": mFilter.Rating.Add(int.Parse(KeyWord1)); break;
                case "Actress": mFilter.Actress.Add(KeyWord1); break;
                case "Tag": mFilter.Tag.Add(KeyWord1); break;
                case "FilePath": mFilter.FilePath = KeyWord1; break;
                case "CountPlay": mFilter.MinCountPlay = mFilter.MaxCountPlay = KeyWord1; break;

                // --------- Unknow What TOPIC???
                default:            
                    return;
            }
            _DoApplySearchResult(mFilter);
        }
        private void _DoApplySearchResult(MovieFilter filter)
        {
            that.DebugAndLog("frmMovieStat -> DoApplySearchResult()");
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
                + ((filter.NeedCheckCountPlay()) ? ("CountPlay, ") : (""))
                + ((filter.NeedCheckFilePath()) ? ("FilePath, ") : (""))
                ;

            __RefreshSearchResult(movieList, descMovie);
        }
        private void __RefreshSearchResult(List<MovieProfile> listResult, string descMovie)
        {
            // Build new moview result tab is Difference Topic
            if (movieList != null)
            {
                if (!movieList.Visible)
                {
                    movieList = null;
                }
                else
                {
                    if (movieList.Tag != null)
                    {
                        if (!movieList.Tag.ToString().Equals(CurrentTopic))
                            movieList = null;
                    }
                    else
                    {
                        movieList.Tag = CurrentTopic;
                    }
                }
            }

            // Build Result in form Main & New TAB
            if (movieList == null)
            {
                movieList = new ucMovieList();
                movieList.Dock = DockStyle.Fill;
                movieList.Location = new Point(0, 0);
                movieList.OnDoubleClickMovieList += new WhenDoubleClickMovieList(that.movieList_OnDoubleClickMovieList);
                movieList.OnKeyUpMovieList += new WhenKeyUpMovieList(that.movieList_OnKeyUpMovieList);

                movieList.Tag = CurrentTopic;

                tabSearchResult = new TabPage();
                tabSearchResult.Tag = new string[] { "search_result", "Search Result" };
                tabSearchResult.Controls.Add(movieList);

                FRM.Main.tabMain.TabPages.Add(tabSearchResult);
                FRM.Main.tabMain.SelectedTab = tabSearchResult;
                FRM.Main.generateTabFunctionKey();
            }

            // Action !!!
            movieList.RefreshMovieList(listResult, descMovie);
        }
        
    }
}
