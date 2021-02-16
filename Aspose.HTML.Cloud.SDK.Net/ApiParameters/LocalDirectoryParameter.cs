using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.HTML.Cloud.Sdk.ApiParameters
{
    /// <summary>
    /// Class that represents a directory path in the local file system.
    /// </summary>
    public class LocalDirectoryParameter : PathParameter
    {
        public LocalDirectoryParameter(string path)
            : base("localDir", path)
        { }
    }
}
