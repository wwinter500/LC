using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class Median
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
}
