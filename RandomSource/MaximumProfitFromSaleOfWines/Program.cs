using System;
using System.Collections.Generic;

namespace MaximumProfitFromSaleOfWines
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 2, 4, 6, 2, 5 };
            Console.WriteLine("Input: [" + string.Join(", ", input) + "]");
            Console.WriteLine("Max Profit: " + MaxProfit(input, 0, input.Length - 1));
        }

        private static IDictionary<string, int> profitDict = new Dictionary<string, int>();
        public static int MaxProfit(int[] prices, int l, int r)
        {
            string key = $"{l}#{r}";
            if (profitDict.TryGetValue(key, out var v))
            {
                return v;
            }

            if (l == r)
            {
                profitDict[key] = prices[l] * prices.Length;
            }
            else
            {
                profitDict[key] = Max(prices[l] * (l + prices.Length - r) + MaxProfit(prices, l + 1, r), prices[r] * (l + prices.Length - r) + MaxProfit(prices, l, r - 1));
            }

            return profitDict[key];
        }

        private static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
