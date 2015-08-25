using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace ZhuJi.Library.Xml
{
	/// <summary>
	/// 序列化帮助类
	/// </summary>
	public class SerialiazeHelper
	{
		/// <summary>
		/// 序列化成字符串
		/// </summary>
		/// <returns>序列化后的字符串</returns>
		public string Serialiaze(object obj)
		{
			XmlSerializer xs = new XmlSerializer(obj.GetType());
			MemoryStream ms = new MemoryStream();
			XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.UTF8);
			xtw.Formatting = Formatting.Indented;
			xs.Serialize(xtw, obj);
			ms.Seek(0, SeekOrigin.Begin);
			StreamReader sr = new StreamReader(ms);
			string str = sr.ReadToEnd();
			xtw.Close();
			sr.Close();
			ms.Close();
			return str;
		}

		/// <summary>
		/// 反序列化从字符串
		/// </summary>
		/// <param name="xml">xml 字符串</param>
		/// <param name="type">要生成的对象类型</param>
		/// <returns>反序列化后的对象</returns>
		public object Deserialize(string xml, Type type)
		{
			XmlSerializer xs = new XmlSerializer(type);
			StringReader sr = new StringReader(xml);
			object obj = xs.Deserialize(sr);
			sr.Close();
			return obj;
		}
	}
}
