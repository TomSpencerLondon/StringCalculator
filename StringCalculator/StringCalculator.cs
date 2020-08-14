using System;
using System.Collections.Generic;
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
            List<String> regex = new List<string>(new string[]{",", "\\n"});
            StringBuilder result = new StringBuilder();

            if (numbers.StartsWith("//"))
            {
            }
            
            result.Append(numbers);
            
            return result.ToString()
                .Split(regex.ToArray(), StringSplitOptions.None)
                .Select(x => x.Trim())
                .Select(c => c.ToString())
                .ToArray()
                .Where(x => x.Length > 0)
                .Select(int.Parse)
                .Sum();
        }
    }
}