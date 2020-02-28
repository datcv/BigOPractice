using System;

namespace _238.ProductOfArrayExceptSelf
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArr = new int[]{1, 2, 3, 4, 9};
            var outputArr = ProductExceptSelf(inputArr);

            Console.WriteLine("Input: [" + string.Join(", ", inputArr) + "]");
            Console.WriteLine("Output: [" + string.Join(", ", outputArr) + "]");
        }


        public static int[] ProductExceptSelf(int[] nums)
        {
            var arr = new int[nums.Length];
            int c = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                arr[i] = c;
                c *= nums[i];
            }

            c = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                arr[i] *= c;
                c *= nums[i];
            }

            return arr;
        }
    }
}
