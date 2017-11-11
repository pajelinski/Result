using System;

namespace Result.Test
{
    public interface Result<out T>
    {
        bool IsSuccess();
        T GetValue();
        string GetError();
        Result<Y> ContinueWith<Y>(Func<Result<Y>> continuation);
        Result<Y> ContinueWith<Y>(Func<Result<T>,Result<Y>> continuation);
    }
}