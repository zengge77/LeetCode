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
        /// 14. 最长公共前缀-简单-字符串
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string LongestCommonPrefix(string[] strs)
        {
            //题目：编写一个函数来查找字符串数组中的最长公共前缀。如果不存在公共前缀，返回空字符串 ""。

            //思路：利用string.Indexof(string)，包含且在第一位开始为为0，包含但不在第一位为下标，不包含为-1

            if (strs.Length == 0) { return ""; };

            string commonPrefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                while (strs[i].IndexOf(commonPrefix) != 0)
                {
                    commonPrefix = commonPrefix.Substring(0, commonPrefix.Length - 1);
                    if (commonPrefix.Length == 0) { return ""; };
                }
            }
            return commonPrefix;
        }
    }
}
