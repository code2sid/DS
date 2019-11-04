using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public bool IsMagazineRansomNote2(char[] m, string r)
        {
            foreach (var ch in m)
            {
                r = r.Replace(ch.ToString(), "");
                if (r.Length == 0)
                    return true;
            }

            return r.Length == 0;
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 2

        #region day2-ReturnMedian

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
            var d = sortedArray1.ToDictionary(k => k, v => 0);
            foreach (var s in sortedArray2)
            {
                if (d.ContainsKey(s))
                    d[s] += 1;
            }

            return d.Where(kvp => kvp.Value > 0).Select(s => s.Key).ToArray();
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 3

        #region day3-URLify

        public bool HasUniqueElements(string s)
        {
            // w/o additional data structures
            for (var i = 0; i < s.Length; i++)
            {
                for (var j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                    {
                        return false;
                    }
                }
            }

            return true;
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

        #region day4-Completed

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

        public static bool IsOneEditAway(string original, string edited)
        {
            var d = new ConcurrentDictionary<char, int>();
            foreach (var ch in original.ToCharArray())
            {
                d.AddOrUpdate(ch, 1, (key, existingValue) => existingValue + 1);
            }

            foreach (var ch in edited.ToCharArray())
            {
                if (!d.ContainsKey(ch))
                    d.AddOrUpdate(ch, 1, (k, val) => val++);
            }

            foreach (var k in d.Keys)
            {
                if (original.Contains(k))
                {
                    d[k] -= 1;
                }
            }

            return d.Values.Sum(k => k) == 1;
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
            
            var sb = new StringBuilder();
            const int bigSmallDif = (int) 'a' - (int) 'A';

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '_')
                {
                    sb.Append((char) ((int) s[i + 1] - bigSmallDif));
                    i++;
                }

                else if ((int) s[i] < 97)
                {
                    sb.Append('_');
                    sb.Append((char) ((int) s[i] + bigSmallDif));
                }

                else
                {
                    sb.Append(s[i]);
                }
            }

            return sb.ToString();
        }

        public string NaggaroStringCompression(string s)
        {
            Array.Sort(s.ToArray());
            return RepeatStringCompression(s);
        }

        public string RepeatStringCompression(string s)
        {
            var sb = new StringBuilder();

            int i = 0, j = 0;
            while (j < s.Length)
            {
                if (s[i] == s[j])
                    j++;
                else
                {
                    sb.Append($"{s[i]}{j - i}");
                    i = j;
                }
            }

            sb.Append($"{s[i]}{j - i}");
            return sb.ToString();
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 6

        #region day6-Completed

        public static int[,] RotateMatrix(int[,] matrix)
        {
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);
            var res = new int[m, n];
            for (var i = 0; i < m; i++)
            {
                var cntr = 0;
                for (var j = 0; j < n; j++)
                {
                    res[cntr++, n - i - 1] = matrix[i, j];
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
        /// <summary>
        /// Linked List
        /// </summary>

        #region day7-Completed

        public class Node
        {
            public Node next { get; set; }
            public string value { get; set; }
            public int intValue { get; set; }

            public Node(int intVal, Node nxt)
            {
                next = nxt;
                intValue = intVal;
            }

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
        }

        public static Node RemoveDuplicatesFromSortedLinkedListWithoutTempBuffer(Node sortedHead)
        {
            var pt = sortedHead;
            //temporary buffer is not allowed
            while (pt != null)
            {
                if (pt.next != null && pt.intValue == pt.next.intValue)
                {
                    pt.next = pt.next.next;
                }

                else
                    pt = pt.next;
            }

            return sortedHead;
        }

        public Node ReturnKthFromLast(Node head, int k)
        {
            var ptr = head;
            var m = GetNodeLength(head);
            var i = 0;
            while (m - i > k)
            {
                ptr = ptr.next;
                i++;
            }
            return ptr;
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 8

        #region day8-2Pendings

        public Node ReturnPartitionedLlAroundANumberWithSameOrder(Node head, int x)
        {
            return head;
        }

        public Node ReturnSumLl(Node node1, Node node2)
        {
            var sumNode = new Node("", null);
            return sumNode;
        }

        public bool IsLlPalindrome(Node head)
        {
            var slow = head;
            var s = new Stack<int>();
            var isPalim = true;

            while (slow != null)
            {
                s.Push(slow.intValue);
                slow = slow.next;
            }

            while (head != null)
            {
                if (s.Pop() == head.intValue)
                    isPalim = true;
                else
                    isPalim = false;

                head = head.next;
            }

            return isPalim;
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 9

        #region Day9-Completed

        public Node IntersectionNode(Node n1, Node n2)
        {
            int d, c1, c2;
            c1 = GetNodeLength(n1);
            c2 = GetNodeLength(n2);

            if (c1 > c2)
            {
                d = c1 - c2;
                return GetIntersection(n1, n2, d);
            }

            else
            {
                d = c2 - c1;
                return GetIntersection(n2, n1, d);
            }
        }

        private static Node GetIntersection(Node biggerNode, Node smallerNode, int d)
        {
            for (var i = 0; i < d; i++)
            {
                if (biggerNode == null)
                    return null;
                biggerNode = biggerNode.next;
            }

            while (biggerNode != null && smallerNode != null)
            {
                if (biggerNode == smallerNode)
                    return biggerNode;
                biggerNode = biggerNode.next;
                smallerNode = smallerNode.next;
            }

            return null;
        }

        private int GetNodeLength(Node n)
        {
            var i = 0;
            while (n != null)
            {
                i++;
                n = n.next;
            }

            return i;
        }

        public Node LoopDetectionOptimize(Node header)
        {
            var hash = new HashSet<Node>();
            while (header != null)
            {
                if (hash.Contains(header))
                    return header;
                hash.Add(header);
                header = header.next;
            }

            return null;
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////// day 10
        /// <summary>
        ///  Stacks
        /// </summary>

        #region Day10

        public void ThreeInOne(int[] arr)
        {
            
        }

        #region StackMin

        readonly Stack<int> _stackExample = new Stack<int>();
        private int _minEle = 0;
        
        public void StackPush(int n)
        {
            if (_stackExample.Count == 0)
            {
                _minEle = n;
                _stackExample.Push(n);
            }

            else if (n < _minEle)
            {
                _stackExample.Push(2*n - _minEle);
                _minEle = n;
            }

            else
            {
                _stackExample.Push(n);
            }
        }

        public int StackPop()
        {
            var t = _stackExample.Pop();

            if (t >= _minEle)
            {
                return t;
            }

            var retVal = _minEle;
            _minEle = 2 * _minEle - t;
            return retVal;

        }

        public int StackPeek()
        {
            var t = _stackExample.Peek();
            return t < _minEle ? _minEle : t;
        }
        
        public int StackMin()
        {
            return _minEle;
        }

        #endregion

        private int _counter = 0;
        public int Capacity { get; set; }
        private List<Stack<int>> _sets = new List<Stack<int>>();
        Stack<int> stack = new Stack<int>();
       
        public void StackOfPlatesPush(int ele)
        {
            if (_counter == 0 || _counter == Capacity)
            {
                _counter = 0;
                stack = new Stack<int>();
                _sets.Add(stack);
            }
            
            stack.Push(ele);
            _counter++;
        }
        public int StackOfPlatesPop()
        {
            if (_counter == 1)
                _counter = Capacity;
            
            else
                _counter--;
            
            return _sets.GetRange(_sets.Count - 1, 1)[0].Pop();
        }

        #endregion
        ///////////////////////////////////////////////////////////////////////////////////////// day 11

        #region QuqueUsing2Stacks-EnQueueCostly

        public Stack<int> st1 = new Stack<int>();
        public Stack<int> st2 = new Stack<int>();
        
        public void enQueueUsingStacks(int ele)
        {
            while (st1.Count > 0)
            {
                st2.Push(st1.Pop());
            }
            
            st1.Push(ele);

            while (st2.Count > 0)
            {
                st1.Push(st2.Pop());
            }
        }

        public int deQueueUsingStacks()
        {
            return st1.Pop();
        }
        

        #endregion

        #region QueueUsing2Stacks-DeQueueCostly-better

        public void enQueueUsingStacks1(int e)
        {
            st1.Push(e);
        }

        public int deQueueUsingStacks1()
        {
            while (st1.Count > 0)
            {
                st2.Push(st1.Pop());
            }

            return st2.Pop();
        }

        #endregion

        public Stack<int> SortStack(Stack<int> st)
        {
            var tmp = new Stack<int>();
            var e = 0;
            while (st.Count > 0)
            {
                e = st.Pop();
                while (tmp.Count > 0 && tmp.Peek() > e)
                {
                    st.Push(tmp.Pop());
                }
                
                tmp.Push(e);
                
            }
            return tmp;
        }
        ///////////////////////////////////////////////////////////////////////////////////////// day 12

        #region Day-12

        public 

        #endregion
        ///////////////////////////////////////////////////////////////////////////////////////// day 13
        ///////////////////////////////////////////////////////////////////////////////////////// day 14 
        ///////////////////////////////////////////////////////////////////////////////////////// day 15 


        #region Extras

        public static Node RemoveDuplicatesFromUnsortedLinkedListWithoutTempBuffer(Node head)
        {
            var pt1 = head;
            var pt2 = head;

            while (pt1 != null)
            {
                pt2 = pt1;
                while (pt2 != null)
                {
                    if (pt2.next != null && pt1.intValue == pt2.next.intValue)
                    {
                        pt2.next = pt2.next.next;
                    }

                    else
                    {
                        pt2 = pt2.next;
                    }
                }

                pt1 = pt1.next;
            }

            return head;
        }

        public Node SortLinkedListN2(Node head)
        {
            var pt1 = head;
            var pt2 = head;
            while (pt1 != null)
            {
                pt2 = pt1.next;
                while (pt2 != null)
                {
                    if (pt1.intValue > pt2.intValue)
                    {
                        pt1.intValue += pt2.intValue;
                        pt2.intValue = pt1.intValue - pt2.intValue;
                        pt1.intValue = pt1.intValue - pt2.intValue;
                    }

                    pt2 = pt2.next;
                }
                pt1 = pt1.next;
            }

            return head;
        }

        #endregion
    }
}