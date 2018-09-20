using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Leetcode
{
    public partial class _Median
    {
        
    }

    public partial class _Easy
    {
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

    }
}
