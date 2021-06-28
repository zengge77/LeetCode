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
        /// 38. 外观数列-中等-字符串
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string CountAndSay(int n)
        {
            //题目：有一个字符串为1，给定一个整数n，生成计数的第n项字符串。字符串内容为“读出”上一个字符串。例如前几项为：1：1   2：11  3：21  4：1211  5：111221

            //思路：设置当前位unit，计数值count，新字符串newNum，遍历字符串取得当前值：
            //当前位不同于当前值：newNum+=count，+=unit，重置unit，count；
            //当前位等同于当前值：count++；
            //当前值为最后一位：newNum+=count，+=unit
            //主要是计数操作count 在循环过程中容易混乱，
            //当涉及改变字符串的操作时最好使用可变字符串StringBuilder来作为容器，结尾再赋值回string

            string num = 1.ToString();

            for (int i = 1; i < n; i++)
            {
                StringBuilder newNum = new StringBuilder();
                int count = 0;
                char unit = num[0];
                for (int j = 0; j < num.Length; j++)
                {
                    if (num[j] != unit)
                    {
                        newNum.Append(count);
                        newNum.Append(unit);
                        count = 0;
                        unit = num[j];
                    }

                    if (num[j] == unit)
                    {
                        count++;
                    }

                    if (j == num.Length - 1)
                    {
                        newNum.Append(count);
                        newNum.Append(unit);
                    }
                }
                num = newNum.ToString();
            }

            return num;
        }
    }
}
