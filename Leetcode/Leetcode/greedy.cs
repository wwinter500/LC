using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class _Median
    {
        #region greedy
        public string RemoveKdigits(string num, int k)
        {
            Stack<char> st = new Stack<char>();
            //solution with greddy and stack
            if (k < 1)
                return num;
            else if (num.Length < k)
                return "0";
            else if (num.Length == k)
                return "0";
            else
            {
                int start = 0, end = k, remain = num.Length - k, available = 0;
                while (end < num.Length)
                {
                    for (int i = start; i <= end; ++i)//period process
                    {
                        while (st.Count > available)
                        {
                            if (st.Peek() <= num[i])
                            {
                                st.Push(num[i]);
                                break;
                            }
                            else
                                st.Pop();
                        }

                        if (st.Count == available)
                            st.Push(num[i]);
                    }

                    available++;
                    start = end + 1;
                    end = num.Length - (--remain);
                }

                remain = num.Length - k;
                while (st.Count > remain)
                {
                    st.Pop();
                }
            }

            string sre = "";
            Stack<char> scp = new Stack<char>();
            while (st.Count > 0)
                scp.Push(st.Pop());

            while (scp.Count > 0)
            {
                char cp = scp.Pop();
                if (sre != "" || cp != '0')
                    sre += cp;
            }

            if (sre == "")
                sre += '0';
            return sre;
        }
        #endregion

        #region 763
        public IList<int> PartitionLabels(string S)
        {
            List<int> re = new List<int>();
            if (S == null || S.Length == 0)
                return re;

            Dictionary<char, int[]> dic = new Dictionary<char, int[]>();
            for(int i = 0; i < S.Length; ++i)
            {
                if(dic.ContainsKey(S[i]))
                {
                    dic[S[i]][1] = i;
                }
                else
                {
                    int[] range = new int[2] { i, i };
                    dic.Add(S[i], range);
                }
            }

            int head = 0, tail = 0;
            int cp = 0;
            while(tail < S.Length)
            {
                //if(dic[S[head]])
                if(dic[S[head]][1] == tail)
                {
                    re.Add(tail - head + 1);
                }
                if (dic[S[head]][1] > tail)
                {
                    tail = dic[S[head]][1];
                    head++;
                }
                
            }
            return re;
        }
        #endregion
    }
}
