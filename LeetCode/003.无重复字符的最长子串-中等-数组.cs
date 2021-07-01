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
        /// 003.无重复字符的最长子串-中等-数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            //题目：给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。

            //思路：维持一个滑动窗口，即符合要求的范围，每次移动都记录更新最大长度，最后返回最大长度
            //使用一个字典记录已出现的数字，值为数字下标+1，用来确认遇到重复数字并根据下标做新起点
            //具体：每次移动都更新到字典，终点+1；遇到重复根据字典更新起点

            Dictionary<char, int> map = new Dictionary<char, int>();

            int max = 0;
            for (int end = 0, start = 0; end < s.Length; end++)
            {
                char c = s[end];
                if (map.ContainsKey(c))
                {
                    start = Math.Max(start, map[c]);
                }
                max = Math.Max(max, end - start + 1);
                map[c] = end + 1;
            }
            return max;
        }
    }
}
