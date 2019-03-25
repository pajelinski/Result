namespace ResultType.Tests
{
    public static class TestHelpers
    {
        public static Result<T> PassValue<T>(T value) => ResultFactory.CreateSuccess(value);

        public static Result<Nothing> ReturnSuccessWithNothing() => ResultFactory.CreateSuccess();

        public static Result<Nothing> ReturnErrorWithNothing(string errorMessage) => ResultFactory.CreateError(errorMessage);

        public static Result<string> ReturnSuccessWithString(string value) => ResultFactory.CreateSuccess(value);

        public static Result<string> ReturnErrorWithString(string errorMessage) => ResultFactory.CreateError<string>(errorMessage);
    }
}