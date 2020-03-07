using System;

namespace _55.JumpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanJump(new int[]{2, 3, 1, 1, 4}));
        }

        public static bool CanJump(int[] nums)
        {
            var finalIndex = nums.Length - 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (i + nums[i] >= finalIndex)
                {
                    finalIndex = i;
                }
            }

            return finalIndex == 0;
        }

        public static bool CanJump2(int[] nums)
        {
            if (nums.Length == 1)
            {
                return true;
            }

            var maxGo = -1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (maxGo >= nums.Length)
                {
                    return true;
                }

                if (nums[i] != 0)
                {
                    if (maxGo < i + nums[i])
                    {
                        maxGo = i + nums[i];
                    }
                }
                else if (maxGo <= i)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
