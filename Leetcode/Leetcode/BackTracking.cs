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

    public partial class Easy
    {
        #region back track
        /*401. binary watch
         */
        public IList<string> ReadBinaryWatch(int num)
        {
            //            
            List<string> r = new List<string>();

            for (int i = 1; i < num; i++)
            {
                List<IList<int>> hour = Getsubset(i, 1, 3);
            }
            return r;
        }

        public List<IList<int>> Getsubset(int ci, int start, int end)
        {
            List<IList<int>> ll = new List<IList<int>>();
            int n = end - start + 1;

            if (ci < 1)
                return ll;
            if (n < ci)
                return ll;
            if (n == ci)
            {
                List<int> l = new List<int>();
                for (int i = start; i < start + n; i++)
                    l.Add(i);

                ll.Add(l);
                return ll;
            }

            if (ci == 1)
            {
                for (int i = start; i < start + n; i++)
                {
                    List<int> l = new List<int>();
                    l.Add(i);
                    ll.Add(l);
                }
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    List<IList<int>> sll = Getsubset(ci - 1, i + 1, end);//

                    foreach (List<int> sl in sll)
                    {
                        List<int> nl = new List<int>(sl);
                        nl.Add(i);
                        ll.Add(nl);
                    }
                }
            }

            return ll;
        }
        #endregion
    }
}
