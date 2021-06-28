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
        /// 20. 有效的括号-简单-字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValid(string s)
        {
            //题目：给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串 s ，判断字符串是否有效。
            //有效字符串需满足：左括号必须用相同类型的右括号闭合。左括号必须以正确的顺序闭合。

            //思路：利用栈后进先出的特性，一一配对消除，检查不配对的字符；最后再检查栈是否为空

            Stack<char> stack = new Stack<char>();

            foreach (char c in s.ToCharArray())
            {
                if (c == '(')
                    stack.Push(')');
                else if (c == '{')
                    stack.Push('}');
                else if (c == '[')
                    stack.Push(']');
                else if (stack.Count == 0 || stack.Pop() != c)
                    return false;
            }
            return stack.Count == 0;
        }
    }
}
