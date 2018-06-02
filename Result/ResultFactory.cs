namespace Result
{
    public class ResultFactory
    {
        public static IResult<T> CreateSuccess<T>(T value) => new Success<T>(value);
        public static IResult<Nothing> CreateSuccess() => new Success<Nothing>(new Nothing());
        public static IResult<Nothing> CreateError(string errorMessage) => new Error<Nothing>(errorMessage);
        public static IResult<T> CreateError<T>(string errorMessage) => new Error<T>(errorMessage);
    }
}