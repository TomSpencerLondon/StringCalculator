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

        [Test]
        public void AddMethodReturnsZeroForEmptyString()
        {
            var result = _stringCalculator.Add("");
            Assert.That(result, Is.EqualTo(0));
        }

        [TestCase("1,1", 2)]
        [TestCase("2,2", 4)]
        [TestCase("2, 2, 2", 6)]
        public void AddSingleNumbers(string numbers, int output)
        {
            var result = _stringCalculator.Add(numbers);
            Assert.That(result, Is.EqualTo(output));
        }
    }
}