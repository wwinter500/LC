using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class Median
    {
        #region dynamic programming
        /*
         * 338
         */
        public int[] CountBits(int num)
        {
            List<int> _list = new List<int>();


            return _list.ToArray();
        }

        /*
         * 64 minimun path sum
         */
        public int MinPathSum(int[,] grid)
        {
            int result = 0;
            if (grid == null)
                return 0;

            int m = grid.GetLength(0);
            int n = grid.GetLength(1);

            //sub structure
            int[,] recorder = new int[m, n];

            //transmission equlation
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (r == 0 && c == 0)
                        recorder[r, c] = grid[r, c];
                    else if (r != 0 && c == 0)
                        recorder[r, c] = recorder[r - 1, c] + grid[r, c];
                    else if (r == 0 && c != 0)
                        recorder[r, c] = recorder[r, c - 1] + grid[r, c];
                    else
                        recorder[r, c] = Math.Min(recorder[r - 1, c], recorder[r, c - 1]) + grid[r, c];
                }

            }

            return recorder[m - 1, n - 1];
        }

        /*
         * 300. Longest Increasing Subsequence
         */
        public int LengthOfLIS(int[] nums)
        {

            //n2 solution
            int len = nums.Length;
            if (len == 0)
                return 0;

            int[] status = new int[len];
            int re = 0;
            for (int i = 0; i < len; i++)
            {
                if (i == 0)
                    status[i] = 0;
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (nums[i] > nums[j] && status[i] < status[j] + 1)
                            status[i] = status[j] + 1;
                    }
                }
            }

            string s = "";
            foreach (int v in status)
            {
                if (v > re)
                    re = v;
                s += v.ToString() + " ";
            }

            Console.WriteLine(re + 1);
            return re + 1;
        }

        public int LengthOfLIS2(int[] nums)
        {
            //nlogn time complexity
            int len = nums.Length;
            if (len == 0)
                return 0;

            int[] status = new int[len];//dp array
            int re = 0;
            for (int i = 0; i < len; i++)
            {
                if (i == 0)
                    status[i] = 0;
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (nums[i] > nums[j] && status[i] < status[j] + 1)
                            status[i] = status[j] + 1;
                    }
                }
            }

            string s = "";
            foreach (int v in status)
            {
                if (v > re)
                    re = v;
                s += v.ToString() + " ";
            }

            Console.WriteLine(re + 1);
            return re + 1;
        }
        #endregion
    }
}
