using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class _Median
    {
        #region 366
        /*
         * Find all tree leaves
         */
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();

            //List<int> level = FindLeavesHelper();                
            //result.Add(level);

            return result;
        }

        public List<int> FindLeavesHelper(ref Stack<TreeNode> s)
        {
            List<int> lv = new List<int>();
            while (s.Count > 0)
            {
                TreeNode p = s.Peek();

            }

            return lv;
        }
        #endregion
        #region 513
        /*
         *513. Find Bottom Left Tree Value
         */
        public int FindBottomLeftValue(TreeNode root)
        {
            //dfs
            if (root == null)
                return 0;

            int h = 0;
            return FindBLValueHelper(root, ref h);
        }

        public int FindBLValueHelper(TreeNode node, ref int height)
        {
            if (node.left == null && node.right == null)
            {
                height++;
                return node.val;
            }

            int rh = height + 1, lh = height + 1;
            int rv = 0, lv = 0;
            if (node.left != null)
                lv = FindBLValueHelper(node.left, ref lh);
            if (node.right != null)
                rv = FindBLValueHelper(node.right, ref rh);

            height = Math.Max(lh, rh);
            return (height == lh ? lv : rv);
        }
        #endregion
        #region 889
        /// <summary>
        /// 889 construct binary tree from pre - post order
        /// </summary>
        public TreeNode ConstructFromPrePost(int[] pre, int[] post)
        {
            if (pre == null || post == null || pre.Length == 0 || post.Length == 0 || pre.Length != post.Length)
                return null;

            Dictionary<int, int> pre_dic = new Dictionary<int, int>();
            for (int i = 0; i < pre.Length; ++i)
                pre_dic.Add(pre[i], i);
            Dictionary<int, int> post_dic = new Dictionary<int, int>();
            for (int i = 0; i < post.Length; ++i)
                post_dic.Add(post[i], i);

            return ConstructFromPrePost(pre_dic, post_dic, pre, 0, pre.Length - 1, post, 0, post.Length - 1);
        }

        public TreeNode ConstructFromPrePost(Dictionary<int, int> pre_dic, Dictionary<int, int> post_dic, int[] pre, int ph, int pe, int[] post, int poh, int poe)
        {
            if (ph > pe || poh > poe)
                return null;

            if (ph == pe)
            {
                TreeNode leave = new TreeNode(pre[ph]);
                return leave;
            }

            if (pe == ph + 1)
            {
                TreeNode leave = new TreeNode(pre[pe]);
                TreeNode lparent = new TreeNode(pre[ph]);

                lparent.left = leave;
                return lparent;
            }

            TreeNode root = new TreeNode(pre[ph]);

            int pre_left = ph + 1;
            int post_left = post_dic[pre[pre_left]];

            int post_right = poe - 1;
            int pre_right = pre_dic[post[post_right]];

            if (pre_right > pre_left)
            {
                root.left = ConstructFromPrePost(pre_dic, post_dic,
                                             pre, pre_left, pre_right - 1,
                                             post, poh, post_left);
                root.right = ConstructFromPrePost(pre_dic, post_dic,
                                                  pre, pre_right, pe,
                                                  post, post_left + 1, post_right);
            }
            else
            {
                root.left = ConstructFromPrePost(pre_dic, post_dic,
                                             pre, pre_left, pe,
                                             post, poh, post_left);
            }

            return root;
        }

        #endregion
        #region 536
        /// <summary>
        /// 536 contruct from string 
        /// </summary>
        public TreeNode Str2tree(string s)
        {
            if (s == null || s.Length == 0)
                return null;

            return Str2tree(s, 0, s.Length - 1);
        }

        public TreeNode Str2tree(string s, int h, int e)
        {
            if (h == e)
            {
                if (s[h] >= '0' && s[h] <= '9')
                    return new TreeNode(s[h] - '0');
                else
                    return null;
            }

            //for single value case
            bool singlevalue = true;
            int sum = 0;
            for (int i = h; i <= e; ++i)
            {
                if (s[i] < '0' || s[i] > '9')
                {
                    singlevalue = false;
                    break;
                }

                sum *= 10;
                sum += s[i] - '0';
            }

            return null;
        }
        #endregion
        #region 666
        public int PathSum(int[] nums)
        {
            Dictionary<int, Dictionary<int, int>> dic = new Dictionary<int, Dictionary<int, int>>();

            //parse
            foreach (int v in nums)
            {
                int cp = v;
                int va = cp % 10;
                cp /= 10;
                int i = cp % 10;
                cp /= 10;
                int l = cp;

                if (dic.ContainsKey(l))
                {
                    if (!dic[l].ContainsKey(i))
                        dic[l].Add(i, va);
                }
                else
                {
                    Dictionary<int, int> subdic = new Dictionary<int, int>();
                    subdic.Add(i, va);
                    dic.Add(l, subdic);
                }
            }

            List<IList<int>> re = GetPaths(dic, 1, 1);
            int sum = 0;
            foreach (List<int> l in re)
                foreach (int v in l)
                    sum += v;

            return sum;
        }

        public List<IList<int>> GetPaths(Dictionary<int, Dictionary<int, int>> dic, int level, int idx)
        {
            List<IList<int>> re = new List<IList<int>>();
            if (dic.ContainsKey(level) && dic[level].ContainsKey(idx))
            {
                if (!dic.ContainsKey(level + 1) || (!dic[level + 1].ContainsKey(idx * 2 - 1) && !dic[level + 1].ContainsKey(idx * 2)))
                {
                    List<int> l = new List<int>();
                    l.Add(dic[level][idx]);
                    re.Add(l);
                }
                else
                {
                    List<IList<int>> left = GetPaths(dic, level + 1, 2 * idx - 1);
                    foreach (List<int> ll in left)
                    {
                        ll.Add(dic[level][idx]);
                        re.Add(ll);
                    }

                    List<IList<int>> right = GetPaths(dic, level + 1, 2 * idx);
                    foreach (List<int> rl in right)
                    {
                        rl.Add(dic[level][idx]);
                        re.Add(rl);
                    }
                }
            }

            return re;
        }

        #endregion
        #region 776*
        public TreeNode[] SplitBST(TreeNode root, int V)
        {
            TreeNode[] re = new TreeNode[2];
            if (root == null)
                return re;

            if (root.val <= V)
            {
                TreeNode[] right = SplitBST(root.right, V);
                if (right != null)
                {
                    root.right = right[0];
                    re[0] = root;
                    re[1] = right[1];
                }
                else
                {
                    re[0] = root;
                    re[1] = null;
                }
            }

            if (root.val > V)
            {
                TreeNode[] left = SplitBST(root.left, V);
                if (left != null)
                {
                    root.left = left[1];
                    re[0] = left[0];
                    re[1] = root;
                }
                else
                {
                    re[0] = null;
                    re[1] = root;
                }
            }

            return re;
        }


        #endregion
        #region 450*
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            //stage 1 find the node
            if (root == null)
                return root;

            if (root.val == key)
            {
                if (root.right == null)
                {
                    TreeNode left = root.left;
                    root.left = null;
                    return left;
                }
                else
                {
                    TreeNode swap = root.right;
                    while (swap.left != null)
                        swap = swap.left;

                    root.val ^= swap.val;
                    swap.val ^= root.val;
                    root.val ^= swap.val;
                }
            }

            root.left = DeleteNode(root.left, key);
            root.right = DeleteNode(root.right, key);

            return root;
        }
        #endregion
        #region 129
        public int SumNumbers(TreeNode root)
        {
            return 0;
        }
        #endregion
        #region 663
        public bool CheckEqualTree(TreeNode root)
        {
            //[1, null, 2, 2]- test case
            int sum = UpdateTree(root);
            if (CheckValueExist(root, sum))
                return true;
            else
                return false;
        }
        public int UpdateTree(TreeNode root)
        {
            if (root == null)
                return 0;
            else if (root.left == null && root.right == null)
                return root.val;
            else
            {
                int lv = UpdateTree(root.left);
                int rv = UpdateTree(root.right);
                root.val += lv + rv;

                return root.val;
            }
        }
        public bool CheckValueExist(TreeNode root, int val)
        {
            if (root == null)
                return false;

            if (root.left != null)
            {
                if (root.left.val * 2 == val)
                    return true;
                else
                {
                    bool left = CheckValueExist(root.left, val);
                    if (left)
                        return true;
                }
            }

            if (root.right != null)
            {
                if (root.right.val * 2 == val)
                    return true;
                else
                {
                    bool right = CheckValueExist(root.right, val);
                    if (right)
                        return true;
                }
            }

            return false;
        }
        #endregion
        #region 199
        public IList<int> RightSideView(TreeNode root)
        {
            List<int> re = new List<int>();
            if (root == null)
                return re;           
            Queue<TreeNode> qu = new Queue<TreeNode>();
            TreeNode cp = root;
            qu.Enqueue(cp);
            while(qu.Count > 0)
            {
                List<TreeNode> list = new List<TreeNode>();
                while(qu.Count > 0)
                {
                    TreeNode tn = qu.Dequeue();
                    if (qu.Count == 0)
                        re.Add(tn.val);

                    if (tn.left != null)
                        list.Add(tn.left);
                    if (tn.right != null)
                        list.Add(tn.right);
                }

                foreach (TreeNode tn in list)
                    qu.Enqueue(tn);
            }

            return re;
        }
        #endregion
    }

    public partial class _Easy
    {
        #region tree
        double min = Double.MaxValue;
        int val = int.MaxValue;
        public int ClosestValue(TreeNode root, double target)
        {
            FindMiniDiff(root, target);
            return val;
        }

        public void FindMiniDiff(TreeNode root, double target)
        {
            double diff = Math.Abs((double)root.val - target);
            if (diff < min)
            {
                val = root.val;
                min = diff;
            }

            if (root.left != null)
                FindMiniDiff(root.left, target);
            if (root.right != null)
                FindMiniDiff(root.right, target);
        }
        #endregion
    }

    public partial class _Hard
    {
        #region 158 max sum path of tree

        #endregion
    }
}
