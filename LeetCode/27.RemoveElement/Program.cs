using System;

namespace _27.RemoveElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = RemoveElement(new int[]{1, 2, 2, 3, 4, 3}, 3);
            Console.WriteLine(t);
        }

        public static int RemoveElement(int[] nums, int val) 
        {
            int l = 0, r = nums.Length - 1;
            while(l <= r)
            {
                if (nums[l] != val && nums[r] == val)
                {
                    l++;
                    r--;
                }
                else if (nums[l] != val)
                {
                    l++;
                }
                else
                {
                    nums[l] = nums[r];
                    r--;
                }
            }
        
            return l;
        }
    }
}
