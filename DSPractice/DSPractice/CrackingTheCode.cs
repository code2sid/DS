using System.Collections.Generic;
using System.Linq;

namespace DSPractice
{
    public class CrackingTheCode
    {
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

            var charArray = ransomNote.ToCharArray();
            for (int i = 0; i < charArray.Length - 1; i++)
            {
                if (hash.ContainsKey(charArray[i]))
                {
                    hash[charArray[i]]++;
                }
                else
                {
                    hash.Add(charArray[i], 1);
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

        public string[] ReturnStringPermutations(string s)
        {
            return null;
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

        public bool hasUniqueElements(string s)
        {
            // w/o additional data structures
            return false;
        }
    }
}