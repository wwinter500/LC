using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Leetcode
{
    public enum easyfunc : int 
    {
        FindRadius = 0,
        FindUnsortedSubarray,
        CountBinaryString,
        IsPalindrome_s,
        dp_climb,
        subset,
        findcloset,
        letterpermutate
    }
    public partial class EasySolution
    {
        public void EasyRun(string func)
        {
            object result = null;
            if (func == easyfunc.FindUnsortedSubarray.ToString())
            {
                int[] test = { 1, 2, 3, 3, 3 };
                //int[] test = {2,6,4,8,10,9,15};
                //int[] test = { 2, 1 };
                result = FindUnsortedSubarray(test);
            }
            if (func == easyfunc.CountBinaryString.ToString())
            {
                //string test = "1111111101010110000111111111111000111110001111111110111110110010111010011111110111111110111111011101111011111110000111101111011011111110111011111011110110010100110111111101101100111110101110100010001011101111001111001100011101110111111111110110001101110101111010010110101010111011111010111000001001111111011000110100101000111101111110111101001011110100111111111100101100011011111010110010101101111110110101111001011000101011110111011001011011101001111111111101000100111011110111011111111011110110011111011111110101001110110111010110011010011010101101110111100011011100111001110110110011110110111001010101110011111111110110111110111001110001111110111111111111110010111100111011111011011110111101111111010100011101110111111110111010010010111101111101111101110110110011111110111010110111101111100011101111100111111011110101000111001101101111111111001111011010111011011111100001110000111101010011110110101111011001010000101111111110110111101111101111001011111110111111110111110110110111111101101101111101110111110010111111111110101011101111011111010101001100111111111111111111100000110111100101011111101011011011111110011011101010100101111111001001011110101101111011100000111110011110010110111111011101110101110001011011101010110110011101010011111111101110111101111000001101010110111100110011001110011110011001111111100111111111100011001011111110110111110111100111111111011101101110101100111110111101111101011011101111011110100101011111111000101110110000110010010111111111111001001101111110110101011011111101011111111010011111111000111011100011001111100110011110011111011111110111100111110100010100100001011111100101110111011111110100100100101010111111011011111001110111000111111111001111111010111101011011011101010001101101110111101111111111010011011010010111101100011011111111001011110111111101111111010011001111101111101111110011011101110110111110010101110110111111111111110011111101010100110111011010101000011101111001111111111111111111101111111010101100001010100110010111000110001110100110001101101100011100111111111101111111111001000001100010010111101111001111110111111111001111110100010011100001110010011110111011011000111111011111111000101111111000111000101011011011100001011110011111111101001110111101101110110101010101001111011110011110101111111010000101111101101101011011111111111101111001011101111110111011011011101101100011111010011110101001110110011011111011111111111110110111101001100101111011111111011011001101100111111110011110101011111101000111111011111111110101100101111100101110100110111101010111110000111111101111110110111111111000100111001011110111010011111101101011001111101110110111100011111111010111011111011111110101001100001011110001100100110011110101111111011111011001111110010101110111111111101010101111010111110001010100111110111111110111101010000111100010011101111111111110111111100100011101100110110000101001010101111111101011111100111111110001110111110101011000111011101011011111010110111110101110111110011111110011010111101110111110100111111100101111011011111101000111101011111011011111111111011011111101100010100100100110011111010110111111100000110111111101110110000110111101110011110101111000111111111011001111011100110101111011011011111111110011111111111111110111011101001001101001010100111110110111110001110010110011111111111111111101111000101000111110011011001011111011100000010111101000000011111011011111111010011111101101100101111111111010111110001011100111011111111001111111110101100010011110110011111100010010111110011111010000011011111111000111111111111011111011110100111101100111111110101110010011111111001111111111111111100010101000110110100011110011110011101110111100101011011101100001101111000110111100101111111101111101110111111010111011111111100110011100100010101101001111010101111111011110111011001101011111011111010011011100111101100010011111011011111100001111011011111011111011110110110101110011111011111011100011110101111110000100010100110111111101111111111110101111111111111111110101110011111101110110101110111101111111010110100111010111100111111001100101011111101111100011111111010111101010010111111111001010111111111110011001111111111111111010111111001100111011111100110100011100000110110110111110101111110110101111101110010011100001011111111110010101101111111111111011110001111101101110111010111111110111011100100011111011011010101011101101110101111100010100110110000111000011011100100111010111111111111110101101010101110101110011100011001001111101111001111111110010101101110100100011110011011111111111111111010110100111101100110100111111101111101101101011000100011110011100111000100010011101101011111010001111110010011001110111101010111000000111111111000101000111111101001111111110000101001110111111011011111001000110011111101011001010100011011111001100101111111100111100111011111010011110001111110111111110000011110011110110100100010111110111100110110110100110010010111100011111101110101111011100101111000010011110011111100011010001101011001110110001011110011111110011110001111100111101011111111101010100011001111100111010111111110100011111111111111011111011110111110111000101011111011111101110111110011101010000111111111101011111111010011011110111011101101111111110111100101111111111100010001110110111111001001010111110101110111110010011111100111010101111010010010110100110101111111111111010101111111011101110011111011111111101101111101110111110010011011101010111110110011111011011100110011011101111001101010000010001011111110010111011111011101010101101111001111111110101001111110111011100010101011111010001001110101101011001111010111010111101100111111100101110011101100111111101101110110101101010111101000001011111011110101001101101110110101011111011111110101111100011100001111101111101011111101101110111101111111110001101110111111111101101000001111100111111111011001111111111011001011001110111010111000101001000111100101111111011111111010101011010111110101100111000111111100111001101001100000111011011000101111110000111001111011110010111011101111101110111101010011001110110111111111100011111000100110111111100000101011111110101110111100101111100111101010101111111111101111111001101101111010011111111111011101110100111001111101110100100111011010011101101001111010111111110101001101110010001111111001011111010110111110000110111110001101001111111001111111111111010110011101001111000111000101100111111100110110101111001111000111010001000110010100110111001001110011010111011111001100110111111110111111101010101010000111011001011010110011111100011101101111111011111100000111101010001111111001111101111111111000110110101111100011110110010100111111101010011101011100110010010011001011011110010111011111100101011111110111001001011110101100111110101100011111111011111110101111001110110000110101011011111011110010011010110110001001110100010101111010111010010011111001110011111101011001110111101111110101011001001010111111101011011111011111111011111110110010111011111110110111101011110001111111101111110111110100011011011010100100111110110101101101110111110111010110011111011010101111000111111111011110100011001100000111111111011101011111111011100000010100110110101001101001010111110111011101101010111011101010011101101101111101111000010111101000110111110111110011111111011111110111110111110111111101111101111010111110011110111001111011101111111100100111100111111111001111011010110001111111111111111100011101111011110010111101111010011111100110111001111111001111110011001001110101011001100101101001010110011111101011111111100101110110110111111111111011100111000111110110011011001000101010110110010001010011111000101010111111010111111100011111111001111100000011011111111010110101110011111111111101100011101111011111111111000111011111011001101100110111100011101111101011101111110101101100111111010011111111111111111011101101111110100111111111101111011101110001011111000010011110111011011011001011011010111010110011111101011011010001111010110111111100010110100110111101111001011101011111111111101111100001101111111001011111101111001110110111111111111101010110101110110101110111111111111110110100110111100111101010110111011000100101011111101110111001101111100110010101111001010101100101101011110111110011000100100010100100011111101010011110100001110100110110111001111001111101101110010101110110111111111101111111000100000111110111011101110010111101001001110110001011011101100010111110011110111111011101100111011111011100111010101001101110101110010010101111111010111111111011001101111000010011111111110011111111111110110111011101011011011111111010110111110010110111111111101001100100001101000011011011101100110111001101111111000101100110110010110100111110010111101011111111111110011101110111111101101001111011111111011101101011111100101010100111101100100101101101111100110001110101100111011000111111010101111010111110010010001111111110110100011111110011111111111011100101110011111110111111100111001111110110111011101010010101010011001011110101110010100111111100011110111101101111101101110101100101111111000110111111111011100010000110011100010001111010011010111101100110111100111110001101101011111110110010011111010001001111101101101010011011111010000111111000011111110101111101101000011101001101101010111100111111001111101111011111010111111010001001111111010110110101110111110011111000000001011101110111111110101110101111110101001010001100001111011101111110101101001111110111110110011111010111011000011101101111011111011011110000011010111111110101111000111111111011111101110111110000111001001111110110100101111000001001111111010110011011000111001011100111111110011110001111111100111010111111110100001011100101011011001101111110000001001111111000100011111110100001111111011110110101111110000110110001111110001111110101101110010000110001011110000110101010111101110011100101011111101111111011101110111000011110110011010110110011010110111010111100101111101110000111100111110100111110100111011001001100000111101111110111110001101101010111001101111111000111111011101111110010111111100110111111111111001110111110000100111111111010100011111110011111110111111111111111111100111111011100011111100111110010111101001001111111001101101010011100000010111111010111101101100";
                //string test = "00110";
                string test = "10101";
                result = CountBinarySubstrings(test);
            }
            if (func == easyfunc.IsPalindrome_s.ToString())
            {
                string test = "A man, a plan, a canal: Panama";
                //string test = "race a car";
                //string test = "0P";
                result = IsPalindrome(test);
            }
            if (func == easyfunc.dp_climb.ToString())
            {
                int[] test = { 0, 1, 2, 0 };
                result = MinCostClimbingStairs(test);
            }
            if (func == easyfunc.subset.ToString())
            {
                List<IList<int>> r = Getsubset(5, 1, 5);
                foreach (List<int> str in r)
                {
                    string s = "";
                    foreach (int val in str)
                        s += val.ToString() + " ";

                    Console.WriteLine(s);
                }

                result = r.Count;
            }
            if (func == easyfunc.letterpermutate.ToString())
            {
                IList<string> r = LetterCasePermutation("C");
                foreach (string s in r)
                    Console.WriteLine(s);
            }
            Console.WriteLine("result: {0}", result);            
        }
        /**/
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

        ////////////////////////////////
        #region string
        /*581. Shortest Unsorted Continuous Subarray
        Given an integer array, you need to find one continuous subarray that if you only sort this subarray in ascending order, 
        then the whole array will be sorted in ascending order, too.
        You need to find the shortest such subarray and output its length.
        [2, 6, 4, 8, 10, 9, 15] -> [6, 4, 8, 10, 9]
        */
        public int FindUnsortedSubarray(int[] nums) {
	        int result = 0;
            int len = nums.Length;            
            //TODO : find the shortest array to be ascended.
            //top to bottom to recursive             
            int head = 0, end = len - 1;
            int preh = head, pree = end;
            while (end > head)
            {                            
                Console.WriteLine("{0}_{1}", head, end);
                if (needSort(nums, ref head, ref end))
                {
                    if (preh == head && pree == end)
                    {
                        //
                        result = end - head + 1;
                        break;
                    }
                    
                    preh = head;
                    pree = end;
                }                
            }
            
            return result;
        }

        private bool needSort(int[] nums, ref int head, ref int end)
        {
            int max = 0, min = 10000;
            int imax = 0, imin = 0;
            //find min and max loc
            for (int i = head; i <= end; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                    imax = i;
                }

                if (nums[i] < min)
                {
                    min = nums[i];
                    imin = i;
                }
            }

            //check if loc is on end
            bool result = false;
            if (imin != head)            
                result = true;            
            else
                head++;

            if (imax != end)
                result = true;
            else
                end--;
                
            return result;
        }

        ///////////////////////////////////////////////////////////////////////////////               
        /*
         * 696 - solution 2
         */ 
        public int CountBinarySubstrings(string s, int i=0)
        {
            int w_width = (s.Length / 2) * 2;
            
            return CountHelper(s, w_width, 0, s.Length - 1);
        }

        public int CountHelper(string s, int width, int start, int end)
        {
            int sum = 0;
            if (width < 2)
                return 0;

            int ilen = start + width - 1;
            
            //check within start - end
            for(int ip = start; ip <= end - (width - 1);)
            {
                //ip - ip + width
                if(CheckZeroString(s, ip, width))
                {
                    sum += width / 2;
                    start = end;
                    
                }
                else
                {
                    sum += CountHelper(s, width / 2, ip, ip + width - 1);
                }
                    
            }

            return sum;
        }

        public bool CheckZeroString(string s, int head, int width)
        {
            int h = head, w = width, mid = w / 2;
            bool converse = (1 - (s[head] - '0') == (s[head + width - 1] - '0') ? true : false);
            for (int i = 0; i < mid; i++)
            {
                if (!converse || s[i + head] != s[head] || s[w - i + head - 1] != s[w + head - 1])
                    return false;
            }

            return true;
        }

        /**/
        #endregion      
        #region dfs
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
            foreach(NestedInteger ni in list)
            {
                if (ni.IsInteger())
                    sum += level * ni.GetInteger();//single number
                else 
                    sum += DepthSumOnLevel(ni.GetList(), level+1);//list
            }

            return sum;
        }

        /*
         * 784. Letter Case Permutation
         */
        public IList<string> LetterCasePermutation(string S)
        {
            List<string> re = new List<string>();
            if (S == null)
                return re;

            List<int> input = new List<int>();
            for(int i = 0; i < S.Length; ++i)
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
        public void PermutationHelper(ref List<IList<int>>  re, List<int> l, int start)
        {            
            if(start == l.Count - 1)
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
                foreach(List<int> l1 in re)
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
            
            for(int i = 0; i < row; i++)
                for(int j = 0; j < col; j++)
                {
                    int area = dfs(grid,ref visited, row, col, i, j);
                    if (maxSum < area)
                        maxSum = area;                   
                }

            return maxSum;
        }

        public int dfs(int[,] grid, ref int[,] visited,int h, int w, int iy, int ix)
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
            while(ie > ist)
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
        #region dynamic programming
        /*256 paint house - 265 pain house II(hard)
         */
        public int MinCost(int[,] costs)
        {
            int result = int.MaxValue;
            int nhouse = costs.GetLength(0);
            int ncolor = costs.GetLength(1);

            if (nhouse == 0 || ncolor == 0)
                return 0;

            //define optimal substructure
            int[,] recorder = new int[nhouse, ncolor];

            //define status transfier equlation
            for(int c = 0; c < ncolor; c++)
            {
                recorder[0, c] = costs[0, c];
            }
            
            for(int i = 1; i < nhouse; i++)
            {                
                for(int c = 0; c < ncolor; c++)
                {
                    recorder[i, c] = int.MaxValue;
                    for (int c2 = 0; c2 < ncolor; c2++)
                    {
                        if(c2 != c)
                        {
                            int temp = recorder[i - 1, c2] + costs[i, c];
                            if (recorder[i, c] > temp)
                                recorder[i, c] = temp;
                        }                        
                    }                     
                }
            }


            for (int c = 0; c < ncolor; c++)
                if (result > recorder[nhouse - 1, c])
                    result = recorder[nhouse - 1, c];
            return result;
        }

        /*746. Min Cost Climbing Stairs
         */
        public int MinCostClimbingStairs(int[] cost)
        {
            int nl = cost.Length;
            if (nl == 0)
                return 0;
            //define optimal substructure
            int[] recorder = new int[nl];

            //define status transifer equlation
            recorder[0] = 0;
            recorder[1] = 0;
            for(int i = 2; i < nl; i++)
            {
               recorder[i] = Math.Min(recorder[i - 1] + cost[i - 1], recorder[i - 2] + cost[i - 2]);                
            }

            string m = "";
            for (int i = 0; i < nl; i++)
                m += recorder[i].ToString() + "_";
            Console.WriteLine(m);

            return Math.Min(recorder[nl - 1] + cost[nl - 1], recorder[nl - 2] + cost[nl - 2]);
        }

        /*276 paint fence
         */
        public int NumWays(int n, int k)
        {
            int total = 0;
            if (n <= 0 || k <= 0)
                return 0;

            //define optimal sub structure - total numbers
            int[,] recorder = new int[n, k];

            //define status transmission equalation
            for (int c = 0; c < k; c++)
                recorder[0, c] = 1;
            for(int f = 0; f < n; f++)
            {
                for(int c = 0; c < k; c++)
                {
                    if (f == 0)
                        recorder[f, c] = 1;
                    else
                    {
                        recorder[f, c] = 0;
                    }
                }
            }

            return total;
        }
        #endregion
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
        #region back track
        /*401. binary watch
         */
        public IList<string> ReadBinaryWatch(int num)
        {
            //            
            List<string> r = new List<string>();

            for(int i = 1; i < num; i++)
            {
                List<IList<int>> hour = Getsubset(i, 1, 3);
            }
            return r;
        }   
        
        public List<IList<int>> Getsubset(int ci, int start ,int end)
        {
            List<IList<int>> ll = new List<IList<int>>();
            int n = end - start + 1;
            
            if (ci < 1)
                return ll;
            if (n < ci)
                return ll;
            if (n == ci)
            {
                List<int> l = new List<int>();
                for (int i = start; i < start + n; i++)
                    l.Add(i);

                ll.Add(l);
                return ll;
            }
            
            if(ci == 1)
            {
                for (int i = start; i < start + n; i++)
                {
                    List<int> l = new List<int>();
                    l.Add(i);
                    ll.Add(l);
                }
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    List<IList<int>> sll = Getsubset(ci - 1, i + 1, end);//
                    
                    foreach (List<int> sl in sll)
                    {
                        List<int> nl = new List<int>(sl);
                        nl.Add(i);
                        ll.Add(nl);
                    }                    
                }
            }
            
            return ll;
        }
        #endregion

        public int FindCloset(int val, List<int> arr, int start, int end)
        {
            if (start == end)
                return Math.Abs(arr[start] - val);
            else if (start == end - 1)
                return Math.Min(Math.Abs(arr[start] - val), Math.Abs(arr[end] - val));
            else
            {
                int mid = (start + end) / 2;
                int dl = FindCloset(val, arr, start, mid);
                int dr = FindCloset(val, arr, mid + 1, end);

                return Math.Min(dl, dr);
            }
        }
    }
}
