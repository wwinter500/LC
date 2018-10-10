using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Leetcode
{

    public partial class _Median
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
        #region 842+ -split to fibonacci sequence - amazon
        public IList<int> SplitIntoFibonacci(string S)
        {
            //123， 456， 579
            //since val < 2^31 - 1, the number is length < 13
            List<int> re = new List<int>();
            if (S == null || S.Length == 0)
                return re;
            
            for(int i = 1; i < S.Length && i < 13; ++i)
            {
                for(int j = i + 1; j < S.Length && j - i < 13; ++j)
                {
                    string sub0 = S.Substring(0,  i);
                    string sub1 = S.Substring(i, j - i);
                    if (sub0.Length > 1 && sub0[0] == '0')
                        break;
                    if (sub1.Length > 1 && sub1[0] == '0')
                        break;

                    int val0 = 0, val1 = 0;
                    if (!int.TryParse(sub0, out val0) || !int.TryParse(sub1, out val1))
                        break;

                    re.Add(val0);
                    re.Add(val1);

                    if (backtracking(S, j, ref re))
                        return re;
                    else                    
                        re.Clear();                    
                }
            }

            return re;
        }

        public bool backtracking(string S, int idx, ref List<int> l)
        {
            //to check backtracking            
            string head = S.Substring(0, idx);
            if (head.Length > S.Length)
                return false;
            else if (head.Length == S.Length)
                return true;
            else
            {
                int check = l[l.Count - 1] + l[l.Count - 2];
                string scheck = head + check.ToString();
                if (S.Contains(scheck))
                {
                    l.Add(check);
                    return backtracking(S, scheck.Length, ref l);
                }
                else
                    return false;
            }            
        }
        #endregion
    }

    public partial class _Easy
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
