using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace ZhuJi.Library.Security
{
    /// <summary>
    /// ���ܽ��ܰ�����
    /// </summary>
    public sealed class EncryptHelper
    {
        private EncryptHelper()
        {
        }

        #region MD5

        /// <summary>
        /// MD5����
        /// </summary>
        /// <param name="source">Դ��</param>
        /// <returns>�ܴ�</returns>
        public static string MD5(string source)
        {
            return MD5(source, string.Empty);
        }

        /// <summary>
        /// MD5����
        /// </summary>
        /// <param name="source">Դ��</param>
        /// <param name="key">��Կ</param>
        /// <returns>�ܴ�</returns>
        public static string MD5(string source, string key)
        {
            Byte[] data1ToHash = (new UnicodeEncoding()).GetBytes(string.Concat(source, key));
            Byte[] hashvalue1 = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(data1ToHash);
            string md5 = BitConverter.ToString(hashvalue1).Replace("-", "").ToLower(CultureInfo.InvariantCulture);
            return md5;
        }

        #endregion
    }
}