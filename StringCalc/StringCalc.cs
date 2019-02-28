using System;
using System.Collections.Generic;
using System.Linq;

namespace Interviews.StringCalculator
{
    public class StringCalc
    {
        public int add(string input) {
            List<char> delimitingCharacters = new List<char>();
            delimitingCharacters.Add(',');
            delimitingCharacters.Add('\n');
            if (input.StartsWith("//", StringComparison.Ordinal)) {
                delimitingCharacters.Add(input[2]);
                input = input.Substring(4);
            }
            var split = input.Split(delimitingCharacters.ToArray());

            if(split.Any(s => s.Contains("-"))) {
                throw new ArgumentException();
            }

            return split
                .Select(Int32.Parse)
                .Sum();
        }
    }
}
