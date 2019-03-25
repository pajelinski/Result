namespace ResultType.Option
{
    public interface Option<out T>
    {
        bool HasValue();
        T GetValue();
    }
}