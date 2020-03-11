using System;
using System.Collections.Generic;

namespace _994.RottingOranges
{
    class Program
    {
        static void Main(string[] args)
        {

            var r = new int[3][];
            r[0] = new int[] { 2, 1, 1 };
            r[1] = new int[] { 1, 1, 0 };
            r[2] = new int[] { 0, 1, 1 };

            Console.WriteLine(OrangesRotting(r));
        }

        public static int OrangesRotting(int[][] grid)
        {

            var freshCount = 0;

            var queue = new Queue<Tuple<int, int>>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue(Tuple.Create(i, j));
                    }
                    else if (grid[i][j] == 1)
                    {
                        freshCount++;
                    }
                }
            }

            if (freshCount == 0)
            {
                return 0;
            }

            var levelCount = queue.Count;
            var time = 0;
            var travelItem = 0;
            var hasFound = false;
            while (queue.Count > 0 && freshCount > 0)
            {
                var r = queue.Dequeue();
                travelItem++;
                var i = r.Item1;
                var j = r.Item2;
                if (i + 1 < grid.Length && grid[i + 1][j] == 1)
                {
                    grid[i + 1][j] = 2;
                    queue.Enqueue(Tuple.Create(i + 1, j));
                    freshCount--;
                    hasFound = true;
                }

                if (j + 1 < grid[i].Length && grid[i][j + 1] == 1)
                {
                    grid[i][j + 1] = 2;
                    queue.Enqueue(Tuple.Create(i, j + 1));
                    freshCount--;
                    hasFound = true;
                }

                if (i - 1 >= 0 && grid[i - 1][j] == 1)
                {
                    grid[i - 1][j] = 2;
                    queue.Enqueue(Tuple.Create(i - 1, j));
                    freshCount--;
                    hasFound = true;
                }

                if (j - 1 >= 0 && grid[i][j - 1] == 1)
                {
                    grid[i][j - 1] = 2;
                    queue.Enqueue(Tuple.Create(i, j - 1));
                    freshCount--;
                    hasFound = true;
                }


                if (travelItem == levelCount || (hasFound && freshCount <= 0))
                {
                    time++;
                    travelItem = 0;
                    levelCount = queue.Count;
                }

            }

            if (freshCount > 0)
            {
                return -1;
            }

            return time;
        }
    }
}
