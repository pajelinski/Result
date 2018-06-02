namespace Result
{
    using System;

    public interface IResult<out T>
    {
        bool IsSuccess();
        T GetValue();
        string GetError();
        IResult<Y> ContinueWith<Y>(Func<IResult<Y>> continuation);
        IResult<Y> ContinueWith<Y>(Func<IResult<T>,IResult<Y>> continuation);
    }
}