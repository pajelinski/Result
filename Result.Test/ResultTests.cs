using System;
using NUnit.Framework;

namespace Result.Test
{
    public class ResultFactory
    {
        public static Success<T> CreateSuccess<T>(T value)
        {
            return new Success<T>(value);
        }
    }

    public interface Result<out T>
    {
        bool IsSuccess { get; }
        T Unwrap();
    }

    public class Success<T> : Result<T>
    {
        public Success(T value)
        {
            IsSuccess = true;
        }

        public bool IsSuccess { get; }

        public T Unwrap()
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class ResultTests
    {
        public Result<string> ReturnSuccessWithString(string value)
        {
            return ResultFactory.CreateSuccess(value);
        }

        [Test]
        public void GivenSuccess_IsSuccesShouldReturnTrue()
        {
            var result = ReturnSuccessWithString("test");
            Assert.That(result.IsSuccess, Is.True);
        }
    }
}