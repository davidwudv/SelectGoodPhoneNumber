using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SelectGoodNumber
{
    public static class LuckyNumberRegular
    {
        /// <summary>
        /// 验证指定号码是否存在幸运数字（即出现3次以上的数字）
        /// </summary>
        /// <param name="number">需要验证的号码</param>
        /// <returns>成功返回幸运数字，失败返回-1</returns>
        public static List<int> Match(string number)
        {
            var array = number.ToCharArray();
            int[] counts = new int[10];

            for(int i = 3; i < array.Length; ++i)
            {
                counts[Convert.ToInt32(array[i].ToString())]++;
            }

            int index = -1, maxValue = -1;
            for (int i = 0; i < counts.Length; ++i)
            {
                if(counts[i] > maxValue && counts[i] >= 3)
                {
                    maxValue = counts[i];
                    index = i;
                }
            }

            if (index == -1)
                return new List<int>();

            List<int> results = new List<int>();
            results.Add(index);
            for (int i = 0; i < counts.Length; ++i )
            {
                if (i != index && counts[i] == counts[index])
                    results.Add(i);
            }

            return results;
        }
    }
}
