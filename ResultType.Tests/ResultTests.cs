namespace ResultType.Tests
{
    using System;
    using NUnit.Framework;
    using ResultType;
    using static TestHelpers;

    [TestFixture]
    public class ResultTests
    {
        [Test]
        public void GivenVoidFunction_WhenFunctionReturnsEmptySuccess_IsSuccessReturnsTrue() => 
            Assert.That(ReturnSuccessWithNothing().IsSuccess(), Is.True);
        
        [Test]
        public void GivenVoidFunction_WhenFunctionReturnsEmptyError_IsErrorReturnsTrue() => 
            Assert.That(ReturnErrorWithNothing("").IsError(), Is.True);

        [Test]
        public void GivenVoidFunction_WhenFunctionReturnsEmptySuccess__GetValueReturnsNothing() => 
            Assert.That(ReturnSuccessWithNothing().GetValue(), Is.TypeOf<Nothing>());

        [Test]
        public void WhenFunctionReturnsSuccess_IsSuccessReturns_True() => 
            Assert.That(ReturnSuccessWithString(string.Empty).IsSuccess(), Is.True);

        [Test]
        public void WhenFunctionReturnsSuccess_GetValueReturns_test()
        {
            const string expected = "test";
            var result = ReturnSuccessWithString(expected).GetValue();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WhenFunctionReturnsSuccess_GetError_ThrowsInvalidOperationException() => 
            Assert.Catch<InvalidOperationException>(() => ReturnSuccessWithString(string.Empty).GetError(), "Success do not have error message!");

        [Test]
        public void GivenVoidFunction_WhenFunctionReturnsEmptyError_IsSuccessReturnsFalse() => 
            Assert.That(ReturnErrorWithNothing(string.Empty).IsSuccess(), Is.False);

        [Test]
        public void WhenFunctionReturnsError_IsSuccessReturnsFalse() => 
            Assert.That(ReturnErrorWithString(string.Empty).IsSuccess(), Is.False);

        [Test]
        public void WhenFunctionReturnsError_GetErrorReturns_test()
        {
            const string expected = "test";
            var result = ReturnErrorWithString(expected).GetError();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void WhenFunctionReturnsError_GetValueThrowsInvalidOperationException() => 
            Assert.Catch<InvalidOperationException>(() => ReturnErrorWithString("").GetValue(), "Error do not contain value!");
    }
}