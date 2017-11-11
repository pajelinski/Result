using System;

namespace Result.Test
{
    public struct Success<T> : Result<T>
    {
        private readonly T _value;

        public Success(T value)
        {
            _value = value;
        }

        public bool IsSuccess() => true;
        public T GetValue() => _value;
        public string GetError() => throw new InvalidCastException();
    }
}