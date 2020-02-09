using System;

namespace RotateMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            // var arr = new int[n][]{
            //     new int[]{1, 2, 3, 4},
            //     new int[]{5, 6, 7, 8},
            //     new int[]{9, 10, 11, 12},
            //     new int[]{13, 14, 15, 16},
            // };

            var arr = new int[n][]{
                new int[]{1, 2, 3, 4, 0},
                new int[]{5, 6, 7, 8, 0},
                new int[]{9, 10, 11, 12, 0},
                new int[]{13, 14, 15, 16, 0},
                new int[]{1, 2, 3, 4, 5},
            };

            arr = BetterRotate90(arr, n);
            PrintArray(arr, n);
        }

        private static int[][] Rotate90(int[][] a, int n) {
            var arr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                arr[i] = new int[n];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // var t = a[j][n - i - 1];
                    // a[j][n - i - 1] = a[i][j];
                    // a[i][j] = t;
                    arr[j][n - i - 1] = a[i][j];
                }
            }

            return arr;
        }

        /*
            Space complexity is O(1)
        */
        private static int[][] BetterRotate90(int[][] arr, int n) {
            int iMax = n -1;
            int iFirst = 0;
            int jFirst = 0;
            for (int i = iFirst; i < iMax; i++, iFirst++, jFirst++, iMax--)
            {
                for (int j = jFirst; j < iMax; j++)
                {
                    var top = arr[i][j];
                    arr[i][j] = arr[n -1 - j][i]; // Top = left
                    arr[n -1 - j][i] = arr[n -1 - i][n -1 - j];// Left = bottom
                    arr[n -1 - i][n -1 - j] = arr[j][n -1 - i];//  bottom = right
                    arr[j][n -1 - i] = top;
                }
            }

            return arr;
        }   

        private static void PrintArray(int[][] a, int n){
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", a[i]));
            }
        }
    }
}
