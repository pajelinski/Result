namespace ResultType.Option
{
    public class Some<T> : Option<T>
    {
        private readonly T _value;

        public Some(T value)
        {
            _value = value;
        }

        public bool HasValue() => true;

        public T GetValue() => _value;
    }
}