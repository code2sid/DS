using System;
using System.Collections.Generic;
using System.Linq;

namespace DSPractice
{
    public class CrackingTheCode
    {
        ///////////////////////////////////////////////////////////////////////////////////////// day 1
        public List<IList<int>> ReturnDistinctPairs(int[] arr, int key)
        {
            if (arr.Length == 0)
                return null;
            var hash = arr.ToDictionary(k => k);
            var list = new List<IList<int>>();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var l = new List<int>();
                if (hash.ContainsKey(arr[i] + key))
                {
                    l.Add(arr[i]);
                    l.Add(arr[i] + key);
                }
                else if (hash.ContainsKey(arr[i] - key))
                {
                    l.Add(arr[i]);
                    l.Add(arr[i] - key);
                }

                list.Add(l);
            }

            return list;
        }

        public string[] ReturnPossibleSubStrings(string bigString, string smallString)
        {
            return null;
        }

        public bool IsMagazineRansomNote(char[] magazine, string ransomNote)
        {
            if (string.IsNullOrEmpty(ransomNote) || magazine.Length == 0)
                return false;

            var hash = new Dictionary<char, int>();

            var ransomNoteArray = ransomNote.ToCharArray();
            for (int i = 0; i < ransomNoteArray.Length - 1; i++)
            {
                if (hash.ContainsKey(ransomNoteArray[i]))
                {
                    hash[ransomNoteArray[i]]++;
                }
                else
                {
                    hash.Add(ransomNoteArray[i], 1);
                }
            }

            foreach (var h in hash.Keys)
            {
                if (magazine.Contains(h))
                {
                    hash[h] = 0;
                }
            }

            return !hash.Values.Any(v => v > 0);
        }

        ///////////////////////////////////////////////////////////////////////////////////////// day 2
        public void ReturnStringAllPermutations(string s, int l, int lastIndex)
        {
            if (l == lastIndex)
                Console.WriteLine(s);

            for (var i = l; i <= lastIndex; i++)
            {
                s = swap.fnSwap(s, l, i);
                ReturnStringAllPermutations(s, l + 1, lastIndex);
                s = swap.fnSwap(s, l, i);
            }
        }

        public double ReturnMedian(int[] array)
        {
            return 0.0f;
        }

        public int[] ReturnElementsInCommon(int[] sortedArray1, int[] sortedArray2)
        {
            // same in length and distinct elements.
            return null;
        }

        ///////////////////////////////////////////////////////////////////////////////////////// day 3
        public bool HasUniqueElements(string s)
        {
            // w/o additional data structures
            return false;
        }

        public bool IsPermutationOfOtherString(string str1, string str2)
        {
            Permutations(str2, 0, str2.Length - 1);
            
            return _allPermutations.Any(p=>p.Equals(str1));
        }

        public string URLify(string str)
        {
            return null;
        }

        ///////////////////////////////////////////////////////////////////////////////////////// day 4

        private readonly Dictionary<string, string> _allPalindromePermutations = new Dictionary<string, string>();
        private readonly  List<string> _allPermutations = new List<string>();

        public Dictionary<string, string> ReturnAllPalindromePermutations(string s)
        {
            Permutations(s, 0, s.Length - 1);
            return _allPalindromePermutations;
        }

        private static bool IsPalindrome(string s)
        {
            var c = s.ToCharArray();
            for (var i = 0; i < c.Length / 2; i++)
            {
                swap.fnSwap(ref c[i], ref c[c.Length - i - 1]);
            }

            return s.Equals(new string(c));
        }

        private void Permutations(string s, int left, int right)
        {
            if (left == right)
            {
                var key = s.Replace(" ", "");
                _allPermutations.Add(key);
                if (!IsPalindrome(s))
                {
                    return;
                }

                ;

                if (!_allPalindromePermutations.ContainsKey(s))
                {
                    _allPalindromePermutations.Add(key, s);
                }
            }
            else
            {
                for (var i = left; i <= right; i++)
                {
                    s = swap.fnSwap(s, left, i);
                    Permutations(s, left + 1, right);
                    s = swap.fnSwap(s, left, i);
                }
            }
        }


        public string StringCompressions(string s)
        {
            return s;
        }

        public bool IsOneEditAway(string s1, string s2)
        {
            return false;
        }
    }
}