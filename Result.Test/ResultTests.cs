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

        public static Failure<T> CreateFailure<T>(string errorMessage)
        {
            return new Failure<T>(errorMessage);
        }
    }

    public interface Result<T>
    {
       bool IsSuccess { get; }
    }

    public static class ResultExtensions
    {
        public static Success<T> ToSuccess<T>(this Result<T> result)
        {
            return (Success<T>)result;
        }
        
        public static Failure<T> ToFailure<T>(this Result<T> result)
        {
            return (Failure<T>)result;
        }
    } 

    public class Success<T> : Result<T>
    {
        private readonly T _value;

        public Success(T value)
        {
            _value = value;
            IsSuccess = true;
        }

        public bool IsSuccess { get; }

        public T Unwrap()
        {
            return _value;
        }
    }

    public class Failure<T>: Result<T>
    {
        private readonly string _erroMessage;

        public Failure(string erroMessage)
        {
            IsSuccess = false;
            _erroMessage = erroMessage;
        }
        
        public bool IsSuccess { get; }
        public string Unwrap()
        {
            return _erroMessage;
        }
    }

    [TestFixture]
    public class ResultTests
    {
        [Test]
        public void GivenSuccess_IsSuccesShouldReturn_True()
        {
            var result = ReturnSuccessWithString(string.Empty);
            Assert.That(result.IsSuccess, Is.True);
        }

        [Test]
        public void GivenSuccess_UnwrapShouldReturn_test()
        {
            const string expected = "test";
            var result = ReturnSuccessWithString(expected).ToSuccess();
            Assert.That(result.Unwrap(), Is.EqualTo(expected));
        }

        [Test]
        public void GivenFailure_IsSuccessShouldReturn_False()
        {
            var result = ReturnFailureWithString(string.Empty);
            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void GivenFailure_UnwrapShouldReturn_test()
        {
            const string expected = "test";
            var result = ReturnFailureWithString(expected).ToFailure();
            Assert.That(result.Unwrap(), Is.EqualTo(expected));
        }
        
        private static Result<string> ReturnSuccessWithString(string value)
        {
            return ResultFactory.CreateSuccess(value);
        }

        private static Result<string> ReturnFailureWithString(string value)
        {
            return ResultFactory.CreateFailure<string>(value);
        }
    }
}