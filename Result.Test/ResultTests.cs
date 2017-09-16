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
        [Test]
        public void GivenSuccess_IsSuccesShouldReturnTrue()
        {
            const string response = "test";
            var result = ResultFactory.CreateSuccess(response);
            Assert.That(result.IsSuccess, Is.True);
        }
    }
}