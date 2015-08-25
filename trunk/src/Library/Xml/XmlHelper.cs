using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace ZhuJi.Library.Xml
{
    /// <summary>
    /// Xml������
    /// </summary>
    public sealed class XmlHelper
    {
        /// <summary>
        /// ����xml����
        /// </summary>
        private static readonly object lockXml = new object();

        private XmlHelper()
        {
        }

        /// <summary>
        /// ʵ��ת��ΪXml
        /// </summary>
        /// <param name="classInstance">ʵ��</param>
        /// <returns>����Xml</returns>
        public static string PropertyInfoToXml(object classInstance)
        {
            if (classInstance == null)
            {
                throw new ArgumentNullException("classInstance");
            }

            StringBuilder rets = new StringBuilder();
            Type type = classInstance.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                PropertyInfo propInfo = propertyInfos[i];
                rets.AppendFormat("<{0}><![CDATA[{1}]]></{0}>", propInfo.Name, propInfo.GetValue(classInstance, null));
            }
            return rets.ToString();
        }

        /// <summary>
        /// Xmlת��Html����
        /// </summary>
        /// <param name="xslTemplate">Xslģ��·��</param>
        /// <param name="xmlCode">Xml����</param>
        /// <returns>Html����</returns>
        public static string XmlToHtml(string xslTemplate, string xmlCode)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlCode);

            StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
            XslCompiledTransform xsl = new XslCompiledTransform();
            xsl.Load(xslTemplate);
            xsl.Transform(xmlDoc, null, stringWriter);
            string ret = stringWriter.ToString();
            stringWriter.Close();
            return ret;
        }

        /// <summary>
        /// ��DataSet����д�뵽Xml�ļ�
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="fileName"></param>
        public static void WriteXml(DataSet ds, string fileName)
        {
            if (ds == null)
            {
                throw new ArgumentNullException("ds");
            }
            lock (lockXml)
            {
                FileStream sr = new FileStream(fileName, FileMode.Create);
                ds.WriteXml(sr);
                Console.WriteLine(ds.GetXml());
                sr.Close();
            }
        }

        /// <summary>
        /// ��ýڵ�����
        /// </summary>
        /// <param name="fileName">�����ļ���(����·��)</param>
        /// <param name="key">�ڵ�·��</param>
        /// <returns>�ڵ�����</returns>
        public static string GetXmlNodeText(string fileName, string key)
        {
            lock (lockXml)
            {
                string ret = string.Empty;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                XmlNode xmlNode = xmlDoc.SelectSingleNode(key);
                if (xmlNode != null)
                {
                    ret = xmlNode.InnerText;
                }
                return ret;
            }
        }

        /// <summary>
        /// ��Xml�ļ����뵽DataSet
        /// </summary>
        /// <param name="fileName">�����ļ���(����·��)</param>
        /// <returns>DataSet���ݼ�</returns>
        public static DataSet ReadXml(string fileName)
        {
            lock (lockXml)
            {
                DataSet ds = new DataSet();
                ds.Locale = CultureInfo.InvariantCulture;
                FileStream sr = new FileStream(fileName, FileMode.Open);
                ds.ReadXml(sr);
                sr.Close();
                return ds;
            }
        }
    }
}