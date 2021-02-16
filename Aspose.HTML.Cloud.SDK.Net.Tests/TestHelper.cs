using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    static class TestHelper
    {
        public static string AppDir { get; private set; } = AppDomain.CurrentDomain.BaseDirectory;
        public static string ProjPath { get; private set; } = AppDir.Substring(0, AppDir.IndexOf("\\bin"));
        public static string SrcDir { get; private set; } = ProjPath + "/Input/"; //"/TestSource/";
        public static string DstDir { get; private set; } = ProjPath + "/Output/"; //"/TestResult/";

        public static MultipartFormDataContent PrepareMultipart(string pathToFile, params KeyValuePair<string, string>[] formParams) 
        {
            var multiForm = new MultipartFormDataContent();

            foreach (var p in formParams)
            {
                multiForm.Add( new StringContent(p.Key), p.Value);
            }
            
            FileStream fs = File.OpenRead(pathToFile);
            multiForm.Add(new StreamContent(fs), "file", Path.GetFileName(pathToFile));
            return multiForm;
        }
    }
}
