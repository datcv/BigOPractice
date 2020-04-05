using System;
using System.Collections.Generic;

namespace MaximumSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxSubArray(new int[]{1, -1, 1}));
        }

        public static int MaxSubArray(int[] nums) {
            var maxSum = nums[0];
            var currentMax = maxSum;
            for (var i = 1; i < nums.Length; i++)
            {
                currentMax = Max(currentMax + nums[i], nums[i]);
                maxSum = Max(maxSum, currentMax);
            }
            
            return maxSum;
        }

        private static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
