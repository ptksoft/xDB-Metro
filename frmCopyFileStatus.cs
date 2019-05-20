using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace xDB2013
{
	public partial class frmCopyFileStatus : Form
	{
		public string pathToWrite;
		public List<MovieProfile> listMovie;
		protected bool isCancelRequest = false;
		protected int curNum = -1;
		protected Thread tCopy = null;
		
		public frmCopyFileStatus()
		{
			InitializeComponent();
		}		
		private void frmCopyFileStatus_Shown(object sender, EventArgs e)
		{
			pgBar.Maximum = listMovie.Count;
			pgBar.Value = 0;			
		}
		private void tmrUpdate_Tick(object sender, EventArgs e)
		{
			tmrUpdate.Enabled = false;
			if (isCancelRequest) {
				this.Close();
				return;
			}

			if (tCopy != null) {
				if (tCopy.IsAlive) {
					tmrUpdate.Enabled = true;
					return;
				}
				else tCopy = null;
			}
			
			if (curNum < listMovie.Count) {
				curNum++;
				if (curNum >= listMovie.Count)
				{					
					pgBar.Value = pgBar.Maximum;
					lblTotalCopies.Text = curNum.ToString() + " / " + listMovie.Count.ToString();
					btnCancel.Text = "Close";
					this.Refresh();
					tmrUpdate.Enabled = true;
					that.DebugAndLog("Finish Copy ALL moview File ***");
					return;
				}
			}
			else {
				if (isCancelRequest) {
					this.Close();
					return;
				}
				tmrUpdate.Enabled = true;
				return;
			}

			MovieProfile profile = (MovieProfile)listMovie[curNum];
			string filePath2Copy = profile.FilePath;
			string filePath2Write = pathToWrite + Path.DirectorySeparatorChar + Path.GetFileName(filePath2Copy);
			txtFrom.Text = filePath2Copy;
			txtTo.Text = filePath2Write;
			pgBar.Value = curNum + 1;
			lblTotalCopies.Text = curNum.ToString() + " / " + listMovie.Count.ToString();
			this.Refresh();
			
			tCopy = new Thread(new ThreadStart(() => {
			if (File.Exists(filePath2Copy))
			{
				try
				{
					that.DebugAndLog("Begin Copy RealFileInDisk [" + filePath2Copy + "] => [" + filePath2Write + "]");
					File.Copy(filePath2Copy, filePath2Write);
					that.DebugAndLog("... Finish Copy");
				}
				catch (Exception ex)
				{
					that.DebugAndLog("... ! Error in Copy, " + ex.Message);
				}
			}
			else
			{
				that.DebugAndLog("File Not Found [" + filePath2Copy + "] then SKIP !");
			}
			}));
			tCopy.IsBackground = true;
			tCopy.Start();

			tmrUpdate.Enabled = true;
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			btnCancel.Enabled = false;
			isCancelRequest = true;
		}		
	}
}
