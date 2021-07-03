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
        /// 011. 盛最多水的容器-中等-数组
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            //题目：给你 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0) 。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。

            //思路：双指针，从两端向中间逼近，将小的一端向中间移动，因为蓄水量取决于低的那端，移动大端没有意义；重复得到所有可能性答案，记录最大结果并返回

            int l = 0, r = height.Length - 1;
            int max = 0;
            while (l < r)
            {
                int area = Math.Min(height[l], height[r]) * (r - l);
                max = Math.Max(max, area);
                if (height[l] <= height[r]) { l++; }
                else { r--; }
            }
            return max;
        }
    }
}
