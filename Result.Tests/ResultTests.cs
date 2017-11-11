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
            public void GivenVoidFunction_WhenFunctionReturnsEmptySuccess_IsSuccessReturnsTrue()
            {
                Assert.That(ReturnSuccessWithNothing().IsSuccess(), Is.True);
            }

            [Test]
            public void GivenVoidFunction_WhenFunctionReturnsEmptySuccess__GetValueReturnsNothing()
            {
                Assert.That(ReturnSuccessWithNothing().GetValue(), Is.TypeOf<Nothing>());
            }

            [Test]
            public void WhenFunctionReturnsSuccess_IsSuccessReturns_True()
            {
                Assert.That(ReturnSuccessWithString(string.Empty).IsSuccess(), Is.True);
            }

            [Test]
            public void WhenFunctionReturnsSuccess_GetValueReturns_test()
            {
                const string expected = "test";
                var result = ReturnSuccessWithString(expected).GetValue();
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenFunctionReturnsSuccess_GetErrorThrowsInvalidCastException()
            {
                Assert.That(() => ReturnSuccessWithString(string.Empty).GetError(), Throws.InstanceOf<InvalidCastException>());
            }
        }

        class Error
        {
            [Test]
            public void GivenVoidFunction_WhenFunctionReturnsEmptyError_IsSuccessReturnsFalse()
            {
                Assert.That(ReturnErrorWithNothing(string.Empty).IsSuccess(), Is.False);
            }

            [Test]
            public void WhenFunctionReturnsError_IsSuccessReturnsFalse()
            {
                Assert.That(ReturnErrorWithString(string.Empty).IsSuccess(), Is.False);
            }

            [Test]
            public void WhenFunctionReturnsError_GetErrorReturns_test()
            {
                const string expected = "test";
                var result = ReturnErrorWithString(expected).GetError();
                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenFunctionReturnsError_GetValueThrowsInvalidCastException()
            {
                Assert.That(() => ReturnErrorWithString("").GetValue(), Throws.InstanceOf<InvalidCastException>());
            }
        }
       
        private static Result<Nothing> ReturnSuccessWithNothing() => ResultFactory.CreateSuccess();

        private static Result<Nothing> ReturnErrorWithNothing(string errorMessage) => ResultFactory.CreateError(errorMessage);

        private static Result<string> ReturnSuccessWithString(string value) => ResultFactory.CreateSuccess(value);

        private static Result<string> ReturnErrorWithString(string errorMessage) => ResultFactory.CreateError<string>(errorMessage);
    }
}