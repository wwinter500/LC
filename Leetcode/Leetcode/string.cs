using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class _Median
    {
        #region string
        public string longestPalidrome(string str)
        {
            string result = "";
            int len = 0;
            int left = 0, right = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int pLen = FindPalidromeLen(str, i, i);
                int pLen2 = FindPalidromeLen(str, i, i + 1);
                int maxLen = Math.Max(pLen, pLen2);

                if (maxLen >= (right - left + 1))
                {
                    left = i - (maxLen - 1) / 2;
                    right = i + maxLen / 2;
                    len = maxLen;
                }
            }

            result = str.Substring(left, len);
            return result;
        }

        public int FindPalidromeLen(string str, int centerL, int centerR)
        {
            int left = 0, right = 0;
            int l = centerL, r = centerR;
            while (l >= 0 && r < str.Length && str[l] == str[r])
            {
                left = l--;
                right = r++;
            }
            return right - left + 1;
        }

        public string longestPalidrome_dp(string str)
        {
            string result = "";
            int len = str.Length;
            if (len <= 1)
                return str;

            float[][] buffer = new float[len][];
            for (int i = 0; i < len; i++)
                buffer[i] = new float[len];

            return result;
        }

        /*
         * 46 permuation
         */
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> ll = new List<IList<int>>();

            return ll;
        }

        public void PermuteHelper(ref IList<IList<int>> ll, int[] nums, int start)
        {
            //dfs

        }

        #endregion
    }

    public partial class _Easy
    {
        #region string
        /*581. Shortest Unsorted Continuous Subarray
        Given an integer array, you need to find one continuous subarray that if you only sort this subarray in ascending order, 
        then the whole array will be sorted in ascending order, too.
        You need to find the shortest such subarray and output its length.
        [2, 6, 4, 8, 10, 9, 15] -> [6, 4, 8, 10, 9]
        */
        public int FindUnsortedSubarray(int[] nums)
        {
            int result = 0;
            int len = nums.Length;
            //TODO : find the shortest array to be ascended.
            //top to bottom to recursive             
            int head = 0, end = len - 1;
            int preh = head, pree = end;
            while (end > head)
            {
                Console.WriteLine("{0}_{1}", head, end);
                if (needSort(nums, ref head, ref end))
                {
                    if (preh == head && pree == end)
                    {
                        //
                        result = end - head + 1;
                        break;
                    }

                    preh = head;
                    pree = end;
                }
            }

            return result;
        }

        private bool needSort(int[] nums, ref int head, ref int end)
        {
            int max = 0, min = 10000;
            int imax = 0, imin = 0;
            //find min and max loc
            for (int i = head; i <= end; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    imax = i;
                }

                if (nums[i] < min)
                {
                    min = nums[i];
                    imin = i;
                }
            }

            //check if loc is on end
            bool result = false;
            if (imin != head)
                result = true;
            else
                head++;

            if (imax != end)
                result = true;
            else
                end--;

            return result;
        }

        ///////////////////////////////////////////////////////////////////////////////               
        /*
         * 696 - solution 2
         */
        public int CountBinarySubstrings(string s, int i = 0)
        {
            int w_width = (s.Length / 2) * 2;

            return CountHelper(s, w_width, 0, s.Length - 1);
        }

        public int CountHelper(string s, int width, int start, int end)
        {
            int sum = 0;
            if (width < 2)
                return 0;

            int ilen = start + width - 1;

            //check within start - end
            for (int ip = start; ip <= end - (width - 1);)
            {
                //ip - ip + width
                if (CheckZeroString(s, ip, width))
                {
                    sum += width / 2;
                    start = end;

                }
                else
                {
                    sum += CountHelper(s, width / 2, ip, ip + width - 1);
                }

            }

            return sum;
        }

        public bool CheckZeroString(string s, int head, int width)
        {
            int h = head, w = width, mid = w / 2;
            bool converse = (1 - (s[head] - '0') == (s[head + width - 1] - '0') ? true : false);
            for (int i = 0; i < mid; i++)
            {
                if (!converse || s[i + head] != s[head] || s[w - i + head - 1] != s[w + head - 1])
                    return false;
            }

            return true;
        }
    
        /**/
        #endregion
    }
}
