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
        public override string GetError() => throw new InvalidOperationException("Success do not have error message!");
        
        public override Result<TOut> Continue<TOut>(Func<Result<TOut>> continuation) => continuation();
        public override Result<TOut> Continue<TOut>(Func<T, Result<TOut>> continuation) => continuation(_value);
    }
}