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
        /// 128. 最长连续数列-中等-数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int LongestConsecutive(int[] nums)
        {
            //题目：给定一个未排序的整数数组 nums ，找出数字连续的最长序列（不要求序列元素在原数组中连续）的长度。

            //思路：使用字典的key储存数组元素，value储存元素所在区间
            //循环数组，判断当前元素是否有相邻的数字已在字典key中，如果有，更新当前元素所在区间（head，tali），并将新区间赋值到区间两端的key；再添加当前元素和对应的区间到字典中, 更新并获得最长区间的长度。

            Dictionary<int, KeyValuePair<int, int>> dict = new Dictionary<int, KeyValuePair<int, int>>();
            int length = 0;
            int head;
            int tail;

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    //更新当前元素所在区间（该算法下每个非相连元素都记录着元素自身所在的区间，因此获取前元素的key或后元素的value即是最大的区间）
                    if (dict.ContainsKey(nums[i] - 1))
                    {
                        head = dict[nums[i] - 1].Key;
                    }
                    else
                    {
                        head = nums[i];
                    }
                    if (dict.ContainsKey(nums[i] + 1))
                    {
                        tail = dict[nums[i] + 1].Value;
                    }
                    else
                    {
                        tail = nums[i];
                    }

                    //更新两端元素的区间；注意，非两端元素的区间不会被更新，但是我们也用不着他们
                    if (head != nums[i])
                    {
                        dict[head] = new KeyValuePair<int, int>(head, tail);
                    }
                    if (tail != nums[i])
                    {
                        dict[tail] = new KeyValuePair<int, int>(head, tail);
                    }

                    //添加自己
                    dict.Add(nums[i], new KeyValuePair<int, int>(head, tail));

                    length = tail - head + 1 > length ? tail - head + 1 : length;
                }
            }

            return length;
        }
    }
}
