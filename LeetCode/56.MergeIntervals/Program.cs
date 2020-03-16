using System;
using System.Collections.Generic;
using System.Linq;

namespace _56.MergeIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[][] { new[] { 1, 3 }, new[] { 2, 6 }, new[] { 8, 10 }, new[] { 15, 18 } };

            Console.WriteLine(string.Join(", ", arr.Select(x => $"[{x[0]}, {x[1]}]")));

            var mergedArr = Merge(arr);
            Console.WriteLine("Merged:");
            Console.WriteLine(string.Join(", ", mergedArr.Select(x => $"[{x[0]}, {x[1]}]")));
        }

        public static int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length <= 1)
            {
                return intervals;
            }

            var dict = new Dictionary<int, int>();

            var list = new List<int>();
            for (int i = 0; i < intervals.Length; i++)
            {
                var pair = intervals[i];
                if (dict.ContainsKey(pair[0]))
                {
                    dict[pair[0]]--;
                }
                else
                {
                    dict[pair[0]] = -1;
                    list.Add(pair[0]);
                }

                if (dict.ContainsKey(pair[1]))
                {
                    dict[pair[1]]++;
                }
                else
                {
                    dict[pair[1]] = 1;
                    list.Add(pair[1]);
                }
            }

            list.Sort();

            var finalList = new List<int[]>();
            int count = 0, start = 0;
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                count += dict[item];
                if (count == 0)
                {
                    finalList.Add(new int[] { list[start], item });
                    start = i + 1;
                }
            }

            return finalList.ToArray();
        }
    }
}
