using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class Median
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
    }
}
