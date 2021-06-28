using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class 题库101_200
    {
        /// <summary>
        /// 124. 二叉树中的最大路径和-困难-二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxPathSum(TreeNode root)
        {
            //题目:给你一个二叉树的根节点 root ，返回其 最大路径和 。
            //路径 被定义为一条从树中任意节点出发，沿父节点-子节点连接，达到任意节点的序列。同一个节点在一条路径序列中 至多出现一次 。该路径 至少包含一个 节点，且不一定经过根节点。路径和 是路径中各节点值的总和。

            //思路：自然想到DFS+递归，从下往上出结果；因为最大路径可能不会经过根节点，因此使用一个max来记录最大路径和，在递归过程中更新max，我们这里不使用全局参数，使用ref
            
            int max = Int32.MinValue;
            GetMaxPathSum(root, ref max);
            return max;
        }
        public static int GetMaxPathSum(TreeNode root, ref int max)
        {
            /*
             * 当前节点计算路径最大值有以下几种情况，我们一步步计算并对比出最大值
             * 1.最大值完全在左或右子树
             * 2.最大值在当前节点，因为左或右子树皆为负值
             * 3.最大值在当前节点+左或右子树
             * 4.最大值经过左-当前-右
            */

            if (root == null) { return 0; }
            
            //获取最大子树
            int l = GetMaxPathSum(root.left, ref max);
            int r = GetMaxPathSum(root.right, ref max);
            int biggerSub = Math.Max(l, r);

            //单边：自身+最大子树
            int singleSide = Math.Max(root.val, root.val + biggerSub);

            //双边：自身+双子树；注意：该情况下路径经过左中右，又因为路径只能走一次，所以不能作为返回值返回，只做更新max用
            int doubleSide = Math.Max(root.val + l + r, singleSide);
            max = Math.Max(max, doubleSide);

            //返回单边
            return singleSide;
        }

        /// <summary>
        /// 200. 岛屿数量
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int NumIslands(char[][] grid)
        {
            //给你一个由 '1'（陆地）和 '0'（水）组成的的二维网格，请你计算网格中岛屿的数量。岛屿总是被水包围，并且每座岛屿只能由水平方向和 / 或竖直方向上相邻的陆地连接形成。此外，你可以假设该网格的四条边均被水包围。

            //DFS或BFS

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

