namespace Result
{
    using System;

    public class Error<T>: IResult<T>
    {
        private readonly string _errorMessage;

        public Error(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
        
        public bool IsSuccess() => false;
        public T GetValue() => throw new InvalidCastException();
        public string GetError() => _errorMessage;
        public IResult<Y> ContinueWith<Y>(Func<IResult<Y>> continuation) => new Error<Y>(this._errorMessage);
        public IResult<Y> ContinueWith<Y>(Func<IResult<T>, IResult<Y>> continuation) => new Error<Y>(this._errorMessage);
    }
}