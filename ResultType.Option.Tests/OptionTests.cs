namespace ResultType.Option.Tests
{
    using System;
    using NUnit.Framework;
    using static NUnit.Framework.Assert;
    using static OptionFactory;
    
    [TestFixture]
    public class OptionTests
    {
        [Test]
        public void CreateNone_ReturnsNone()
        {
            IsInstanceOf<None<string>>(CreateNone<string>());
        }
        
        [Test]
        public void CreateSome_ReturnsSome()
        {
            IsInstanceOf<Some<string>>(CreateSome(""));
        }
        

        [Test]
        public void HasValue_GivenNone_ReturnsTrue()
        {
            var option = CreateNone<string>();
            
            IsFalse(option.HasValue());
        }
        
        [Test]
        public void HasValue_GivenSome_ReturnsTrue()
        {
            var option = CreateSome("");
            
            IsTrue(option.HasValue());
        }
        
        [Test]
        public void GetValue_GivenNone_ThrowsInvalidOperationException()
        {
            var option = CreateNone<string>();
            
            Throws<InvalidOperationException>(() => option.GetValue(), "Called GetValue() on None. None does not have a value!");
        }
        
        [Test]
        public void GetValue_GivenSome_ReturnsValue()
        {
            var option = CreateSome("Value");

            AreEqual(option.GetValue(), "Value");
        }
    }
}