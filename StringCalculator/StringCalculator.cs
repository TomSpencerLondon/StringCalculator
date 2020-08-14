using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using NUnit.Framework.Constraints;

namespace StringCalculator
{
    public class StringCalculator
    {
        private List<string> _regex = new List<string>(new string[]{",", "\\n"});


        public int Add(string input)
        {
            
            StringBuilder result = new StringBuilder();
            
            if (input.StartsWith("//"))
            {
                ExtractNumbersFrom(input, result);
            }else{
                result.Append(input);
            }

            return result.ToString()
                .Split(_regex.ToArray(), StringSplitOptions.None)
                .Select(x => x.Trim())
                .Select(c => c.ToString())
                .ToArray()
                .Where(x => x.Length > 0)
                .Select(int.Parse)
                .Sum();
        }

        private void ExtractNumbersFrom(string numbers, StringBuilder result)
        {
            int startNumbers = numbers.IndexOf(@"\n", StringComparison.Ordinal) + 2;
            var startCustomDelimiter = numbers.IndexOf("//") + 2;
            int length = numbers.Length - (startNumbers + startCustomDelimiter);
            string toAdd = numbers.Substring(startCustomDelimiter, length);
            _regex.Add(toAdd);
            var numbersLength = numbers.Length - startNumbers;
            result.Append(numbers.Substring(startNumbers, numbersLength));
        }
    }
}