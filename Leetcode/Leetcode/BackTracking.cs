using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class Median
    {
        #region backtrack
        /*
         * 60. Permutation Sequence
         */
        public string GetPermutation(int n, int k)
        {
            string s = "";
            if (n == 0 || k == 0)
                return s;

            int count = 0;
            return s;// dfs(, n, k, ref count);
        }

        public void swap(ref char[] s, int a, int b)
        {
            char temp = s[a];
            s[a] = s[b];
            s[b] = s[a];
        }

        public string dfs(char[] ori, int n0, int k, ref int com)
        {
            string s = "";
            if (n0 == ori.Length)
            {
                com++;
                if (com == k)
                {
                    for (int i = 0; i < ori.Length; ++i)
                        s += ori[i];
                }
            }
            else
            {
                for (int j = n0; j < ori.Length; ++j)
                {
                    swap(ref ori, j, n0);
                    s = dfs(ori, n0 + 1, k, ref com);
                    swap(ref ori, j, n0);

                    if (com == k)
                        return s;
                }
            }

            return s;
        }

        #endregion        
    }
}
