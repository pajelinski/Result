using System;

namespace ResultType.Option
{
    public class None<T> : Option<T>
    {
        public bool HasValue() => false;

        public T GetValue()
        {
            throw new InvalidOperationException("Called GetValue() on None. None does not have a value!");
        }
    }
}