using System;
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

            return board;
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

        public IList<IList<int>> FourSum2(int[] nums, int target)
        {
            //2 + 2 solution for 4 sum
            List<IList<int>> re = new List<IList<int>>();
            if (nums == null || nums.Length < 4)
                return re;

            //a. sort array
            Array.Sort(nums);

            //b. 
            Dictionary<int, Dictionary<int, int>> dic = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                for (int j = i + 1; j < nums.Length; ++j)
                {
                    if (j > 0 && nums[j] == nums[j - 1])
                        continue;

                    int sum2 = nums[i] + nums[j];
                    if (dic.ContainsKey(sum2))
                    {
                        if (!dic[sum2].ContainsKey(nums[i]))
                            dic[sum2].Add(nums[i], nums[j]);
                    }
                    else
                    {
                        Dictionary<int, int> subd = new Dictionary<int, int>();
                        subd.Add(nums[i], nums[j]);
                        dic.Add(sum2, subd);
                    }
                }
            }
                

            List<int> sum2l = new List<int>(dic.Keys);
            foreach (int s in sum2l)
            {
                int rest = target - s;
                if (dic.ContainsKey(rest))
                {
                    foreach (KeyValuePair<int, int> p in dic[s])
                        foreach (KeyValuePair<int, int> p2 in dic[rest])
                        {
                            if(p2.Key >= p.Value)
                            {
                                List<int> l = new List<int>();
                                l.Add(p.Key);
                                l.Add(p.Value);
                                l.Add(p2.Key);
                                l.Add(p2.Value);

                                re.Add(l);
                            }                            
                        }

                    dic.Remove(rest);
                    dic.Remove(s);
                }
            }

            return re;
        }

        #endregion
        #region 548
        public bool SplitArray(int[] nums)
        {
            //0 - i -1 ; i + 1 - j -1 ; j + 1 - k -1 ; k + 1 - n -1 
            return false;
        }

        public int EqualSubArray(int[] nums, int head, int tail)
        {

            return -1;
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
    }
}