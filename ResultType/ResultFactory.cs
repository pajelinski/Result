namespace ResultType
{
    public static class ResultFactory
    {
        public static Result<T> CreateSuccess<T>(T value) => new Success<T>(value);
        public static Result<Nothing> CreateSuccess() => new Success<Nothing>(new Nothing());
        public static Result<Nothing> CreateError(string errorMessage) => new Error<Nothing>(errorMessage);
        public static Result<T> CreateError<T>(string errorMessage) => new Error<T>(errorMessage);
    }
}