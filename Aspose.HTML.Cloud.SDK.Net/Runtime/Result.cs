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