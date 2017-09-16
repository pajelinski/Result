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

    public interface Result
    {
        bool IsSuccess { get; }
    } 

    public class Success<T>: Result
    {
        public Success(T value)
        {
            IsSuccess = true;
        }

        public bool IsSuccess { get; }
    }

    [TestFixture]
    public class ResultTests
    {
        public Result ReturnSuccessWithString(string value)
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