using System;

namespace SortedSquareArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[]{-7, -1, 4, 8, 10};
            var output = SortedSquareArray(input);


            Console.WriteLine("Input: " + string.Join(", ", input));
            Console.WriteLine("Output: " + string.Join(", ", output));
        }

        private static int[] SortedSquareArray(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return null;
            }

            var squareArr = new int[arr.Length];
            int i = 0, j = arr.Length - 1, sIndex = squareArr.Length - 1;

            while (i <= j)
            {
                if (arr[i] * arr[i] > arr[j] * arr[j])
                {
                    squareArr[sIndex] = arr[i] * arr[i];
                    i++;
                }
                else
                {
                    squareArr[sIndex] = arr[j] * arr[j];
                    j--;
                }

                sIndex--;
            }

            return squareArr;
        }
    }
}
