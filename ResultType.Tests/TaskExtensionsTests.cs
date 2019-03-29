
namespace ResultType.Tests
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using static TestHelpers;

    [TestFixture]
    public class TaskExtensionsTests
    {
        [Test]
        public async Task WhenContinuationReturnsSuccess_Continue_ExecutesContinuationAndReturnsSuccess()
        {
            var result = await Task.FromResult(ReturnSuccessWithNothing()).Continue(x => ReturnSuccessWithNothing());

            Assert.IsTrue(result.IsSuccess());
        }
        
        [Test]
        public async Task WhenContinuationIsAsyncAndReturnsSuccess_Continue_ExecutesContinuationAndReturnsSuccess()
        {
            var result = await Task.FromResult(ReturnSuccessWithNothing()).Continue(x => Task.FromResult(ReturnSuccessWithNothing()));

            Assert.IsTrue(result.IsSuccess());
        }
        
        [Test]
        public async Task WhenContinuationReturnsDifferentTypeThanFirstAction_Continue_ExecutesContinuationAndReturnsSuccess()
        {
            var result = await Task.FromResult(ReturnSuccessWithNothing()).Continue(x => ReturnSuccessWithString("test"));

            Assert.IsTrue(result.IsSuccess());
            Assert.AreEqual("test", result.GetValue());
        }
        
        [Test]
        public async Task WhenContinuationReturnsError_Continue_ExecutesContinuationAndReturnsError()
        {
            var result = await Task.FromResult(ReturnSuccessWithNothing()).Continue(x => ReturnErrorWithNothing(""));

            Assert.IsTrue(result.IsError());
        }
        
        [Test]
        public async Task WhenFirstFunctionReturnsError_Continue_ExecutesContinuationAndReturnsError()
        {
            var result = await Task.FromResult(ReturnErrorWithNothing("")).Continue(x => ReturnSuccessWithNothing());

            Assert.IsTrue(result.IsError());
        }
        
        [Test]
        public async Task WhenTaskReturnsSuccessAndContinuationTakesNoArguments_Continue_ExecutesContinuationAndReturnsResult()
        {
            var result = await Task.FromResult(ReturnSuccessWithNothing()).Continue(ReturnSuccessWithNothing);

            Assert.IsTrue(result.IsSuccess());
        }
        
        [Test]
        public async Task WhenTaskReturnsSuccessAndAsyncContinuationTakesNoArguments_Continue_ExecutesContinuationAndReturnsResult()
        {
            var result = await Task.FromResult(ReturnSuccessWithNothing()).Continue(() => Task.FromResult(ReturnSuccessWithNothing()));

            Assert.IsTrue(result.IsSuccess());
        }
        
        [Test]
        public async Task WhenTaskReturnsErrorAndContinuationTakesNoArguments_Continue_ExecutesContinuationAndReturnsResult()
        {
            var result = await Task.FromResult(ReturnErrorWithNothing("test")).Continue(ReturnSuccessWithNothing);

            Assert.IsTrue(result.IsError());
            Assert.AreEqual("test", result.GetError());
        }
        
        [Test]
        public async Task WhenTaskReturnsErrorAndAsyncContinuationTakesNoArguments_Continue_ExecutesContinuationAndReturnsResult()
        {
            var result = await Task.FromResult(ReturnErrorWithNothing("test")).Continue(() => Task.FromResult(ReturnSuccessWithNothing()));

            Assert.IsTrue(result.IsError());
            Assert.AreEqual("test", result.GetError());
        }
    }
}