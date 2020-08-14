using NUnit.Framework;

namespace StringCalculator.Tests
{
    public class StringCalculatorShould
    {
        private StringCalculator _stringCalculator = new StringCalculator();
        
        [Test]
        public void CanInstantiateStringCalculator()
        {
            Assert.That(_stringCalculator, Is.TypeOf<StringCalculator>());
        }
    }
}