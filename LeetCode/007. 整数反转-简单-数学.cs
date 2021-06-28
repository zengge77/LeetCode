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
        /// 7. 整数反转-简单-数学
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            //题目：给你一个 32 位的有符号整数 x ，返回将 x 中的数字部分反转后的结果。如果反转后整数超过 32 位的有符号整数的范围[−231, 231 − 1] ，就返回 0。

            //思路：求余，降位，再升位加余，最后得到结果；注意边界条件，每次升位前计算是否会超标

            int reverseNum = 0;
            while (x != 0)
            {
                int num = x % 10;
                x = x / 10;
                if (reverseNum > Int32.MaxValue / 10 || (reverseNum == Int32.MaxValue / 10 && num > 7)) { return 0; }
                if (reverseNum < Int32.MinValue / 10 || (reverseNum == Int32.MinValue / 10 && num < -8)) { return 0; }
                reverseNum = reverseNum * 10 + num;
            }
            return reverseNum;
        }
    }
}
