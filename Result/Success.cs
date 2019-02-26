namespace Result
{
    using System;

    public class Success<T> : Result<T>
    {
        private readonly T _value;

        public Success(T value)
        {
            _value = value;
        }

        public bool IsSuccess() => true;
        public bool IsError() => !IsSuccess();

        public T GetValue() => _value;
        public string GetError() => throw new InvalidCastException();
        public Result<Y> ContinueWith<Y>(Func<Result<Y>> continuation) => continuation();
        public Result<Y> ContinueWith<Y>(Func<Result<T>, Result<Y>> continuation) => continuation(this);
    }
}