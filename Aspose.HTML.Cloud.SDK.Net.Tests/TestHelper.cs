using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    static class TestHelper
    {
        public static string appDir = AppDomain.CurrentDomain.BaseDirectory;
        public static string projPath = appDir.Substring(0, appDir.IndexOf("\\bin"));
        public static string srcDir = projPath + "/TestSource/";
        public static string dstDir = projPath + "/TestResult/";

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
