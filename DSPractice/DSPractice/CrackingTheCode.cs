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

            var hash = new Dictionary<char,int>();

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

            for (var i = l; i <=lastIndex; i++)
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
            return false;
        }

        public string URLify(string str)
        {
            return null;
        }
        
        
    }
}