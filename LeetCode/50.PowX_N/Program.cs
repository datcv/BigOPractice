using System;
using System.Collections.Generic;

namespace _50.PowX_N
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = MyPow(0.00001, 2147483647);
            // Console.WriteLine(p);
        }

        public static double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }

            var m = n > 0 ? n : -n;
            double r = x;
            int p = 1;

            var dict = new Dictionary<int, double>()
            {
                {1, r}
            };

            var list = new List<int>() { 1 };

            while (p < m / 2 - 1)
            {
                r *= r;
                p *= 2;
                dict[p] = r;
                list.Add(p);
                Console.WriteLine($"{p} -> {dict[p]}");
                // Console.WriteLine(r);
            }

            var remain = m - p;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var t = list[i];
                // Console.WriteLine($"{t} {remain}");
                while (remain >= t)
                {
                    remain -= t;
                    r *= dict[t];
                    // Console.WriteLine(dict[t]);
                }
            }

            return n > 0 ? r : 1 / r;
        }
    }
}
