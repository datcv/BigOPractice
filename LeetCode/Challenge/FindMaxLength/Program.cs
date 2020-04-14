using System;
using System.Collections.Generic;

namespace FindMaxLength
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(FindMaxLength(new int[]{0,0,1,0,0,0,1,1}));
        }

        public static int FindMaxLength(int[] nums) {
            int count = 0, max = 0;
            var dict = new Dictionary<int, int>(){{0, -1}};
            for(var i = 0; i < nums.Length; i++)
            {
                count += (nums[i] == 0 ? -1 : 1);
                if (dict.ContainsKey(count)){
                    max = Math.Max(max, i - dict[count]);
                }
                else{
                    dict[count] = i;
                }
            }
            
            return max;
        }
    }
}
