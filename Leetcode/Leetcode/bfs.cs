using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public partial class Median
    {
        #region bfs
        /// <summary>
        /// 529 - minesweeper
        /// </summary>
        public char[,] UpdateBoard(char[,] board, int[] click)
        {
            if (board == null || click == null || click.Length == 0)
                return board;

            int h = board.GetLength(0);
            int w = board.GetLength(1);


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
                Queue<int[]> que = new Queue<int[]>();
                que.Enqueue(click);
                while (que.Count > 0)
                {
                    int y = que.Peek()[0];
                    int x = que.Peek()[1];

                    int m = CheckNeigbor(ref que, board, h, w, y, x);
                    if (m == 0)
                        board[y, x] = 'B';
                    else
                        board[y, x] = (char)(m + '0');

                    que.Dequeue();
                }
            }
        }

        public int CheckNeigbor(ref Queue<int[]> nei, char[,] board, int h, int w, int y0, int x0)
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
                            if (board[y, x] == 'E')
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
                    nei.Enqueue(iv);
            }

            return m;
        }

        #endregion
    }

    public partial class Hard
    {

    }
}
