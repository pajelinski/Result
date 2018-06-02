namespace Result
{
    using System;

    public class Success<T> : IResult<T>
    {
        private readonly T _value;

        public Success(T value)
        {
            _value = value;
        }

        public bool IsSuccess() => true;
        public T GetValue() => _value;
        public string GetError() => throw new InvalidCastException();
        public IResult<Y> ContinueWith<Y>(Func<IResult<Y>> continuation) => continuation();
        public IResult<Y> ContinueWith<Y>(Func<IResult<T>, IResult<Y>> continuation) => continuation(this);
    }
}