using System;
using System.Collections.Generic;
using System.Linq;
namespace _39.CombinationSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var combinations = CombinationSum(new int[] {2, 3, 5}, 8);
            
            foreach (var combination in combinations)
            {
                Console.WriteLine("[" + string.Join(", ", combination) + "]");
            }
        }
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            if (candidates.Length == 0)
            {
                return new IList<int>[0];
            }

            Array.Sort(candidates);
            int maxIndex = candidates.Length - 1;
            for (int i = candidates.Length - 1; i >= 0; i--)
            {
                if (candidates[i] <= target)
                {
                    maxIndex = i;
                    break;
                }
            }

            if (maxIndex < 0)
            {
                return new IList<int>[0];
            }

            IList<IList<int>> resultList = new List<IList<int>>();
            var tempList = new List<int>();

            for (int i = 0; i <= maxIndex; i++)
            {
                BackTrack(tempList, i, candidates, maxIndex, target - candidates[i], resultList);
            }

            return resultList;

        }

        private static void BackTrack(IList<int> lst, int nextIndex, int[] candidates, int maxIndex, int target, IList<IList<int>> resultList)
        {
            if (target < 0)
            {
                return;
            }


            lst.Add(candidates[nextIndex]);

            if (target == 0)
            {
                resultList.Add(lst.ToList());
                lst.RemoveAt(lst.Count - 1);
                return;
            }

            for (int i = nextIndex; i <= maxIndex; i++)
            {
                BackTrack(lst, i, candidates, maxIndex, target - candidates[i], resultList);
            }

            if (lst.Count > 0)
            {
                lst.RemoveAt(lst.Count - 1);
            }
        }
    }
}
