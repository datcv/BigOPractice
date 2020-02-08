using System;


/*
    One Away: There are three types of edits that can be performed on strings: insert a character, remove a character, or replace a character.
    Given two strings, write a function to check if they are one edit (or zero edits) away.
    Example:
    pale, ple   -> true
    pales, pale -> true
    pale, bale  -> true
    pale, bake  -> false
*/
namespace OneAway
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine(IsOneAway("pale", "ple"));     // True
           Console.WriteLine(IsOneAway("pales", "pale"));   // True
           Console.WriteLine(IsOneAway("pale", "bale"));    // True
           Console.WriteLine(IsOneAway("pale", "bake"));    // False
           Console.WriteLine(IsOneAway("pale22", "bale"));  // False
           Console.WriteLine(IsOneAway("pales", "bales"));  // True
        }

        public static bool IsOneAway(string s, string s2) {
            if (s.Length - s2.Length > 1 || s.Length - s2.Length < -1)
            {
                return false;
            }

            if (s.Length == s2.Length)
            {
                return IsReplaceOneAway(s, s2);
            }
           
            return s.Length > s2.Length ? IsInsertOneAway(s2, s) : IsInsertOneAway(s, s2);
        }

        private static bool IsReplaceOneAway(string s, string s2){
            bool foundDifferent = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s2[i]) {
                    if (foundDifferent){
                        return false;
                    }

                    foundDifferent = true;
                }
            }

            return true;
        }

        private static bool IsInsertOneAway(string s, string l){
            bool foundDifferent = false;
            int i = 0, j = 0;
            while (i < s.Length && j < l.Length)
            {
                if (s[i] == l[j]){
                    i++;
                    j++;
                }
                else {
                    j++;
                    if (foundDifferent){
                        return false;
                    }

                    foundDifferent = true;
                }
            }

            return true;
        }
    }
}
