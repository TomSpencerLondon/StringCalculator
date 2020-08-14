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
        [TestCase(@"1\n2,3", 6)]
        public void AddSingleNumbers(string numbers, int expected)
        {
            var output = _stringCalculator.Add(numbers);
            Assert.That(expected, Is.EqualTo(output));
        }
        
        [TestCase(@"//;\n1;2", 3)]
        [TestCase(@"//[***]\n1***2***3", 6)]
        public void AddWithCustomDelimiter(string input, int expected)
        {
            var output = _stringCalculator.Add(input);
        
            Assert.That(expected, Is.EqualTo(output));
        }
    }
}