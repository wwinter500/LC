using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Leetcode
{
    public partial class _Median
    {
        #region Linked list
        public ListNode ReverseLinkedList(ListNode ln)
        {
            if (ln == null || ln.next == null)
                return ln;

            ListNode ph = new ListNode(0);
            ph.next = ln;

            ListNode p0 = ph;
            ListNode p1 = ph.next;
            while (p1.next != null)
            {
                ListNode temp = p1.next.next;
                p1.next.next = ph.next;
                ph.next = p1.next;
                p1.next = temp;
            }

            return ph.next;
        }

        public ListNode FindMid(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode end = head;
            ListNode mid = head;
            while (end.next != null && end.next.next != null)
            {
                end = end.next.next;
                mid = mid.next;
            }

            return mid;
        }

        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null)
                return null;

            //define prehead 
            ListNode ph = new ListNode(0);
            ph.next = head;

            //loop to switch
            ListNode ph_n = ph;
            while (ph_n.next != null)//until this node to end
            {
                ListNode ph_ref = ph;//head of reference
                bool swap = false;
                while (ph_ref != ph_n)//while they does not meet
                {
                    if (ph_ref.next.val >= ph_n.next.val)
                    {
                        //swap
                        ListNode temp = ph_ref.next;
                        ph_ref.next = ph_n.next;
                        ph_n.next = ph_n.next.next;
                        ph_ref.next.next = temp;
                        swap = true;
                        break;
                    }
                    else
                        ph_ref = ph_ref.next;
                }

                if (!swap)
                    ph_n = ph_n.next;
            }

            return ph.next;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null)
                return null;
            if (n <= 0)
                return head;

            ListNode pn = new ListNode(0);
            pn.next = head;
            ListNode cpn = head;

            int count = 1;
            while (cpn.next != null)
            {
                cpn = cpn.next;//move to next
                count++;
            }

            if (count < n)
                return null;
            else if (count == n)
            {
                if (count == 1)
                    return null;
                else
                {
                    pn.next = pn.next.next;
                }
            }
            else
            {
                cpn = pn;//
                for (int i = 0; i < count - n; i++)
                {
                    cpn = cpn.next;
                }

                if (cpn.next != null)
                    cpn.next = cpn.next.next;
            }

            return pn.next;
        }

        /*445
         */
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
                return null;

            ListNode result = new Leetcode.ListNode(0);


            return result;
        }

        /*24 swap nodes in pairs
         */
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode ph = new Leetcode.ListNode(0);
            ph.next = head;

            ListNode p0 = ph.next;
            ListNode p1 = ph;
            int count = 0;
            while (p0.next != null)
            {
                ListNode temp = p0.next.next;

                p1.next = p0.next;
                p0.next.next = p0;
                p0.next = temp;

                if (count == 0)
                    ph.next = p1.next;

                p1 = p0;
                if (p0.next != null)
                    p0 = p0.next;

                count++;
            }

            return ph.next;
        }

        /*
         * 328. Odd Even Linked List
         */
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode ph = new ListNode(0);
            ph.next = head;

            ListNode p0 = ph.next;//first node
            ListNode p1 = p0.next;//second node
            while (p1 != null)
            {
                if (p1.next == null)//no more odd node
                {
                    break;
                }
                else
                {
                    ListNode temp = p1.next.next;
                    p1.next.next = p0.next;
                    p0.next = p1.next;
                    p1.next = temp;
                    p0 = p0.next;

                    if (temp == null)
                        break;
                    else
                    {
                        p1 = temp;
                    }
                }
            }

            return ph.next;
        }

        /*
         * 143. Reorder List
         */
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null)
                return;

            ListNode mid = FindMid(head);
            ListNode half2 = mid.next;
            mid.next = null;

            ListNode half_rev = ReverseLinkedList(half2);
            ListNode pt = head;

            while (pt != null)
            {
                ListNode temp = pt.next;
                if (temp == null)
                {
                    if (half_rev == null)
                        break;
                    else
                    {
                        pt.next = half_rev;
                        pt = temp;
                    }
                }
                else
                {
                    pt.next = half_rev;
                    half_rev = half_rev.next;
                    pt.next.next = temp;
                    pt = pt.next.next;
                }
            }
        }

        /*
         * 144. plus one linked list
         */
        public ListNode PlusOne(ListNode head)
        {
            if (head == null)
                return null;

            int credit = 1;
            ListNode ph = new ListNode(1);

            ListNode rev0 = ReverseLinkedList(head);
            ListNode rev = rev0;
            while (rev != null)
            {
                rev.val += credit;
                credit = rev.val / 10;
                rev.val = rev.val % 10;

                rev = rev.next;
            }

            ListNode chead = ReverseLinkedList(rev0);
            ph.next = chead;
            return (credit == 0 ? ph.next : ph);
        }

        /*
         * 138 Copy random linked list
         */
        public RandomListNode CopyRandomList(RandomListNode head)
        {
            //use ori list to get index
            //use same index to point random point to correct object
            Hashtable ht_id = new Hashtable();//to record ori node to idx
            Hashtable ht_ran = new Hashtable();
            RandomListNode cp = head;
            int idx = 0;
            while (cp != null)
            {
                ht_id.Add(cp, idx);
                cp = cp.next;
                idx++;
            }

            cp = head;
            idx = 0;
            while (cp != null)
            {
                ht_ran.Add(idx, ht_id[cp.random]);
                cp = cp.next;
                idx++;
            }

            cp = head;
            RandomListNode re = new RandomListNode(cp.label);
            RandomListNode nncp = re;
            Hashtable ht_nran = new Hashtable();
            idx = 0;
            while (cp != null)
            {
                RandomListNode node = new RandomListNode(cp.label);
                ht_nran.Add(idx, nncp);
                idx++;

                nncp.next = node;
                nncp = nncp.next;

                cp = cp.next;
            }

            cp = re;
            idx = 0;
            while (cp != null)
            {
                cp.random = (RandomListNode)ht_nran[(int)ht_ran[idx]];
                cp = cp.next;
                idx++;
            }

            return re;
        }
        #endregion
    }

    public partial class _Hard
    {
        #region linked list - optimal solution O(n), worse solutoin = O(k * Maxlength)
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;
            if (lists.Length == 1)
                return lists[0];

            ListNode ph = new ListNode(0);
            ListNode pt = ph;
            while (true)
            {
                int val = int.MaxValue;
                int secV = int.MaxValue;
                int idx = -1;
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] != null)
                    {
                        if (val >= lists[i].val)
                        {
                            idx = i;
                            secV = val;
                            val = lists[i].val;
                        }

                        if (secV > lists[i].val && secV >= val)
                            secV = lists[i].val;
                    }
                }

                if (idx == -1)
                    break;

                //Console.WriteLine(val.ToString() + "-" + secV.ToString());
                ListNode lpt0 = lists[idx].next;
                while (lpt0 != null)
                {
                    if (lpt0.val > secV)
                        break;

                    lpt0 = lpt0.next;
                }

                pt.next = lists[idx];
                while (lists[idx] != lpt0)
                {
                    lists[idx] = lists[idx].next;
                    pt = pt.next;

                    //Console.WriteLine(pt.val.ToString());
                }

                //Console.WriteLine("----------");
            }

            return ph.next;
        }
        #endregion
    }
}
