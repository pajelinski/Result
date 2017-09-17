namespace Result.Test
{
    public class Failure<T>: Result<T>
    {
        private readonly string _erroMessage;

        public Failure(string erroMessage)
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