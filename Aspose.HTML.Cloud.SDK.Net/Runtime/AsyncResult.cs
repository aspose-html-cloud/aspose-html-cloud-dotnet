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