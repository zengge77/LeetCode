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
        /// 226. 翻转二叉树-简单-二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static TreeNode InvertTree(TreeNode root)
        {
            //题目：y轴镜像翻转二叉树

            //思路：递归
            if (root == null) { return null; }

            if (root.left != null || root.right != null)
            {
                root.left = InvertTree(root.left);
                root.right = InvertTree(root.right);
            }

            TreeNode tempLeft = root.left;
            root.left = root.right;
            root.right = tempLeft;
            return root;
        }
    }
}
