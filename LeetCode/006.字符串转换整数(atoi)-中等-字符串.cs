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
        /// 006.字符串转换整数 (atoi)-中等-字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MyAtoi(string s)
        {
            /*题目：请你来实现一个 myAtoi(string s) 函数，使其能将字符串转换成一个 32 位有符号整数（类似 C/C++ 中的 atoi 函数）。
            函数 myAtoi(string s) 的算法如下：

            读入字符串并丢弃无用的前导空格
            检查下一个字符（假设还未到字符末尾）为正还是负号，读取该字符（如果有）。 确定最终结果是负数还是正数。 如果两者都不存在，则假定结果为正。
            读入下一个字符，直到到达下一个非数字字符或到达输入的结尾。字符串的其余部分将被忽略。
            将前面步骤读入的这些数字转换为整数（即，"123"-> 123， "0032"-> 32）。如果没有读入数字，则整数为 0 。必要时更改符号（从步骤 2 开始）。
            如果整数数超过 32 位有符号整数范围[−231, 231 − 1] ，需要截断这个整数，使其保持在这个范围内。具体来说，小于 −231 的整数应该被固定为 −231 ，大于 231− 1 的整数应该被固定为 231− 1 。
            返回整数作为最终结果。
            注意：
            本题中的空白字符只包括空格字符 ' ' 。
            除前导空格或数字后的其余字符串外，请勿忽略 任何其他字符。
            */

            //思路：直接上

            if (s.Length == 0) { return 0; }

            int result = 0;

            //忽略空格
            int index = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ') { index++; }
                else { break; }
            }
            //单空格判断
            if (index >= s.Length) { return 0; }


            //正负判断
            bool isPositive = true;
            if (s[index] == '-') { isPositive = false; index++; }
            else if (s[index] == '+') { index++; }

            //数字判断
            for (int i = index; i < s.Length; i++)
            {
                //数字
                if (s[i] >= '0' && s[i] <= '9')
                {
                    // 判断是否溢出
                    if (isPositive)
                    {
                        if (result > int.MaxValue / 10) return int.MaxValue;
                        if (result == int.MaxValue / 10 && s[i] >= '7') return int.MaxValue;
                    }
                    else
                    {
                        if (result > int.MaxValue / 10) return int.MinValue;
                        if (result == int.MaxValue / 10 && s[i] >= '8') return int.MinValue;
                    }

                    // 更新结果，s[i] - '0' 为char转int的便捷方法
                    result = result * 10 + (s[i] - '0');
                }
                // 非数字，直接返回结果
                else return result * (isPositive ? 1 : -1);
            }

            return result * (isPositive ? 1 : -1);
        }
    }
}
