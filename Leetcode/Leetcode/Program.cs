using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Leetcode
{
    public enum LC_LEVEL
    {
        EASY = 0,
        MEDIAN,
        HARD
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class RandomListNode
    {
       public int label;
       public RandomListNode next, random;
       public RandomListNode(int x) { this.label = x; }
    };

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public partial class Program
    {
        static public int FindCloset(int val, List<int> arr, int start, int end)
        {
            if (start == end)
                return Math.Abs(arr[start] - val);
            else if (start == end - 1)
                return Math.Min(Math.Abs(arr[start] - val), Math.Abs(arr[end] - val));
            else
            {
                int mid = (start + end) / 2;
                int dl = FindCloset(val, arr, start, mid);
                int dr = FindCloset(val, arr, mid + 1, end);

                return Math.Min(dl, dr);
            }
        }

        static void test()
        {
            string S = "abc";
            char[] s = S.ToCharArray();
            for (int i = 0; i < S.Length; ++i)
                s[i] = (char)(s[i] - 'a' + 'A');

            string s1 = new string(s);
            Console.WriteLine(s1);
        }

        static void Main(string[] args)
        {
            EasySolution easy = new EasySolution();
            Hard hard = new Hard();
            Median med = new Median();
            Stopwatch watch = new Stopwatch();
            watch.Start();

            
            LC_LEVEL cl = LC_LEVEL.MEDIAN;
            //LC_LEVEL cl = LC_LEVEL.EASY;
            //string func = easyfunc.letterpermutate.ToString();
            string func = medianfunc.ConstructTreeFromPrePost.ToString();
            //string func = hardfunc.MergeLists.ToString();

            #region easy
            if (cl == LC_LEVEL.EASY)
            {
                easy.EasyRun(func);
            }
            #endregion
            #region median
            else if (cl == LC_LEVEL.MEDIAN)
            {
                med.MedianRun(func);
            }
            #endregion
            #region hard
            else
            {
                hard.HardRun(func);
            }
            #endregion
            watch.Stop();
            Console.WriteLine("Processing Time: {0:F4} ms", watch.Elapsed.TotalMilliseconds);
        }
    }
}
