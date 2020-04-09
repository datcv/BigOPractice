using System;

namespace BackspaceCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BackspaceCompare("y#fo##f", "y#fx#o##f"));
        }

        public static bool BackspaceCompare(string S, string T)
        {
            int s = S.Length - 1;
            int t = T.Length - 1;
            int sSkip = 0, tSkip = 0;
            while (s >= 0 && t >= 0)
            {
                if (S[s] == '#')
                {
                    sSkip++;
                    s--;
                }
                else if (sSkip > 0)
                {
                    sSkip--;
                    s--;
                }
                else if (T[t] == '#')
                {
                    tSkip++;
                    t--;
                }
                else if (tSkip > 0)
                {
                    tSkip--;
                    t--;
                } 
                else if (S[s--] != T[t--])
                {
                    return false;
                }
            }

            return !(IsAnyCharLeft(S, s, sSkip) || IsAnyCharLeft(T, t, tSkip));

        }

        private static bool IsAnyCharLeft(string str, int i, int skip)
        {
            while (i >= 0)
            {
                if (str[i] == '#')
                {
                    skip++;
                    i--;
                }
                else if (skip > 0)
                {
                    skip--;
                    i--;
                }
                else {
                    return true;
                }
            }

            return false;
        }
    }
}
