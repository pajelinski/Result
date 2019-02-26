using System;

namespace ResultType.Option
{
    public class Some<T> : Option<T>
    {
        public bool HasValue()
        {
            throw new NotImplementedException();
        }

        public T GetValue()
        {
            throw new NotImplementedException();
        }
    }
}