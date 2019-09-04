using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSPractice
{
    public class CrackingTheCode
    {
        ///////////////////////////////////////////////////////////////////////////////////////// day 1

        #region day1-Completed

        public static IEnumerable<IList<int>> ReturnDistinctPairs(int[] arr, int key)
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
            var l = new List<string>();
            Permutations(smallString, 0, smallString.Length - 1);
            _allPermutations.ForEach(p =>
            {
                if (bigString.Contains(p))
                {
                    l.Add(p);
                }
            });
            return l.ToArray();
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

            foreach (var ch in magazine)
            {
                if (hash.ContainsKey(ch))
                {
                    hash[ch] = 0;
                }
            }

            return !hash.Values.Any(v => v > 0);
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 2

        #region day2-2pendings

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

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 3

        #region day3-2pendings

        public bool HasUniqueElements(string s)
        {
            // w/o additional data structures
            return false;
        }

        public bool IsPermutationOfOtherString(string str1, string str2)
        {
            Permutations(str2, 0, str2.Length - 1);

            return _allPermutations.Any(p => p.Equals(str1));
        }

        public string URLify(string str)
        {
            return null;
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 4

        #region day4-isOneEdit

        private readonly Dictionary<string, string> _allPalindromePermutations = new Dictionary<string, string>();
        private readonly List<string> _allPermutations = new List<string>();

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

        public bool IsOneEditAway(string s1, string s2)
        {
            return false;
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 5

        #region day5-Completed

        public int StaircaseProblem(int step, int m)
        {
            return Fib(step + 1, m);
        }

        private static int Fib(int n, int m)
        {
            if (n <= 1)
                return n;
            var res = 0;
            for (var i = 1; i <= n && i <= m; i++)
            {
                res += Fib(n - i, m);
            }

            return res;
        }

        private int Fib(int n)
        {
            if (n <= 1)
                return n;
            return Fib(n - 1) + Fib(n - 2);
        }

        public string NaggaroVariableProblem(string s)
        {
            var c = s.ToCharArray();
            var o = new List<char>();
            const int bigSmallDif = (int) 'a' - (int) 'A';

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == '_')
                {
                    o.Add((char) ((int) c[i + 1] - bigSmallDif));
                    i++;
                }

                else if ((int) c[i] < 97)
                {
                    o.Add('_');
                    o.Add((char) ((int) c[i] + bigSmallDif));
                }

                else
                {
                    o.Add(c[i]);
                }
            }

            return new string(o.ToArray());
        }

        public string NaggaroStringCompression(string s)
        {
            var c = s.ToCharArray();
            Array.Sort(c);
            var d = new Dictionary<char, int>();
            var sb = new StringBuilder();
            foreach (var t in c)
            {
                if (!d.ContainsKey(t))
                {
                    d.Add(t, 1);
                }

                else
                {
                    d[t] += 1;
                }
            }

            foreach (var key in d.Keys)
            {
                sb.Append($"{key}{d[key]}");
            }

            return sb.ToString();
        }

        public string RepeatStringCompression(string s)
        {
            var c = s.ToCharArray();
            var sb = new StringBuilder();

            int i = 0, j = 0;
            while (j < c.Length)
            {
                if (c[i] == c[j])
                    j++;
                else
                {
                    sb.Append($"{c[i]}{j - i}");
                    i = j;
                }
            }

            sb.Append($"{c[i]}{j - i}");
            return sb.ToString();
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 6

        #region day6-Completed

        public static int[,] RotateMatrix(int[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var res = new int[m,n];
            for (var i = 0; i < m; i++)
            {
                var cntr = 0;
                for (var j = 0; j < n; j++)
                {
                    res[cntr++, n - i -1] = matrix[i, j];
                }
            }

            return res;
        }

        public static int[,] ZeroMatrix(int[,] matrix)
        {
            var d = new Dictionary<int, int>();
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 0)
                        d.Add(i, j);
                }
            }

            foreach (var k in d.Keys)
            {
                var row = k;
                for (var i = 0; i < n; i++)
                {
                    matrix[row, i] = 0;
                }

                var col = d[k];
                for (var i = 0; i < m; i++)
                {
                    matrix[i, col] = 0;
                }
            }

            return matrix;
        }

        public static int WaterTrap(int[] building)
        {
            var l = new int[building.Length];
            var r = new int[building.Length];

            l[0] = building[0];
            for (var i = 1; i < l.Length; i++)
            {
                l[i] = Math.Max(l[i - 1], building[i]);
            }

            r[r.Length - 1] = building[building.Length - 1];
            for (var i = r.Length - 2; i >= 0; i--)
            {
                r[i] = Math.Max(r[i + 1], building[i]);
            }

            var water = 0;
            for (var i = 0; i < building.Length; i++)
            {
                water += Math.Min(l[i], r[i]) - building[i];
            }

            return water;
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 7

        #region day7

        public class Node
        {
            public Node next { get; set; }
            private string value { get; set; }

            public Node(string val, Node nxt)
            {
                next = nxt;
                value = val;
            }
        }

        public static Node DeleteMiddleNode(Node head)
        {
            if (head == null || head.next == null)
                return null;
            
            var f_pt = head;
            var s_pt = head;
            Node prev = null;

            while (f_pt != null && f_pt.next != null)
            {
                f_pt = f_pt.next.next;
                prev = s_pt;
                s_pt = s_pt.next;
            }

            prev.next = s_pt.next;

            return head;
            
            return head;
        }

        public static Node DeleteDups(Node head)
        {
            return head;
        }

        public static Node ReturnKthToLast(Node head)
        {
            return head;
        }

        #endregion
        ///////////////////////////////////////////////////////////////////////////////////////// day 8
    }
}