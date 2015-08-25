using System.Text;

namespace ZhuJi.Library.Text
{
    /// <summary>
    /// ������֤������
    /// </summary>
    public sealed class ValidHelper
    {
        /// <summary>
        /// �ַ����ֽ���
        /// </summary>
        /// <param name="input">�����ַ���</param>
        /// <returns>�����ַ����ֽ���</returns>
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
