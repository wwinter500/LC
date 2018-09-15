using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class Median
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
            int re = 0;
            Dictionary<int, Dictionary<int, int>> dic = new Dictionary<int, Dictionary<int, int>>();

            //parse
            foreach(int v in nums)
            {
                int cp = v;
                int va = cp % 10;
                cp /= 10;
                int i = cp % 10;
                cp /= 10;
                int l = cp;

                if(dic.ContainsKey(l))
                {
                    if(!dic[l].ContainsKey(i))                    
                        dic[l].Add(i, va);                    
                }
                else
                {
                    Dictionary<int, int> subdic = new Dictionary<int, int>();
                    subdic.Add(i, va);
                    dic.Add(l, subdic);
                }
            }

            List<int> ll = new List<int>(dic.Keys);            
            return GetSum(dic, ll[ll.Count - 1], 1, 1);
        }

        public int GetSum(Dictionary<int, Dictionary<int,int>> dic, int max, int level, int idx)
        {
            if (!dic[level].ContainsKey(idx))
                return 0;

            if(level == max)            
                return dic[level][idx];                

            int re = 0;
            int leftv = GetSum(dic, max, level + 1, idx * 2 - 1);
            if(leftv != 0)            
                re += dic[level][idx] + leftv;

            int rightv = GetSum(dic, max, level + 1, idx * 2);
            if (rightv != 0)
                re += dic[level][idx] + rightv;

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
}
