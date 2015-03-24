using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

using PTKSOFT.Utils2;
using ZiCure.Log;
using Newtonsoft.Json;

namespace xDB2013
{
    [Serializable]
    public class MovieFilter
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }
        public List<string> Type { get; set; }
        public List<int> Rating { get; set; }
        public List<string> Country { get; set; }
        public List<string> Actress { get; set; }
        public List<string> Tag { get; set; }
        public List<string> FileConnect { get; set; }
        public string MinCountPlay { get; set; }
        public string MaxCountPlay { get; set; }
        public string FilePath { get; set; }

        public bool IsEmptyCode { get; set; }
        public bool IsEmptyTitle { get; set; }
        public bool IsEmptyStory { get; set; }
        public bool IsNoFilePath { get; set; }
        public bool IsNoActress { get; set; }
        public bool IsNoTag { get; set; }

        public MovieFilter()
        {
            this.Code = "";
            this.Title = "";
            this.Story = "";
            this.Type = new List<string>();
            this.Rating = new List<int>();
            this.Country = new List<string>();
            this.Actress = new List<string>();
            this.Tag = new List<string>();
            this.FileConnect = new List<string>();
            this.MinCountPlay = "";
            this.MaxCountPlay = "";
            this.FilePath = "";

            this.IsEmptyCode = false;
            this.IsEmptyTitle = false;
            this.IsEmptyStory = false;
            this.IsNoFilePath = false;
            this.IsNoActress = false;
            this.IsNoTag = false;
        }

        public bool NeedCheckCode() 
        { 
            return (
                this.IsEmptyCode ||
                this.Code.Trim().Length > 0 
            );
        }
        public bool NeedCheckTitle()
        {
            return (
                this.IsEmptyTitle ||
                this.Title.Trim().Length > 0
            );
        }
        public bool NeedCheckStory() 
        {
            return(
                this.IsEmptyStory ||
                this.Story.Trim().Length > 0
            );
        }
        public bool NeedCheckType()
        {
            return (this.Type.Count > 0);
        }
        public bool NeedCheckRating()
        {
            return (this.Rating.Count > 0);
        }
        public bool NeedCheckCountry()
        {
            return (this.Country.Count > 0);
        }
        public bool NeedCheckActress() 
        { 
            return (
                this.IsNoActress ||
                this.Actress.Count > 0 
            ); 
        }
        public bool NeedCheckTag()
        {
            return (
                this.IsNoTag ||
                this.Tag.Count > 0 
            );
        }
        public bool NeedCheckFileConnect()
        {
            return (this.FileConnect.Count > 0);
        }
        public bool NeedCheckNoFilePath()
        {
            return (this.IsNoFilePath);
        }
        public bool NeedCheckCountPlay()
        {
            return ( this.MinCountPlay.Length > 0 || this.MaxCountPlay.Length > 0);
        }
        public bool NeedCheckFilePath()
        {
            return (this.FilePath.Length > 0);
        }
    }
}
