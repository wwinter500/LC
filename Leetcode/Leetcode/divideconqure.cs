using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class Median
    {
        #region divide and conqure
        /*240. Search a 2D Matrix II
         */
        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null)
                return false;

            int h = matrix.GetLength(0);
            int w = matrix.GetLength(1);

            return SearchMatrixHelper(matrix, target, 0, 0, w - 1, h - 1);
        }

        public bool SearchMatrixHelper(int[,] mtr, int target, int x0, int y0, int x1, int y1)
        {
            if (x1 == x0 && y1 == y0)
            {
                if (mtr[y0, x0] == target)
                    return true;
                else
                    return false;
            }

            int midx = x0 + (x1 - x0) / 2;
            int midy = y0 + (y1 - y0) / 2;

            //divide and conqure
            if (mtr[midy, midx] == target)
                return true;
            else if (mtr[midy, midx] < target)
                return (SearchMatrixHelper(mtr, target, x0, y0, midx, midy) || SearchMatrixHelper(mtr, target, midx, y0, x1, midy) || SearchMatrixHelper(mtr, target, x0, midy, midx, y1));
            else
                return (SearchMatrixHelper(mtr, target, x0, y0, midx, midy) || SearchMatrixHelper(mtr, target, midx, midy, x1, y1) || SearchMatrixHelper(mtr, target, x0, midy, midx, y1));
        }
        #endregion        
    }
}
