using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace ZhuJi.Library.Xml
{
	/// <summary>
	/// ���л�������
	/// </summary>
	public class SerialiazeHelper
	{
		/// <summary>
		/// ���л����ַ���
		/// </summary>
		/// <returns>���л�����ַ���</returns>
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
		/// �����л����ַ���
		/// </summary>
		/// <param name="xml">xml �ַ���</param>
		/// <param name="type">Ҫ���ɵĶ�������</param>
		/// <returns>�����л���Ķ���</returns>
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
