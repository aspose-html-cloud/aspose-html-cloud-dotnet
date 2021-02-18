// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="Result.cs">
//   Copyright (c) 2020 Aspose.HTML Cloud
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

namespace Aspose.HTML.Cloud.Sdk.Runtime
{
    public class Result<TValue> : Result
    {
        public TValue Data { get; private set; }

        internal Result<TValue> WithData(TValue data)
        {
            this.Data = data;
            return this;
        }
    }

    public class Result : IDisposable
    {
        public string Id { get; }
        public int Status { get; protected set; }

        public Exception Error { get; protected set;  }

        internal Result WithError(Exception ex)
        {
            this.Error = ex;
            return this;
        }

        internal static AsyncResult<TData> CreateAsyncResult<TData>()
        {
            return new AsyncResult<TData>();
        }

        internal static AsyncResult<TValue> CreateAsyncResult<TValue>(TValue value)
            where TValue : AsyncResult<TValue>, new()
        {
            return CreateAsyncResult<TValue>().WithData(value);
        }

        internal static Result<TData> CreateResult<TData>()
        {
            return new Result<TData>();
        }

        internal static Result<TValue> CreateResult<TValue>(TValue value)
            where TValue : Result<TValue>, new()
        {
            return CreateResult<TValue>().WithData(value);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}