using System;
using System.Collections.Generic;
namespace ValidateBalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" => " + IsBalancedParentheses(""));
            Console.WriteLine("((())) => " + IsBalancedParentheses("((()))"));
            Console.WriteLine("[()]{} => " + IsBalancedParentheses("[()]{}"));
            Console.WriteLine("({[)] => " + IsBalancedParentheses("({[)]"));

        }

        private static bool IsBalancedParentheses(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            var pairParenthesesDict = new Dictionary<char, char>()
            {
                {'(', ')'},
                {'[', ']'},
                {'{', '}'},
            };

            var stack = new Stack<char>();
            var i = 0;
            while (i < s.Length)
            {
                if (IsOpenParenthese(s[i], pairParenthesesDict))
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    var o = stack.Pop();
                    if (!IsPairParenthese(o, s[i], pairParenthesesDict))
                    {
                        return false;
                    }
                }

                i++;
            }

            return stack.Count == 0;
        }

        private static bool IsOpenParenthese(char c, IDictionary<char, char> pairDict)
        {
            return pairDict.ContainsKey(c);
        }

        private static bool IsPairParenthese(char o, char c, IDictionary<char, char> pairDict)
        {
            return pairDict.TryGetValue(o, out var closeParenthese) && closeParenthese == c;
        }
    }
}
