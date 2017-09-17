using System;
using NUnit.Framework;

namespace Result.Test
{
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