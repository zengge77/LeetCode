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
        /// 28. 实现 strStr()-简单-字符串
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public static int StrStr(string haystack, string needle)
        {
            //题目：给你两个字符串 haystack 和 needle ，请你在 haystack 字符串中找出 needle 字符串出现的第一个位置（下标从 0 开始）。如果不存在，则返回  -1 。

            //思路：把字符串看成字符集合，双重循环匹配每一字符，寻找正确的位置。

            if (needle.Length == 0) { return -1; }
            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                for (int j = 0; j < needle.Length; j++)
                {
                    if (needle[j] != haystack[i + j]) { break; }
                    if (j == needle.Length - 1) { return i; }
                }
            }
            return -1;

            //现成的api return haystack.IndexOf(needle);
        }
    }
}
