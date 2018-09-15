using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class _Median
    {
        #region 338
        public int[] CountBits(int num)
        {
            List<int> _list = new List<int>();


            return _list.ToArray();
        }
        #endregion
        #region 64
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
        #endregion
        #region 300
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
        #region 62 - 63 unique path without / with obstacle
        public int UniquePaths(int m, int n)
        {
            //decare and init
            int[,] record = new int[n,m];
            
            //declare queue to access all point
            Queue<int[]> que = new Queue<int[]>();
            int[] target = new int[2] { n - 1, m - 1};
                        
            que.Enqueue(target);
            while(que.Count > 0)
            {
                int[] poi = que.Dequeue();
                if(poi[0] == n - 1 && poi[1] == m - 1)                
                    record[poi[0], poi[1]] = 1;                                                        
                else if(poi[0] == n - 1)                
                    record[poi[0], poi[1]] = record[poi[0], poi[1] + 1];
                else if(poi[1] == m - 1)
                    record[poi[0], poi[1]] = record[poi[0] + 1, poi[1]];
                else                
                    record[poi[0], poi[1]] = record[poi[0], poi[1] + 1] + record[poi[0] + 1, poi[1]];
                

                if(poi[0] - 1 >= 0 && record[poi[0] - 1, poi[1]] == 0)
                {
                    int[] pu = new int[2] { poi[0] - 1, poi[1]};
                    que.Enqueue(pu);
                }

                if(poi[1] - 1 >= 0 && record[poi[0], poi[1] - 1] == 0)
                {
                    int[] pl = new int[2] { poi[0], poi[1] - 1};
                    que.Enqueue(pl);
                }
            }
                
            return record[0, 0];
        }

        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {          
            int n = obstacleGrid.GetLength(0);
            int m = obstacleGrid.GetLength(1);
            if (obstacleGrid[n - 1, m - 1] == 1)//obstacle at target position
                return 0;

            int[,] record = new int[n, m];
            Queue<int[]> que = new Queue<int[]>();
            int[] target = new int[2] { n - 1, m - 1 };

            que.Enqueue(target);
            while (que.Count > 0)
            {
                int[] poi = que.Dequeue();
                if (poi[0] == n - 1 && poi[1] == m - 1)
                    record[poi[0], poi[1]] = 1;
                else if (poi[0] == n - 1 && obstacleGrid[poi[0], poi[1] + 1] == 0)
                    record[poi[0], poi[1]] = record[poi[0], poi[1] + 1];
                else if (poi[1] == m - 1 && obstacleGrid[poi[0] + 1, poi[1]] == 0)
                    record[poi[0], poi[1]] = record[poi[0] + 1, poi[1]];
                else
                {
                    if (obstacleGrid[poi[0], poi[1] + 1] == 0)
                        record[poi[0], poi[1]] += record[poi[0], poi[1] + 1];
                    if (obstacleGrid[poi[0] + 1, poi[1]] == 0)
                        record[poi[0], poi[1]] += record[poi[0] + 1, poi[1]];
                }
                if (poi[0] - 1 >= 0 && record[poi[0] - 1, poi[1]] == 0 && obstacleGrid[poi[0] - 1, poi[1]] == 0)
                {
                    int[] pu = new int[2] { poi[0] - 1, poi[1] };
                    que.Enqueue(pu);
                }

                if (poi[1] - 1 >= 0 && record[poi[0], poi[1] - 1] == 0 && obstacleGrid[poi[0], poi[1] - 1] == 0)
                {
                    int[] pl = new int[2] { poi[0], poi[1] - 1 };
                    que.Enqueue(pl);
                }
            }

            return record[0,0];
        }
        #endregion
    }

    public partial class _Easy
    {
        #region dynamic programming
        /*256 paint house - 265 pain house II(hard)
         */
        public int MinCost(int[,] costs)
        {
            int result = int.MaxValue;
            int nhouse = costs.GetLength(0);
            int ncolor = costs.GetLength(1);

            if (nhouse == 0 || ncolor == 0)
                return 0;

            //define optimal substructure
            int[,] recorder = new int[nhouse, ncolor];

            //define status transfier equlation
            for (int c = 0; c < ncolor; c++)
            {
                recorder[0, c] = costs[0, c];
            }

            for (int i = 1; i < nhouse; i++)
            {
                for (int c = 0; c < ncolor; c++)
                {
                    recorder[i, c] = int.MaxValue;
                    for (int c2 = 0; c2 < ncolor; c2++)
                    {
                        if (c2 != c)
                        {
                            int temp = recorder[i - 1, c2] + costs[i, c];
                            if (recorder[i, c] > temp)
                                recorder[i, c] = temp;
                        }
                    }
                }
            }


            for (int c = 0; c < ncolor; c++)
                if (result > recorder[nhouse - 1, c])
                    result = recorder[nhouse - 1, c];
            return result;
        }

        /*746. Min Cost Climbing Stairs
         */
        public int MinCostClimbingStairs(int[] cost)
        {
            int nl = cost.Length;
            if (nl == 0)
                return 0;
            //define optimal substructure
            int[] recorder = new int[nl];

            //define status transifer equlation
            recorder[0] = 0;
            recorder[1] = 0;
            for (int i = 2; i < nl; i++)
            {
                recorder[i] = Math.Min(recorder[i - 1] + cost[i - 1], recorder[i - 2] + cost[i - 2]);
            }

            string m = "";
            for (int i = 0; i < nl; i++)
                m += recorder[i].ToString() + "_";
            Console.WriteLine(m);

            return Math.Min(recorder[nl - 1] + cost[nl - 1], recorder[nl - 2] + cost[nl - 2]);
        }

        /*276 paint fence
         */
        public int NumWays(int n, int k)
        {
            int total = 0;
            if (n <= 0 || k <= 0)
                return 0;

            //define optimal sub structure - total numbers
            int[,] recorder = new int[n, k];

            //define status transmission equalation
            for (int c = 0; c < k; c++)
                recorder[0, c] = 1;
            for (int f = 0; f < n; f++)
            {
                for (int c = 0; c < k; c++)
                {
                    if (f == 0)
                        recorder[f, c] = 1;
                    else
                    {
                        recorder[f, c] = 0;
                    }
                }
            }

            return total;
        }
        #endregion
    }
}