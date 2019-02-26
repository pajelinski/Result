namespace Result
{
    using System;

    public interface Result<out T>
    {
        bool IsSuccess();
        bool IsError();
        T GetValue();
        string GetError();
        Result<Y> ContinueWith<Y>(Func<Result<Y>> continuation);
        Result<Y> ContinueWith<Y>(Func<Result<T>,Result<Y>> continuation);
    }
}