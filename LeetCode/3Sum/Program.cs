using System;
using System.Collections.Generic;
namespace _3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 };
            Console.WriteLine("3Sum of [" + string.Join(" ", nums) + "]");
            foreach (var item in ThreeSum(nums))
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var numHash = new Dictionary<int, IList<int>>();
            var pairHash = new HashSet<string>();
            var list = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numHash.TryGetValue(nums[i], out var l))
                {
                    if (l.Count < 3)
                        l.Add(i);
                }
                else
                {
                    numHash[nums[i]] = new List<int>() { i };
                }
            }

            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    var sum2 = -(nums[i] + nums[j]);
                    if (!numHash.TryGetValue(sum2, out var l))
                    {
                        continue;
                    }

                    if (l[l.Count - 1] <= j)
                    {
                        continue;
                    }

                    var min = Min(nums[i], nums[j], sum2);
                    var max = Max(nums[i], nums[j], sum2);

                    if (!pairHash.Contains($"{min}#{max}"))
                    {
                        pairHash.Add($"{min}#{max}");
                        list.Add(new List<int>() { min, max, 0 - min - max });
                    }
                }
            }

            return list;
        }

        private static int Min(int a, int b, int c)
        {
            var min = a;
            if (min > b)
                min = b;
            if (min > c)
                min = c;

            return min;
        }

        private static int Max(int a, int b, int c)
        {
            var max = a;
            if (max < b)
                max = b;
            if (max < c)
                max = c;

            return max;
        }
    }
}
