using Aspose.HTML.Cloud.Sdk.Runtime.Utils;
using System.IO;
using Xunit;

namespace Aspose.HTML.Cloud.Sdk.Tests
{
    public class ZipOperationsTests
    {
        string sourceDir = TestHelper.SrcDir + "ZipUnzipOperations";
        string destDir = TestHelper.DstDir + "ZipUnzipOperationsResult";


        [Fact]
        public void DirSizeTest()
        {
            DirectoryInfo dirInfo = Directory.CreateDirectory(Path.Combine(sourceDir, "ZeroDir"));
            long sz = ZipUtils.GetDirSize(dirInfo.FullName);
            Assert.True(sz == 0);

            sz = ZipUtils.GetDirSize(Path.Combine(sourceDir, "EmptyDirWithEmptyDirs"));
            Assert.True(sz == 0);

            sz = ZipUtils.GetDirSize(Path.Combine(sourceDir, "Dir1099554"));
            Assert.True(sz == 1099554);

            sz = ZipUtils.GetDirSize(Path.Combine(sourceDir, "DirWithDirsWithFiles8796432"));
            Assert.True(sz == 8796432);
        }

        [Fact]
        public void ZipFolderToArrayTest()
        {
            string resultFolder = Directory.CreateDirectory(destDir).FullName;
            string sourceFolder = Path.Combine(sourceDir, "Dir1099554");

            string destFile = Path.Combine(resultFolder, "Zipped1099554.zip");
            byte[] zipArray = ZipUtils.ZipFolder(sourceFolder);
            File.WriteAllBytes(destFile, zipArray);

            Assert.True(File.Exists(destFile));

            sourceFolder = Path.Combine(sourceDir, "DirWithDirsWithFiles8796432");
            destFile = Path.Combine(resultFolder, "Zipped8796432.zip");
            zipArray = ZipUtils.ZipFolder(sourceFolder);
            File.WriteAllBytes(destFile, zipArray);

            Assert.True(File.Exists(destFile));
        }

        [Fact]
        public void ZipFolderToTempDirTest()
        {
            string sourceFolder = Path.Combine(sourceDir, "Dir1099554");

            string zipFile = ZipUtils.ZipFolderToTempDir(sourceFolder);
            Assert.True(File.Exists(zipFile));

            File.Delete(zipFile);

            sourceFolder = Path.Combine(sourceDir, "DirWithDirsWithFiles8796432");
            zipFile = ZipUtils.ZipFolderToTempDir(sourceFolder);
            Assert.True(File.Exists(zipFile));

            File.Delete(zipFile);
        }

        [Fact]
        public void UnzipFileToTempDirTest()
        {
            string sourceFile = Path.Combine(sourceDir, "Dir1099554.zip");
            string unzipDir = ZipUtils.UnzipFolderToTempDir(sourceFile);
            Assert.True(Directory.Exists(unzipDir));

            sourceFile = Path.Combine(sourceDir, "DirWithDirsWithFiles8796432.zip");
            unzipDir = ZipUtils.UnzipFolderToTempDir(sourceFile);
            Assert.True(Directory.Exists(unzipDir));
        }

        [Fact]
        public void UnzipFileToDirTest()
        {
            string zipFile = "Dir1099554.zip";
            string sourceFile = Path.Combine(sourceDir, zipFile);
            ZipUtils.UnzipFolder(sourceFile, destDir);

            string resultFolder = Path.Combine(destDir, "Dir1099554");
            Assert.True(Directory.Exists(resultFolder));

            zipFile = "DirWithDirsWithFiles8796432.zip";
            sourceFile = Path.Combine(sourceDir, zipFile);
            ZipUtils.UnzipFolder(sourceFile, destDir);

            resultFolder = Path.Combine(destDir, "DirWithDirsWithFiles8796432");
            Assert.True(Directory.Exists(resultFolder));
        }
    }
}
