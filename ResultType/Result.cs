namespace ResultType
{
    using System;

    public abstract class Result<T>
    {
        public abstract bool IsSuccess();
        public bool IsError() => !IsSuccess();
        public abstract T GetValue();
        public abstract string GetError();
        public abstract Result<TContinuation> ContinueWith<TContinuation>(Func<Result<TContinuation>> continuation);
        public abstract Result<TContinuation> ContinueWith<TContinuation>(Func<Result<T>,Result<TContinuation>> continuation);
    }
}