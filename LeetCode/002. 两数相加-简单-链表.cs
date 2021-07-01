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
        /// 002. 两数相加-简单-链表
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //题目：给你两个 非空 的链表，表示两个非负的整数。它们每位数字都是按照 逆序 的方式存储的，并且每个节点只能存储 一位 数字。请你将两个数相加，并以相同形式返回一个表示和的链表。你可以假设除了数字 0 之外，这两个数都不会以 0 开头。

            //思路：为了不丢失链表头，我们在一开始使用一个firstNode和currentNode指向同一个ndoe，后续currentNode添加next并移动，但firstNode的next不会变。，最后返回firstNode.next

            ListNode firstNode = new ListNode(0);
            ListNode currentNode = firstNode;

            int add = 0;
            while (l1 != null || l2 != null)
            {
                int l1value = l1 != null ? l1.val : 0;
                int l2value = l2 != null ? l2.val : 0;
                int sum = l1value + l2value + add;
                int num = sum % 10;
                add = sum / 10;

                currentNode.next = new ListNode(num);
                currentNode = currentNode.next;

                if (l1 != null) { l1 = l1.next; }
                if (l2 != null) { l2 = l2.next; }
            }
            if (add != 0) { currentNode.next = new ListNode(1); }

            return firstNode.next;
        }

    }
}
