namespace Result.Test
{
    public interface Result<out T>
    {
        bool IsSuccess();
        T GetValue();
        string GetError();
    }
}