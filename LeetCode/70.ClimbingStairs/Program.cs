using System;
using System.Collections.Generic;

namespace _70.ClimbingStairs
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(ClimbStairs(2));
            Console.WriteLine(ClimbStairs(3));
            Console.WriteLine(ClimbStairs(4));
            Console.WriteLine(ClimbStairs(5));
            Console.WriteLine(ClimbStairs(6));
            Console.WriteLine(ClimbStairs(7));

        }

        public static int ClimbStairs(int n)
        {
            return ClimbStairsDP(n, new Dictionary<int, int>() { { -1, 0 }, { -2, 0 }, { 0, 1 } });
        }

        public static int ClimbStairsDP(int n, IDictionary<int, int> resultDict)
        {
            if (resultDict.TryGetValue(n, out var result))
            {
                return result;
            }

            resultDict[n - 1] = ClimbStairsDP(n - 1, resultDict);
            resultDict[n - 2] = ClimbStairsDP(n - 2, resultDict);
            return resultDict[n - 1] + resultDict[n - 2];
        }

    }
}
