using System;

namespace _35.SearchInsertPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArr = new int[]{1, 2, 5, 6};
            var target = 7;
            
            Console.WriteLine("Input: [" + string.Join(", ", inputArr) + "]" + $" - Tagert: {target}");
            Console.WriteLine($"Output: {SearchInsert(inputArr, target)}");            
        }

        public static int SearchInsert(int[] nums, int target)
        {
            int l = 0, r = nums.Length - 1;
            while (l < r)
            {
                var m = l + (r - l) / 2;
                if (nums[m] == target)
                {
                    return m;
                }
                else if (nums[m] > target)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }

            return nums[l] >= target ? l : l + 1;
        }
    }
}
