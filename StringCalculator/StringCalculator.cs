using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using NUnit.Framework.Constraints;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            StringBuilder result = new StringBuilder();

            result.Append(numbers);

            return result.ToString()
                .Split(new string[]{",", "\\n"}, StringSplitOptions.None)
                .Select(x => x.Trim())
                .Select(c => c.ToString())
                .ToArray()
                .Where(x => x.Length > 0)
                .Select(int.Parse)
                .Sum();
        }
    }
}