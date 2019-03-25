namespace ResultType.Tests
{
    using NUnit.Framework;
    using static TestHelpers;
    
    [TestFixture]
    public class ContinueTests
    {
        [Test]
        public void WhenContinuationFunctionReturnsSuccess_IsSuccessReturnsTrue()
        {
            var result = ReturnSuccessWithNothing().Continue(ReturnSuccessWithNothing);
            Assert.That(result.IsSuccess(), Is.True);
        }

        [Test]
        public void WhenContinuationFunctionReturnsError_IsSuccessReturnsFalse()
        {
            var result = ReturnSuccessWithNothing().Continue(() => ReturnErrorWithNothing(string.Empty));
            Assert.That(result.IsSuccess(), Is.False);
        }

        [Test]
        public void WhenContinuationFunctionReturnsSuccess_GetValueReturns_test2()
        {
            var result = ReturnSuccessWithString("test1").Continue(() => ReturnSuccessWithString("test2"));
            Assert.That(result.GetValue, Is.EqualTo("test2"));
        }

        [Test]
        public void WhenContinuationFunctionPassPreviousResult_GetValueReturns_test()
        {
            var result = ReturnSuccessWithString("test1").Continue(PassValue);
            Assert.That(result.GetValue, Is.EqualTo("test1"));
        }

        [Test]
        public void GivenThatFirsResultIsError_WhenContinuationFunctionPassPreviousResult_GetValueReturns_error()
        {
            var result = ReturnErrorWithString("error").Continue(PassValue);
            Assert.That(result.GetError, Is.EqualTo("error"));
        }

        [Test]
        public void GivenContinuationWithDifferentReturnTypeThanFirstAction_ContinueReturnsResultOfContinuation()
        {
            var result = ReturnSuccessWithNothing().Continue(x => ReturnSuccessWithString("test1"));
            Assert.That(result.GetValue, Is.EqualTo("test1"));
        }
        
        [Test]
        public void GivenContinuationWithDifferentReturnTypeThanFirstAction_WhenContinuationDoNotTakesResultFromFirstAction_ContinueWithReturnsResultOfContinuation()
        {
            var result = ReturnSuccessWithNothing().Continue(() => ReturnSuccessWithString("test1"));
            Assert.That(result.GetValue, Is.EqualTo("test1"));
        }
        
        [Test]
        public void GivenContinuationWithDifferentReturnTypeThanFirstAction_WhenContinuationRetrunsError_ContinueWithReturnsResultOfContinuation()
        {
            var result = ReturnSuccessWithNothing().Continue(x => ReturnErrorWithString("test1"));
            Assert.That(result.GetError(), Is.EqualTo("test1"));
        }
        
        [Test]
        public void GivenContinuationWithDifferentReturnTypeThanFirstAction_WhenContinuationDoNotTakesResultFromFirstActionAndReturnsError_ContinueWithReturnsResultOfContinuation()
        {
            var result = ReturnSuccessWithNothing().Continue(() => ReturnErrorWithString("test1"));
            Assert.That(result.GetError(), Is.EqualTo("test1"));
        }
    }
}