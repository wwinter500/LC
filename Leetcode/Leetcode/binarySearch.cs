using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class Median
    {
        #region 454
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            int re = 0;
            Dictionary<int, List<int[]>> dic = new Dictionary<int, List<int[]>>();
            int len = A.Length;
            for(int g0 = 0; g0 < 3; g0++)
                for(int g1= g0 + 1; g1 < 4; g1++)
                {
                    int[] cp0 = null, cp1 = null;
                    if (g0 == 0)
                        cp0 = A;
                    if (g0 == 1)
                        cp0 = B;
                    if (g0 == 2)
                        cp0 = C;
                    if (g0 == 3)
                        cp0 = D;

                    if (g1 == 0)
                        cp1 = A;
                    if (g1 == 1)
                        cp1 = B;
                    if (g1 == 2)
                        cp1 = C;
                    if (g1 == 3)
                        cp1 = D;

                    for (int i = 0; i < len; ++i)
                        for (int j = 0; j < len; ++j)
                        {
                            int sum = cp0[i] + cp1[j];
                            if(dic.ContainsKey(sum))
                            {
                                int[] arr = new int[4];
                                arr[0] = g0;
                                arr[1] = g1;
                                arr[2] = i;
                                arr[3] = j;
                                dic[sum].Add(arr);
                            }
                            else
                            {
                                List<int[]> l = new List<int[]>();
                                int[] arr = new int[4];
                                arr[0] = g0;
                                arr[1] = g1;
                                arr[2] = i;
                                arr[3] = j;

                                l.Add(arr);
                                dic.Add(sum, l);
                            }
                        }                    
                }

            List<int> r = new List<int>(dic.Keys);
            foreach(int v in r)
            {
                if(dic.ContainsKey(-v))
                {
                    if(v != -v)
                    {
                        foreach(int[] a0 in dic[v])
                            foreach(int[] a1 in dic[-v])
                            {
                                if (a0[0] != a1[0] && a0[1] != a1[0] && a0[0] != a1[1] && a0[1] != a1[1])
                                {
                                    //Console.WriteLine(a0[0] + "_" + a0[2] + " " + a0[1] + "_" + a0[3] + " " 
                                    //                + a1[0] + "_" + a1[2] + " " + a1[1] + "_" + a1[3]);

                                    Console.WriteLine(v + " " + -v);
                                    re++;
                                }                                    
                            }

                        Console.WriteLine("-----------");
                        //dic.Remove(v);
                        //dic.Remove(-v);
                    }
                    else
                    {
                        for(int i = 0; i < dic[v].Count - 1; ++i)
                            for(int j = i + 1; j < dic[v].Count; ++j)
                            {
                                int[] a0 = dic[v][i];
                                int[] a1 = dic[v][j];

                                if (a0[0] != a1[0] && a0[1] != a1[0] && a0[0] != a1[1] && a0[1] != a1[1])
                                {
                                    //Console.WriteLine(a0[0] + "_" + a0[2] + " " + a0[1] + "_" + a0[3] + " "
                                    //                + a1[0] + "_" + a1[2] + " " + a1[1] + "_" + a1[3]);

                                    Console.WriteLine(v + " " + -v);
                                    re++;
                                }                                    
                            }

                        Console.WriteLine("-----------");
                        //dic.Remove(v);
                    }
                }
            }

            return re;
        }        
        #endregion
    }
}
