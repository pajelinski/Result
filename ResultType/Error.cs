namespace ResultType
{
    using System;

    public class Error<T>: Result<T>
    {
        private readonly string _errorMessage;

        public Error(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
        
        public override bool IsSuccess() => false;
        public override T GetValue() => throw new InvalidOperationException("Error do not contain value!");
        public override string GetError() => _errorMessage;
        
        public override Result<TOut> Continue<TOut>(Func<Result<TOut>> continuation) => new Error<TOut>(_errorMessage);
        public override Result<TOut> Continue<TOut>(Func<T, Result<TOut>> continuation) => new Error<TOut>(_errorMessage);
    }
}