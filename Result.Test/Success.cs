namespace Result.Test
{
    public class Success<T> : Result<T>
    {
        private readonly T _value;

        public Success(T value)
        {
            _value = value;
            IsSuccess = true;
        }

        public bool IsSuccess { get; }

        public T Unwrap()
        {
            return _value;
        }
    }
}