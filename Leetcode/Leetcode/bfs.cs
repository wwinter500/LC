﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class _Median
    {
        #region 529
        /// <summary>
        /// 529 - minesweeper
        /// </summary>
        public char[,] UpdateBoard(char[,] board, int[] click)
        {
            if (board == null || click == null || click.Length == 0)
                return board;

            int h = board.GetLength(0);
            int w = board.GetLength(1);

            ClickAction(ref board, h, w, click);
            return board;
        }

        public void ClickAction(ref char[,] board, int h, int w, int[] click)
        {
            int y0 = click[0], x0 = click[1];
            if (y0 < 0 || y0 >= h || x0 < 0 || x0 >= w)
                return;
            
            if (board[y0, x0] == 'M')
            {
                board[y0, x0] = 'X';
                return;
            }
            else if (board[y0, x0] == 'E')
            {
                int[,] visited = new int[h, w];
                Queue<int[]> que = new Queue<int[]>();
                que.Enqueue(click);
                while (que.Count > 0)
                {
                    int y = que.Peek()[0];
                    int x = que.Peek()[1];

                    int m = CheckNeigbor(ref que, ref visited, board, h, w, y, x);
                    if (m == 0)
                        board[y, x] = 'B';
                    else
                        board[y, x] = (char)(m + '0');

                    que.Dequeue();
                }
            }
        }

        public int CheckNeigbor(ref Queue<int[]> nei, ref int[,] visited, char[,] board, int h, int w, int y0, int x0)
        {
            int m = 0;
            List<int[]> l = new List<int[]>();
            for (int iy = -1; iy <= 1; ++iy)
            {
                int y = y0 + iy;
                if (y >= 0 && y < h)
                {
                    for (int ix = -1; ix <= 1; ++ix)
                    {
                        int x = ix + x0;
                        if (x >= 0 && x < w)
                        {
                            if (board[y, x] == 'E' && visited[y,x] == 0)
                            {
                                int[] ic = new int[2] { y, x };
                                l.Add(ic);
                            }
                            else if (board[y, x] == 'M')
                            {
                                m++;
                            }
                        }
                    }
                }
            }

            if (m == 0)
            {
                foreach (int[] iv in l)
                {
                    visited[iv[0], iv[1]] = 1;
                    nei.Enqueue(iv);
                }
                    
            }

            return m;
        }
        #endregion
        #region 310
        public IList<int> FindMinHeightTrees(int n, int[,] edges)
        {
            List<int> re = new List<int>();
            Queue<int> qu = new Queue<int>();


            return re;
        }
        #endregion
    }

    public partial class _Hard
    {

    }
}
