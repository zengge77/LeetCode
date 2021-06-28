using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class 剑指Offer
    {
        /// <summary>
        /// 32 - I. 从上到下打印二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int[] LevelOrder(TreeNode root)
        {
            if (root == null) { return new int[] { }; }

            List<int> values = new List<int>();
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);
            while (nodes.Count > 0)
            {
                TreeNode node = nodes.Dequeue();
                if (node.left != null) { nodes.Enqueue(node.left); }
                if (node.right != null) { nodes.Enqueue(node.right); }
                values.Add(node.val);
            }
            int[] result = new int[values.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = values[i];
            }
            return result;
        }
    }
}
