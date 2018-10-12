using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Leetcode
{
    public partial class _Median
    {
        #region 454
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            int re = 0;
            Array.Sort(A);
            Array.Sort(B);
            Array.Sort(C);
            Array.Sort(D);

            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> dic2 = new Dictionary<int, List<int>>();
            int len = A.Length;
            for (int a = 0; a < A.Length; ++a)
            {
                for (int b = 0; b < B.Length; ++b)
                {
                    int sum2 = A[a] + B[b];
                    if (dic.ContainsKey(sum2))
                    {
                        dic[sum2].Add(A[a]);
                    }
                    else
                    {
                        List<int> l = new List<int>();
                        l.Add(A[a]);
                        dic.Add(sum2, l);
                    }
                }
            }

            for (int c = 0; c < C.Length; ++c)
            {
                for (int d = 0; d < D.Length; ++d)
                {
                    int sum2 = C[c] + D[d];
                    if (dic2.ContainsKey(sum2))
                    {
                        dic2[sum2].Add(C[c]);
                    }
                    else
                    {
                        List<int> l = new List<int>();
                        l.Add(C[c]);
                        dic2.Add(sum2, l);
                    }
                }
            }

            foreach (KeyValuePair<int, List<int>> p in dic)
            {
                int rest = -p.Key;
                if (dic2.ContainsKey(rest))
                {
                    re += p.Value.Count * dic2[rest].Count;
                }
            }

            return re;
        }
        #endregion
        #region 609
        public IList<IList<string>> FindDuplicate(string[] paths)
        {
            List<IList<string>> re = new List<IList<string>>();
            if (paths == null || paths.Length == 0)
                return re;

            Dictionary<string, List<string>> sdic = new Dictionary<string, List<string>>();
            foreach(string s in paths)
            {
                string[] subs = s.Split(' ');
                string head = subs[0] + "/";
                for(int i = 1; i < subs.Length; ++i)
                {
                    string[] ssub = subs[i].Split('(');
                    string fn = head + ssub[0];
                    if (sdic.ContainsKey(ssub[1]))
                    {
                        sdic[ssub[1]].Add(fn);
                    }
                    else
                    {
                        List<string> ls = new List<string>();
                        ls.Add(fn);
                        sdic.Add(ssub[1], ls);
                    }
                        
                }
            }

            foreach (KeyValuePair<string, List<string>> pair in sdic)
                re.Add(pair.Value);

            return re;
        }
        #endregion
    }

    public partial class _Easy
    {
        public int FindRadius(int[] houses, int[] heaters)
        {
            int radius = 1;
            int hn = houses.Length, heats = heaters.Length;
            if (heats <= 0)
                return 0;
            if (hn <= 0)
                return 1;

            Hashtable hs = new Hashtable();
            while (true)
            {
                foreach (int hi in heaters)
                {
                    for (int i = radius; i >= 0; i--)
                    {
                        if (!hs.ContainsKey(hi - i))
                            hs.Add(hi - i, 1);
                        if (!hs.ContainsKey(hi + i))
                            hs.Add(hi + i, 1);
                    }
                }

                bool coverall = true;
                foreach (int ho in houses)
                    if (!hs.ContainsKey(ho))
                    {
                        coverall = false;
                        radius++;
                        hs.Clear();
                        break;
                    }

                if (coverall)
                    break;
            }

            return radius;
        }
    }
}
