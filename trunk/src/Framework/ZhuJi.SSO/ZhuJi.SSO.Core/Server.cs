using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace ZhuJi.SSO.Core
{
	/// <summary>
	/// SSO验证端
	/// </summary>
	public class Server
	{
		private string PrivateKey = "<RSAKeyValue><Modulus>pT9iNe4Du7wbaGLdS5q/s6RF7pj00BK7gTwm5WswPdJfq4P7hxh1hS/6wPm0aYCKxCryJOVEADxTh2zbadFttXTRqwsIt3RVnmtePco4czxpZE5IqzoFJ+U5yptlSqD+zDE9kdbU9DbdJ+0CY5NZcBVALKN2WaDTt9TY88N8Oxk=</Modulus><Exponent>AQAB</Exponent><P>0bYk4rgAqcSR87TWGDAF32PQHdijvj4EkfOVnanHMq2zRAQngcQI/RerwkptSKJjiSjtOm/zFMhitiy3BFAz8Q==</P><Q>ybjImyoaZJNgyB369EioX4fSmp9mpXLYOzEKAWjh9+RywzxU0Dh1rCTJyN2UjADSt5caaIGsYpLWmNp8fbYBqQ==</Q><DP>PdQPx/Ar8eGMjmeQf40ZDiWlZEdM73flbQp94AAARMbFhZYb97xOUiA6eYvr8HBAHF4+ou4Couv5fnBsfQ8QYQ==</DP><DQ>uJrqu1VkofZd88W8DCMSM5rRGcAW6AKZ8FGInpGlen8Op61m0MdaqRdhsvlVIGsAbBNUj59cazmGOox4sXMHQQ==</DQ><InverseQ>Nzz2V+RJIh+uvJ5fCpnpvbYJrNp7CFEA6mSZ7LYhRy4r8MBiFGBiAtF0pl08c1bW4Pj7yEpmGdNqFO07+7rHQw==</InverseQ><D>Vvy1s1P27SWJe/rHKVxt25/3HDGydbHWuKI0i4JQY8rRh9UzXBtZCeKG6nzIJt1+ruM4komJsWIQSnLYUazoRcuCeevKznu1/GGtUHHWeFlEkNpPd8s7lkg4JGetC8fuS85ApspGtCL42849CkU9YdXmGxRZyjG4d0n0b3NGMIE=</D></RSAKeyValue>";

		/// <summary>
		/// 签名用户信息
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public string SignatueData(string data)
		{
			try
			{
				UnicodeEncoding ByteConverter = new UnicodeEncoding();

				byte[] dataToSignatue = ByteConverter.GetBytes(data);

				RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512);
				RSA.FromXmlString(PrivateKey);

				string SignadString = Convert.ToBase64String(RSA.SignData(dataToSignatue, new SHA1CryptoServiceProvider()));
				return SignadString;
			}
			catch
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// Base64编码
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public string EncodeBase64(string data)
		{
			try
			{
				UnicodeEncoding ByteConverter = new UnicodeEncoding();
				byte[] bytes = ByteConverter.GetBytes(data);
				return Convert.ToBase64String(bytes);
			}
			catch
			{
				return string.Empty;
			}
		}
	}
}
