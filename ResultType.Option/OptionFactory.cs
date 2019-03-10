namespace ResultType.Option
{
    public static class OptionFactory
    {
        public static Option<T> CreateNone<T>() => new None<T>();

        public static Some<T> CreateSome<T>(T value) => new Some<T>(value);
    }
}