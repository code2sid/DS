using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds
{
    public class Level1
    {
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

        internal int Reverse(int p)
        {
            int r = 0;
            while (p > 0)
            {
                r = r * 10 + p % 10;
                p = p / 10;
            }

            return r;
        }

        internal bool isPalimdrome(int p)
        {
            int hr = 0;
            while (p > hr)
            {
                hr = hr * 10 + p % 10;
                p = p / 10;
            }


            return hr == p || hr / 10 == p;
        }

        internal bool isPalimdrome(string p)
        {
            char[] clist = p.ToCharArray();
            int p1 = 0, p2 = p.Length - 1;
            while (p1 < p2)
                Program.swap(ref clist[p1++], ref clist[p2--]);

            return new string(clist).Equals(p);
        }

        internal int BinarySrch(int[] p, int item)
        {
            int mid = 0, low = 0, high = p.Length;
            while (low < high)
            {
                mid = (low + high) / 2;
                if (item == p[mid])
                    return mid;
                else if (item > p[mid])
                    low = mid + 1;
                else if (item < p[mid])
                    high = mid - 1;
            }

            return -1;
        }

        internal int MaxinArray(int[] p)
        {
            if (p.Length == 0)
                return -1;
            int max = 0;
            for (int i = 0; i < p.Length; i++)
                if (p[i] > max)
                    max = p[i];
            return max;
        }
        internal int NthMaxinArray(int[] p1, int p2)
        {
            if (p1.Length == 0)
                return -1;
            int lastMax = 0, skip = 0;
            while (p2 > 0)
            {
                lastMax = 0;
                for (int i = 0; i < p1.Length; i++)
                    if (p1[i] > lastMax && ((skip == 0) || p1[i] < skip))
                        lastMax = p1[i];
                skip = lastMax;
                p2--;
            }

            return lastMax;
        }
        internal int PatternCnt(string p1, string p2)
        {
            string t = p1;
            p1 = p1.Replace(p2, "");
            return (t.Length - p1.Length) / p2.Length;
        }
        internal int fact(int p)
        {
            if (p == 1)
                return 1;
            return p * fact(p - 1);
        }
        internal int fibIndex(int p)
        {
            if (p == 0)
                return 0;
            if (p == 1)
                return 1;
            return (fibIndex(p - 1) + fibIndex(p - 2));
        }
        internal bool IsPrimeNo(int p)
        {
            for (int i = 2; i < p / 2; i++)
            {
                if (p % i == 0)
                {
                    return false;
                }

            }

            return true;
        }
        internal int[] NPrimeNos(int p)
        {
            int num = 1, ctr, ptr = 0;
            int[] pn = new int[p];
            while (p > 0)
            {
                num++;
                ctr = 0;

                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        ctr++;
                        break;
                    }
                }

                if (ctr == 0 && num != 1)
                {
                    pn[ptr++] = num;
                    p--;
                }

            }
            foreach (var item in pn)
                Console.Write(" " + item);

            return pn;
        }
        internal int NthPrimeNo(int p)
        {
            int num = 0, cnt, pn = 0;
            while (p > 0)
            {
                num++;
                cnt = 0;
                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        cnt++;
                        break;
                    }

                }

                if (cnt == 0 && num != 1)
                {
                    p--;
                    pn = num;
                }
            }
            Console.WriteLine("\n" + pn);
            return pn;
        }
        internal string vovelReplace(string p)
        {
            char[] c = p.ToCharArray();
            for (int i = 0; i < p.Length;i++ )
            {
                switch(p[i])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u': { c[i] = (char)((int)c[i] - 32); break; }

                }

            }
            return new string(c);
        }
        internal char[] UniqueCharacters(string p)
        {
            int p1 = 0, p2 = 1;
            HashSet<char> c = new HashSet<char>();
            while (p1 < p.Length)
            {
                if (p[p1] == p[p2] && p1 != p2)
                {
                    p1++;
                    p2 = 0;
                }
                else if (p2 == p.Length - 1)
                {
                    c.Add(p[p1]);
                    p1++;
                    p2 = 0;
                }
                else
                    p2++;

            }

            char[] ch = new char[c.Count];
            c.CopyTo(ch);
            return ch;
        }
        internal char FirstUniqueCharacter(string p)
        {
            char c = p[0];
            int cnt = 0, l = p.Length;
            while (p.Length > 0)
            {
                c = p[cnt];
                p = p.Replace(c.ToString(), string.Empty);

                if (p.Length == l - 1)
                    return c;

                l = p.Length;
            }

            return ' ';

        }

        internal void SumCombinations(int[] input, int target)
        {
            var permutations = Permute(input);

            // check each permutation for the sum
            foreach (var item in permutations)
            {

                if (item.Sum() == target)
                {

                    Console.Write(string.Join(" + ", item.Select(n => n.ToString()).ToArray()));
                    Console.Write(" = " + target.ToString());
                    Console.WriteLine();

                }
            }

        }
        private IEnumerable<int[]> Permute(int[] data) { return Permute(data, 0); }
        private IEnumerable<int[]> Permute(int[] data, int level)
        {
            // reached the edge yet? backtrack one step if so.
            if (level >= data.Length) yield break;

            // yield the first #level elements
            yield return data.Take(level + 1).ToArray();

            // permute the remaining elements
            for (int i = level + 1; i < data.Length; i++)
            {
                var temp = data[level];
                data[level] = data[i];
                data[i] = temp;

                foreach (var item in Permute(data, level + 1))
                    yield return item;

                temp = data[i];
                data[i] = data[level];
                data[level] = temp;
            }

        }


        /*
         SQL:
         * Indexes
         * CTE vs Temp tables vs tabls variables
         * Queries: partition, dept/order max/without orders/
         
         
         C#:
         * ref vs out
         * logical questions
         * Web Services vs WebAPI
         * asyn await
         */


        internal void StringCombinations(char[] c, int strt, int end)
        {
            if (strt == end)
                Console.WriteLine(new string(c));
            else
            {
                for (int i = strt; i <= end; i++)
                {
                    Program.swap(ref c[i], ref c[strt]);
                    StringCombinations(c, strt + 1, end);
                    Program.swap(ref c[i], ref c[strt]);
                }
            }
        }
    }

    public class ListNode
    {
        public int val;
        public string Val { get; set; }
        public ListNode next;
        public ListNode(int x = 0, string str = "") { val = x; Val = str; }
    }
}
