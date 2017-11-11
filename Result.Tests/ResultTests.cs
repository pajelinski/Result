using System;
using NUnit.Framework;

namespace Result.Test
{
    [TestFixture]
    public class ResultTests
    {
        class Sucess
        {
            [Test]
            public void GivenSuccess_IsSuccessReturns_True()
            {
                var result = ReturnSuccessWithString(string.Empty);
                Assert.That(result.IsSuccess(), Is.True);
            }

            [Test]
            public void GivenSuccess_GetValueReturns_test()
            {
                const string expected = "test";
                var result = ReturnSuccessWithString(expected).GetValue();
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void GivenSuccess_WhenGetErrorIsCalled_ThrowsInvalidCastException()
            {
                Assert.That(() => ReturnSuccessWithString("").GetError(), Throws.InstanceOf<InvalidCastException>());
            }
        }

        class Error
        {
            [Test]
            public void GivenFailure_IsSuccessReturns_False()
            {
                var result = ReturnErrorWithString(string.Empty);
                Assert.That(result.IsSuccess(), Is.False);
            }

            [Test]
            public void GivenError_GetErrorReturns_test()
            {
                const string expected = "test";
                var result = ReturnErrorWithString(expected).GetError();
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void GivenError_WhenGetValueIsCalled_ThrowsInvalidCastException()
            {
                Assert.That(() => ReturnErrorWithString("").GetValue(), Throws.InstanceOf<InvalidCastException>());
            }
        }

        private static Result<string> ReturnSuccessWithString(string value)
        {
            return ResultFactory.CreateSuccess(value);
        }

        private static Result<string> ReturnErrorWithString(string value)
        {
            return ResultFactory.CreateError<string>(value);
        }
    }
}