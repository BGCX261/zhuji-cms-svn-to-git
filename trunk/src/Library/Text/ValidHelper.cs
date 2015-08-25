using System.Text;

namespace ZhuJi.Library.Text
{
    /// <summary>
    /// 数据验证帮助类
    /// </summary>
    public sealed class ValidHelper
    {
        /// <summary>
        /// 字符串字节数
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <returns>返回字符串字节数</returns>
        public static int BytesSize(string input)
        {
            int ret = 0;
            if (!string.IsNullOrEmpty(input))
            {
                Encoding encoding = Encoding.GetEncoding("gb2312");
                ret = encoding.GetBytes(input).Length;
            }
            return ret;
        }

        private ValidHelper()
        {
        }
    }
}
