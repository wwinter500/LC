using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Leetcode
{
    public enum hardfunc : int
    {
        NQueens = 0,
        MergeLists
    }
    public partial class Hard
    {
        public List<string> Nqueen(int n = 4)
        {
            List<string> result = new List<string>();
            string fl = "Q...";
            result.Add(fl);
            
            //record used space
            int[] record = new int[n];//to record occupied queen
            record[0] = 0;
            for (int row = 1; row < n; row++)
            {
                //for each line detect if that line is ok to use
                string str = "";                
                for (int col = 0; col < n; col++)
                {
                    bool avail = true;
                    for(int i = 0; i <= row; i++)
                    {
                        if (col == record[i] || Math.Abs(col - record[i]) == Math.Abs(row - i))
                        {
                            avail = false;
                            break;
                        }
                    }

                    if (avail)
                    {
                        str += 'Q';
                        break;
                    }
                    else
                        str += '.';
                }

                result.Add(str);
            }
            return result;
        }

        

        #region divide and conqure
        /*312. Burst Balloons
         */
        public int MaxCoins(int[] nums)
        {
            return 0;
        }

        public void HardRun(string func)
        {
            if (func == hardfunc.NQueens.ToString())
            {
                List<string> r2 = Nqueen();
                foreach (string st in r2)
                    Console.WriteLine("{0}", st);
            }

            if (func == hardfunc.MergeLists.ToString())
            {
                ListNode[] input = new ListNode[3];

                //
                ListNode p0 = new ListNode(1);
                input[0] = p0;
                p0.next = new ListNode(4);
                p0 = p0.next;
                p0.next = new ListNode(5);

                ListNode p1 = new ListNode(1);
                input[1] = p1;
                p1.next = new ListNode(3);
                p1 = p1.next;
                p1.next = new ListNode(4);

                ListNode p2 = new ListNode(2);
                input[2] = p2;
                p2.next = new ListNode(6);

                ListNode pz = MergeKLists(input);

                string re = "";
                while (pz != null)
                {
                    re += pz.val;
                    pz = pz.next;
                }
                Console.WriteLine(re);
            }
        }
        #endregion
    }
}
