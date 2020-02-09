using System;

namespace ZeroMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[5][]{
                new int[]{1, 2, 3, 4},
                new int[]{5, 0, 7, 8},
                new int[]{9, 10, 11, 12},
                new int[]{13, 14, 0, 16},
                new int[]{1, 2, 3, 4, },
            };

            PrintArray(arr);

            Console.WriteLine("Output: ");
            BetterZeroMatrix(arr);
            PrintArray(arr);

            
        }

        private static void ZeroMatrix(int [][] arr, int m, int n){
            var zeroIndexes = new System.Collections.Generic.List<Tuple<int, int>>();
            for (int i = 0; i < arr.Length; i++)
            {
              for (int j = 0; j < arr[i].Length; j++)
              {
                  if (arr[i][j] == 0)
                  {
                      zeroIndexes.Add(Tuple.Create(i, j));
                  }
              }
            }

            foreach (var index in zeroIndexes)
            {
                for (var i = 0; i < arr.Length; i++)
                {
                    arr[i][index.Item2] = 0;
                }
                
                for (var i = 0; i < arr[0].Length; i++)
                {
                    arr[index.Item1][i] = 0;
                }
            }
        }

        // Reduce space complexity to O(1)
        private static void BetterZeroMatrix(int [][] arr){
            var firstRowHasZero = false;
            var firstColHasZero = false;

            var colCount = arr[0].Length;
            for (int i = 0; i < colCount; i++)
            {
                if (arr[0][i] == 0) {
                    firstRowHasZero = true;
                    break;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i][0] == 0) {
                    firstColHasZero = true;
                    break;
                }
            }

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 1; j < colCount; j++)
                {
                    if (arr[i][j] == 0){
                        arr[i][0] = 0;
                        arr[0][j] = 0;
                    }
                }
            }

            for (int i = 0; i < colCount; i++)
            {
                if (arr[0][i] == 0) {
                    ClearColumn(arr, i);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i][0] == 0) {
                    ClearRow(arr, i);
                }
            }

            if (firstColHasZero){
                ClearColumn(arr, 0);
            }

            if (firstRowHasZero){
                ClearRow(arr, 0);
            }
        }

        private static void ClearRow(int[][] arr, int rowIndex){
             for (int i = 0; i < arr[0].Length; i++)
            {
                arr[rowIndex][i] = 0;
            }
        }

        private static void ClearColumn(int[][] arr, int colIndex){
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i][colIndex] = 0;
            }
        }

        private static void PrintArray(int[][] a){
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(string.Join('\t', a[i]));
            }
        }
    }
}
