using System;

namespace StringRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsRotation2("waterbottle", "erbottlewat"));
            Console.WriteLine(IsRotation2("waterbottle", "erbottlewta"));
        }

        private static bool IsRotation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                if (CompareRotation(s1, s2, i))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CompareRotation(string s1, string s2, int index)
        {
            for (int i = 0; i < index; i++)
            {
                if (s1[i] != s2[s2.Length - index + i])
                {
                    return false;
                }
            }

            int j = 0;
            for (int i = index; i < s1.Length; i++)
            {
                if (s1[i] != s2[j++])
                {
                    return false;
                }
            }

            return true;
        }

        // Correct Answer For This Problem
        private static bool IsRotation2(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            var s1s1 = s1 + s1;
            return IsSubstring(s1s1, s2);
        }

        private static bool IsSubstring(string s1, string word)
        {
            return s1.Contains(word);
        }
    }
}
