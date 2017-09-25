using System;

namespace Result.Test
{
    public class Error<T>: Result<T>
    {
        private readonly string _errorMessage;

        public Error(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
        
        public virtual bool IsSuccess() => false;
        public virtual T GetValue()
        {
            throw new InvalidCastException();
        }

        public virtual string GetError() => _errorMessage;
    }
}