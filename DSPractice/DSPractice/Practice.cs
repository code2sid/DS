using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPractice
{
    public class Practice
    {
        #region Level 1
        public int[] sum(int[] arr, int tar)
        {
            int[] sol = new int[2];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == tar)
                    {
                        sol[0] = i;
                        sol[1] = j;
                        break;
                    }
                }

                if (sol[0] > 0 && sol[1] > 0)
                    break;

            }

            return sol;
        }

        public int[] ptrsum(int[] arr, int tar)
        {
            // if not sorted error, n if we sort then we changed the expected result.
            // good in case where we need numbers only and not the index.
            int ptr1 = 0, ptr2 = arr.Length - 1;
            int[] indexes = { 0 };
            while (ptr1 <= ptr2)
            {
                if (arr[ptr1] + arr[ptr2] > tar)
                    ptr2--;
                else if (arr[ptr1] + arr[ptr2] < tar)
                    ptr1++;
                else if (arr[ptr1] + arr[ptr2] == tar)
                { indexes = new int[] { ptr1, ptr2 }; break; }

            }

            return indexes;
        }

        public int[] sumof2_hash(int[] arr, int target)
        {
            //error in 3,3,4,4 target = 6 same key already added>>> resolve them by checking is already exists.
            var d = new Dictionary<int, int>();
            var res = new int[2];
            for (int i = 0; i < arr.Length; i++)
            {
                if (d.ContainsKey(target - arr[i]))
                {
                    res[0] = i;
                    res[1] = d[target - arr[i]];
                }

                if (!d.ContainsKey(arr[i]))
                    d.Add(arr[i], i);
            }

            return res;
        }

        public IList<IList<int>> Threesum(int[] arr)
        {
            arr = new QuickSort().sort(arr);
            var res = new List<IList<int>>();
            int threeSum = 0, x = 0, y = 0, z = 0;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                x = arr[i];
                y = i + 1;
                z = arr.Length - 1;
                while (y < z)
                {
                    threeSum = x + arr[y] + arr[z];
                    if (threeSum == 0 && isDulpicate(res, x, arr[y], arr[z]))
                    {
                        var r = new List<int>();
                        r.Add(x); r.Add(arr[y]); r.Add(arr[z]);
                        res.Add(r);
                        y++; z--;
                    }
                    else if (threeSum < 0)
                        y++;
                    else
                        z--;
                }

            }

            return res;
        }

        public bool isDulpicate(IList<IList<int>> arr, int x, int y, int z)
        {
            foreach (var item in arr)
            {
                if (item[0] == x && item[1] == y && item[2] == z)
                    return false;
            }

            return true;
        }

        public ListNode Add2Nos(ListNode a, ListNode b)
        {
            var res = new ListNode(0);
            ListNode r = res;
            int sum = 0;
            while (a != null || b != null)
            {
                if (a != null)
                {
                    sum += a.val;
                    a = a.next;
                }

                if (b != null)
                {
                    sum += b.val;
                    b = b.next;
                }

                sum += r.next != null ? r.next.val : 0;
                r.next = new ListNode(sum);
                r = r.next;
                if (sum / 10 == 1)
                {
                    r.next = new ListNode(1);
                    r.val %= 10;
                }
                sum = 0;
            }


            return res.next;

        }

        public int Reverse(int a)
        {
            long r = 0;
            while (a != 0)
            {
                r = r * 10 + a % 10;
                a = a / 10;
            }
            if (r > int.MaxValue || r < int.MinValue)
                return 0;
            else
                return (int)r;
        }

        public bool isPalimdrome(int x)
        {
            if (x < 0)
                return false;
            int hr = 0;
            while (x > hr)
            {
                hr = hr * 10 + x % 10;
                x = x / 10;
            }
            return (x == hr) || (x == hr / 10);
        }

        public int romanToInt(string s)
        {
            var map = new Dictionary<char, int>();
            map.Add('I', 1);
            map.Add('V', 5);
            map.Add('X', 10);
            map.Add('L', 50);
            map.Add('C', 100);
            map.Add('D', 500);
            map.Add('M', 1000);
            int sum = map[s[s.Length - 1]];
            for (int i = s.Length - 2; i >= 0; --i)
            {
                if (map[s[i]] < map[s[i + 1]])
                    sum -= map[s[i]];
                else
                    sum += map[s[i]];
            }


            return sum;
        }

        public string intToRoman(int num)
        {
            string[] M = { "", "M", "MM", "MMM" };
            string[] C = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] X = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] I = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            return M[num / 1000] + C[(num % 1000) / 100] + X[(num % 100) / 10] + I[num % 10];
        }

        String[] LESS_THAN_20 = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", 
                                        "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        String[] TENS = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        String[] THOUSANDS = { "", "Thousand", "Million", "Billion" };

        public string intToEngWords(int num)
        {
            if (num == 0) return "Zero";

            int i = 0;
            StringBuilder words = new StringBuilder();

            while (num > 0)
            {
                if (num % 1000 != 0)
                    words = new StringBuilder(helper(num % 1000) + THOUSANDS[i] + " " + words);
                num /= 1000;
                i++;
            }

            return words.ToString().Trim();
        }

        private String helper(int num)
        {
            if (num == 0)
                return "";
            else if (num < 20)
                return LESS_THAN_20[num] + " ";
            else if (num < 100)
                return TENS[num / 10] + " " + helper(num % 10);
            else
                return LESS_THAN_20[num / 100] + " Hundred " + helper(num % 100);
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Count() == 0) return "";
            string sb = strs[0];
            //StringBuilder sb = new StringBuilder(strs[0]);
            for (int i = 1; i < strs.Length; i++)
                while (strs[i].IndexOf(sb) != 0)
                    sb = sb.Substring(0, sb.Length - 1);

            return sb;
        }

        public bool IsValid(string s)
        {
            if (s.Contains("["))
                return false;
            return true;
        }

        public int LargestContiSum(int[] arr)
        {
            int sum = 0, maxSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (sum < 0)
                    sum = 0;
                if (maxSum < sum)
                    maxSum = sum;
            }
            return maxSum;
        }

        public int[] LargestContiArray(int[] arr)
        {
            int sum = 0, maxSum = 0, strt = 0, end = 0, j = 0;
            int[] res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (sum < 0)
                {
                    sum = 0;
                    strt = i + 1;
                }
                if (maxSum < sum)
                {
                    maxSum = sum;
                    end = i;
                }
            }

            while (strt != end + 1)
                res[j++] = arr[strt++];

            return res;
        }

        public int LargestNonAdjacentSum(int[] arr)
        {
            int inc = arr[0], exc = 0, new_exc = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                new_exc = inc > exc ? inc : exc;
                inc = exc + arr[i];
                new_exc = exc;
            }
            return inc > exc ? inc : exc;
        }

        public int LargestNonContiSum(int[] arr)
        {
            int maxSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                    maxSum += arr[i];
            }

            return maxSum;
        }
        public int[] LargestNonContiArray(int[] arr)
        {
            int s1 = 0, s2 = 0, j = 0;
            int[] res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                    res[j++] = arr[i];
            }

            return res;
        }

        public string Reverse(string str)
        {
            string[] s = str.Split(' ');
            StringBuilder res = new StringBuilder();
            foreach (var item in s)
            {
                char[] r = item.ToCharArray();
                for (int i = 0; i < item.Length / 2; i++)
                    swap.fnSwap(ref r[i], ref r[r.Length - i - 1]);
                res.Append(new string(r) + " ");
            }

            return res.ToString().Trim();
        }
        #endregion Level 1

        internal int RodCutProblem(int[] price, int n)
        {
            if (n <= 0)
                return 0;

            int maxSum = 0;
            for (int i = 0; i < n; i++)
                maxSum = Math.Max(maxSum, price[i] + RodCutProblem(price, n - i - 1));
            return maxSum;

        }

        #region treeNodes
        public TreeNode Merge2Trees(TreeNode a, TreeNode b)
        {
            if (a == null && b == null) return null;
            if (a == null && b != null) return b;
            if (a != null && b == null) return a;

            a.val += b.val;

            a.left = Merge2Trees(a.left, b.left);
            a.right = Merge2Trees(a.right, b.right);

            return a;
        }
        internal int BTMaxDepth(TreeNode t)
        {
            if (t == null) return 0;
            //DFS
            //return 1 + Math.Max(BTMaxDepth(t.left), BTMaxDepth(t.right));

            //BFS
            int cnt = 0;
            var q = new Queue();
            q.Enqueue(t);
            int size = -100;
            while (q.Count != 0)
            {
                cnt++;
                size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var c = (TreeNode)q.Dequeue();
                    if (c.left != null) q.Enqueue(c.left);
                    if (c.right != null) q.Enqueue(c.right);
                }
            }

            return cnt;


        }
        internal TreeNode DFSTreeInvertRecur(TreeNode root)
        {
            if (root == null)
                return null;

            TreeNode l = root.left, r = root.right;
            root.left = DFSTreeInvertRecur(r);
            root.right = DFSTreeInvertRecur(l);

            return root;


        }
        internal TreeNode DFSTreeInvertIterate(TreeNode root)
        {
            Stack s = new Stack();
            s.Push(root);
            while (s.Count != 0)
            {
                var t = (TreeNode)s.Pop();
                var temp = t.left;
                t.left = t.right;
                t.right = temp;

                if (t.left != null)
                    s.Push(t.left);
                if (t.right != null)
                    s.Push(t.right);
            }
            return root;
        }
        internal TreeNode BFSTreeInvertIterate(TreeNode root)
        {
            var q = new Queue();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                var t = (TreeNode)q.Dequeue();
                var temp = t.left;
                t.left = t.right;
                t.right = temp;

                if (t.left != null)
                    q.Enqueue(t.left);
                if (t.right != null)
                    q.Enqueue(t.right);
            }
            return root;
        }

        //tree traversal
        TreeNode result;
        void isT2(TreeNode t1, int val)
        {
            if (t1 == null)
                return;
            if (t1.val == val)
            {
                result = t1;
                return;
            }
            isT2(t1.left, val);
            isT2(t1.right, val);
        }
        bool isSubtree2(TreeNode result, TreeNode b)
        {
            if (result == null && b == null)
                return true;
            if (b == null && result != null)
                return false;
            if (result == null && b != null)
                return false;
            if (result.val != b.val)
                return false;

            return isSubtree2(result.left, b.left) && isSubtree2(result.right, b.right);
        }

        public int BTMinDepth(TreeNode node)
        {
            if (node == null)
                return 0;
            int l = BTMinDepth(node.left);
            int r = BTMinDepth(node.right);

            if (l == 0 || r == 0)
                return l + r + 1;

            return 1 + Math.Min(l, r);
        }

        //preorder traversal
        public IList<IList<int>> BTLevelOrderTraversal(TreeNode t)
        {
            var res = new List<IList<int>>();
            if (t == null)
                return res;
            Queue q = new Queue();
            var s = new List<int>();
            q.Enqueue(t);
            while (q.Count != 0)
            {
                int level = q.Count;
                s = new List<int>();
                for (int i = 0; i < level; i++)
                {
                    var c = (TreeNode)q.Dequeue();
                    s.Add(c.val);
                    if (c.left != null) q.Enqueue(c.left);
                    if (c.right != null) q.Enqueue(c.right);
                }
                res.Add(s);
            }
            return res;
        }
        public IList<IList<int>> BTReverseLevelOrderTraversal(TreeNode t)
        {
            var res = new List<IList<int>>();
            if (t == null)
                return res;
            Queue q = new Queue();
            var s = new List<int>();
            q.Enqueue(t);
            while (q.Count != 0)
            {
                int level = q.Count;
                s = new List<int>();
                for (int i = 0; i < level; i++)
                {
                    var c = (TreeNode)q.Dequeue();
                    s.Add(c.val);
                    if (c.left != null) q.Enqueue(c.left);
                    if (c.right != null) q.Enqueue(c.right);
                }
                res.Insert(0, s);
            }
            return res;
        }

        public TreeNode Search(TreeNode t, int val)
        {
            var res = new TreeNode();
            if (t == null)
                return res;
            var q = new Queue();
            q.Enqueue(t);
            while (q.Count != 0)
            {
                var c = (TreeNode)q.Dequeue();
                if (c.val == val)
                    return c;
                else if (val > c.val && c.right != null)
                    q.Enqueue(c.right);
                else if (val < c.val && c.left != null)
                    q.Enqueue(c.left);

            }

            return res;

        }
        public TreeNode RecSearch(TreeNode t, int val)
        {
            if (t == null || t.val == val)
                return t;
            if (val > t.val)
                return RecSearch(t.right, val);

            return RecSearch(t.left, val);

        }

        public List<int> InOrderTraversal(TreeNode t)
        {
            var res = new List<int>();
            if (t == null)
                return res;

            var s = new Stack();
            TreeNode cur = t;
            while (s.Count != 0 || cur != null)
            {
                while (cur != null)
                {
                    s.Push(cur);
                    cur = cur.left;
                }
                cur = (TreeNode)s.Pop();
                res.Add(cur.val);
                cur = cur.right;
            }
            return res;

        }
        public List<int> PreOrderTraversal(TreeNode t)
        {
            var res = new List<int>();
            if (t == null)
                return res;
            var s = new Stack();
            s.Push(t);
            while (s.Count != 0)
            {
                var c = (TreeNode)s.Pop();
                res.Add(c.val);
                if (c.right != null) s.Push(c.right);
                if (c.left != null) s.Push(c.left);
            }
            return res;
        }
        public List<int> PostOrderTraversal(TreeNode t)
        {
            var res = new List<int>();
            if (t == null)
                return res;
            var s = new Stack();
            s.Push(t);
            while (s.Count != 0)
            {
                var c = (TreeNode)s.Pop();
                res.Insert(0, c.val);
                if (c.left != null) s.Push(c.left);
                if (c.right != null) s.Push(c.right);
            }
            return res;
        }



        #endregion treeNodes

        #region Level 2
        int m, n;
        public int NumIslands(char[,] grid)
        {
            int cntr = 0;
            m = grid.GetLength(0);
            n = grid.GetLength(1);
            if (m == 0)
                return 0;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (grid[i, j] == '1')
                    {
                        marking(grid, i, j);
                        ++cntr;
                    }
            return cntr;
        }
        public void marking(char[,] g, int i, int j)
        {
            if (i < 0 || j < 0 || i >= m || j >= n || g[i, j] != '1') return;
            g[i, j] = '0';
            marking(g, i + 1, j);
            marking(g, i - 1, j);
            marking(g, i, j + 1);
            marking(g, i, j - 1);
        }

        public ListNode Intersectionof2(ListNode a, ListNode b)
        {
            int alen = NodeLength(a), blen = NodeLength(b);
            while (alen > blen)
            {
                a = a.next;
                alen--;
            }

            while (blen > alen)
            {
                b = b.next;
                blen--;
            }

            while (a != b)
            {
                a = a.next;
                b = b.next;
            }

            return a;
        }
        private int NodeLength(ListNode n)
        {
            int l = 0;
            while (n != null)
            {
                l++;
                n = n.next;
            }

            return l;
        }

        public int ShortestPath(int[,] grid)
        {
            m = grid.GetLength(0);
            n = grid.GetLength(1);
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j != 0) grid[i, j] += grid[i, j - 1];
                    if (i != 0 && j == 0) grid[i, j] += grid[i - 1, j];
                    if (i != 0 && j != 0) grid[i, j] += Math.Min(grid[i - 1, j], grid[i, j - 1]);
                }
            return grid[m - 1, n - 1];
        }

        public int[] MoveZeroes(int[] nums)
        {
            int inspos = 0;
            foreach (var item in nums)
                if (item != 0) nums[inspos++] = item;
            while (inspos < nums.Length)
                nums[inspos++] = 0;

            return nums;
        }


        #endregion level 2

        #region level 3

        public int minPalPartion(string str)
        {
            int n = str.Length;
            int[] c = new int[n];
            bool[,] p = new bool[n, n];
            int i, j, k, l;
            for (i = 0; i < n; i++)
                p[i, i] = true;


            for (l = 2; l <= n; l++)
                for (i = 0; i < n - l + 1; i++)
                {
                    j = i + l - 1;
                    if (l == 2)
                        p[i, j] = (str[i] == str[j]);
                    else
                        p[i, j] = (str[i] == str[j]) && p[i + 1, j - 1];
                }
            for (i = 0; i < n; i++)
            {
                if (p[0, i])
                    c[i] = 0;
                else
                {
                    c[i] = int.MaxValue;
                    for (j = 0; j < i; j++)
                        if (p[j + 1, i] == true && 1 + c[j] < c[i])
                            c[i] = 1 + c[j];
                }
            }

            return c[n - 1];


        }
        public int BTDiameter(TreeNode t, int ht)
        {
            if (t == null)
            {
                ht = 0;
                return 0;
            }

            int lht = 0, rht = 0;
            int ldm = 0, rdm = 0;

            ldm = BTDiameter(t.left, lht);
            rdm = BTDiameter(t.left, rht);


            ht = Math.Max(lht, rht) + 1;

            return Math.Max(lht + rht + 1, Math.Max(ldm, rdm));
        }
        public int BTMaxDiff(TreeNode t, int res)
        {
            if (t == null)
                return 0;
            if (t.left == null && t.right == null)
                return t.val;
            int minVal = Math.Min(BTMaxDiff(t.left, res), BTMaxDiff(t.right, res));
            res = Math.Max(res, t.val - minVal);
            return Math.Min(res, minVal);

        }

        public int WaterTrap(int[] arr)
        {
            int l = arr.Length, water = 0;
            int[] left = new int[l];
            int[] right = new int[l];

            left[0] = arr[0];
            for (int i = 1; i < l; i++)
                left[i] = Math.Max(left[i - 1], arr[i]);

            right[l - 1] = arr[l - 1];
            for (int i = l - 2; i >= 0; i--)
                right[i] = Math.Max(right[i + 1], arr[i]);

            for (int i = 0; i < l; i++)
                water += Math.Min(left[i], right[i]) - arr[i];

            return water;
        }
        public int ThreeFiveTen_1(int target)
        {
            Dictionary<int, int> arr = new Dictionary<int, int>();
            arr.Add(3, 3);
            arr.Add(5, 5);
            arr.Add(10, 10);
            int ways = 0;


            return ways;
        }

        #endregion level 3
    }


    public class BSTIterator
    {
        public TreeNode BST { get; set; }
        public int MinVal { get; set; }
        public BSTIterator(TreeNode root)
        {
            BST = root;
            if (root != null)
                MinVal = root.val;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            if (BST == null)
                return false;
            if (BST.left != null && BST.left.val < MinVal)
            {
                BST = BST.left;
                MinVal = BST.val;
                return true;
            }

            return false;
        }

        /** @return the next smallest number */
        public int Next()
        {
            return MinVal;
        }
    }

    public class ListNode
    {
        public int val;
        public string Val { get; set; }
        public ListNode next;
        public ListNode(int x = 0, string str = "") { val = x; Val = str; }
    }

    public class CacheSolution
    {
        List<NodeLinkedList> res = new List<NodeLinkedList>();
        public int cap;
        public CacheSolution(int capacity)
        {

            cap = capacity;
        }

        public int get(int key)
        {
            var r = res.Where(i => i.key == key).FirstOrDefault();
            if (r != null)
            {
                res.Remove(r);
                res.Insert(0, r);
                return r.val;
            }
            return -1;
        }

        public void set(int key, int value)
        {

            var r = res.Where(i => i.key == key).FirstOrDefault();
            if (r != null)
            {
                return;
            }

            if (res.Count == cap)
            {
                res.RemoveAt(cap - 1);
                res.Add(new NodeLinkedList { key = key, val = value });
            }
            else
                res.Add(new NodeLinkedList { key = key, val = value });

        }

    }

    class NodeLinkedList
    {
        public int key { get; set; }
        public int val { get; set; }
    }






}
