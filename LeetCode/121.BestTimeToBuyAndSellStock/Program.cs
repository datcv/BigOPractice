using System;

namespace _121.BestTimeToBuyAndSellStock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MaxProfit: " + MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
        }

        public static int MaxProfit(int[] prices)
        {

            var min = int.MaxValue;
            var maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }
                else if (prices[i] - min > maxProfit)
                {
                    maxProfit = prices[i] - min;
                }
            }

            return maxProfit;
        }
    }
}
