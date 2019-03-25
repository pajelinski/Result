
namespace ResultType.Tests
{
    using System.Threading.Tasks;
    using NUnit.Framework;
    using static TestHelpers;

    [TestFixture]
    public class TaskExtensionsTests
    {
        [Test]
        public async Task GivenTask_WhenContinuationReturnsSuccess_Continue_ExecutesContinuationAndReturnsSuccess()
        {
            var result = await Task.FromResult(ReturnSuccessWithNothing()).Continue(x => ReturnSuccessWithNothing());

            Assert.IsTrue(result.IsSuccess());
        }
        
        [Test]
        public async Task GivenTask_WhenContinuationReturnsDifferentTypeThanFirstAction_Continue_ExecutesContinuationAndReturnsSuccess()
        {
            var result = await Task.FromResult(ReturnSuccessWithNothing()).Continue(x => ReturnSuccessWithString("test"));

            Assert.IsTrue(result.IsSuccess());
            Assert.AreEqual("test", result.GetValue());
        }
        
        [Test]
        public async Task GivenTask_WhenContinuationReturnsError_Continue_ExecutesContinuationAndReturnsError()
        {
            var result = await Task.FromResult(ReturnSuccessWithNothing()).Continue(x => ReturnErrorWithNothing(""));

            Assert.IsTrue(result.IsError());
        }
        
        [Test]
        public async Task GivenTask_WhenFirstFunctionReturnsError_Continue_ExecutesContinuationAndReturnsError()
        {
            var result = await Task.FromResult(ReturnErrorWithNothing("")).Continue(x => ReturnSuccessWithNothing());

            Assert.IsTrue(result.IsError());
        }
        
        [Test]
        public async Task GivenTask_WhenTaskReturnsSuccessAndContinuationTakesNoArguments_Continue_ExecutesContinuationAndReturnsResult()
        {
            var result = await Task.FromResult(ReturnSuccessWithNothing()).Continue(ReturnSuccessWithNothing);

            Assert.IsTrue(result.IsSuccess());
        }
    }
}