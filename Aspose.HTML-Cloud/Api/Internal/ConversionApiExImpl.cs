// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="ConversionApiExImpl.cs">
//   Copyright (c) 2019 Aspose.HTML Cloud
// </copyright>
// <summary>
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using Aspose.Html.Cloud.Sdk.Client;
using Aspose.Html.Cloud.Sdk.Api.Model;
using Aspose.Html.Cloud.Sdk.Api.Model.Requests;
using Aspose.Html.Cloud.Sdk.Api.Interfaces;
using Aspose.Html.Cloud.Sdk.Api.Interfaces.Extended;
using Aspose.Html.Cloud.Sdk.Api.Utils;


namespace Aspose.Html.Cloud.Sdk.Api.Internal
{
    internal class ConversionApiExImpl: ApiImplBase, IConversionApiEx
    {
        IConversionApi m_convApiImpl = null;
        IStorageFileApi m_storageFileApiImpl = null;
        IStorageFolderApi m_storageFolderApiImpl = null;
        IStorageApi m_storageApiImpl = null;

        #region Constructor
        public ConversionApiExImpl(ApiClient apiClient) : base(apiClient)
        {
            m_convApiImpl = new ConversionApiImpl(apiClient);
            m_storageFileApiImpl = new StorageFileApiImpl(apiClient);
            m_storageFolderApiImpl = new StorageFolderApiImpl(apiClient);
            m_storageApiImpl = new StorageApiImpl(apiClient);
        }

        #endregion

        #region IConversionApiEx interface implementation


        public StreamResponse PostConvertDocumentToImageAndDownload(Stream inStream, string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null)
        {
            var methodName = "PostConvertDocumentToImageAndDownload";
            //if(string.IsNullOrEmpty(outPath))
            //{
            //    outPath = 
            //}
            var response = m_convApiImpl.PostConvertDocumentToImage(inStream, outFormat, outPath, width, height,
                leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage);
            if(response.Code == 200)
            {
                var stResp = m_storageFileApiImpl.DownloadFile(outPath, storage);
                return stResp;
            }
            return new StreamResponse() { Code = response.Code,
                Status = response.Status,
                ReasonPhrase = response.ReasonPhrase };
        }

        public StreamResponse PostConvertDocumentToImageAndDownload(string localFilePath, string outFormat, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, int? resolution = null, string storage = null)
        {
            var methodName = "PostConvertDocumentToImageAndDownload";
            var response = m_convApiImpl.PostConvertDocumentToImage(localFilePath, outFormat, outPath, width, height,
                leftMargin, rightMargin, topMargin, bottomMargin, resolution, storage);
            if (response.Code == 200)
            {
                var stResp = m_storageFileApiImpl.DownloadFile(outPath, storage);
                return stResp;
            }
            return new StreamResponse()
            {
                Code = response.Code,
                Status = response.Status,
                ReasonPhrase = response.ReasonPhrase
            };
        }

        public StreamResponse PostConvertDocumentToMarkdownAndDownload(string localFilePath, string outPath, bool? useGit = false, string storage = null)
        {
            var methodName = "PostConvertDocumentToMarkdownAndDownload";
            var response = m_convApiImpl.PostConvertDocumentToMarkdown(localFilePath, outPath, useGit, storage);
            if (response.Code == 200)
            {
                var stResp = m_storageFileApiImpl.DownloadFile(outPath, storage);
                return stResp;
            }
            return new StreamResponse()
            {
                Code = response.Code,
                Status = response.Status,
                ReasonPhrase = response.ReasonPhrase
            };
        }

        public StreamResponse PostConvertDocumentToMarkdownAndDownload(Stream inStream, string outPath, bool? useGit = false, string storage = null)
        {
            var methodName = "PostConvertDocumentToMarkdownAndDownload";
            var response = m_convApiImpl.PostConvertDocumentToMarkdown(inStream, outPath, useGit, storage);
            if (response.Code == 200)
            {
                var stResp = m_storageFileApiImpl.DownloadFile(outPath, storage);
                return stResp;
            }
            return new StreamResponse()
            {
                Code = response.Code,
                Status = response.Status,
                ReasonPhrase = response.ReasonPhrase
            };
        }

        public StreamResponse PostConvertDocumentToPdfAndDownload(Stream inStream, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            var methodName = "PostConvertDocumentToPdfAndDownload";
            var response = m_convApiImpl.PostConvertDocumentToPdf(inStream, outPath, width, height,
                leftMargin, rightMargin, topMargin, bottomMargin, storage);
            if (response.Code == 200)
            {
                var stResp = m_storageFileApiImpl.DownloadFile(outPath, storage);
                return stResp;
            }
            return new StreamResponse()
            {
                Code = response.Code,
                Status = response.Status,
                ReasonPhrase = response.ReasonPhrase
            };
        }

        public StreamResponse PostConvertDocumentToPdfAndDownload(string localFilePath, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            var methodName = "PostConvertDocumentToPdfAndDownload";
            var response = m_convApiImpl.PostConvertDocumentToPdf(localFilePath, outPath, width, height,
                leftMargin, rightMargin, topMargin, bottomMargin, storage);
            if (response.Code == 200)
            {
                var stResp = m_storageFileApiImpl.DownloadFile(outPath, storage);
                return stResp;
            }
            return new StreamResponse()
            {
                Code = response.Code,
                Status = response.Status,
                ReasonPhrase = response.ReasonPhrase
            };
        }

        public StreamResponse PostConvertDocumentToXpsAndDownload(Stream inStream, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            var methodName = "PostConvertDocumentToXpsAndDownload";
            var response = m_convApiImpl.PostConvertDocumentToXps(inStream, outPath, width, height,
                leftMargin, rightMargin, topMargin, bottomMargin, storage);
            if (response.Code == 200)
            {
                var stResp = m_storageFileApiImpl.DownloadFile(outPath, storage);
                return stResp;
            }
            return new StreamResponse()
            {
                Code = response.Code,
                Status = response.Status,
                ReasonPhrase = response.ReasonPhrase
            };
        }

        public StreamResponse PostConvertDocumentToXpsAndDownload(string localFilePath, string outPath, int? width = null, int? height = null, int? leftMargin = null, int? rightMargin = null, int? topMargin = null, int? bottomMargin = null, string storage = null)
        {
            var methodName = "PostConvertDocumentToXpsAndDownload";
            var response = m_convApiImpl.PostConvertDocumentToXps(localFilePath, outPath, width, height,
                leftMargin, rightMargin, topMargin, bottomMargin, storage);
            if (response.Code == 200)
            {
                var stResp = m_storageFileApiImpl.DownloadFile(outPath, storage);
                return stResp;
            }
            return new StreamResponse()
            {
                Code = response.Code,
                Status = response.Status,
                ReasonPhrase = response.ReasonPhrase
            };
        }

        #endregion

        #region Protected methods

        protected string CreateTempStorageFolder(string storage = null)
        {
            const string F_TEMP = "/Temp";
            if (m_storageApiImpl.FileOrFolderExists(F_TEMP, storage))
            {
                m_storageFolderApiImpl.CreateFolder(F_TEMP, storage);
            }
            string tmpPath = Path.Combine(F_TEMP, Guid.NewGuid().ToString()).Replace('\\', '/');
            AsposeResponse resp = m_storageFolderApiImpl.CreateFolder(tmpPath, storage);
            if (resp.Code == 200)
                return tmpPath;

            return null;
        }

        protected void DeleteTempStorageFolder(string folder, string storage = null)
        {

        }

        #endregion

    }
}
