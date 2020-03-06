using System;

namespace _75.SortColors
{
    class Program
    {
        static void Main(string[] args)
        {
            var colors = new int[]{2,0,1,2,1,0,0,0,2,1,1,1,1,1,1,1,1,1,0};
            SortColors(colors);
            Console.WriteLine(string.Join(", ", colors));
        }

        public static void SortColors(int[] nums)
        {
            int redIndex = 0, blueIndex = nums.Length - 1;
            var m = nums.Length / 2;
            var i = m;
            var d = true;
            var step = 1;
            bool beyondBlue = i > blueIndex;
            bool beyondRed = i < redIndex;
            while (!beyondBlue || !beyondRed)
            {
                if (i > blueIndex || i < redIndex || nums[i] == 1)
                {                    
                    i = d ? i + step : i - step;
                    step++;
                    d = !d;
                }
                else if (nums[i] == 0)
                {
                    Swap(nums, i, redIndex);
                    redIndex++;
                }
                else if (nums[i] == 2)
                {
                    Swap(nums, i, blueIndex);
                    blueIndex--;
                }

                if (!beyondBlue)
                {
                    beyondBlue = i > blueIndex;
                }

                if (!beyondRed)
                {
                    beyondRed = i < redIndex;
                }
            }

        }

        private static void Swap(int[] nums, int i, int j)
        {
            var t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
        }
    }
}
