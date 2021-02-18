﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aspose.HTML.Cloud.Sdk.ApiParameters
{
    /// <summary>
    /// Class that represents a directory path in the cloud storage.
    /// </summary>
    public class RemoteDirectoryParameter : PathParameter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path">Storage directory path.</param>
        /// <param name="storage">Storage name. Optional, empty value means the default storage.</param>
        public RemoteDirectoryParameter(string path, string storage = null)
            : base("remoteDir", path?.Replace('\\', '/'))
        { }

        /// <summary>
        /// Storage name. Empty value means the default storage.
        /// </summary>
        public string Storage { get; protected set; }

        /// <summary>
        /// Full storage path in "storage://{Storage}/{FolderPath}" format
        /// </summary>
        public string FullRemotePath
        {
            get { return $"storage://{Storage}/{Value}";  }
        }
            
    }
}