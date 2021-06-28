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
        /// 9. 回文数-简单-数学
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome(int x)
        {
            //题目：给你一个整数 x ，如果 x 是一个回文整数，返回 true ；否则，返回 false 。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。例如，121 是回文，而 123 不是。

            //思路：做一个数字反转，判断二者是否相等；这里做一个优化，只反转到一半，x为偶数时判断二者是否相等，x为奇数时判断 reversrNum / 10 == x，因为此时 reversrNum > x，且中间位数字无需判断

            if (x < 0 || (x % 10 == 0 && x != 0)) { return false; }

            int reversrNum = 0;
            while (x > reversrNum)
            {
                int num = x % 10;
                x /= 10;
                reversrNum = reversrNum * 10 + num;
            }
            return (reversrNum == x || reversrNum / 10 == x);
        }
    }
}
