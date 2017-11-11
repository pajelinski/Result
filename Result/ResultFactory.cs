namespace Result.Test
{
    public class ResultFactory
    {
        public static Result<T> CreateSuccess<T>(T value)
        {
            return new Success<T>(value);
        }

        public static Result<T> CreateError<T>(string errorMessage)
        {
            return new Error<T>(errorMessage);
        }
    }
}