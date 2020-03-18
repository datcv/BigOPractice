using System;
using System.Linq;
using System.Collections.Generic;

namespace _830.PositionsOfLargeGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = LargeGroupPositions("abcdddeeeeaabbbcd");

            var s = String.Join(", ", groups.Select(x => $"[{x[0]}, {x[1]}]"));

            Console.WriteLine(s);
        }

        public static IList<IList<int>> LargeGroupPositions(string S)
        {
            var result = new List<IList<int>>();
            int start = 0;
            for (int i = 1; i < S.Length; i++)
            {
                if (S[i] != S[start])
                {
                    if (i - start >= 3)
                    {
                        result.Add(new[] { start, i - 1 });
                    }

                    start = i;
                }
            }

            if (S.Length - start >= 3)
            {
                result.Add(new[] { start, S.Length - 1 });
            }

            return result;
        }
    }
}
