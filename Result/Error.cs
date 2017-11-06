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
        
        public bool IsSuccess() => false;
        public T GetValue()
        {
            throw new InvalidCastException();
        }

        public virtual string GetError() => _errorMessage;
    }
}