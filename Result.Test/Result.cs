namespace Result.Test
{
    public interface Result<T>
    {
        bool IsSuccess { get; }
    }
}