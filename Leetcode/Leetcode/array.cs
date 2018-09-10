using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{    
    public partial class Median
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
            return board;
        }
        #endregion
    }

    public partial class Easy
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
    }
}