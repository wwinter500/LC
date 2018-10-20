using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Leetcode
{    
    public partial class _Hard
    {                
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
            if(func == hardfunc.longestkunique.ToString())
            {
                string s = "eqgkcwGFvjjmxutystqdfhuMblWbylgjxsxgnoh";
                int k = 16;
                Console.WriteLine(LengthOfLongestSubstringKDistinct(s, k));
            }
        }        
    }

    public enum hardfunc : int
    {
        NQueens = 0, MergeLists, longest2unique, longestkunique
    }
}
