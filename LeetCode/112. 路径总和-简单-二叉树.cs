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
        /// 112. 路径总和-简单-二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public static bool HasPathSum(TreeNode root, int targetSum)
        {
            //题目：给你二叉树的根节点 root 和一个表示目标和的整数 targetSum ，判断该树中是否存在 根节点到叶子节点 的路径，这条路径上所有节点值相加等于目标和 targetSum 。


            //方案1：递归，非叶节点时将剩余值传递下去，叶节点时判断该路径是否正确

            //空树空结点判断
            if (root == null) { return false; }

            //叶子节点，判断该路线最终结果
            if (root.left == null && root.right == null) { return root.val == targetSum; }

            //非叶子节点，递归；子节点为空时也调用，会被空树空结点判断返回false
            return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);


            //方案2：双队列记录节点和实时结果

            //if (root == null) { return false; }
            //Queue<TreeNode> nodes = new Queue<TreeNode>();
            //Queue<int> results = new Queue<int>();
            //nodes.Enqueue(root);
            //results.Enqueue(root.val);
            //while (nodes.Count != 0)
            //{
            //    TreeNode node = nodes.Dequeue();
            //    int sum = results.Dequeue();
            //    if (node.left != null) { nodes.Enqueue(node.left); results.Enqueue(sum + node.left.val); }
            //    if (node.right != null) { nodes.Enqueue(node.right); results.Enqueue(sum + node.right.val); }
            //    if (node.left == null && node.right == null && sum == targetSum) { return true; }
            //}
            //return false;
        }
    }
}
