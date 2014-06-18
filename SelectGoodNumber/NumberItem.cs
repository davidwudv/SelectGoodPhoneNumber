using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectGoodNumber
{
    [Serializable]
    public class NumberItem
    {
        /// <summary>
        /// 号码等级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 匹配优先级
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 号码特征
        /// </summary>
        public string Feature { get; set; }
        /// <summary>
        /// 正则表达式
        /// </summary>
        public string RegularExpression { get; set; }

        public NumberItem()
        {
            Level = Feature = RegularExpression = String.Empty;
            Priority = -100;
        }

        public NumberItem(string numberLevel, string feature, string regularExpression, int priority)
        {
            Level = numberLevel;
            Feature = feature;
            RegularExpression = regularExpression;
            Priority = priority;
        }
    }
}
