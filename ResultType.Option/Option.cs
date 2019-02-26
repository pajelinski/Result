namespace ResultType.Option
{
    public interface Option<T>
    {
        bool HasValue();
        T GetValue();
    }
}