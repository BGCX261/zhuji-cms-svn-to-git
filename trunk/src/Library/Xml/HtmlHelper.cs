using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using Sgml;

namespace ZhuJi.Library.Xml
{
    /// <summary>
    /// Html������
    /// </summary>
    public sealed class HtmlHelper
    {
        private HtmlHelper()
        {
        }

        /// <summary>
        ///���ַ�����ʽ��ΪHTML
        /// </summary>
        /// <param name="normalStr">��Ҫ��ʽ�����ַ���</param>
        /// <returns>���ظ�ʽ�����HTML����</returns>
        public static string FormatToHtml(string normalStr)
        {
            normalStr = HttpContext.Current.Server.UrlDecode(normalStr);
            normalStr = HttpContext.Current.Server.HtmlEncode(normalStr);

            StringBuilder html = new StringBuilder(normalStr);

            html.Replace(" ", "&nbsp;");
            html.Replace("\r\n", "<br />");

            return html.ToString();
        }

        /// <summary>
        /// ��HTMLתΪ��ͨ�ı���ʽ
        /// </summary>
        /// <param name="htmlStr">��Ҫת����HTML�ַ���</param>
        /// <returns>������ͨ�ı�</returns>
        public static string RestoreFromHtml(string htmlStr)
        {
            htmlStr = HttpContext.Current.Server.HtmlDecode(htmlStr);

            StringBuilder normalStr = new StringBuilder(htmlStr);

            normalStr.Replace("<br />", "\r\n");

            normalStr.Replace("&quot;", "\"");
            normalStr.Replace("&lt;", "<");
            normalStr.Replace("&gt;", ">");
            normalStr.Replace("&nbsp;", " ");
            normalStr.Replace("&amp;", "&");

            return normalStr.ToString();
        }

        /// <summary>
        /// ����Html����
        /// </summary>
        /// <param name="orig">Html����</param>
        /// <returns>���˺�Html����</returns>
        public static string FilterHtml(string orig)
        {
            if (orig == null)
            {
                throw new ArgumentNullException("orig");
            }

            string html = orig.Trim();

            html = html.Replace("&nbsp; ", " ");
            html = html.Replace("&ndash;", "-");
            html = html.Replace("&rsquo;", "'");
            html = html.Replace("&lsquo;", "'");
            html = html.Replace("&ldquo;", "\"");
            html = html.Replace("&rdquo;", "\"");

            return html;
        }

        /// <summary>
        /// ת����Xhtml
        /// </summary>
        /// <param name="html">html����</param>
        /// <returns>Xhtml����</returns>
        public static string ToXhtml(string html)
        {
            SgmlReader reader = new SgmlReader();
            reader.CaseFolding = CaseFolding.ToLower;
            reader.DocType = "HTML";
            reader.InputStream = new StringReader(html);

            StringWriter sw = new StringWriter(CultureInfo.InvariantCulture);
            XmlTextWriter writer = new XmlTextWriter(sw);
            writer.Formatting = Formatting.Indented;
            reader.WhitespaceHandling = WhitespaceHandling.None;
            while (!reader.EOF)
            {
                writer.WriteNode(reader, true);
            }
            reader.Close();
            sw.Close();
            writer.Close();
            return sw.ToString();
        }

        /// <summary>
        /// �滻ʵ��
        /// </summary>
        /// <param name="text">ʵ�崮</param>
        /// <returns>�滻��ʵ�崮</returns>
        public static string ReplaceEntities(string text)
        {
            string res = string.Empty;
            if (!string.IsNullOrEmpty(text))
            {
                res = text.Replace("", "&#232;");
                res = res.Replace("", "&#233;");
            }
            return res;
        }

        /// <summary>
        /// ��ȡHtml����
        /// </summary>
        /// <param name="html">Html����</param>
        /// <param name="maxLength">��󳤶�</param>
        /// <returns>��ȡ��Html����</returns>
        public static string HtmlSubstr(string html, int maxLength)
        {
            bool isText = true;
            StringBuilder r = new StringBuilder();
            int i = 0;

            char currentChar;
            int lastSpacePosition = -1;
            char lastChar = ' ';

            Dictionary<int, string> tagsArray = new Dictionary<int, string>();
            string currentTag = "";
            int tagLevel = 0;

            int noTagLength = 0;
            int j;

            // Calculate string length without tags
            for (j = 0; j < html.Length; j++)
            {
                currentChar = html[j];
                if (currentChar == '<')
                {
                    isText = false;
                }
                if (isText)
                {
                    noTagLength++;
                }
                if (currentChar == '>')
                {
                    isText = true;
                }
            }

            // Parser loop
            for (j = 0; j < html.Length; j++)
            {
                currentChar = html[j];
                r.Append(currentChar);

                // Lesser than event
                if (currentChar == '<')
                {
                    isText = false;
                }

                // Character handler
                if (isText)
                {
                    // Memorize last space position
                    if (currentChar == ' ')
                    {
                        lastSpacePosition = j;
                    }
                    else
                    {
                        lastChar = currentChar;
                    }
                    i++;
                }
                else
                {
                    currentTag += currentChar;
                }

                // Greater than event
                if (currentChar == '>')
                {
                    isText = true;

                    // Opening tag handler
                    if (currentTag.IndexOf("<") != -1 && currentTag.IndexOf("/>") == -1 &&
                        currentTag.IndexOf("</") == -1)
                    {
                        // Tag has attribute(s)
                        if (currentTag.IndexOf(" ") != -1)
                        {
                            currentTag = currentTag.Substring(1, currentTag.IndexOf(" ") - 1);
                        }
                        else
                        {
                            // Tag doesn't have attribute(s)
                            currentTag = currentTag.Substring(1, currentTag.Length - 2);
                        }

                        tagsArray[tagLevel] = currentTag;
                        tagLevel++;
                    }
                    else if (currentTag.IndexOf("</") != -1)
                    {
                        // Closing tag handler
                        tagsArray[tagLevel - 1] = null;
                        tagLevel--;
                    }

                    currentTag = "";
                }

                if (i == maxLength)
                {
                    break;
                }
            }

            // Cut HTML string at last space position
            if (maxLength < noTagLength)
            {
                if (lastSpacePosition != -1)
                {
                    r = new StringBuilder(html.Substring(0, lastSpacePosition));
                }
                else
                {
                    r = new StringBuilder(html.Substring(0, j));
                }
            }

            // Close broken XHTML elements
            for (int a = tagsArray.Count - 1; a >= 0; a--)
            {
                if (tagsArray[a] != null)
                {
                    r.Append("</" + tagsArray[a] + ">");
                }
            }

            if (maxLength < noTagLength)
            {
                if (lastChar != '.')
                {
                    r.Append("...");
                }
                else
                {
                    r.Append("..");
                }
            }

            return r.ToString();
        }
    }
}