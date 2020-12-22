// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose" file="AsyncResult.cs">
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
using System.Threading;

namespace Aspose.HTML.Cloud.Sdk.Runtime
{
    public class AsyncResult<TValue> : AsyncResult
    {
        private string id;

        public TValue Data { get; private set; }

        internal AsyncResult<TValue> WithId(string id)
        {
            this.id = id;
            return this;
        }

        internal AsyncResult<TValue> WithData(TValue data)
        {
            this.Data = data;
            return this;
        }
    }

    public class AsyncResult : Result, IAsyncResult
    {
        const int PENDING = 0;
        const int COMPLETED = 1 << 0;
        const int ASYNCHRONOUS = 1 << 1;
        const int COMPLETED_SYNCHRONOUSLY = COMPLETED;
        const int COMPLETED_ASYNCHRONOUSLY = COMPLETED | ASYNCHRONOUS;

        int state = PENDING;
        private ManualResetEvent waitHandle;
        private readonly int threadId = Thread.CurrentThread.ManagedThreadId;

        public WaitHandle AsyncWaitHandle
        {
            get
            {
                if (waitHandle == null)
                {
                    ManualResetEvent mre = new ManualResetEvent(false);

                    if (Interlocked.CompareExchange(ref waitHandle, mre, null) != null)
                        mre.Close();

                    if ((Thread.VolatileRead(ref state) & COMPLETED) == COMPLETED)
                        waitHandle.Set();
                }
                return waitHandle;
            }
        }

        public object AsyncState
        {
            get { return state; }
        }

        public bool CompletedSynchronously
        {
            get { return (Thread.VolatileRead(ref state) & ASYNCHRONOUS) == ASYNCHRONOUS; }
        }

        public bool IsCompleted
        {
            get { return (Thread.VolatileRead(ref state) & COMPLETED) == COMPLETED; }
        }

        internal void Complete()
        {
            var newState = threadId != Thread.CurrentThread.ManagedThreadId
                ? COMPLETED_ASYNCHRONOUSLY
                : COMPLETED_SYNCHRONOUSLY;
            if ((Interlocked.Exchange(ref state, newState) & COMPLETED) == COMPLETED)
                return;

            if (waitHandle != null)
                waitHandle.Set();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var wh = Interlocked.Exchange(ref waitHandle, null);
                ((IDisposable)wh)?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}