﻿using System;
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
        private static string _clientId = null;
        private static string _clientSecret = null;
        private static string _basePath = null;
        private static string _authPath = null;
        private static string _apiVersion = null;

 
        public static string DefaultBaseUrl = "http://api.aspose.cloud";

        static CommonSettings()
        {

        }

        private static string DefaultLocalDataFolder
        {
            get
            {
                return DirectoryHelper.GetPath("TestData", "HTML");

            }
        }

        private static string DefaultDataFolder
        {
            get
            {
                return "/HTML/SdkTestData/";
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

        private static string DefaultApiVersion = "3.0";
            

        public static string ApiVersion
        {
            get
            {
                if (_apiVersion == null)
                {
                    string val = ConfigurationManager.AppSettings["apiVersion"];
                    if (string.IsNullOrEmpty(val))
                        val = DefaultApiVersion;
                    _basePath = val;
                }
                return _apiVersion;
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
                        val = Environment.GetEnvironmentVariable("baseUrl");
                    if (string.IsNullOrEmpty(val))
                        val = DefaultBaseUrl;
                    _basePath = val;
                }
                return _basePath;
            }
        }

        public static string AuthPath
        {
            get
            {
                if (_basePath == null)
                {
                    string val = ConfigurationManager.AppSettings["authUrl"];
                    if (string.IsNullOrEmpty(val))
                        val = Environment.GetEnvironmentVariable("authUrl");
                    if (string.IsNullOrEmpty(val))
                        val = ConfigurationManager.AppSettings["baseUrl"] ?? DefaultBaseUrl;
                    _authPath = val;
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


        public static string ClientId
        {
            get
            {
                if(_clientId == null)
                {
                    string val = ConfigurationManager.AppSettings["appSID"];
                    if (string.IsNullOrEmpty(val))
                        val = Environment.GetEnvironmentVariable("appSID");
                    if (string.IsNullOrEmpty(val))
                        throw new Exception("appSID entry isn't specified in the App.config");
                    _clientId = val;
                }
                return _clientId;
            }
        }

        public static string ClientSecret
        {
            get
            {
                if (_clientSecret == null)
                {
                    string val = ConfigurationManager.AppSettings["appKey"];
                    if (string.IsNullOrEmpty(val))
                        val = Environment.GetEnvironmentVariable("appKey");
                    if (string.IsNullOrEmpty(val))
                        throw new Exception("appKey entry isn't specified in the App.config");
                    _clientSecret = val;
                }
                return _clientSecret;
            }
        }

        public static string LocalDataFolder
        {
            get
            {
                string path = null;
                try
                {
                    path = ConfigurationManager.AppSettings["LocalDataPath"];
                    if (string.IsNullOrEmpty(path))
                        path = CommonSettings.DefaultLocalDataFolder;
                    if (!Directory.Exists(path))
                    {
                        throw new Exception($"LocalDataPath = {path}: directory does not exist.");
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return path;
            }
        }

        public static string StorageDataFolder
        {
            get
            {
                string path = null;
                try
                {
                    path = ConfigurationManager.AppSettings["DataPath"];
                    if (string.IsNullOrEmpty(path))
                        path = CommonSettings.DefaultDataFolder;
                    //if (!Directory.Exists(path))
                    //{
                    //    throw new Exception($"DataPath = {path}: directory does not exist.");
                    //}
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