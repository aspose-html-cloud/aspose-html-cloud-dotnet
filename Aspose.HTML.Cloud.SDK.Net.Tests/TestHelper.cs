using System;
using System.IO;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    static class TestHelper
    {
        public static string AppDir = AppDomain.CurrentDomain.BaseDirectory;
        public static string ProjPath = AppDir.Substring(0, AppDir.IndexOf("\\bin", StringComparison.OrdinalIgnoreCase));
        public static string SrcDir = Path.Combine(ProjPath, "TestSource");
        public static string DstDir = Path.Combine(ProjPath, "TestResult");

    }
}
