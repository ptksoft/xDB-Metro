using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using PTKSOFT.Utils2;
using ZiCure.Log;
using Newtonsoft.Json;

namespace xDB2013
{
	public partial class frmProfileViewer : Form
	{
		public MovieProfile param_MovieProfile = null;
		public ucMovieList param_MovieList = null;
		
		private bool isEnableSavePosition = true;
		
		public frmProfileViewer()
		{
			InitializeComponent();
		}

		private void frmProfileViewer_Load(object sender, EventArgs e)
		{
			tabMain.TabPages.Remove(tabFrontCover);
			tabMain.TabPages.Remove(tabBackCover);
			tabMain.TabPages.Remove(tabScreenShot1);
			tabMain.TabPages.Remove(tabScreenShot2);

			_Do_LoadPositionOfWindows();
		}
		private void frmProfileViewer_ResizeEnd(object sender, EventArgs e)
		{
			if (this == null) return;
			if (!this.Visible) return;
			if (!this.Enabled) return;
			if (this.WindowState != FormWindowState.Normal) return;

			_Do_SavePositionOfWindows();
		}
		private void _Do_SavePositionOfWindows()
		{
			if (this.WindowState != FormWindowState.Normal) return;
			if (!this.isEnableSavePosition) return;

			that.Config[KW.ViewerLeft] = this.Left.ToString();
			that.Config[KW.ViewerTop] = this.Top.ToString();
			that.Config[KW.ViewerWidth] = this.Width.ToString();
			that.Config[KW.ViewerHeight] = this.Height.ToString();

			that.Config.Save();
		}
		private void _Do_LoadPositionOfWindows()
		{
			//-- Load Width & Height if value is reasonable
			if (
				(that.Config.GetInt(KW.ViewerWidth) > 400) &&
				(that.Config.GetInt(KW.ViewerHeight) > 200)
			)
			{
				this.Width = that.Config.GetInt(KW.ViewerWidth);
				this.Height = that.Config.GetInt(KW.ViewerHeight);
			}

			this.Left = that.Config.GetInt(KW.ViewerLeft);
			this.Top = that.Config.GetInt(KW.ViewerTop);
		}
		
		private void frmProfileViewer_Shown(object sender, EventArgs e)
		{
			zLog.Write(
				"Form ProfileViewer Shown: Movie->FilePath("
				+ param_MovieProfile.FilePath
				+ ") Hash={"
				+ param_MovieProfile.Hash + "}");
			
			btnPrevious.Visible = (null != param_MovieList);
			btnNext.Visible = (null != param_MovieList);
			
			refreshDataFromParam();
			RefreshTabMovieImage(0);
		}

		private void refreshDataFromParam()
		{
			if (param_MovieProfile == null) return;
			
			this.Text = 
				"[" + param_MovieProfile.Type.ToUpper() + "][" + 
				param_MovieProfile.Country.ToUpper() + "][+" +
				param_MovieProfile.Rating.ToString() + "]";
			string[] p = param_MovieProfile.FilePath.Split(new string[] {"\\"}, StringSplitOptions.RemoveEmptyEntries);
			if (p.Length > 0) {
				p[p.Length-1] = "";
				this.Text += "[" + string.Join("\\", p) + "]";
			}
			
			lblCode.Text = param_MovieProfile.Code;
			lblTitle.Text = param_MovieProfile.Title;


			flowActress.Controls.Clear();
			string[] arrActress = param_MovieProfile.Actress.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < arrActress.Length; i++) {
				Label lbl = new Label();
				lbl.BorderStyle = BorderStyle.FixedSingle;
				lbl.AutoSize = true;
				lbl.Text = arrActress[i];						
				flowActress.Controls.Add(lbl);
			}

			flowTag.Controls.Clear();
			string[] arrTag = param_MovieProfile.Tag.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < arrTag.Length; i++) {
				Label lbl = new Label();
				lbl.BorderStyle = BorderStyle.FixedSingle;
				lbl.AutoSize = true;
				lbl.Text = arrTag[i];
				flowTag.Controls.Add(lbl);
			}

			param_MovieProfile.CheckFileConnect();
			btnPlay.Visible = param_MovieProfile.FileConnect.Equals("Y");
		}
		private void RefreshTabMovieImage(int idx)
		{
			if (idx == 1 || idx == 0)
				_Do_LoadImageAndDisplayTab(
					MovieDB.GetFilePath_MovieImage_FrontCover(this.param_MovieProfile),
					tabFrontCover);

			if (idx == 2 || idx == 0)
				_Do_LoadImageAndDisplayTab(
					MovieDB.GetFilePath_MovieImage_BackCover(this.param_MovieProfile),
					tabBackCover);

			if (idx == 3 || idx == 0)
				_Do_LoadImageAndDisplayTab(
					MovieDB.GetFilePath_MovieImage_ScreenShot1(this.param_MovieProfile),
					tabScreenShot1);

			if (idx == 4 || idx == 0)
				_Do_LoadImageAndDisplayTab(
					MovieDB.GetFilePath_MovieImage_ScreenShot2(this.param_MovieProfile),
					tabScreenShot2);
		}
		private void _Do_LoadImageAndDisplayTab(string fileImg, TabPage tab)
		{
			if (fileImg.Length < 1) return;

			// Remove any control in tab if tab is alread add to tabMain.Tabpages
			if (tabMain.TabPages.Contains(tab))
			{
				foreach (Control ctl in tab.Controls)
					tab.Controls.Remove(ctl);
			}
			else
			{
				tabMain.TabPages.Add(tab);
			}

			// Create new picture box to load Image into tab
			tab.Tag = fileImg;
			PictureBox pcb = new PictureBox();
			pcb.Parent = tab;
			pcb.Dock = DockStyle.Fill;
			pcb.SizeMode = PictureBoxSizeMode.Zoom;
			pcb.Load(fileImg);
		}				
		
		private void frmProfileViewer_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) {
				this.Close();
				this.Dispose();
			}
			else if (e.KeyCode == Keys.Space) {
				_Do_PlayMovie();
			}
		}
		private void _Do_PlayMovie()
		{
			param_MovieProfile.CheckFileConnect();
			if (!param_MovieProfile.FileConnect.Equals("Y"))
			{
				that.DebugAndLog("Movie: {" + param_MovieProfile.Hash + "} is not connecting");
				that.DebugAndLog("File: " + param_MovieProfile.FilePath + " is not existing");
				MessageBox.Show("This file is not Connecting to System", "File !Connect", MessageBoxButtons.OK);
				return;
			}

			// Update Last Played time
			param_MovieProfile.ViewTime = DateTime.Now;

			// Start shell process file for run media with your favorite player
			System.Diagnostics.Process.Start(param_MovieProfile.FilePath);
			param_MovieProfile.CountPlay++;

			// Update Count Play if NOT FirstImport
			string hKey = param_MovieProfile.Hash;
			if (hKey.Length.Equals(32)) {
				MovieDB.SaveMovieProfile(param_MovieProfile);
				zLog.Write("Save CountPlay to MovieProfile {" + hKey + "}");
			}			
		}

		private void btnPlay_Click(object sender, EventArgs e)
		{
			if (! btnPlay.Visible) return;
			_Do_PlayMovie();
		}
		private void btnPrevious_Click(object sender, EventArgs e)
		{
			if (! btnPrevious.Visible) return;
			if (null == param_MovieList) return;
			MovieProfile mp = param_MovieList.GetPreviousMovie();
			if (null==mp) return;
			param_MovieProfile = mp;
			_Refresh_param_MovieProfile();
		}
		private void btnNext_Click(object sender, EventArgs e)
		{
			if (!btnNext.Visible) return;
			if (null == param_MovieList) return;
			MovieProfile mp = param_MovieList.GetNextMovie();
			if (null==mp) return;
			param_MovieProfile = mp;
			_Refresh_param_MovieProfile();
		}
		private void _Refresh_param_MovieProfile() {
			tabMain.TabPages.Remove(tabFrontCover);
			tabMain.TabPages.Remove(tabBackCover);
			tabMain.TabPages.Remove(tabScreenShot1);
			tabMain.TabPages.Remove(tabScreenShot2);
			zLog.Write(
				"Form ProfileViewer Refresh_param_MovieProfile: Movie->FilePath("
				+ param_MovieProfile.FilePath
				+ ") Hash={"
				+ param_MovieProfile.Hash + "}");

			refreshDataFromParam();
			RefreshTabMovieImage(0);
		
		}
		
	}
}
