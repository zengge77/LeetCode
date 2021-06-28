using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Solution
    {
        static void Main(string[] args)
        {
            #region 测试用例

            //数组
            int[] nums = new int[] { 3, 1, 2 };

            //二叉树
            TreeNode nodeOne = new TreeNode(4);
            TreeNode nodeTwo = new TreeNode(5);
            TreeNode root = new TreeNode(5, nodeOne, nodeTwo);

            #endregion

            //工作区



            Console.Read();
        }

        //工具方法
        public static void PrintArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }

    //数据结构
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
