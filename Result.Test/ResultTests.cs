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
            Assert.That(result.IsSuccess(), Is.True);
        }

        [Test]
        public void GivenSuccess_GetValueShouldReturn_test()
        {
            const string expected = "test";
            var result = ReturnSuccessWithString(expected).GetValue();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GivenFailure_IsSuccessShouldReturn_False()
        {
            var result = ReturnFailureWithString(string.Empty);
            Assert.That(result.IsSuccess(), Is.False);
        }

        [Test]
        public void GivenError_GetErrorShouldReturn_test()
        {
            const string expected = "test";
            var result = ReturnFailureWithString(expected).GetError();
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void GivenError_WhenGetValueIsCalled_ShouldThrowInvalidCastException()
        {
            Assert.That(() => ReturnFailureWithString("").GetValue(), Throws.InstanceOf<InvalidCastException>());
        }
        
        [Test]
        public void GivenSuccess_WhenGetErrorIsCalled_ShouldThrowInvalidCastException()
        {
            Assert.That(() => ReturnSuccessWithString("").GetError(), Throws.InstanceOf<InvalidCastException>());
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