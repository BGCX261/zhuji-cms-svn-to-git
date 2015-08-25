using System;
using System.Collections.Generic;
using System.Text;

namespace ZhuJi.Library.Text
{
    /// <summary>
    /// SQL字符管理帮助类
    /// </summary>
    public sealed class SqlStringHelper
    {
        /// <summary>
        /// 清理Sql通配符
        /// </summary>
        /// <param name="input">Sql字符</param>
        /// <returns>清理后Sql字符</returns>
        public static string ClearInput(string input)
        {
            string ret = input;
            ret = ret.Replace("[","[[]");
            return ret;
        }
    }
}
