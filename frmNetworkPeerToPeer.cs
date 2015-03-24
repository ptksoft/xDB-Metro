using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xDB2013
{
    public partial class frmNetworkPeerToPeer : Form
    {
        public frmNetworkPeerToPeer()
        {
            InitializeComponent();
        }
        private void frmNetworkPeerToPeer_Load(object sender, EventArgs e)
        {

        }
        private void frmNetworkPeerToPeer_Shown(object sender, EventArgs e)
        {
            RefreshPeerProfile();
        }
        private void RefreshPeerProfile()
        {
            lvwPeerProfile.SuspendLayout();

            lvwPeerProfile.GridLines = true;
            lvwPeerProfile.Columns.Clear();
            lvwPeerProfile.Columns.Add("colHost", "Host Name", 50);
            lvwPeerProfile.Columns.Add("colIpAddress", "IP Address", 50);
            lvwPeerProfile.Columns.Add("colVersion", "Software Version", 50);
            lvwPeerProfile.Columns.Add("colTotalMovieProfile", "Total Movie Profile", 50);
            lvwPeerProfile.Columns.Add("colRemark", "Remark", 50);

            string[] k = new string[P2P.hPeerProfile.Keys.Count];
            P2P.hPeerProfile.Keys.CopyTo(k, 0);
            PeerProfile pp = null;
            for (int i = 0; i < k.Length; i++)
            {
                string PeerID = k[i];
                lock (P2P.hPeerProfile.SyncRoot)
                {
                    if (P2P.hPeerProfile.Contains(PeerID))
                        pp = (PeerProfile)P2P.hPeerProfile[PeerID];
                    else
                        continue;
                }
                ListViewItem itm = new ListViewItem(new string[] {
                    pp.HostName,
                    pp.IpAddress,
                    pp.Version,
                    pp.TotalProfile.ToString(),
                    ""
                });
                lvwPeerProfile.Items.Add(itm);
            }

            lvwPeerProfile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvwPeerProfile.ResumeLayout();
        }
    }
}
