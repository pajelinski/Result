namespace Result.Test
{
    public class Error<T>: Result<T>
    {
        private readonly string _erroMessage;

        public Error(string erroMessage)
        {
            IsSuccess = false;
            _erroMessage = erroMessage;
        }
        
        public bool IsSuccess { get; }
        public string Unwrap()
        {
            return _erroMessage;
        }
    }
}