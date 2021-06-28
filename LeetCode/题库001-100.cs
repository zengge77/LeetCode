using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LeetCode
{
    class 题库001_100
    {
        /// <summary>
        /// 1. 两数之和-数组-简单
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
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

        /// <summary>
        /// 7. 整数反转-数学-简单
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            //题目：给你一个 32 位的有符号整数 x ，返回将 x 中的数字部分反转后的结果。如果反转后整数超过 32 位的有符号整数的范围[−231, 231 − 1] ，就返回 0。

            //思路：求余，降位，再升位加余，最后得到结果；注意边界条件，每次升位前计算是否会超标

            int reverseNum = 0;
            while (x != 0)
            {
                int num = x % 10;
                x = x / 10;
                if (reverseNum > Int32.MaxValue / 10 || (reverseNum == Int32.MaxValue / 10 && num > 7)) { return 0; }
                if (reverseNum < Int32.MinValue / 10 || (reverseNum == Int32.MinValue / 10 && num < -8)) { return 0; }
                reverseNum = reverseNum * 10 + num;
            }
            return reverseNum;
        }

        /// <summary>
        /// 9. 回文数-数学-简单
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome(int x)
        {
            //题目：给你一个整数 x ，如果 x 是一个回文整数，返回 true ；否则，返回 false 。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。例如，121 是回文，而 123 不是。

            //思路：做一个数字反转，判断二者是否相等；这里做一个优化，只反转到一半，x为偶数时判断二者是否相等，x为奇数时判断 reversrNum / 10 == x，因为此时 reversrNum > x，且中间位数字无需判断

            if (x < 0 || (x % 10 == 0 && x != 0)) { return false; }

            int reversrNum = 0;
            while (x > reversrNum)
            {
                int num = x % 10;
                x /= 10;
                reversrNum = reversrNum * 10 + num;
            }
            return (reversrNum == x || reversrNum / 10 == x);
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            //返回前缀的最大公共字符串
            //利用string.indexof(string)，包含且在第一位开始为为0，包含但不在第一位为下标，不包含为-1
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

        public static bool IsValid(string s)
        {
            //判断是否为对称挂号字符串
            //利用栈后进先出的特性，一一配对消除，检查不配对的字符；最后再检查栈是否为空
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

        public static int RemoveDuplicates(int[] nums)
        {
            //将数组内非重复的数据移到最前，并返回数组长度
            //看描述还以为是删除重复数据，还奇怪O(1) 空间复杂度怎么做，原来只是移动
            //循环数组，若有相邻的不同数据则填到前面
            if (nums.Length == 0) { return 0; }

            int index = 0;
            //两种循环方法
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] != nums[i + 1])
                {
                    index++;
                    nums[index] = nums[i + 1];
                }
            }

            //for (int i = 1; i < nums.Length; i++)
            //{
            //    if (nums[i] != nums[index])
            //    {
            //        index++;
            //        nums[index] = nums[i];
            //    }
            //}

            return index + 1;
        }

        public static int RemoveElement(int[] nums, int val)
        {
            //与上题类似，移除包含的指定元素

            //1.0 循环数组，记录指定元素出现的次数count，同时把遇到的其他元素往前移动count位
            //int count = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] == val) { count++; }
            //    else { nums[i - count] = nums[i]; }
            //}
            //return nums.Length - count;

            //2.0 设一个下标0，每遇到其他元素便将其移到下标处，同时下标加1
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

        public static int StrStr(string haystack, string needle)
        {
            //返回字符串中第一次出现指定字符串的索引，如果没有，则返回-1。
            //把字符串看成字符集合，双重循环匹配每一字符，寻找正确的位置。
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

        /// <summary>
        /// 35. 搜索插入位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int SearchInsert(int[] nums, int target)
        {
            //给定排序数组和目标值，如果找到目标，则返回索引。
            //如果没有，则返回按顺序插入索引的位置。可以假定数组中没有重复项。
            //
            //思路1.：直接便遍历查找
            //int index = 0;
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] >= target)
            //    {
            //        break;
            //    }
            //}
            //return index;

            //思路2：二分查找：
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;
        }

        public static string CountAndSay(int n)
        {
            //有一个字符串为1，给定一个整数n，生成计数的第n项字符串。
            //字符串内容为“读出”上一个字符串
            //例如前几项为：1：1   2：11  3：21  4：1211  5：111221
            //
            //思路：设置固定位unit，计数值count，，新字符串newNum，遍历字符串取得当前值：
            //固定位不同于当前值：newNum+=count +=unit，重置unit，count；
            //固定位等同于当前值：count++；
            //当前位为最后一位：newNum+=count +=unit
            //
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

        /// <summary>
        /// 128. 最长连续数列
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int LongestConsecutive(int[] nums)
        {
            //核心思路：使用字典的key储存数组元素，value储存元素所在区间
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

        /// <summary>
        /// 100. 相同的树
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            //如果两个树在结构上相同，并且节点具有相同的值，则认为它们是相同的。


            //方案1，递归

            ////空判断
            //if (p == null && q == null) { return true; }
            //if ((p == null && q != null) || (p != null && q == null)) { return false; }
            ////数值不同判断
            //if (p.val != q.val) { return false; }
            ////递归
            //return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);


            //方案2，双队列
            Queue<TreeNode> PNodes = new Queue<TreeNode>();
            Queue<TreeNode> QNodes = new Queue<TreeNode>();
            PNodes.Enqueue(p);
            QNodes.Enqueue(q);
            while (PNodes.Count > 0 && QNodes.Count > 0)
            {
                TreeNode P = PNodes.Dequeue();
                TreeNode Q = QNodes.Dequeue();
                if (P != null) { PNodes.Enqueue(P.left); PNodes.Enqueue(P.right); }
                if (Q != null) { QNodes.Enqueue(Q.left); QNodes.Enqueue(Q.right); }

                if (P == null && Q == null) { continue; }
                if ((P == null && Q != null) || (P != null && Q == null)) { return false; }
                if (P.val != Q.val) { return false; }
            }
            return true;
        }

        /// <summary>
        /// 112. 路径总和
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public static bool HasPathSum(TreeNode root, int targetSum)
        {
            //给你二叉树的根节点 root 和一个表示目标和的整数 targetSum ，判断该树中是否存在 根节点到叶子节点 的路径，这条路径上所有节点值相加等于目标和 targetSum 。


            //方案1：递归，非叶节点时将剩余值传递下去，叶节点时判断该路径是否正确

            //空树空结点判断
            if (root == null) { return false; }

            //叶子节点，判断该路线最终结果
            if (root.left == null && root.right == null) { return root.val == targetSum; }

            //非叶子节点，递归；子节点为空时也调用，会被空树空结点判断返回false
            return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);


            //方案2：双队列记录节点和实时结果

            //if (root == null) { return false; }
            //Queue<TreeNode> nodes = new Queue<TreeNode>();
            //Queue<int> results = new Queue<int>();
            //nodes.Enqueue(root);
            //results.Enqueue(root.val);
            //while (nodes.Count != 0)
            //{
            //    TreeNode node = nodes.Dequeue();
            //    int sum = results.Dequeue();
            //    if (node.left != null) { nodes.Enqueue(node.left); results.Enqueue(sum + node.left.val); }
            //    if (node.right != null) { nodes.Enqueue(node.right); results.Enqueue(sum + node.right.val); }
            //    if (node.left == null && node.right == null && sum == targetSum) { return true; }
            //}
            //return false;
        }

        /// <summary>
        /// 226. 翻转二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static TreeNode InvertTree(TreeNode root)
        {
            //y轴镜像翻转

            //递归
            if (root == null) { return null; }

            if (root.left != null || root.right != null)
            {
                root.left = InvertTree(root.left);
                root.right = InvertTree(root.right);
            }

            TreeNode tempLeft = root.left;
            root.left = root.right;
            root.right = tempLeft;
            return root;
        }

    }
}
