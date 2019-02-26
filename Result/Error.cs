namespace Result
{
    using System;

    public class Error<T>: Result<T>
    {
        private readonly string _errorMessage;

        public Error(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
        
        public bool IsSuccess() => false;
        public bool IsError() => !IsSuccess();
        public T GetValue() => throw new InvalidCastException();
        public string GetError() => _errorMessage;
        public Result<Y> ContinueWith<Y>(Func<Result<Y>> continuation) => new Error<Y>(this._errorMessage);
        public Result<Y> ContinueWith<Y>(Func<Result<T>, Result<Y>> continuation) => new Error<Y>(this._errorMessage);
    }
}