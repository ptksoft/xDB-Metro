using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

using PTKSOFT.Utils2;
using ZiCure.Log;

namespace xDB2013
{
    /* Template for Convert to/from JSON */
    [Serializable]
    public class _MovieProfile  
    {
        public string Country { get; set; }
        public int Rating { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string[] Actress { get; set; }
        public string[] Tag { get; set; }
        public string Hash { get; set; }
        public string CreatedTime { get; set; }
        public string ModifiedTime { get; set; }
        public string ViewTime { get; set; }
        public string[] FilePath { get; set; }
        public long FileSize { get; set; }
        public string Story { get; set; }
        public string CountPlay { get; set; }
    }

    /*  Real Object that use in Memory/DB   */
    [Serializable]
    public class MovieProfile
    {
        public static List<string> ListCountry = new List<string> {
            /* See avaliable country here http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2 */
            "JP",  // Japan
            "TH",  // ThaiLand
            "CN",  // China
            "US",  // United State
            "KR",  // Korea South & North
            "UK",  // English
            "IN",  // India
            "FR",  // France                        
            "ID",  // Indonesia            
            "__",  // Unknow Country
        };
        public static List<string> ListType = new List<string> { 
            "X",    // Really fucking, uncensor, Cansee COCK & PUSSY :O
            "C",    // Really fucking, but censor :(
            "R",    // Acting as fucking T__T
        };
        public static List<string> ListRating = new List<string>
        {
            "0","1","2","3","4","5",    // Rating Score
        };
        public static List<string> ListCharInFileName = new List<string>
        {
            "+",    // Rating +1 .. +5
            "!",    // Type R, C, X
            "(", ")",   // Code
            "$",        // Title
            "{", "}",   // Actress
            "[", "]",   // Tag
            "=",        // Hash
        };
        public static List<string> ListFileConnect = new List<string>
        {
            "Y",    // Physical File is Online can access on current System
            "N",    // Physical File is Offline cannot access
            "G",    // Global Profile no local path Data
            "?",    // Unknow Status
        };
        public static List<string> ListActress = new List<string>();    // Global List Actress, collect from MovieDB
        public static List<string> ListTag = new List<string>();        // Global List Tag, collect from MovieDB
        public static bool isValidFileName(string filePath)
        {
            string FileNameOnly = Path.GetFileNameWithoutExtension(filePath);
            if (FileNameOnly.Length < 1) return (false);
            string[] charInFile = MovieProfile.ListCharInFileName.ToArray();
            for (int i = 0; i < charInFile.Length; i++)
            {
                string C1 = charInFile[i];
                if (C1 == "$")
                {   // Special Case "$" have two begin/end
                    string[] parts = FileNameOnly.Split(new string[] { C1 }, StringSplitOptions.None);
                    if (parts.Length != 3) return (false);  // Must have two char and separate as 3 Parts
                }
                else
                {
                    // Normal Case, Check must Only 1 existing
                    if (FileNameOnly.IndexOf(C1) < 0)
                        return (false);
                    if (
                        FileNameOnly.IndexOf(C1) !=
                        FileNameOnly.LastIndexOf(C1)
                    )
                        return (false);
                }
            }
            // Everything is OK
            return (true);
        }
        
        /* Zone of Private Variable */
        protected string _Country = "__";
        protected int _Rating = 0;
        protected string _Type = "U";
        protected string _Code = "";
        protected string _Title = "";
        protected List<string> _Actress = new List<string>();
        protected List<string> _Tag = new List<string>();
        protected string _Hash = "";
        protected DateTime _CreatedTime = DateTime.MinValue;
        protected DateTime _ModifiedTime = DateTime.MinValue;
        protected DateTime _ViewTime = DateTime.MinValue;
        protected Stack<string> _FilePath = new Stack<string>();
        protected long _FileSize = 0;        
        protected string _Story = "";

        protected string _FileConnect = "?";
        protected long _CountPlay = 0;

        /* Zone of Public Properties */
        public string Country
        {
            get { return (_Country); }
            set {
                if (value.Trim().Length != 2) return;
                string dumyCN = value.Trim().ToUpper();
                if (!MovieProfile.ListCountry.Contains(dumyCN)) return;
                _Country = dumyCN;
                _ModifiedTime = DateTime.Now;
            }
        }
        public int Rating
        {
            get { return (_Rating); }
            set {
                if (value < 0) _Rating = 0;
                    else if (value > 5) _Rating = 5;
                        else _Rating = value;
                _ModifiedTime = DateTime.Now;
            }
        }
        public string Type
        {
            get { return (_Type); }
            set {
                if (value.Trim().Length != 1) return;
                string T = value.Trim().ToUpper();
                if (MovieProfile.ListType.Contains(T)) _Type = T;
                _ModifiedTime = DateTime.Now;
            }
        }
        public string Code
        {
            get { return (_Code); }
            set {
                _Code = this._RemoveInvalidChar(value.Trim().ToUpper());
                _ModifiedTime = DateTime.Now;
            }
        }
        public string Title
        {
            get { return (_Title); }
            set {
                _Title = this._RemoveInvalidChar(value.Trim());
                _ModifiedTime = DateTime.Now;
            }
        }
        public string Actress
        {
            get
            {
                if (_Actress.Count < 1) return ("");
                return (string.Join(",", _Actress.ToArray()));
            }
        }
        public string Tag
        {
            get
            {
                if (_Tag.Count < 1) return ("");
                return (string.Join(",", _Tag.ToArray()));
            }
        }
        public string Hash
        {
            get { return (_Hash); }
            set
            {
                if (
                    value.Trim().Length == 32 ||
                    value.Trim().Length == 0
                    )
                {
                    _Hash = value.Trim().ToLower();
                    _ModifiedTime = DateTime.Now;
                }
            }
        }
        public DateTime CreatedTime
        {
            get { return (_CreatedTime); }
            set { _CreatedTime = value; }
        }
        public DateTime ModifiedTime
        {
            get { return (_ModifiedTime); }
            set { _ModifiedTime = value; }
        }
        public DateTime ViewTime
        {
            get { return (_ViewTime); }
            set { _ViewTime = value; }
        }
        public string FilePath
        {
            get {
                if (_FilePath.Count < 1) return ("");
                return (_FilePath.Peek());
            }
            set
            {
                if (value == "")    // User Wanna Remove
                {
                    if (_FilePath.Count > 0)
                    {
                        string file2Remove = _FilePath.Pop();
                        that.DebugAndLog("Remove Path=" + file2Remove + " From MovieProfile{" + _Hash + "}");
                    }
                    return;
                }

                if (_FilePath.Contains(value))
                {
                    Stack<string> bufferStack = new Stack<string>();
                    while (_FilePath.Count > 0) 
                        if (!_FilePath.Peek().Equals(value))
                            bufferStack.Push(_FilePath.Pop());
                    while (bufferStack.Count > 0) 
                        _FilePath.Push(bufferStack.Pop());
                    // Add this value to TOP
                    _FilePath.Push(value);
                    _ModifiedTime = DateTime.Now;
                    that.DebugAndLog("Update Path=" + value + " To MovieProfile{" + _Hash + "}");
                }
                else
                {
                    _FilePath.Push(value);
                    _ModifiedTime = DateTime.Now;
                    that.DebugAndLog("Add Path=" + value + " To MovieProfile{" + _Hash + "}");
                }
            }
        }
        public long FileSize { 
            get { return (_FileSize); } 
            set { if (value > 0) _FileSize = value; } 
        }
        public string Story
        {
            get { return (_Story); }
            set { 
                _Story = value.Trim();
                _ModifiedTime = DateTime.Now;
            }
        }
        public string FileConnect
        {
            get { return (_FileConnect); }
            set {
                value = value.Trim().ToUpper();
                if (value.Length < 1) return;
                if (!MovieProfile.ListFileConnect.Contains(value)) return;
                _FileConnect = value;
            }
        }
        public long CountPlay
        {
            get { return (_CountPlay); }
            set
            {
                if (value >= 0) _CountPlay = value;
                else _CountPlay = 0;
            }
        }

        /* Zone Public Method */
        public void AddActress(string Actress)
        {
            string newActress = this._RemoveInvalidChar(Actress.Trim().ToUpper());
            if (newActress.Length < 1) return;
            if (_Actress.Contains(newActress)) return;
            _Actress.Add(newActress);
            
            // Collecting for GlobalList
            if (!MovieProfile.ListActress.Contains(newActress)) 
                MovieProfile.ListActress.Add(newActress);
        }
        public void AddTag(string Tag)
        {
            string newTag = this._RemoveInvalidChar(Tag.Trim().ToLower());
            if (newTag.Length < 1) return;
            if (_Tag.Contains(newTag)) return;
            _Tag.Add(newTag);

            // Collect for Global TAG list
            if (!MovieProfile.ListTag.Contains(newTag))
                MovieProfile.ListTag.Add(newTag);
        }
        public void RemoveActress(string Actress)
        {
            string newActress = this._RemoveInvalidChar(Actress.Trim().ToUpper());
            if (newActress.Length < 1) return;
            if (!_Actress.Contains(newActress)) return;
            _Actress.Remove(newActress);
        }
        public void RemoveTag(string Tag)
        {
            string newTag = this._RemoveInvalidChar(Tag.Trim().ToLower());
            if (newTag.Length < 1) return;
            if (!_Tag.Contains(newTag)) return;
            _Tag.Remove(newTag);
        }
        public void ClearActress() { _Actress.Clear(); }
        public void ClearTag() { _Tag.Clear(); }
        public bool RenameFileToAttribute() 
        {
            if (_FilePath.Count < 1)
            {
                that.DebugAndLog("RenameFileToAttribute()! Error _FilePath.Count < 1");
                return (false);
            }
            string curPath = _FilePath.Peek();
            if (!File.Exists(curPath))
            {
                that.DebugAndLog("RenameFileToAttribute()! curPath not Existing -> " + curPath);
                return (false);
            }

            string dirOld = Path.GetDirectoryName(curPath);
            string fileNameOld = Path.GetFileNameWithoutExtension(curPath);
            string extOld = Path.GetExtension(curPath);
            string fileNameNew = _BuildFileNameFromAttribute();
            if (fileNameOld == fileNameNew) return (true);

            string newPath = dirOld + Path.DirectorySeparatorChar + fileNameNew + extOld;

            that.DebugAndLog("Rename file " + curPath + " ==> " + newPath);
            try
            {
                File.Move(curPath, newPath);
                _FilePath.Pop();
                _FilePath.Push(newPath);
                return (true);
            }
            catch (Exception ex)
            {
                that.DebugAndLog("Exception Error: " + ex.Message);
                return (false);
            }
        }
        public _MovieProfile ExportProfile()
        {
            _MovieProfile clone = new _MovieProfile();

            clone.Country = _Country;
            clone.Rating = _Rating;
            clone.Type = _Type;
            clone.Code = _Code;
            clone.Title = _Title;
            clone.Actress = _Actress.ToArray();
            clone.Tag = _Tag.ToArray();
            clone.Hash = _Hash;
            clone.CreatedTime = ptkConvert.DateTimeToSqlFormat(_CreatedTime);
            clone.ModifiedTime = ptkConvert.DateTimeToSqlFormat(_ModifiedTime);
            clone.ViewTime = ptkConvert.DateTimeToSqlFormat(_ViewTime);
            clone.FilePath = _FilePath.ToArray();
            clone.FileSize = _FileSize;
            clone.Story = _Story;
            clone.CountPlay = _CountPlay.ToString();

            return (clone);
        }
        public bool ImportProfile(_MovieProfile clone)
        {
            if (null == clone) return (false);

            Country = clone.Country;
            Rating = clone.Rating;
            Type = clone.Type;
            Code = clone.Code;
            Title = clone.Title;

            _Actress.Clear();
            for (int i = 0; i < clone.Actress.Length; i++)
            {
                _Actress.Add(clone.Actress[i]);
                if (!MovieProfile.ListActress.Contains(clone.Actress[i]))
                    MovieProfile.ListActress.Add(clone.Actress[i]);
            }
                
            _Tag.Clear();
            for (int i = 0; i < clone.Tag.Length; i++)
            {
                _Tag.Add(clone.Tag[i]);
                if (!MovieProfile.ListTag.Contains(clone.Tag[i]))
                    MovieProfile.ListTag.Add(clone.Tag[i]);
            }

            Hash = clone.Hash;
            if (! Hash.Length.Equals(32)) return (false);

            _CreatedTime = ptkConvert.SqlFormatToDateTime(clone.CreatedTime);
            _ModifiedTime = ptkConvert.SqlFormatToDateTime(clone.ModifiedTime);
            _ViewTime = ptkConvert.SqlFormatToDateTime(clone.ViewTime);

            _FilePath.Clear();
            for (int i = clone.FilePath.Length - 1; i >= 0; i--)
                _FilePath.Push(clone.FilePath[i]);

            FileSize = clone.FileSize;
            Story = clone.Story;
            try { CountPlay = int.Parse(clone.CountPlay); }
            catch { CountPlay = 0;}

            // Everything OK
            return (true);
        }
        public void CheckFileConnect()
        {
            if (_FilePath.Count < 1) { _FileConnect = "G"; return; }

            _FileConnect = "?";
            string[] allPath = new string[_FilePath.Count];
            _FilePath.CopyTo(allPath, 0);
            string filePath;
            for (int i = allPath.Length; i > 0; i--)
            {
                filePath = allPath[i-1];
                if (File.Exists(filePath))
                {
                    if (filePath != this.FilePath) this.FilePath = filePath;    // Swap file to Default if not Default
                    _FileConnect = "Y";
                    return;
                }
            }
            _FileConnect = "N";     // Not found after try all history
        }

        /* Private Method */
        protected bool _ParseFileNameToAttribute(string FilePath)
        {
            string Name2Parse = Path.GetFileNameWithoutExtension(FilePath).Trim();
            if (Name2Parse.Length < 13) return (false);

            // Get Country
            string CN = Name2Parse.Substring(0, 2).ToUpper();
            if (MovieProfile.ListCountry.Contains(CN)) _Country = CN;
            
            // Rating "+"
            string[] partRating = Name2Parse.Split(new string[] { "+" }, StringSplitOptions.None);
            if (partRating.Length == 2)
            {
                try { _Rating = int.Parse(partRating[1].Substring(0, 1)); }
                catch { }
                if (_Rating > 5) _Rating = 5;
                if (_Rating < 0) _Rating = 0;
            }

            // Type "!"
            string[] partType = Name2Parse.Split(new string[] { "!" }, StringSplitOptions.None);
            if (partType.Length == 2)
            {
                string charType = partType[1].Substring(0, 1).ToUpper();
                if (MovieProfile.ListType.Contains(charType)) _Type = charType;
            }

            // Code "(..)"
            string[] partCode = Name2Parse.Split(new string[] { "(", ")" }, StringSplitOptions.None);
            if (partCode.Length == 3) _Code = partCode[1].Trim().ToUpper();

            // Title "$..$"
            string[] partTitle = Name2Parse.Split(new string[] { "$" }, StringSplitOptions.None);
            if (partTitle.Length == 3) _Title = partTitle[1].Trim();

            // Actress "{..}"
            string[] partActress = Name2Parse.Split(new string[] { "{", "}" }, StringSplitOptions.None);
            if (partActress.Length == 3)
            {
                string[] allActress = partActress[1].Trim().ToUpper().Split(
                                        new string[] { "," },
                                        StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < allActress.Length; i++) _Actress.Add(allActress[i].Trim());
            }

            // TAG "[..]"
            string[] partTAG = Name2Parse.Split(new string[] { "[", "]" }, StringSplitOptions.None);
            if (partTAG.Length == 3)
            {
                string[] allTAG = partTAG[1].Trim().ToLower().Split(
                                        new string[] { "," },
                                        StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < allTAG.Length; i++) _Tag.Add(allTAG[i].Trim());
            }

            // Hash "="
            string[] partHash = Name2Parse.Split(new string[] { "=" }, StringSplitOptions.None);
            if (partHash.Length == 2 && partHash[1].Trim().Length >= 32)
                _Hash = partHash[1].Trim().Substring(0, 32).ToLower();


            /// Everything OK
            return (true);
        }
        protected string _BuildFileNameFromAttribute()
        {
            string fileName = "";

            fileName += _Country;
            fileName += "+" + Rating.ToString();
            fileName += "!" + Type;
            fileName += "(" + Code + ")";
            fileName += "$" + Title + "$";
            fileName += "{" + Actress + "}";
            fileName += "[" + Tag + "]";
            fileName += "=" + Hash;

            return (fileName);
        }
        protected string _RemoveInvalidChar(string sData)
        {
            string listInvalid = "!@#$%^&*()+=[]{}|\\/?<>:;]'\"";
            string buff = sData;
            for (int i = 0; i < listInvalid.Length; i++)
            {
                buff = buff.Replace(listInvalid.Substring(i,1),"");
            }
            return (buff);
        }

        /* Constructor */
        public MovieProfile() : this("") { }
        public MovieProfile(string FilePath)
        {
            _CreatedTime = DateTime.Now;
            _ModifiedTime = DateTime.Now;

            if (FilePath.Trim().Length.Equals(0)) return;
            if (File.Exists(FilePath))
            {
                // Try to get FileSize
                try {
                    FileInfo fi = new FileInfo(FilePath);
                    _FileSize = fi.Length;
                    fi = null;
                } 
                catch { }
                // Push file to  FilePath Stack
                _FilePath.Push(FilePath);
            }

            // Collect Attribute from FileName
            _ParseFileNameToAttribute(FilePath);
        }
    }
}
