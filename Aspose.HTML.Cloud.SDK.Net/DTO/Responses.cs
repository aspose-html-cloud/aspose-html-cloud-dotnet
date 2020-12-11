using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Xml.Serialization;

namespace Aspose.HTML.Cloud.Sdk.DTO
{
    #region Storage responses

    /// <summary>
    /// Storage exists
    /// </summary>
    [XmlRoot(ElementName = "Response", Namespace = "")]
    public class StorageExist
    {
        /// <summary>
        ///     Shows that the storage exists.
        /// </summary>
        public bool Exists { get; set; }
    }

    /// <summary>
    /// File versions <see cref="FileVersion" />.
    /// </summary>
    [XmlRoot("Response")]
    public class FileVersions
    {
        /// <summary>
        /// File versions <see cref="FileVersion" />.
        /// </summary>
        public List<FileVersion> Value { get; set; }
    }

    #endregion

    #region Folder responses

    /// <summary>
    /// Files list
    /// </summary>
    [XmlRoot(ElementName = "Response", Namespace = "")]
    public class FilesList
    {
        /// <summary>
        /// Files and folders contained by folder <see cref="StorageFile" />.
        /// </summary>
        public List<StorageFile> Value { get; set; }
    }

    #endregion

    #region File responses

    /// <summary>
    /// File upload result
    /// </summary>
    [XmlRoot(ElementName = "Response", Namespace = "")]
    public class FilesUploadResult
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public FilesUploadResult()
        {
            Uploaded = new List<string>();
            Errors = new List<Error>();
        }

        /// <summary>
        /// List of uploaded file names
        /// </summary>
        public List<string> Uploaded { get; set; }

        /// <summary>
        /// List of errors.
        /// </summary>
        public List<Error> Errors { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public class Error
        {
            /// <summary>
            ///     Public constructor
            /// </summary>
            public Error()
            {
                InnerError = new ErrorDetails();
            }

            /// <summary>
            ///     Public constructor
            /// </summary>
            public Error(string code, string message, string description, string requestId, DateTime date)
            {
                Code = code;
                Message = message;
                Description = description;
                InnerError = new ErrorDetails { RequestId = requestId, Date = date };
            }

            /// <summary>
            ///     Code
            /// </summary>
            public string Code { get; set; }

            /// <summary>
            ///     Message
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            ///     Description
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            ///     Inner Error
            /// </summary>
            public ErrorDetails InnerError { get; set; }
        }

        /// <summary>
        /// The error details
        /// </summary>
        public class ErrorDetails
        {
            /// <summary>
            /// The request id
            /// </summary>
            public string RequestId { get; set; }

            /// <summary>
            /// Date
            /// </summary>
            public DateTime Date { get; set; }
        }
    }

    /// <summary>
    /// File upload result
    /// </summary>
    [XmlRoot(ElementName = "Response", Namespace = "")]
    public class FilesUploadResultEx : FilesUploadResult
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public FilesUploadResultEx() : base()
        {
            UploadedInfo = new List<StorageFile>();
            Errors = new List<Error>();
        }

        /// <summary>
        /// List of uploaded file names
        /// </summary>
        public List<StorageFile> UploadedInfo { get; set; }

    }

    public class StreamResponse
    {
        public Stream  Stream { get; protected set; }

        public long StreamLength { get; protected set; }


        internal StreamResponse()
        {
        }

        public static StreamResponse GetFromHttpResponse(HttpResponseMessage response)
        {
            var res = new StreamResponse();
            res.Stream = response.Content.ReadAsStreamAsync().Result;
            res.StreamLength = response.Content.Headers.ContentLength.Value;
            return res;
        }
    }

    #endregion

}
