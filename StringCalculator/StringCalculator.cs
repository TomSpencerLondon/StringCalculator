using NUnit.Framework.Constraints;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var result = 1;
            
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            return result;
        }
    }
}