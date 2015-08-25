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
    /// Xml帮助类
    /// </summary>
    public sealed class XmlHelper
    {
        /// <summary>
        /// 锁定xml操作
        /// </summary>
        private static readonly object lockXml = new object();

        private XmlHelper()
        {
        }

        /// <summary>
        /// 实体转换为Xml
        /// </summary>
        /// <param name="classInstance">实体</param>
        /// <returns>返回Xml</returns>
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
        /// Xml转换Html代码
        /// </summary>
        /// <param name="xslTemplate">Xsl模板路径</param>
        /// <param name="xmlCode">Xml代码</param>
        /// <returns>Html代码</returns>
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
        /// 把DataSet数据写入到Xml文件
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
        /// 获得节点内容
        /// </summary>
        /// <param name="fileName">完整文件名(包括路径)</param>
        /// <param name="key">节点路径</param>
        /// <returns>节点内容</returns>
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
        /// 把Xml文件读入到DataSet
        /// </summary>
        /// <param name="fileName">完整文件名(包括路径)</param>
        /// <returns>DataSet数据集</returns>
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