using System;
using System.Collections.Generic;
using System.Text;

namespace ZhuJi.Library.Text
{
    /// <summary>
    /// SQL�ַ����������
    /// </summary>
    public sealed class SqlStringHelper
    {
        /// <summary>
        /// ����Sqlͨ���
        /// </summary>
        /// <param name="input">Sql�ַ�</param>
        /// <returns>�����Sql�ַ�</returns>
        public static string ClearInput(string input)
        {
            string ret = input;
            ret = ret.Replace("[","[[]");
            return ret;
        }
    }
}
