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
    public class MovieDB
    {
        private static string DbPath = ptkGeneral.ThisProgramPath() + Path.DirectorySeparatorChar + "MDB";
        private static string[] DbSubDir = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        
        private static string ImgPath = ptkGeneral.ThisProgramPath() + Path.AltDirectorySeparatorChar + "IMG";        
        private static string[] ImgSubDir1 = new string[] { "FCV", "BCV", "SS1", "SS2" };
        private static string[] ImgSubDir2 = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

        public static Hashtable hMovie = Hashtable.Synchronized(new Hashtable());

        public static bool CheckAndPrepareDbFolder()
        {
            zLog.Write("Begin Initialize MovieDB");

            /* check root DbPath */
            if (!Directory.Exists(DbPath))
            {
                zLog.Write("DbPath[" + DbPath + "] Not existing, Try create new");
                try { Directory.CreateDirectory(DbPath); }
                catch (Exception ex) 
                {
                    zLog.Write("Error create dbPath [" + DbPath + "]");
                    zLog.Write(ex.Message);
                    return (false);
                }
            }
            
            /* check sub direct Db */
            string DbPathSub;
            for (int i = 0; i < DbSubDir.Length; i++)
            {
                DbPathSub = DbPath + Path.DirectorySeparatorChar + DbSubDir[i];
                if (Directory.Exists(DbPathSub)) continue;
                
                // Not existing, then try create new
                zLog.Write("dbPathSub [" + DbPathSub + "] Not existing, try create new");
                try { Directory.CreateDirectory(DbPathSub); }
                catch (Exception ex)
                {
                    zLog.Write("Error create new dbPathSub [" + DbPathSub + "]");
                    zLog.Write(ex.Message);
                    return (false);
                }
            }

            // Everything OK
            return (true);
        }
        public static bool CheckAndPrepareImgFolder()
        {
            zLog.Write("Begin Initialize MovieIMG");

            /* Check root ImgPath */
            if (!Directory.Exists(ImgPath))
            {
                zLog.Write("ImgPath[" + ImgPath + "] Not existing, Try create new");
                try { Directory.CreateDirectory(ImgPath); }
                catch (Exception ex)
                {
                    zLog.Write("Error create ImgPath [" + ImgPath+ "]");
                    zLog.Write(ex.Message);
                    return (false);
                }
            }

            /* Check SubDir1 */
            for (int i = 0; i < ImgSubDir1.Length; i++)
            {
                string ImgPathSub1 = ImgPath + Path.DirectorySeparatorChar + ImgSubDir1[i];
                if (!Directory.Exists(ImgPathSub1))
                {
                    zLog.Write("ImgPathSub1[" + ImgPathSub1 + "] Not existing, Try create new");
                    try { Directory.CreateDirectory(ImgPathSub1); }
                    catch (Exception ex)
                    {
                        zLog.Write("Error create ImgPathSub1[" + ImgPathSub1 + "]");
                        zLog.Write(ex.Message);
                        return (false);
                    }
                }

                /* Check SubDir2 */
                for (int j = 0; j < ImgSubDir2.Length; j++)
                {
                    string ImgPathSub2 = ImgPathSub1 + Path.DirectorySeparatorChar + ImgSubDir2[j];
                    if (!Directory.Exists(ImgPathSub2))
                    {
                        zLog.Write("ImgPathSub2[" + ImgPathSub2 + "] Not existing, Try create new");
                        try { Directory.CreateDirectory(ImgPathSub2); }
                        catch (Exception ex)
                        {
                            zLog.Write("Error create ImgPathSub2[" + ImgPathSub2 + "]");
                            zLog.Write(ex.Message);
                            return (false);
                        }
                    }
                }
            }
                

            // Everything OK
            return (true);
        }
        
        public static bool LoadMovieProfileFromDisk()
        {
            that.DebugAndLog("LoadMovieProfileFromDisk() Begin");
            hMovie.Clear();
            for (int i = 0; i < DbSubDir.Length; i++)
            {
                if (!_LoadMovieProfileInDir(DbPath + Path.DirectorySeparatorChar + DbSubDir[i])) return (false);
                Application.DoEvents();
            }

            // Everything OK
            that.DebugAndLog("LoadMovieProfileFromDisk() Finish, Total Movie = " + hMovie.Count.ToString());
            return (true);
        }
        private static bool _LoadMovieProfileInDir(string dirName)
        {
            string[] listFile = Directory.GetFiles(dirName, "*.json");
            if (listFile.Length < 1) return (true);

            that.DebugAndLog("_LoadMovieProfileInDir(" + dirName + ") Found " + listFile.Length + " file(s)");
            for (int i = 0; i < listFile.Length; i++)
            {
                zLog.Write("Process File[" + listFile[i] + "]");
                if (!__ReadFileDataToMovieProfile(listFile[i])) return (false);
            }

            // Everything OK
            return (true);
        }
        private static bool __ReadFileDataToMovieProfile(string fileName)
        {
            string[] lines;
            _MovieProfile clone;
            if (!ptkTextFile.ReadStringArray(fileName, out lines))
            {
                that.DebugAndLog("Error in ReadStringArray [" + fileName + "]");
                return (false);
            }
            try
            {
                clone = JsonConvert.DeserializeObject<_MovieProfile>(string.Join("", lines));
            }
            catch (Exception ex)
            {
                that.DebugAndLog("Error _ReadFileDataToMovieProfile -> Json DeserializeObject");
                zLog.Write(ex.Message);
                return (false);
            }

            if (null == clone)
            {
                that.DebugAndLog("File movie profile is ERROR! read and NULL");
                that.DebugAndLog("File name = " + fileName);
                that.DebugAndLog("Try To delete file ");
                File.Delete(fileName);
                return (false);
            }
            MovieProfile newProfile = new MovieProfile();
            if ((!newProfile.ImportProfile(clone)) || (newProfile.Hash.Length!=32))
            {
                that.DebugAndLog("Error _ReadFileDataToMovieProfile:: Cannot Import _MovieProfile");
                return (false);
            }
            if (newProfile.Hash.Length != 32)
            {
                that.DebugAndLog("Error _ReadFileDataToMovieProfile:: newProfile.Hash.Length <> 32");
                return (false);
            }

            // Check File Status if it can access of NOT?
            newProfile.CheckFileConnect();

            // Push Object to Movie
            lock (MovieDB.hMovie.SyncRoot)
            {
                hMovie[newProfile.Hash] = newProfile;
            }

            // Everyting OK
            return (true);
        }
        
        public static bool SaveMovieProfile(MovieProfile movieProfile)
        {
            string hKey = movieProfile.Hash;
            if (!hKey.Length.Equals(32))
            {
                that.DebugAndLog("MovieDB->SaveMovieProfile():Error! hKey.Length <> 32");
                return (false);
            }

            that.DebugAndLog("Start SaveMoveProfile(" + hKey + ")");
            // Clone movieProfile as local myProfile for safty in Save to Disk
            string filePath = 
                DbPath + Path.DirectorySeparatorChar + 
                hKey.Substring(0, 1) + Path.DirectorySeparatorChar 
                + hKey + ".json";
            if (!_SaveMovieProfileToJSON(movieProfile, filePath))
            {
                that.DebugAndLog("MovieDB->SaveMovieProfile():Error! !_SaveMovieProfileToJSON()");
                return (false);
            }

            lock (MovieDB.hMovie.SyncRoot)
            {
                hMovie[hKey] = movieProfile;    // User real movieProfile as linking Object
            }
            return (true);
        }
        private static bool _SaveMovieProfileToJSON(MovieProfile profile, string filePath)
        {
            string hashKey = profile.Hash;
            if (profile.Hash.Length != 32)
            {
                that.DebugAndLog("_SaveMovieProfileToJSON()! profile.Hash.Length <> 32");
                return (false);
            }

            _MovieProfile clone = profile.ExportProfile();
            string jsonData = "";
            try
            {
                zLog.Write("SaveMovieProfileToJSON->Convert Profile to JSON");
                jsonData = JsonConvert.SerializeObject(clone, Formatting.Indented);
            }
            catch (Exception ex)
            {
                that.DebugAndLog("Exception Error: " + ex.Message);
                return (false);
            }
            string[] arrLines = jsonData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Return WriteResult as main result
            that.DebugAndLog("Begin ptkTextFile.WriteStringArray(" + filePath + ")");
            return (ptkTextFile.WriteStringArray(filePath, arrLines));
        }

        public static bool SaveMovieImage_FrontCover(string filePath, MovieProfile profile)
        {
            if (!_IsImageFile(filePath)) return (false);
            string file2save = _BuildImageFilePath(filePath, "FCV", profile);
            return (_CopyFileToPathIMG(filePath, file2save));
        }
        public static bool SaveMovieImage_BackCover(string filePath, MovieProfile profile)
        {
            if (!_IsImageFile(filePath)) return (false);
            string file2save = _BuildImageFilePath(filePath, "BCV", profile);
            return (_CopyFileToPathIMG(filePath, file2save));
        }
        public static bool SaveMovieImage_ScreenShot1(string filePath, MovieProfile profile)
        {
            if (!_IsImageFile(filePath)) return (false);
            string file2save = _BuildImageFilePath(filePath, "SS1", profile);
            return (_CopyFileToPathIMG(filePath, file2save));
        }
        public static bool SaveMovieImage_ScreenShot2(string filePath, MovieProfile profile)
        {
            if (!_IsImageFile(filePath)) return (false);
            string file2save = _BuildImageFilePath(filePath, "SS2", profile);
            return (_CopyFileToPathIMG(filePath, file2save));
        }
        public static string GetFilePath_MovieImage_FrontCover(MovieProfile profile)
        {
            if (profile.Hash.Length != 32) return ("");
            return (_GetMovieImageFile_If_Exists("FCV", profile));
        }
        public static string GetFilePath_MovieImage_BackCover(MovieProfile profile)
        {
            if (profile.Hash.Length != 32) return ("");
            return (_GetMovieImageFile_If_Exists("BCV", profile));
        }
        public static string GetFilePath_MovieImage_ScreenShot1(MovieProfile profile)
        {
            if (profile.Hash.Length != 32) return ("");
            return (_GetMovieImageFile_If_Exists("SS1", profile));
        }
        public static string GetFilePath_MovieImage_ScreenShot2(MovieProfile profile)
        {
            if (profile.Hash.Length != 32) return ("");
            return (_GetMovieImageFile_If_Exists("SS2", profile));
        }
        private static string _GetMovieImageFile_If_Exists(string typeImage, MovieProfile profile)
        {
            string pathOnly =
                ImgPath + Path.DirectorySeparatorChar
                + typeImage + Path.DirectorySeparatorChar
                + profile.Hash.Substring(0, 1);
            string[] fileList = Directory.GetFiles(pathOnly, profile.Hash + ".*");
            if (fileList.Length < 1) return ("");
            return (fileList[0]);
        }
        private static bool _CopyFileToPathIMG(string filePath, string filePathNew)
        {
            if (File.Exists(filePathNew))
            {
                try { File.Delete(filePathNew); }
                catch (Exception ex)
                {
                    that.DebugAndLog("Cannot clear old existing Image [" + filePathNew + "]");
                    that.DebugAndLog("Error Desc: " + ex.Message);
                    return (false);
                }
            }
            try
            {
                File.Copy(filePath, filePathNew);
                that.DebugAndLog("Copy [" + filePath + "] -> [" + filePathNew + "] Success !!");
                return (true);
            }
            catch (Exception ex)
            {
                that.DebugAndLog("Copy [" + filePath + "] -> [" + filePathNew + "] FAIL !!");
                that.DebugAndLog("Error Desc: " + ex.Message);
                return (false);
            }

        }
        private static string _BuildImageFilePath(string filePath, string subDir1, MovieProfile profile)
        {
            return(
                ImgPath + Path.DirectorySeparatorChar
                + subDir1 + Path.DirectorySeparatorChar
                + profile.Hash.Substring(0,1) + Path.DirectorySeparatorChar
                + profile.Hash
                + Path.GetExtension(filePath)
                );
        }
        private static bool _IsImageFile(string filePath)
        {
            if (!File.Exists(filePath)) return (false);
            System.Windows.Forms.PictureBox pcb = new PictureBox();
            try { 
                pcb.Load(filePath);
                if (pcb.Image.Size.IsEmpty) 
                    return (false);
            }
            catch (Exception ex)
            {
                that.DebugAndLog("Error on Loading image [" + filePath + "]");
                that.DebugAndLog("Error Desc: " + ex.Message);
                return (false);
            }

            // Everything OK
            return (true);
        }

        public static List<MovieProfile> GetMovieList()
        {
            List<MovieProfile> curList = new List<MovieProfile>();
            lock (MovieDB.hMovie.SyncRoot)
            {
                foreach (DictionaryEntry kv in hMovie) curList.Add((MovieProfile)kv.Value);
            }
            return (curList);
        }
        public static List<MovieProfile> GetMovieList(MovieFilter filter)
        {
            List<MovieProfile> curList = new List<MovieProfile>();
            lock (MovieDB.hMovie.SyncRoot)
            {
                foreach (DictionaryEntry kv in hMovie) curList.Add((MovieProfile)kv.Value);
            }

            if (filter.NeedCheckCode())
            {
                that.DebugAndLog("MovieDB.GetMovieList():: filter->CheckCode");
                if (filter.IsEmptyCode)
                {
                    for (int i = curList.Count - 1; i >= 0; i--)
                        if (!curList[i].Code.Length.Equals(0))
                            curList.RemoveAt(i);
                }
                else
                {
                    string keyword = filter.Code.Trim().ToUpper();
                    for (int i = curList.Count - 1; i >= 0; i--)
                        if (!curList[i].Code.Contains(keyword))
                            curList.RemoveAt(i);
                }
            }
            if (filter.NeedCheckTitle())
            {
                that.DebugAndLog("MovieDB.GetMovieList():: filter->CheckTitle");
                if (filter.IsEmptyTitle)
                {
                    for (int i = curList.Count - 1; i >= 0; i--)
                        if (!curList[i].Title.Length.Equals(0))
                            curList.RemoveAt(i);
                }
                else
                {
                    string keyword = filter.Title.Trim();
                    for (int i = curList.Count - 1; i >= 0; i--)
                        if (!curList[i].Title.Contains(keyword))
                            curList.RemoveAt(i);
                }
            }
            if (filter.NeedCheckStory())
            {
                that.DebugAndLog("MovieDB.GetMovieList():: filter->CheckStory");
                if (filter.IsEmptyStory)
                {
                    for (int i = curList.Count - 1; i >= 0; i--)
                        if (!curList[i].Story.Length.Equals(0))
                            curList.RemoveAt(i);
                }
                else
                {
                    string keyword = filter.Story.Trim();
                    for (int i = curList.Count - 1; i >= 0; i--)
                        if (!curList[i].Story.Contains(keyword))
                            curList.RemoveAt(i);
                }
            }
            if (filter.NeedCheckType()) 
            {   // Include one of filter.Type
                that.DebugAndLog("MovieDB.GetMovieList():: filter->CheckType");
                for (int i = curList.Count - 1; i >= 0; i--)
                {
                    if (!filter.Type.Contains(curList[i].Type))
                        curList.RemoveAt(i);
                }
            }
            if (filter.NeedCheckRating())
            {   // Include one of filter.Rating
                that.DebugAndLog("MovieDB.GetMovieList():: filter->CheckRating");
                for (int i = curList.Count - 1; i >= 0; i--)
                {
                    if (!filter.Rating.Contains(curList[i].Rating))
                        curList.RemoveAt(i);
                }
            }
            if (filter.NeedCheckCountry())
            {
                that.DebugAndLog("MovieDB.GetMovieList():: filter->CheckCountry");
                for (int i = curList.Count - 1; i >= 0; i--)
                {
                    if (!filter.Country.Contains(curList[i].Country))
                        curList.RemoveAt(i);
                }
            }
            if (filter.NeedCheckActress())
            {   // Find any actress match filter
                that.DebugAndLog("MovieDB.GetMovieList():: filter->CheckActress");
                if (filter.IsNoActress)
                {
                    for (int i = curList.Count - 1; i >= 0; i--)
                        if (curList[i].Actress.Length > 0)
                            curList.RemoveAt(i);
                }
                else
                {
                    string[] keywords = filter.Actress.ToArray();
                    for (int i = 0; i < keywords.Length; i++) keywords[i] = keywords[i].ToUpper();
                    bool isFound;
                    for (int i = curList.Count - 1; i >= 0; i--)
                    {
                        isFound = false;
                        for (int k = 0; k < keywords.Length; k++)
                        {
                            if (curList[i].Actress.Contains(keywords[k]))
                            {
                                isFound = true;
                                break;
                            }
                        }
                        if (isFound) continue;
                        curList.RemoveAt(i);    // Not Found of any keyword
                    }
                }
            }
            if (filter.NeedCheckTag())
            {
                that.DebugAndLog("MovieDB.GetMovieList():: filter->CheckTag");
                if (filter.IsNoTag)
                {
                    for (int i = curList.Count - 1; i >= 0; i--)
                        if (curList[i].Tag.Length > 0)
                            curList.RemoveAt(i);
                }
                else
                {
                    string[] keywords = filter.Tag.ToArray();
                    for (int i = 0; i < keywords.Length; i++) keywords[i] = keywords[i].ToLower();
                    bool isFound;
                    for (int i = curList.Count - 1; i >= 0; i--)
                    {
                        isFound = false;
                        for (int k = 0; k < keywords.Length; k++)
                        {
                            if (curList[i].Tag.Contains(keywords[k]))
                            {
                                isFound = true;
                                break;
                            }
                        }
                        if (isFound) continue;
                        curList.RemoveAt(i);    // Not Found of any keyword
                    }
                }
            }
            if (filter.NeedCheckFileConnect())
            {
                that.DebugAndLog("MovieDB.GetMovieList():: filter->CheckFileConnect");
                string[] keywords = filter.FileConnect.ToArray();
                for (int i = 0; i < keywords.Length; i++) keywords[i] = keywords[i].ToUpper();
                bool isFound;
                for (int i = curList.Count - 1; i >= 0; i--)
                {
                    isFound = false;
                    for (int k = 0; k < keywords.Length; k++)
                    {
                        if (curList[i].FileConnect.Equals(keywords[k]))
                        {
                            isFound = true;
                            break;
                        }
                    }
                    if (isFound) continue;
                    curList.RemoveAt(i);    // Not found of any keyword
                }
            }
            if (filter.NeedCheckNoFilePath())
            {   // Have no FilePath
                that.DebugAndLog("MovieDB.GetMovieList():: filter->CheckNoFilePath");
                for (int i = curList.Count - 1; i >= 0; i--)
                {
                    if (curList[i].FilePath.Length > 0)
                        curList.RemoveAt(i);
                }
            }
            if (filter.NeedCheckCountPlay())
            {   // Count play in range of Min & Max
                that.DebugAndLog("MovieDB.GetMovieList:: filter->CheckCountPlay");
                if (filter.MinCountPlay.Length > 0)
                {
                    long minPlay = long.Parse(filter.MinCountPlay);
                    for (int i = curList.Count - 1; i >= 0; i--)
                        if (curList[i].CountPlay < minPlay)
                            curList.RemoveAt(i);
                }
                if (filter.MaxCountPlay.Length > 0)
                {
                    long maxPlay = long.Parse(filter.MaxCountPlay);
                    for (int i = curList.Count - 1; i >= 0; i--)
                        if (curList[i].CountPlay > maxPlay)
                            curList.RemoveAt(i);
                }
            }
            if (filter.NeedCheckFilePath())
            {   // Check Have FilePath in Last Path
                that.DebugAndLog("MovieDB.GetMovieList:: filter->CheckFilePath");
                string keyword = filter.FilePath.ToLower();
                for (int i = curList.Count - 1; i >= 0; i--)
                    if (!curList[i].FilePath.ToLower().Contains(keyword))
                        curList.RemoveAt(i);
            }
            

            return (curList);
        }
    }
}
