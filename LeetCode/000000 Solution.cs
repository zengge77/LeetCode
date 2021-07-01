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

            Problems problems = new Problems();

            //数组
            int[] nums = new int[] { 3, 1, 2 };

            //二叉树
            TreeNode nodeOne = new TreeNode(4);
            TreeNode nodeTwo = new TreeNode(5);
            TreeNode root = new TreeNode(5, nodeOne, nodeTwo);

            //链表
            ListNode l1 = new ListNode(1);
            ListNode listNodeTwo = new ListNode(2);
            ListNode listNodeThree = new ListNode(3);
            l1.next = listNodeTwo;
            listNodeTwo.next = listNodeThree;

            ListNode l2 = new ListNode(4);
            ListNode listNodeFive = new ListNode(5);
            ListNode listNodeSix = new ListNode(7);
            l2.next = listNodeFive;
            listNodeFive.next = listNodeSix;

            #endregion

            //工作区
            PrintListNode(problems.AddTwoNumbers(l1,l2));

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

        public static void PrintListNode(ListNode listNode)
        {
            ListNode current = listNode;
            while (current != null)
            {
                Console.Write(current.val);
                current = current.next;
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

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
