using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPractice
{
    public class Practice
    {
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


    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }


}
