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
        
        public override  bool IsSuccess() => false;
        public override  T GetValue() => throw new InvalidCastException();
        public override  string GetError() => _errorMessage;
        public override  Result<Y> ContinueWith<Y>(Func<Result<Y>> continuation) => new Error<Y>(this._errorMessage);
        public override  Result<Y> ContinueWith<Y>(Func<Result<T>, Result<Y>> continuation) => new Error<Y>(this._errorMessage);
    }
}