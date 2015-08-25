using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;

namespace ZhuJi.SSO.Core
{
	/// <summary>
	/// SSO被验证端
	/// </summary>
    public class Client
    {
		private string PublicKey = "<RSAKeyValue><Modulus>pT9iNe4Du7wbaGLdS5q/s6RF7pj00BK7gTwm5WswPdJfq4P7hxh1hS/6wPm0aYCKxCryJOVEADxTh2zbadFttXTRqwsIt3RVnmtePco4czxpZE5IqzoFJ+U5yptlSqD+zDE9kdbU9DbdJ+0CY5NZcBVALKN2WaDTt9TY88N8Oxk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

		/// <summary>
		/// 通过将指定的签名数据与为指定数据计算的签名进行比较来验证指定的签名数据。
		/// </summary>
		/// <param name="data">已签名的数据。</param>
		/// <param name="signature">要验证的签名数据。</param>
		/// <returns>如果签名验证为有效，则为 true；否则，为 false。</returns>
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
		/// Base64解码
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
		/// 获取用户名
		/// </summary>
		/// <param name="data">用户信息</param>
		/// <returns>用户名</returns>
		public string getUsername(string data)
		{
			UnicodeEncoding ByteConverter = new UnicodeEncoding();
			return data.Split('$')[0];
		}

		/// <summary>
		/// 获取角色ID
		/// </summary>
		/// <param name="data">用户信息</param>
		/// <returns>角色ID</returns>
		public string getRolesId(string data)
		{
			UnicodeEncoding ByteConverter = new UnicodeEncoding();
			return data.Split('$')[1];
		}
    }
}
