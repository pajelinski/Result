namespace ResultType
{
    using System;

    public class Success<T> : Result<T>
    {
        private readonly T _value;

        public Success(T value)
        {
            _value = value;
        }

        public override bool IsSuccess() => true;

        public override T GetValue() => _value;
        public override string GetError() => throw new InvalidCastException();
        public override Result<Y> ContinueWith<Y>(Func<Result<Y>> continuation) => continuation();
        public override Result<Y> ContinueWith<Y>(Func<Result<T>, Result<Y>> continuation) => continuation(this);
    }
}