﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{    
    public partial class _Median
    {
        #region 16- three sum closet  +  259 three sum smaller
        public int ThreeSumClosest(int[] nums, int target)
        {
            int diff = int.MaxValue;
            if (nums == null || nums.Length < 3)
                return 0;

            Array.Sort(nums);
            int re = 0;
            for (int i = 0; i < nums.Length - 2; ++i)
            {
                int head = i + 1, tail = nums.Length - 1;
                while (head < tail)
                {
                    int sum3 = nums[i] + nums[head] + nums[tail];
                    int l_diff = Math.Abs(sum3 - target);
                    if (l_diff < diff)
                    {
                        diff = l_diff;
                        re = sum3;
                    }

                    if (sum3 == target)
                        return sum3;
                    else if (sum3 < target)
                        head++;
                    else
                        tail--;
                }
            }
            return re;
        }

        public int ThreeSumSmaller(int[] nums, int target)
        {
            int re = 0;
            if (nums == null || nums.Length < 3)
                return 0;

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; ++i)
            {
                int head = i + 1, tail = nums.Length - 1;
                while (head < tail)
                {
                    int sum3 = nums[i] + nums[head] + nums[tail];
                    if (sum3 < target)
                    {
                        re += tail - head;
                        head++;
                    }
                    else
                        tail--;
                }
            }
            return re;
        }
        #endregion
        #region 611 - valid triangle number
        public int TriangleNumber(int[] nums)
        {
            int re = 0;
            if (nums == null || nums.Length == 0)
                return 0;

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; ++i)
            {
                for (int head = i + 1; head < nums.Length - 1; ++head)
                {
                    int tail = nums.Length - 1;
                    if (nums[tail] < nums[i] + nums[head])
                    {
                        re += tail - head;
                        Console.WriteLine(nums[i] + " " + nums[head] + " " + nums[tail]);
                    }
                    else
                    {
                        while (tail > head)
                        {
                            if (nums[tail] >= nums[i] + nums[head])
                                tail--;
                            else
                            {
                                re += tail - head;
                                Console.WriteLine(nums[i] + " " + nums[head] + " " + nums[tail]);
                                break;
                            }
                        }
                    }
                }
            }

            return re;
        }
        #endregion
        #region 670 - maximun swap
        public int MaximumSwap(int num)
        {
            //num within {0, 10^8}
            //            
            string ori = num.ToString();
            char[] oriArr = ori.ToCharArray();

            for (int i = 0; i < oriArr.Length - 1; ++i)
            {
                int large = oriArr[i];
                int idex = i;
                for (int j = i + 1; j < oriArr.Length; ++j)
                {
                    if (oriArr[j] >= large)//should be >= to find most end largest
                    {
                        large = oriArr[j];
                        idex = j;
                    }
                }

                if (large > oriArr[i])//should be larger instead of another index
                {
                    oriArr[i] ^= oriArr[idex];
                    oriArr[idex] ^= oriArr[i];
                    oriArr[i] ^= oriArr[idex];
                    break;
                }
            }

            int re = 0;
            for (int i = 0; i < oriArr.Length; ++i)
            {
                re *= 10;
                re += oriArr[i] - '0';
            }

            return re;
        }
        #endregion
        #region 723 candy crush
        public int[,] CandyCrush(int[,] board)
        {
            int w = board.GetLength(1);
            int h = board.GetLength(0);

            //a. clear crush candy
            List<Coordinates> l = new List<Coordinates>();
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    int cur = board[i, j];
                    if (cur == 0) continue;
                    if ((i - 2 >= 0 && board[i - 1, j] == cur && board[i - 2, j] == cur) ||                                                 // check left 2 candies
                       (i + 2 <= h - 1 && board[i + 1, j] == cur && board[i + 2, j] == cur) ||                                   // check right 2 candies
                       (j - 2 >= 0 && board[i, j - 1] == cur && board[i, j - 2] == cur) ||                                                 // check 2 candies top
                       (j + 2 <= w - 1 && board[i, j + 1] == cur && board[i, j + 2] == cur) ||                               // check 2 candies below
                       (i - 1 >= 0 && i + 1 <= h - 1 && board[i - 1, j] == cur && board[i + 1, j] == cur) ||                    // check if it is a mid candy in row
                       (j - 1 >= 0 && j + 1 <= h - 1 && board[i, j - 1] == cur && board[i, j + 1] == cur))
                    {                
                        // check if it is a mid candy in column
                        l.Add(new Coordinates(i, j));
                    }
                }
            }

            if (l.Count == 0)
                return board;
            else
            {
                foreach (Coordinates co in l)
                    board[co.y, co.x] = 0;
            }
            
            //b. clear 0 and move first
            CompressBoard(ref board, w, h);
            return CandyCrush(board);
        }
        
        public bool CompressBoard(ref int[,] board, int w, int h)
        {
            bool updated = false;
            //clear all 0 pointer if under values
            for (int x = 0; x < w; ++x)
            {
                int z = h - 1, o =  h - 2;
                while (o >= 0)
                {
                    if (o >= z)
                    {
                        o = z - 1;
                        continue;
                    }
                    else
                    {
                        if (board[z, x] != 0)
                        {
                            z--;
                            continue;
                        }
                        else
                        {
                            if (board[o, x] == 0)
                            {
                                o--;
                                continue;
                            }
                            else
                            {
                                board[o, x] ^= board[z, x];
                                board[z, x] ^= board[o, x];
                                board[o, x] ^= board[z, x];

                                updated = true;
                            }
                        }
                    }
                }                
            }

            return updated;
        }
        
        public void CompressArray(ref int[] arr)
        {
            int len = arr.Length;

            int z = 0, o = 1;
            while(o < len)
            {
                if (o <= z)
                {
                    o = z + 1;
                    continue;
                }
                else
                {
                    if(arr[z] != 0)
                    {
                        z++;
                        continue;
                    }
                    else
                    {
                        if(arr[o] == 0)
                        {
                            o++;
                            continue;
                        }
                        else
                        {
                            arr[o] ^= arr[z];
                            arr[z] ^= arr[o];
                            arr[o] ^= arr[z];
                        }
                    }
                }                    
            }
        }
        #endregion
        #region 15 3sum / 18 4sum
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            return ThreeSum(nums, 0);
        }

        public IList<IList<int>> ThreeSum(int[] nums, int s, int target = 0)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums.Length == 0 || s >= nums.Length)
                return result;
            
            for (int ap = s; ap < nums.Length - 2; ap++)
            {
                if (ap > s && nums[ap - 1] == nums[ap])
                    continue;
                else
                {
                    //search 2sum from sorted array
                    int bp = ap + 1, cp = nums.Length - 1;
                    while (cp > bp)
                    {
                        int sum2 = nums[cp] + nums[bp];
                        int rest = target - nums[ap];
                        if (sum2 == rest)
                        {
                            if (bp > ap + 1 && nums[bp - 1] == nums[bp])//if already exist
                            {
                                bp++;
                                continue;
                            }

                            List<int> list = new List<int>();
                            list.Add(nums[ap]);
                            list.Add(nums[bp++]);
                            list.Add(nums[cp--]);
                            result.Add(list);
                        }
                        else if (sum2 < rest)
                            bp++;
                        else
                            cp--;
                    }
                }
            }

            return result;
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> re = new List<IList<int>>();
            if (nums == null || nums.Length < 4)
                return re;

            //a. sort array
            Array.Sort(nums);
            
            //b. 
            for(int a = 0; a < nums.Length - 3; ++a)
            {
                if (a > 0 && nums[a] == nums[a - 1])
                    continue;

                IList<IList<int>> ll = ThreeSum(nums, a + 1, target - nums[a]);
                if (ll.Count > 0)
                {
                    foreach (List<int> l in ll)
                    {
                        l.Add(nums[a]);
                        re.Add(l);
                    }                    
                }
            }

            return re;
        }        
        #endregion
        #region 548*
        public bool SplitArray(int[] nums)
        {
            //0 ~ i - 1 ; i + 1 ~ j -1 ; j + 1 ~ k - 1 ; k + 1 ~ n -1
            if (nums == null || nums.Length <= 3)
                return false;

            //front to end
            int[] sums = new int[nums.Length];
            for(int i = 0; i < nums.Length; ++i)
            {
                if (i == 0)
                    sums[i] = nums[i];
                else
                    sums[i] = sums[i - 1] + nums[i];
            }

            //end to front by using dictionary
            Dictionary<int, List<int>> r_dic = new Dictionary<int, List<int>>();
            int rsum = 0;
            for(int i = nums.Length - 1; i >= 0; --i)
            {
                rsum += nums[i];
                if (r_dic.ContainsKey(rsum))
                    r_dic[rsum].Add(i);
                else
                {
                    List<int> l = new List<int>();
                    l.Add(i);
                    r_dic.Add(rsum, l);
                }
            }

            //search
            for(int lo = 0; lo < nums.Length - 6; ++lo)
            {
                if(r_dic.ContainsKey(sums[lo]))
                {
                    foreach(int hi in r_dic[sums[lo]])
                    {
                        if(lo < hi - 5)
                        {
                            for (int mid = lo + 3; mid < hi - 2; mid++)
                            {
                                int mlv = sums[mid - 1] - sums[lo + 2] + nums[lo + 2];
                                int mrv = sums[hi - 2] - sums[mid + 1] + nums[mid + 1];
                                if (mlv == mrv)
                                    return true;
                            }
                        }                        
                    }
                }
            }

            return false;
        }        
        #endregion
        #region 277
        bool Knows(int a, int b){ return true; }
        public int FindCelebrity(int n)
        {
            //find celebrity with minimun quest
            Queue<int> known = new Queue<int>();
            for (int i = 0; i < n; ++i)
                known.Enqueue(i);
            
            for(int i = 0; i < n; ++i)
            {
                int c = known.Count;
                for(int a = 0; a < c; ++a)
                {
                    int check = known.Dequeue();
                    if (Knows(i, check))
                        known.Enqueue(check);
                }
            }

            if (known.Count == 1)
            {
                int re = known.Dequeue();
                for(int i = 0; i < n; ++i)
                {
                    if (Knows(re, i) && i != re)
                        return -1;
                }

                return re;
            }
           
            return -1;
        }
        #endregion
        #region 306
        public bool IsAdditiveNumber(string num)
        {
            if (num == null || num.Length < 3)
                return false;

            for (int i = 1; i < num.Length && i < 13; ++i)
            {
                string f = num.Substring(0, i);
                if (f.Length > 1 && f[0] == '0')
                    break;

                int fv = 0;
                if (!int.TryParse(f, out fv))
                    break;

                for (int j = i + 1; j < num.Length && j - i < 13; ++j)
                {
                    string s = num.Substring(i, j - i);
                    if (s.Length > 1 && s[0] == '0')
                        break;

                    int sv = 0;
                    if (!int.TryParse(s, out sv))
                        break;

                    if (backtracking(num, j, fv, sv))
                        return true;                    
                }
            }

            return false;
        }

        public bool backtracking(string num, int idx, int hv, int sv)
        {
            if (idx > num.Length)
                return false;
            else if (idx == num.Length)
                return true;
            else
            {
                int v = hv + sv;
                string s = num.Substring(0, idx) + v.ToString();
                if (num.Contains(s))
                    return backtracking(num, s.Length, sv, v);
                else
                    return false;
            }
        }
        #endregion
    }

    public partial class _Easy
    {        
        #region 888
        public int[] FairCandySwap(int[] A, int[] B)
        {
            int sumA = 0, sumB = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int a in A)
                sumA += a;
            foreach (int b in B)
            {
                sumB += b;
                if (!dic.ContainsKey(b))
                    dic.Add(b, 1);
            }
                

            Array.Sort(A);
            Array.Sort(B);

            int[] re = new int[2];
            int diff = (sumA - sumB) / 2;
            for (int i = 0; i < A.Length; ++i)
            {
                if (dic.ContainsKey(A[i] - diff))
                {
                    re[0] = A[i];
                    re[1] = A[i] - diff;
                    break;
                }
            }

            return re;
        }

        #endregion
        #region 905
        public int[] SortArrayByParity(int[] A)
        {
            if (A == null || A.Length <= 1)
                return A;

            int e = A.Length, o = A.Length;
            for(int i = A.Length - 1; i >= 0; --i)//find left most odd
            {
                if (A[i] % 2 == 1)
                    o = i;       
            }

            if (o == A.Length)
                return A;

            for(int i = A.Length - 1; i > o; --i)//find left most even right to odd
            {
                if (A[i] % 2 == 0)
                    e = i;
            }

            while(e < A.Length)
            {
                //no even number between e and o
                if (A[e] % 2 == 1)
                    e++;
                else if (A[o] % 2 == 0)
                    o++;
                else
                {
                    SharedFunc.swap(ref A[e], ref A[o]);
                    e++;
                    o++;
                }
            }

            return A;
        }
        #endregion
        #region findcloset
        public int FindCloset(int val, List<int> arr, int start, int end)
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
        #endregion
        #region 54
        public IList<int> SpiralOrder(int[,] matrix)
        {
            List<int> ls = new List<int>();
            if (matrix == null)
                return ls;

            int h = matrix.GetLength(0);
            int w = matrix.GetLength(1);
            int turn = 0;

            return ls;
        }
        #endregion
    }
}