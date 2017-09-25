namespace Result.Test
{
    public static class ResultExtensions
    {
        public static T GetValue<T>(this Result<T> result)
        {
            return ((Success<T>)result).Unwrap();
        }
        
        public static string GetError<T>(this Result<T> result)
        {
            return ((Error<T>)result).Unwrap();
        }
    }
}