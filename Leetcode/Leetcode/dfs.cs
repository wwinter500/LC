using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class _Median
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
    public partial class _Hard
    {
    }

    public partial class _Easy
    {
        #region 339
        /*
         * 339. Nested List Weight Sum
         */
        public interface NestedInteger
        {
            // Constructor initializes an empty nested list.
            /*public NestedInteger();

            // Constructor initializes a single integer.
            public NestedInteger(int value);*/

            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            bool IsInteger();

            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            int GetInteger();

            // Set this NestedInteger to hold a single integer.
            void SetInteger(int value);

            // Set this NestedInteger to hold a nested list and adds a nested integer to it.
            void Add(NestedInteger ni);

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            IList<NestedInteger> GetList();
        }

        public int DepthSum(IList<NestedInteger> nestedList)
        {
            return DepthSumOnLevel(nestedList, 1);
        }

        public int DepthSumOnLevel(IList<NestedInteger> list, int level)
        {
            if (list.Count == 0)
                return 0;

            int sum = 0;
            foreach (NestedInteger ni in list)
            {
                if (ni.IsInteger())
                    sum += level * ni.GetInteger();//single number
                else
                    sum += DepthSumOnLevel(ni.GetList(), level + 1);//list
            }

            return sum;
        }
        #endregion
        #region 784
        /*
         * 784. Letter Case Permutation
         */
        public IList<string> LetterCasePermutation(string S)
        {
            List<string> re = new List<string>();
            if (S == null)
                return re;

            List<int> input = new List<int>();
            for (int i = 0; i < S.Length; ++i)
            {
                if ((S[i] >= 'a' && S[i] <= 'z') || (S[i] >= 'A' && S[i] <= 'Z'))
                    input.Add(i);
            }

            if (input.Count == 0)
            {
                re.Add(S);
                return re;
            }

            List<IList<int>> ll0 = new List<IList<int>>();
            PermutationHelper(ref ll0, input, 0);

            foreach (List<int> l in ll0)
            {
                char[] s = S.ToCharArray();
                foreach (int i in l)
                    charFormatConverter(ref s[i]);

                string s1 = new string(s);
                re.Add(s1);
            }

            return re;
        }

        public void charFormatConverter(ref char ori)
        {
            char test = ori;
            if (ori >= 'a' && ori <= 'z')
                test = (char)(ori - 'a' + 'A');
            if (ori >= 'A' && ori <= 'Z')
                test = (char)(ori - 'A' + 'a');

            ori = test;
        }
        public void PermutationHelper(ref List<IList<int>> re, List<int> l, int start)
        {
            if (start == l.Count - 1)
            {
                //with start pos
                List<int> l0 = new List<int>();
                l0.Add(l[start]);
                re.Add(l0);

                //without start pos
                List<int> l1 = new List<int>();
                re.Add(l1);
            }
            else
            {
                //get permutation start with next character
                PermutationHelper(ref re, l, start + 1);

                List<IList<int>> nl = new List<IList<int>>();
                foreach (List<int> l1 in re)
                {
                    //copy list with adding start node
                    List<int> l2 = new List<int>();
                    l2.Add(l[start]);
                    foreach (int v in l1)
                        l2.Add(v);

                    //add l2 to nl
                    nl.Add(l2);
                }

                //add back to re
                foreach (List<int> l2 in nl)
                    re.Add(l2);
            }
        }
        #endregion
        #region edges of island
        /*
         * Given a non-empty 2D array grid of 0's and 1's, an island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.)
         * You may assume all four edges of the grid are surrounded by water.
         * Find the maximum area of an island in the given 2D array. (If there is no island, the maximum area is 0.)
         */
        public int MaxAreaOfIsland(int[,] grid)
        {
            int maxSum = 0;
            int row = grid.GetLength(0);
            int col = grid.GetLength(1);

            if (row == 0 || col == 0)
                return maxSum;

            int[,] visited = new int[row, col];

            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    int area = dfs(grid, ref visited, row, col, i, j);
                    if (maxSum < area)
                        maxSum = area;
                }

            return maxSum;
        }

        public int dfs(int[,] grid, ref int[,] visited, int h, int w, int iy, int ix)
        {
            int area = 0;
            if (iy < 0 || iy >= h || ix < 0 || ix >= w)
                return 0;

            if (grid[iy, ix] == 0 || visited[iy, ix] == 1)
            {
                return 0;
            }

            area++;
            visited[iy, ix] = 1;

            area += dfs(grid, ref visited, h, w, iy, ix + 1);
            area += dfs(grid, ref visited, h, w, iy, ix - 1);
            area += dfs(grid, ref visited, h, w, iy + 1, ix);
            area += dfs(grid, ref visited, h, w, iy - 1, ix);

            return area;
        }


        /*
         * Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
         * Note: For the purpose of this problem, we define empty string as valid palindrome.
         */

        public bool IsPalindrome(string s)
        {
            if (s.Length == 0)
                return true;

            int ist = 0, ie = s.Length - 1;
            while (ie > ist)
            {
                int i_ssr = s[ist] - 'a';
                bool b_ss = i_ssr >= 0 && i_ssr <= 25;

                int i_scr = s[ist] - 'A';
                bool b_sc = i_scr >= 0 && i_scr <= 25;

                int i_snr = s[ist] - '0';
                bool b_sn = i_snr >= 0 && i_snr <= 9;

                int i_esr = s[ie] - 'a';
                bool b_es = i_esr >= 0 && i_esr <= 25;

                int i_ecr = s[ie] - 'A';
                bool b_ec = i_ecr >= 0 && i_ecr <= 25;

                int i_enr = s[ie] - '0';
                bool b_en = i_enr >= 0 && i_enr <= 9;

                if (b_ss || b_sc || b_sn)
                {
                    if (b_es || b_ec || b_en)
                    {
                        if ((b_es || b_ec) && (b_ss || b_sc))
                        {
                            if (s[ist] - s[ie] == 0 || Math.Abs(s[ist] - s[ie]) == 32)
                            {
                                ist++;
                                ie--;
                            }
                            else
                                return false;
                        }
                        else if (b_en && b_sn)
                        {
                            if (s[ist] - s[ie] == 0)
                            {
                                ist++;
                                ie--;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        ie--;
                }
                else
                    ist++;
            }

            return true;
        }
        #endregion
    }
}
