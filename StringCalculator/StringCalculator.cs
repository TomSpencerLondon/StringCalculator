using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                .Select(number =>
                {
                    if (number < 0)
                    {
                        throw new Exception("negatives not allowed");
                    }
                    if(number > 1000)
                    {
                        return 0;
                    }

                    return number;
                }).Sum();
        }

        private void ExtractNumbersFrom(string input, StringBuilder result)
        {
            int startNumbers = input.IndexOf(@"\n", StringComparison.Ordinal) + 2;
            var startCustomDelimiter = input.IndexOf("//", StringComparison.Ordinal) + 2;
            int numberLength = input.Length - startNumbers;
            
            int length = input.Length - (numberLength + startCustomDelimiter + 2);
            
            AddToRegex(input, startCustomDelimiter, length);
            
            AppendToResult(input, result, startNumbers);
        }

        private static void AppendToResult(string input, StringBuilder result, int startNumbers)
        {
            var numbersLength = input.Length - startNumbers;
            result.Append(input.Substring(startNumbers, numbersLength));
        }

        private void AddToRegex(string input, int startCustomDelimiter, int length)
        {
            string toAdd = input.Substring(startCustomDelimiter, length);
            if (toAdd.StartsWith("[")) {
                List<string> list = toAdd.ToCharArray().Select(c => c.ToString()).ToList()
                    .Where(x => !x.Equals("[") && !x.Equals("]")).ToList();
                    foreach (var s in list)
                    {
                        _regex.Add(s);
                    }
                    
            }else {
                _regex.Add(item: toAdd);
            }
        }
    }
}