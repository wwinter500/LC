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
        static public bool binarySearch(int[] A, int head, int tail, int target)
        {
            if (head == tail)
            {
                if (A[head] == target)
                    return true;
                else
                    return false;
            }

            int mid = (head + tail) / 2;
            if (A[mid] == target)
                return true;
            else
                return binarySearch(A, head, mid, target) ||
                    binarySearch(A, mid + 1, tail, target);
        }

        static void Main(string[] args)
        {
            _Easy easy = new _Easy();
            _Hard hard = new _Hard();
            Median med = new Median();
            Stopwatch watch = new Stopwatch();
            watch.Start();

            
            LC_LEVEL cl = LC_LEVEL.EASY;
            //LC_LEVEL cl = LC_LEVEL.EASY;
            string func = easyfunc.candyexchange.ToString();
            //string func = medianfunc.maxbyswap.ToString();
            //string func = hardfunc.MergeLists.ToString();

            if (cl == LC_LEVEL.EASY)
            {
                easy.EasyRun(func);
            }
            else if (cl == LC_LEVEL.MEDIAN)
            {
                med.MedianRun(func);
            }
            else
            {
                hard.HardRun(func);
            }

            watch.Stop();
            Console.WriteLine("Processing Time: {0:F4} ms", watch.Elapsed.TotalMilliseconds);
        }
    }
}
