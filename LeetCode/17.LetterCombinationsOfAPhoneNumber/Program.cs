using System;
using System.Collections.Generic;
using System.Linq;
namespace _17.LetterCombinationsOfAPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "237";
            Console.WriteLine($"Input: {input}");
            var l = LetterCombinations(input);
            Console.WriteLine($"Output: " + string.Join(", ", l));
            
        }
        public static IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return new List<string>();
            }

            var digitToChars = new Dictionary<char, char[]>()
            {
                {'2', new char[3] {'a', 'b', 'c'}},
                {'3', new char[3] {'d', 'e', 'f'}},
                {'4', new char[3] {'g', 'h', 'i'}},
                {'5', new char[3] {'j', 'k', 'l'}},
                {'6', new char[3] {'m', 'n', 'o'}},
                {'7', new char[4] {'p', 'q', 'r', 's'}},
                {'8', new char[3] {'t', 'u', 'v'}},
                {'9', new char[4] {'w', 'x', 'y', 'z'}},
            };

            var lst = new List<string>();
            CombinationBackTrack(new char[digits.Length], 0, digits, digitToChars, lst);
            return lst;
        }


        private static void CombinationBackTrack(char[] combinationArr, int nextDigit, string digits, IDictionary<char, char[]> charMap, IList<string> combinationLists)
        {
            if (nextDigit == digits.Length)
            {
                combinationLists.Add(new string(combinationArr));
            }
            else
            {       
                if (charMap.TryGetValue(digits[nextDigit], out var charArr))
                {
                    for (int i = 0; i < charArr.Length; i++)
                    {
                        combinationArr[nextDigit] = charArr[i];
                        CombinationBackTrack(combinationArr, nextDigit + 1, digits, charMap, combinationLists);                        
                    }
                }
            }
        }
    }
}
