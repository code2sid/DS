using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds
{
    class Program
    {
        static void Main(string[] args)
        {
            ds();
            //syncAwait.callMethod();
            //new RefOut().PrintEmp();
            //new listTypes().returnLists();
            Console.ReadLine();

            /*
             ArrayList - An array-based list that doesn't support generic types. It does not enforce type safety and should generally be avoided.
             List - An array list that supports generic types and enforces type-safety. Since it is non-contiguous, it can grow in size without re-allocating memory 
                    for the entire list. This is the more commonly used list collection.
             HashTable - A basic key-value-pair map that functions like an indexed list.
             Dictionary - A hashtable that supports generic types and enforces type-safety.
             */
        }

        static void ds()
        {
            var n1 = new ListNode(0, "");
            var n2 = new ListNode(0, "");
            //CreateNodes(ref t1, ref t2);
            CreateNodes(ref n1, ref n2);

            var o = new Level1();
            var l = o.Add2Nos(n1, n2);
            int r = o.Reverse(1234);
            bool p = o.isPalimdrome(1221);
            bool p1 = o.isPalimdrome("arora");
            int bs = o.BinarySrch(new int[] { 1, 3, 5, 7, 9 }, 11);
            int mxVal = o.MaxinArray(new int[] { 22, 6, 33, 4, 55, 6, 88 });
            int mxVal1 = o.NthMaxinArray(new int[] { 22, 6, 33, 4, 55, 6, 88 }, 2);
            int ptcnt = o.PatternCnt("abcdeabfghabijk", "ab");
            int factVal = o.fact(5);
            int fibVal = o.fibIndex(8);
            string vr = o.vovelReplace("siddharth");
            int[] npn = o.NPrimeNos(10);
            int pn = o.NthPrimeNo(10);
            o.SumCombinations(new int[] { 1, 2, 3, 5, 7, 9 }, 10);
            char[] uc = o.UniqueCharacters("siddharth");
            char uc1 = o.FirstUniqueCharacter("scrumofscrum");
            bool isPn = o.IsPrimeNo(21);
            o.StringCombinations(new char[] { 'a', 'b', 'c' }, 0, 2);
            Console.ReadLine();

        }

        static void CreateNodes(ref ListNode n1, ref ListNode n2)
        {
            n1 = new ListNode { val = 9, next = new ListNode { val = 2 } };
            n2 = new ListNode { val = 2 };
        }

        public static void swap(ref char a, ref char b)
        {
            char t = a;
            a = b;
            b = t;
        }
    }
}
