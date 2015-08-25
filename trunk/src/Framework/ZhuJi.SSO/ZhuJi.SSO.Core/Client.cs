using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;

namespace ZhuJi.SSO.Core
{
	/// <summary>
	/// SSO����֤��
	/// </summary>
    public class Client
    {
		private string PublicKey = "<RSAKeyValue><Modulus>pT9iNe4Du7wbaGLdS5q/s6RF7pj00BK7gTwm5WswPdJfq4P7hxh1hS/6wPm0aYCKxCryJOVEADxTh2zbadFttXTRqwsIt3RVnmtePco4czxpZE5IqzoFJ+U5yptlSqD+zDE9kdbU9DbdJ+0CY5NZcBVALKN2WaDTt9TY88N8Oxk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

		/// <summary>
		/// ͨ����ָ����ǩ��������Ϊָ�����ݼ����ǩ�����бȽ�����ָ֤����ǩ�����ݡ�
		/// </summary>
		/// <param name="data">��ǩ�������ݡ�</param>
		/// <param name="signature">Ҫ��֤��ǩ�����ݡ�</param>
		/// <returns>���ǩ����֤Ϊ��Ч����Ϊ true������Ϊ false��</returns>
		public bool ValidataData(string data, string signature)
        {
			bool ret = false;
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512);
				RSA.FromXmlString(PublicKey);
				UnicodeEncoding ByteConverter = new UnicodeEncoding();
				SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
				ret = RSA.VerifyData(ByteConverter.GetBytes(data), new SHA1CryptoServiceProvider(), Convert.FromBase64String(signature));
            }
            catch
            {
            }
			return ret;
        }

		/// <summary>
		/// Base64����
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public string DecodeBase64(string data)
		{
			try
			{
				UnicodeEncoding ByteConverter = new UnicodeEncoding();
				byte[] bytes = Convert.FromBase64String(data);
				return ByteConverter.GetString(bytes);
			}
			catch
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// ��ȡ�û���
		/// </summary>
		/// <param name="data">�û���Ϣ</param>
		/// <returns>�û���</returns>
		public string getUsername(string data)
		{
			UnicodeEncoding ByteConverter = new UnicodeEncoding();
			return data.Split('$')[0];
		}

		/// <summary>
		/// ��ȡ��ɫID
		/// </summary>
		/// <param name="data">�û���Ϣ</param>
		/// <returns>��ɫID</returns>
		public string getRolesId(string data)
		{
			UnicodeEncoding ByteConverter = new UnicodeEncoding();
			return data.Split('$')[1];
		}
    }
}
