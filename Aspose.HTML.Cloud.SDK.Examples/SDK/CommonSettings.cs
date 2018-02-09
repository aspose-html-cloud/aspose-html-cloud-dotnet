using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.HTML.Cloud.SDK.Examples.Utils;

namespace Aspose.HTML.Cloud.Examples.SDK
{
    public static class CommonSettings
    {
        private static string _appSID = null;
        private static string _appKey = null;
        private static string _basePath = null;
        private static string _version = "v1.1";

 
        public static string DefaultBaseUrl = "http://localhost:8081";

        static CommonSettings()
        {

        }

        private static string DefaultDataFolder
        {
            get
            {
                return DirectoryHelper.GetPath("TestData", "HTML");
            }
        }

        private static string DefaultOutDir
        {
            get
            {
                var res = "";
                var info = new DirectoryInfo(DirectoryHelper.GetRootSdkFolder());
                if(info != null)
                {
                    var dirs = info.GetDirectories("testout*");
                    if(dirs.Any<DirectoryInfo>())
                    {
                        res = dirs.First<DirectoryInfo>().FullName;
                    }
                    else
                    {
                        res = Path.Combine(info.FullName, "testout");
                    }
                }
                return res;
            }
        }
            

        public static string BasePath
        {
            get
            {
                if(_basePath == null)
                {
                    string val = ConfigurationManager.AppSettings["baseUrl"];
                    if (string.IsNullOrEmpty(val))
                        val = DefaultBaseUrl;
                    _basePath = string.Format("{0}/{1}", val, _version);
                }
                return _basePath;
            }
        }

        public static string OutDirectory
        {
            get
            {
                var outPath = Path.GetFullPath(DefaultOutDir);
                if (!Directory.Exists(outPath))
                    Directory.CreateDirectory(outPath);
                return outPath;
            }
        }


        public static string AppSID
        {
            get
            {
                if(_appSID == null)
                {
                    string val = ConfigurationManager.AppSettings["appSID"];
                    if (string.IsNullOrEmpty(val))
                        throw new Exception("appSID entry isn't specified in the App.config");
                    _appSID = val;
                }
                return _appSID;
            }
        }

        public static string AppKey
        {
            get
            {
                if (_appKey == null)
                {
                    string val = ConfigurationManager.AppSettings["appKey"];
                    if (string.IsNullOrEmpty(val))
                        throw new Exception("appKey entry isn't specified in the App.config");
                    _appKey = val;
                }
                return _appKey;
            }
        }

        public static string DataFolder
        {
            get
            {
                string path = null;
                try
                {
                    path = ConfigurationManager.AppSettings["DataPath"];
                    if (string.IsNullOrEmpty(path))
                        path = CommonSettings.DefaultDataFolder;
                        //throw new Exception("DataPath entry isn't specified in the App.config");
                    if (!Directory.Exists(path))
                    {
                        throw new Exception("DataPath directory does not exist.");
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return path;
            }
        }

    }
}
