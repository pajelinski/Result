namespace ResultType
{
    using System;

    public abstract class Result<T>
    {
        public abstract bool IsSuccess();
        public bool IsError() => !IsSuccess();
        public abstract T GetValue();
        public abstract string GetError();
        public abstract Result<TOut> Continue<TOut>(Func<Result<TOut>> continuation);
        public abstract Result<TOut> Continue<TOut>(Func<T, Result<TOut>> continuation);
    }
}