namespace ResultType
{
    using System;

    public interface Result<out T>
    {
        bool IsSuccess();
        bool IsError();
        T GetValue();
        string GetError();
        Result<TContinuation> ContinueWith<TContinuation>(Func<Result<TContinuation>> continuation);
        Result<TContinuation> ContinueWith<TContinuation>(Func<Result<T>,Result<TContinuation>> continuation);
    }
}