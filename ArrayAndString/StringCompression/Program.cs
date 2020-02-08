using System;

namespace StringCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Compress("aabcccccaaaf"));
            Console.WriteLine(Compress("aabcccccaaafde"));
        }

        private static string Compress(string s){
            if (s.Length <= 2){
                return s;
            }

            var sb = new System.Text.StringBuilder();
            var consecutiveCount = 0;
            var compressedCharCount = 0;
            for (int i = 1; i < s.Length; i++)
            {
                consecutiveCount++;
                if (i + 1 >= s.Length || s[i] != s[i + 1])
                {
                    sb.Append(s[i]);
                    sb.Append(consecutiveCount);
                    compressedCharCount += 1 + (int)Math.Log10(consecutiveCount) + 1;
                    consecutiveCount = 0;
                    if (compressedCharCount >= s.Length){
                        return s;
                    }
                }
            }

            return sb.ToString();
        }
    }
}
