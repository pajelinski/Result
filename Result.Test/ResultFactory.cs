namespace Result.Test
{
    public class ResultFactory
    {
        public static Success<T> CreateSuccess<T>(T value)
        {
            return new Success<T>(value);
        }

        public static Failure<T> CreateFailure<T>(string errorMessage)
        {
            return new Failure<T>(errorMessage);
        }
    }
}