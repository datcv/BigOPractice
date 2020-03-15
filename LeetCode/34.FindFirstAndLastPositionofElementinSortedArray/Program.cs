using System;

namespace _34.FindFirstAndLastPositionofElementinSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = SearchRange(new int[]{1,2,3,4,5,5,5,5,5,6,7,7,8}, 5);
            Console.WriteLine(string.Join(", ", f));
        }

        public static int[] SearchRange(int[] nums, int target)
        {
            int start = -1, end = -1;
            var foundIndex = BinarySearch(nums, target);

            if (foundIndex >= 0 && nums[foundIndex] == target)
            {
                end = foundIndex;
            }

            for (int i = end; i >= 0; i--)
            {
                if (nums[i] == target)
                {
                    start = i;
                }
                else
                {
                    break;
                }
            }

            return new int[] { start, end };
        }

        public static int BinarySearch(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] > target)
                {
                    right = mid;
                }
                else if (nums[mid] <= target)
                {
                    left = mid + 1;
                }
            }

            if (left < nums.Length && nums[left] == target)
            {
                return left;
            }

            return left - 1;
        }
    }
}
