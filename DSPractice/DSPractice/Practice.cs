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

        public int[] hash(int[] arr, int target)
        {
            //error in 3,3,4,4 target = 6 same key already added
            var d = new Dictionary<int, int>();
            var res = new int[2];
            for (int i = 0; i < arr.Length; i++)
                d.Add(arr[i], i);

            foreach (var i in d.Keys)
            {
                if ((target - i) != i && d[target - i] != null)
                {
                    res[0] = d[i];
                    res[1] = d[target - i];
                    break;
                }
            }

            return res;
        }

        public IList<IList<int>> sum(int[] arr)
        {
            arr = new QuickSort().sort(arr);
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if ((arr[i] + arr[j] + arr[k] == 0))
                        {
                            var s = new List<int>();
                            s.Add(arr[i]);
                            s.Add(arr[j]);
                            s.Add(arr[k]);
                            res.Add(s);
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < res.Count; i++)
            {
                for (int j = i + 1; j < res.Count; j++)
                {
                    if ((res[i][0] == res[j][0] || res[i][0] == res[j][1] || res[i][0] == res[j][2]) &&
                    (res[i][1] == res[j][0] || res[i][1] == res[j][1] || res[i][1] == res[j][2]) &&
                    (res[i][2] == res[j][0] || res[i][2] == res[j][1] || res[i][2] == res[j][2]))
                    {
                        res.RemoveAt(j); j--;
                    }
                }
            }
            int allzeros = 0;
            if (res.Count == 0)
            {
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] != 0)
                    {
                        allzeros = 1;
                        break;
                    }
                if (arr.Length > 2 && allzeros == 0)
                {
                    var s = new List<int>();
                    s.Add(0);
                    s.Add(0);
                    s.Add(0);
                    res.Add(s);
                }
            }

            return res;
        }

        public IList<IList<int>> Threesum(int[] arr)
        {
            arr = new HeapSort().sort(arr);
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
    }
}
