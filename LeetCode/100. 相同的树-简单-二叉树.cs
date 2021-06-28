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
        /// 100. 相同的树-简单-二叉树
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            //题目：给你两棵二叉树的根节点 p 和 q ，编写一个函数来检验这两棵树是否相同。如果两个树在结构上相同，并且节点具有相同的值，则认为它们是相同的。

            //方案1，递归

            ////空判断
            //if (p == null && q == null) { return true; }
            //if ((p == null && q != null) || (p != null && q == null)) { return false; }
            ////数值不同判断
            //if (p.val != q.val) { return false; }
            ////递归
            //return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);


            //方案2，双队列
            Queue<TreeNode> PNodes = new Queue<TreeNode>();
            Queue<TreeNode> QNodes = new Queue<TreeNode>();
            PNodes.Enqueue(p);
            QNodes.Enqueue(q);
            while (PNodes.Count > 0 && QNodes.Count > 0)
            {
                TreeNode P = PNodes.Dequeue();
                TreeNode Q = QNodes.Dequeue();
                if (P != null) { PNodes.Enqueue(P.left); PNodes.Enqueue(P.right); }
                if (Q != null) { QNodes.Enqueue(Q.left); QNodes.Enqueue(Q.right); }

                if (P == null && Q == null) { continue; }
                if ((P == null && Q != null) || (P != null && Q == null)) { return false; }
                if (P.val != Q.val) { return false; }
            }
            return true;
        }
    }
}
