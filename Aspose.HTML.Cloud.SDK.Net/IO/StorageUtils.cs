// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="StorageUtils.cs">
//   Copyright (c) 2022 Aspose.HTML Cloud
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

namespace Aspose.HTML.Cloud.Sdk.IO
{
    internal static class StorageUtils
    {
        internal static string GetStorageUri(string storageName = null)
        {
            return $"{storageName}/";
        }

        internal static string GetLocalUri(string resourceUri)
        {
            return GetLocalUri(Guid.NewGuid().ToString(), resourceUri);
        }

        internal static string GetLocalUri(string folder, string resourceUri)
        {
            return $"{folder}/{resourceUri}";
        }

        internal static string GetResourceUri(string resourceUri, string storageName = null)
        {
            if (string.IsNullOrWhiteSpace(resourceUri))
            {
                return null;
            }

            if (resourceUri.StartsWith("/"))
            {
                resourceUri = resourceUri.TrimStart('/');
            }

            return $"{GetStorageUri(storageName)}{resourceUri}";
        }
    }
}