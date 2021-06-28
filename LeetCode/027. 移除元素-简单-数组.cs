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
        /// 27. 移除元素-简单-数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int RemoveElement(int[] nums, int val)
        {
            //题目：给你一个数组 nums 和一个值 val，你需要 原地 移除所有数值等于 val 的元素，并返回移除后数组的新长度。不要使用额外的数组空间，你必须仅使用 O(1) 额外空间并 原地 修改输入数组。元素的顺序可以改变。你不需要考虑数组中超出新长度后面的元素。

            //方案1: 循环数组，记录指定元素出现的次数count，同时把遇到的其他元素往前移动count位
            //int count = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] == val) { count++; }
            //    else { nums[i - count] = nums[i]; }
            //}
            //return nums.Length - count;

            //方案2 设一个下标0，每遇到其他元素便将其移到下标处，同时下标加1
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[index] = nums[i];
                    index++;
                }
            }
            return index;
        }
    }
}
