namespace ResultType
{
    using System;
    using System.Threading.Tasks;

    public static class TaskExtensions
    {
        public static async Task<Result<TOut>> Continue<T,TOut>(this Task<Result<T>> task, Func<T, Result<TOut>> continuation)
        {
            var result = await task;
            return result.Continue(continuation);
        }
        
        public static async Task<Result<T>> Continue<T>(this Task<Result<T>> task, Func<Result<T>> continuation)
        {
            var result = await task;
            return result.Continue(continuation);
        }
    }
}