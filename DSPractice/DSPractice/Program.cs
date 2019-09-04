using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prac();
            //Graph();
            //search();
            //sort();
            //GetHastTable();
            CrackingCode();
        }

        private static void CrackingCode()
        {
            var o = new CrackingTheCode();

            const string permutationString = "ABC";
            o.ReturnStringAllPermutations(permutationString, 0, permutationString.Length - 1);
            var r = CrackingTheCode.ReturnDistinctPairs(new[] {1, 3, 5, 9, 7}, 2);
            var magazine = new[] {'t','h','i','s',' ','a','r','n','o','m','e'};
            var resBool = o.IsMagazineRansomNote(magazine, "this is a ransom note");
            var resDic = o.ReturnAllPalindromePermutations("tact coa");
            resBool = o.IsPermutationOfOtherString("abc", "cbb");
            var resStrArray = o.ReturnPossibleSubStrings("abcdbcadcdabdabc", "abcd");
            var resStr = o.NaggaroVariableProblem("thisIsAVariable");
            resStr = o.NaggaroVariableProblem("this_is_a_variable");
            resStr = o.NaggaroStringCompression("bbbaaaeeedddcccaa");
            resStr = o.RepeatStringCompression("bbbaaaeeedddcccaabbbbb");
            var resInt = o.StaircaseProblem(4, 2);
            resInt = CrackingTheCode.WaterTrap(new[] {3, 0, 0, 2, 0, 4});
            var matrix = new[,]
            {
                {1, 1, 1, 1},
                {2, 2, 2, 2},
                {3, 3, 3, 3},
                {4, 4, 4, 4}    
            };
            var resMatrix = CrackingTheCode.ZeroMatrix(matrix);
            var head = new CrackingTheCode.Node("1",new CrackingTheCode.Node("2",new CrackingTheCode.Node("3",
                new CrackingTheCode.Node("4", new CrackingTheCode.Node("5", new CrackingTheCode.Node("6", null))))));
            resMatrix = CrackingTheCode.RotateMatrix(matrix);
            var n = CrackingTheCode.DeleteMiddleNode(head);
            resBool = CrackingTheCode.IsOneEditAway("sidd", "sidh");
            var resIntArr = o.ReturnElementsInCommon(new[] {11, 23, 25, 55, 66, 77, 990}, new[] {44, 88, 99, 11, 25});
            resBool = o.HasUniqueElements("sidhart");
            Console.ReadLine();
        }

        static void Prac()
        {
            int[] i = { -2, -3, 4, -1, -2, 1, 5, -3 };
            int[] i1 = { -2, -3, 4, -1, -2, 1, 5, -3 };
            int[] j = { 5, 5, 10, 40, 50, 35 };
            int[] r = { 3, 5, 8, 9, 10, 17, 17, 20 };
            var o = new Practice();
            var t1 = new TreeNode();
            var t2 = new TreeNode();
            var n1 = new ListNode(0, "");
            var n2 = new ListNode(0, "");
            CreateNodes(ref t1, ref t2);
            CreateNodes(ref n1, ref n2);
            //o.sum(i, 4); o.ptrsum(i, 4); o.sumof2_hash(i, 4);
            //o.Threesum(i);

            #region Practice Ques
            
            var a = new ListNode(9,""){next = new ListNode(8,""){next = new ListNode(7,"")}};
            var b = new ListNode(7,""){next = new ListNode(8,""){next = new ListNode(9,"")}};
            
            o.Add2Nos2(a, b);
            //o.Reverse(123453);
            //o.isPalimdrome(1221);
            //o.romanToInt("IMMMM");
            //o.intToRoman(2159);
            //o.intToEngWords(89789456);
            //o.LongestCommonPrefix(new string[] { "abd", "abe", "abc", "abz" });
            //o.IsValid("[");
            //o.LargestContiSum(i);
            //o.IsValid("([)]");

            //o.LargestNonAdjacentSum(j);
            //o.LargestNonContiSum(i);
            //o.LargestNonContiArray(i);
            //var res = o.Reverse("Let's take the contest");
            //var m = o.RodCutProblem(r, 8);
            #endregion Practice Ques

            #region Trees
            //var res = o.Merge2Trees(t1, t2);
            //var d = o.BTMaxDepth(t1);
            //var nd = o.DFSTreeInvertRecur(t2);
            //var nd = o.DFSTreeInvertIterate(t1);
            //var nd = o.BFSTreeInvertIterate(t1);
            //var a = o.BTMinDepth(t1);
            //var l = o.BTLevelOrderTraversal(t1);
            //var l = o.BTReverseLevelOrderTraversal(t1);
            //var s = o.RecSearch(t1, 26);
            //var l = o.InOrderTraversal(t1);
            //var l = o.PreOrderTraversal(t1);
            //var l = o.PostOrderTraversal(t1);
            #endregion Trees

            /*CacheSolution s = new CacheSolution(2);
            s.set(2, 1);
            s.set(1, 1);
            s.set(2, 3);
            s.set(4, 1);
            Console.Write(s.get(1));
            Console.Write(s.get(2));
            Console.ReadLine();
             */

            //var n = o.Intersectionof2(n1, n2);

            var g = new char[,] { { '1', '1', '1', '1', '0' }, { '1', '1', '0', '1', '0' }, { '1', '1', '0', '0', '0' }, { '0', '0', '0', '0', '0' } };
            g = new char[,] { { '1' }, { '1' } };
            //var c = o.NumIslands(g);

            //var s = o.ShortestPath(new int[,]{{ 1, 1, 0, 1 },{0,1,1,0},{0,0,0,1},{1,1,1,0}});

            //var a = o.MoveZeroes(new int[] { 1, 2, 0, 3, 4, 0, 5, 0 });
            //////////////////////////////////////////////////////////////////////////////////var p = o.minPalPartion("ababbbabbababa");
            //////////////////////////////////////////////////////////////////////////////////var h = o.BTDiameter(t1, 0);
            //var m = o.BTMaxDiff(t1, 0);

            //var w = o.WaterTrap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            //var p = o.PanCakeProblem(new int[] { 0, -1, 2, 3, 4, 1, 9, 6 }, 0);

            //var jumble = o.JumbleNumbers(new int[] { 12346,12345, 54321,21232, 64321 }, 1);
            //var jum = o.JumbleNumbers(100, 1);

            var k = o.knapsack(50, new int[] { 10, 20, 30 }, new int[] { 60, 100, 120 }, 3);

            SkyLine so = new SkyLine();
            so.getSkyline(new int[,] { { 2, 9, 10 }, { 3, 6, 15 }, { 5, 12, 12 }, { 13, 16, 10 }, { 13, 16, 10 }, { 15, 17, 5 } });
        }

        static void CreateNodes(ref TreeNode t1, ref TreeNode t2)
        {
            t1 = new TreeNode
            {
                val = 8,
                left = new TreeNode
                {
                    val = 3,
                    left = new TreeNode { val = 1 },
                    right = new TreeNode
                    {
                        val = 6,
                        left = new TreeNode { val = 4 },
                        right = new TreeNode { val = 7 }
                    }
                },
                right = new TreeNode { val = 10, right = new TreeNode { val = 14, left = new TreeNode { val = 13 } } }
            };
            t2 = new TreeNode { val = 2, left = new TreeNode { val = 1, right = new TreeNode { val = 4 } }, right = new TreeNode { val = 3, right = new TreeNode { val = 7 } } };


        }

        static void CreateNodes(ref ListNode n1, ref ListNode n2)
        {
            n1 = new ListNode { val = 1, next = new ListNode { val = 2 } };
            n2 = new ListNode { val = 2 };
        }

        static void Graph()
        {
            var treeNode = new TreeNode();
            treeNode.val = 14;
            treeNode.left = new TreeNode { val = 19, left = new TreeNode { val = 33 }, right = new TreeNode { val = 35 } };
            treeNode.right = new TreeNode { val = 27, left = new TreeNode { val = 42 }, right = new TreeNode { val = 50 } };

            var q = new Queue();
            q.Enqueue(treeNode);
            var _current = new TreeNode();
            _current = treeNode;

            try
            {
                while (q.Count != 0)
                {
                    _current = (TreeNode)q.Dequeue();
                    Console.Write(_current.val + " ");
                    q.Enqueue(_current.left);
                    q.Enqueue(_current.right);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
            }


            Console.Write("Enter no to search: ");
            var o = new BFS(treeNode);
            o.Search(int.Parse(Console.ReadLine()));
            Console.ReadLine();

        }

        static void search()
        {
            int[] i = { 14, 33, 27, 10, 35, 19, 42, 44 };
            foreach (var item in i)
                Console.Write(item + ",");
            Console.WriteLine("");
            var o = new QuickSort();
            i = o.sort(i);
            foreach (var item in i)
                Console.Write(item + ",");
            Console.ReadLine();
        }

        static void sort()
        {
            int[] i = { 10, 17, 22, 36, 46, 52, 64, 77, 81, 90 };
            foreach (var item in i)
                Console.Write(item + ",");
            Console.WriteLine("");
            var ls = new BinarySearch();
            Console.Write("Enter no to search: ");
            int n = int.Parse(Console.ReadLine());
            int pos = ls.SearchMyNo(n, i);
            if (pos > -1)
                Console.WriteLine("Number:{0} found at position:{1}", n, pos);
            else
                Console.WriteLine("Number:{0} not found", n);


            Console.ReadLine();
        }

        static Hashtable SetHashtable()
        {
            // Create and return new Hashtable.
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Area", 1000);
            hashtable.Add("Perimeter", 55);
            hashtable.Add("Mortgage", 540);
            return hashtable;
        }

        static void GetHastTable()
        {
            Hashtable hashtable = SetHashtable();
            // See if the Hashtable contains this key.
            Console.WriteLine(hashtable.ContainsKey("Perimeter"));
            // Test the Contains method. It works the same way.
            Console.WriteLine(hashtable.Contains("Area"));
            // Get value of Area with indexer.
            int value = (int)hashtable["Area"];
            // Write the value of Area.
            Console.WriteLine(value);
        }
    }
}
