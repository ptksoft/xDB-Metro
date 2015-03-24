using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace xDB2013
{
    public delegate void WhenDoubleClickMovieList(object sender, EventArgs s);
    public delegate void WhenKeyUpMovieList(object sender, KeyEventArgs e);

    public partial class ucMovieList : UserControl
    {        
        public event WhenDoubleClickMovieList OnDoubleClickMovieList;
        public event WhenKeyUpMovieList OnKeyUpMovieList;

        private ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();

        public ucMovieList()
        {
            InitializeComponent();            
            TheList.ListViewItemSorter = lvwColumnSorter;
        }
        public void RefreshMovieList(List<MovieProfile> listMovie, string descMovie)
        {
            TheList.BeginUpdate();
            _ClearMovieList();
            for (int i = 0; i < TheList.Columns.Count; i++) TheList.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            TheList.EndUpdate();
            this.Refresh();
            for (int i = 0; i < TheList.Columns.Count; i++) TheList.Columns[i].Tag = TheList.Columns[i].Width;

            TheList.BeginUpdate();
            for (int i = 0; i < listMovie.Count; i++) _PutMovieProfileToList(listMovie[i]);
            TheList.Columns["colFileconnect"].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            TheList.Columns["colCode"].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            TheList.Columns["colCountry"].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            TheList.Columns["colRating"].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            TheList.Columns["colType"].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            TheList.Columns["colTitle"].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            TheList.Columns["colActress"].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            TheList.Columns["colTag"].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            
            // ReSize ColumnHeaderAgain with Check Header & Content
            for (int i = 0; i < TheList.Columns.Count; i++)
                if (((int)TheList.Columns[i].Tag) > TheList.Columns[i].Width)
                    TheList.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

            TheList.EndUpdate();
            TheStatus.Items[0].Text = "Total " + listMovie.Count.ToString("#,0") + " profile(s)";
            TheStatus.Items[1].Text = descMovie;
            this.Refresh();
        }
        private void _ClearMovieList()
        {
            TheList.Items.Clear();
            TheList.Columns.Clear();
            TheList.Columns.Add("colFileConnect", " ");
            TheList.Columns.Add("colCode", "Code");
                TheList.Columns["colCode"].TextAlign = HorizontalAlignment.Left;
            TheList.Columns.Add("colCountry", "Country");
                TheList.Columns["colCountry"].TextAlign = HorizontalAlignment.Center;
            TheList.Columns.Add("colRating", "Rating");
                TheList.Columns["colRating"].TextAlign = HorizontalAlignment.Center;
            TheList.Columns.Add("colType", "Type");
                TheList.Columns["colType"].TextAlign = HorizontalAlignment.Center;
            TheList.Columns.Add("colTitle", "Title");
            TheList.Columns.Add("colActress", "Actress");
            TheList.Columns.Add("colTag", "Tag");
        }
        public void _PutMovieProfileToList(MovieProfile mProfile)
        {
            ListViewItem lvi = new ListViewItem(new string[] {
                mProfile.FileConnect,
                mProfile.Code,
                mProfile.Country,
                "+" + mProfile.Rating.ToString(),
                mProfile.Type,
                mProfile.Title,
                mProfile.Actress,
                mProfile.Tag
            });
            lvi.Tag = mProfile;
            TheList.Items.Add(lvi);
        }
        public void _UpdateMovieProfileInList(MovieProfile mProfile)
        {
            ListViewItem lvi = new ListViewItem(new string[] {
                mProfile.FileConnect,
                mProfile.Code,
                mProfile.Country,
                "+" + mProfile.Rating.ToString(),
                mProfile.Type,
                mProfile.Title,
                mProfile.Actress,
                mProfile.Tag
            });
            lvi.Tag = mProfile;
            for (int i = 0; i < TheList.Items.Count; i++)
            {
                if (TheList.Items[i].Tag == mProfile)
                {
                    TheList.BeginUpdate();
                    TheList.Items[i] = lvi;
                    TheList.EndUpdate();
                    break;
                }
            }
        }

        /* forward Event call */
        private void TheList_DoubleClick(object sender, EventArgs e)
        {
            // Forward event to parent
            this.OnDoubleClickMovieList(sender, e);
        }
        private void TheList_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUpMovieList(sender, e);
        }
        private void TheList_ColumnClick(object sender, ColumnClickEventArgs e)
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
            TheList.Sort();
        }

    }
    class ListViewColumnSorter : IComparer
    {
        private int ColumnToSort;
        private SortOrder OrderOfSort;
        private CaseInsensitiveComparer ObjectCompare;
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }

}
