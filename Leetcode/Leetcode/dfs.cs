using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class Median
    {
        #region 109        
        /* .109 Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
         * For this problem, a height-balanced binary tree is defined as a binary tree 
         * in which the depth of the two subtrees of every node never differ by more than 1.
         */
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
                return null;

            ListNode pE = head;
            while (pE.next != null)
            {
                pE = pE.next;
            }

            return SortedListToBSTHelper(head, pE);
        }

        public TreeNode SortedListToBSTHelper(ListNode head, ListNode end)
        {
            TreeNode root = null;
            if (head == end)
            {
                root = new TreeNode(head.val);
                return root;
            }
            else if (head.next == end)
            {
                root = new TreeNode(head.val);
                root.right = new TreeNode(end.val);

                return root;
            }

            ListNode pE = head;
            ListNode pM = head;
            ListNode pPreM = head;
            while (pE != end && pE.next != end)
            {
                pE = pE.next.next;
                pPreM = pM;
                pM = pM.next;
            }

            root = new TreeNode(pM.val);
            root.left = SortedListToBSTHelper(head, pPreM);
            root.right = SortedListToBSTHelper(pM.next, end);

            return root;
        }

        /* 114
         * Given a binary tree, flatten it to a linked list in-place.
         */
        public void Flatten(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root == null)
                return;

            FlattenHelper(root.left, ref queue);
            FlattenHelper(root.right, ref queue);

            root.right = null;
            root.left = null;

            TreeNode node = root;
            while (queue.Count > 0)
            {
                root.left = queue.Dequeue();
                root = root.left;
            }

            root = node;
        }

        public void FlattenHelper(TreeNode root, ref Queue<TreeNode> queue)
        {
            if (queue.Count == 0)
                return;

            queue.Enqueue(root);

            if (root == null)
                return;

            if (root.left != null)
            {
                FlattenHelper(root.left, ref queue);
            }

            if (root.right != null)
            {
                queue.Enqueue(root.right);
                FlattenHelper(root.right, ref queue);
            }
        }

        #endregion
    }
    public partial class Hard
    {
    }
}
