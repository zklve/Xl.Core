using System;
using System.Collections.Generic;
using System.Text;

namespace Xl.Core.UniversalCommon.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 去除前后空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimStartEnd(this string str)
        {
            return str.TrimStart().TrimEnd();
        }

        /// <summary>
        /// 是否非空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool NotNull(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNull(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

    }
}
