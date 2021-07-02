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
        /// 021. 合并两个有序链表-简单-链表
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            //题目：将两个升序链表合并为一个新的 升序 链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。

            //方案1：新链表作返回，双指针遍历俩链表，比大小，小的添加到新链表，并++，继续比较直到任一链表为空，再在新链表上添加剩余链表，得到结果

            //ListNode prehead = new ListNode(0);
            //ListNode current = prehead;

            //while (l1 != null && l2 != null)
            //{
            //    if (l1.val < l2.val)
            //    {
            //        current.next = l1;
            //        l1 = l1.next;
            //    }
            //    else
            //    {
            //        current.next = l2;
            //        l2 = l2.next;
            //    }
            //    current = current.next;
            //}
            //current.next = l1 != null ?l1:l2;

            //return prehead.next;

            //方案2：递归,两个链表头部值较小的一个节点与剩下元素的 merge 操作结果合并

            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }
    }
}
