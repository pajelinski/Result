namespace Result.Test
{
    public static class ResultExtensions
    {
        public static Success<T> ToSuccess<T>(this Result<T> result)
        {
            return (Success<T>)result;
        }
        
        public static Failure<T> ToFailure<T>(this Result<T> result)
        {
            return (Failure<T>)result;
        }
    }
}