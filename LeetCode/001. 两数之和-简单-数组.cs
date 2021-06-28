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
        /// 1. 两数之和-简单-数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            //题目：给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 target  的那 两个 整数，并返回它们的数组下标。

            //思路：用字典，循环数组，如果元素不在字典键里，将元素补值设为键，下标设为值，这样便储存了可被配对的元素补值和原元素的下标；如果元素在字典键里，意味找到了对应的值，返回以该元素为键的值（即已储存的下标）和 该元素下标。

            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    return new int[] { dic[nums[i]], i };
                }
                dic[target - nums[i]] = i;
            }
            return null;
        }
    }
}
