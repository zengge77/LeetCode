using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class Problems
    {
        /// <summary>
        /// 200. 岛屿数量-中等-搜索
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int NumIslands(char[][] grid)
        {
            //题目：给你一个由 '1'（陆地）和 '0'（水）组成的的二维网格，请你计算网格中岛屿的数量。岛屿总是被水包围，并且每座岛屿只能由水平方向和 / 或竖直方向上相邻的陆地连接形成。此外，你可以假设该网格的四条边均被水包围。

            //思路：DFS或BFS

            //注意：char[][]是交错数组，不是二维数组，获取长宽用下面的方法
            int row = grid.Length;
            int col = grid[0].Length;

            if (grid == null || row == 0) { return 0; }

            int count = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    //遇到1时获取所有相连的格子，并改为0，count+1
                    if (grid[i][j] == '1')
                    {
                        NumIslandsDFS(grid, i, j);
                        count++;
                    }
                }
            }
            return count;
        }
        public static void NumIslandsDFS(char[][] grid, int h, int w)
        {
            //已遍历过的或本来是水的直接返回
            if (grid[h][w] == '0') { return; }
            //未遍历的改为0，视为遍历
            else { grid[h][w] = '0'; }
            //向四周递归
            int row = grid.Length;
            int col = grid[0].Length;
            if (h - 1 >= 0) { NumIslandsDFS(grid, h - 1, w); }
            if (h + 1 < row) { NumIslandsDFS(grid, h + 1, w); }
            if (w - 1 >= 0) { NumIslandsDFS(grid, h, w - 1); }
            if (w + 1 < col) { NumIslandsDFS(grid, h, w + 1); }
        }
    }
}
