using System;

namespace _12.IntegerToRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            const int num = 1994;
            Console.WriteLine($"{num} = {IntToRoman(num)}");
        }

        public static string IntToRoman(int num) {
            var arr = new char[] {'I', 'V', 'X','L','C','D','M'};
            var stack = new System.Collections.Generic.Stack<char>();
            var oneIndex = 0;
            var fiveIndex = 1;
            var tenIndex = 2;

            while(num > 0)
            {
                var mod = num % 10;                
                switch(mod)
                {
                    case 4:
                        stack.Push(arr[fiveIndex]);
                        stack.Push(arr[oneIndex]);
                    break;
                    case 9:
                        stack.Push(arr[tenIndex]);
                        stack.Push(arr[oneIndex]);
                    break;

                    default:
                        for (int i = 0; i < mod % 5; i++)
                        {
                            stack.Push(arr[oneIndex]);
                        }

                        if (mod >= 5)
                        {
                            stack.Push(arr[fiveIndex]);
                        }
                    break;
                }
                
                num /= 10;

                oneIndex += 2;
                fiveIndex += 2;
                tenIndex += 2;
            }

            var charArr = new char[stack.Count];
            
            for (int i = 0; i < charArr.Length; i++)
            {
                charArr[i] = stack.Pop();
            }
            
            return new string(charArr);
        }
    }
}
