using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZhuJi.Library.Web
{
    /// <summary>
    /// 控件处理帮助类
    /// </summary>
    public sealed class UIControlHelper
    {
        private const char SYMBOLS = '┣';

        private UIControlHelper()
        {
        }

        /// <summary>
        /// 初始化ListControl
        /// </summary>
        /// <param name="lc">ListControl控件</param>
        /// <param name="data">数据</param>
        public static void InitListControl(ListControl lc, string data)
        {
            if (lc == null)
            {
                throw new ArgumentNullException("lc");
            }
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            string[] search = data.Split(',');
            for (int i = 0; i < search.Length; i++)
            {
                string[] temp = search[i].Split('|');
                lc.Items.Add(new ListItem(temp[1], temp[0]));
            }
        }

        /// <summary>
        /// 设置ListControl值
        /// </summary>
        /// <param name="lc">ListControl控件</param>
        /// <param name="data">数据</param>
        public static void SetListControl(ListControl lc, string data)
        {
            if (lc == null)
            {
                throw new ArgumentNullException("lc");
            }
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            for (int i = 0; i < lc.Items.Count; i++)
            {
                if (data.IndexOf(lc.Items[i].Value) >= 0)
                {
                    lc.Items[i].Selected = true;
                }
            }
        }

        /// <summary>
        /// 获取ListControl值
        /// </summary>
        /// <param name="lc">ListControl控件</param>
        /// <returns>数据</returns>
        public static string GetListControl(ListControl lc)
        {
            if (lc == null)
            {
                throw new ArgumentNullException("lc");
            }
            StringBuilder rets = new StringBuilder();
            for (int i = 0; i < lc.Items.Count; i++)
            {
                if (lc.Items[i].Selected)
                {
                    rets.Append(lc.Items[i].Value);
                }
            }
            return rets.ToString();
        }

        /// <summary>
        /// 获取Web控件Html
        /// </summary>
        /// <param name="c">Web控件</param>
        /// <returns>返回Web控件Html</returns>
        public static string GetControlHtml(Control c)
        {
            if (c == null)
            {
                throw new ArgumentNullException("c");
            }
            StringWriter sw = new StringWriter(CultureInfo.InvariantCulture);
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            c.RenderControl(writer);
            string controlhtml = sw.ToString();
            return controlhtml;
        }

        /// <summary>
        /// 遍历Web控件
        /// </summary>
        /// <param name="c">Web控件</param>
        public static void ListControl(Control c)
        {
            if (c == null)
            {
                throw new ArgumentNullException("c");
            }
            //HttpContext.Current.Response.Write(c.ID + ":" + c.GetType().Name + "<BR>");
            if (c.Controls.Count > 0)
            {
                for (int i = 0; i < c.Controls.Count; i++)
                {
                    ListControl(c.Controls[i]);
                }
            }
        }

        /// <summary>
        /// 获得Repeater中已选的CheckBox值集合
        /// </summary>
        /// <param name="list">列表控件</param>
        /// <param name="checkId">CheckBox名称</param>
        /// <returns></returns>
        public static string GetCheckBoxByRepeater(Repeater list, string checkId)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            StringBuilder rets = new StringBuilder();
            for (int i = 0; i < list.Items.Count; i++)
            {
                CheckBox check = (CheckBox) list.Items[i].FindControl(checkId);
                if (check.Checked)
                {
                    if (rets.Length > 0)
                    {
                        rets.Append(",");
                        rets.Append(check.Text);
                    }
                    else
                    {
                        rets.Append(check.Text);
                    }
                }
            }
            return rets.ToString();
        }

        /// <summary>
        /// 获得TreeView中已选的CheckBox值集合
        /// </summary>
        /// <param name="list">列表控件</param>
        /// <returns></returns>
        public static string GetCheckBoxByTreeView(TreeView list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            string rets = string.Empty;
            GetCheckBoxByTreeView(list.Nodes, ref rets);
            return rets;
        }

        /// <summary>
        /// 获得TreeView中已选的CheckBox值集合
        /// </summary>
        /// <param name="nodes">TreeNodeCollection</param>
        /// <param name="rets"></param>
        public static void GetCheckBoxByTreeView(TreeNodeCollection nodes, ref string rets)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }
            if (rets == null)
            {
                throw new ArgumentNullException("rets");
            }

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Checked)
                {
                    if (rets.Length > 0)
                    {
                        rets = string.Concat(rets, ",", nodes[i].Value);
                    }
                    else
                    {
                        rets = string.Concat(rets, nodes[i].Value);
                    }
                }
                if (nodes[i].ChildNodes.Count > 0)
                {
                    GetCheckBoxByTreeView(nodes[i].ChildNodes, ref rets);
                }
            }
        }

        /// <summary>
        /// 树形DropDownList
        /// </summary>
        /// <param name="lc">ListControl控件</param>
        /// <param name="dataName">控件值对应名称</param>
        /// <param name="ds">DataSet数据集</param>
        public static void TreeDropDownList(ListControl lc, string dataName, DataSet ds)
        {
            if (lc == null)
            {
                throw new ArgumentNullException("lc");
            }
            if (dataName == null)
            {
                throw new ArgumentNullException("dataName");
            }
            if (ds == null)
            {
                throw new ArgumentNullException("ds");
            }

            dataName = dataName.Replace(".", "_");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int length = Convert.ToInt32(row["Category_Depth"], CultureInfo.InvariantCulture);
                string title =
                    row["Category_Title"].ToString().PadLeft(row["Category_Title"].ToString().Length + length, SYMBOLS);
                string id = row[dataName].ToString();
                lc.Items.Add(new ListItem(title, id));
            }
        }

        /// <summary>
        /// 建立控件
        /// </summary>
        /// <param name="controlsType">控件类型</param>
        /// <param name="controlsName">控件名称</param>
        /// <returns></returns>
        public static Control CreateControl(string controlsType, string controlsName)
        {
            Control newControl;
            try
            {
                string assemblyQualifiedName = typeof (Control).AssemblyQualifiedName;
                string assemblyInformation = assemblyQualifiedName.Substring(assemblyQualifiedName.IndexOf(","));
                Type type = Type.GetType(controlsType + assemblyInformation);
                newControl = (Control) Activator.CreateInstance(type);
                newControl.ID = controlsName;
            }
            catch
            {
                return null;
            }
            return newControl;
        }

        #region 注释

        ///// <summary>
        ///// 初始化RadioButtonList
        ///// </summary>
        ///// <param name="rbl">RadioButtonList控件</param>
        ///// <param name="data">数据</param>
        //public static void InitRadioButtonList(RadioButtonList rbl, string data)
        //{
        //    if (rbl == null)
        //    {
        //        throw new ArgumentNullException("rbl");
        //    }
        //    if (data == null)
        //    {
        //        throw new ArgumentNullException("data");
        //    }
        //    string[] search = data.Split(',');
        //    for (int i = 0; i < search.Length; i++)
        //    {
        //        string[] temp = search[i].Split('|');
        //        rbl.Items.Add(new ListItem(temp[1], temp[0]));
        //    }
        //}

        ///// <summary>
        ///// 初始化DropDownList
        ///// </summary>
        ///// <param name="ddl">DropDownList控件</param>
        ///// <param name="data">数据</param>
        //public static void InitDropDownList(DropDownList ddl, string data)
        //{
        //    if (ddl == null)
        //    {
        //        throw new ArgumentNullException("ddl");
        //    }
        //    if (data == null)
        //    {
        //        throw new ArgumentNullException("data");
        //    }

        //    string[] search = data.Split(',');
        //    for (int i = 0; i < search.Length; i++)
        //    {
        //        string[] temp = search[i].Split('|');
        //        ddl.Items.Add(new ListItem(temp[1], temp[0]));
        //    }
        //}

        ///// <summary>
        ///// 初始化CheckBoxList
        ///// </summary>
        ///// <param name="cbl">CheckBoxList控件</param>
        ///// <param name="data">数据</param>
        //public static void InitCheckBoxList(CheckBoxList cbl, string data)
        //{
        //    if (cbl == null)
        //    {
        //        throw new ArgumentNullException("cbl");
        //    }
        //    if (data == null)
        //    {
        //        throw new ArgumentNullException("data");
        //    }
        //    string[] search = data.Split(',');
        //    for (int i = 0; i < search.Length; i++)
        //    {
        //        string[] temp = search[i].Split('|');
        //        cbl.Items.Add(new ListItem(temp[1], temp[0]));
        //    }
        //}

        ///// <summary>
        ///// 设置CheckBoxList值
        ///// </summary>
        ///// <param name="cbl">CheckBoxList控件</param>
        ///// <param name="data">数据</param>
        //public static void SetCheckBoxList(CheckBoxList cbl, string data)
        //{
        //    if (cbl == null)
        //    {
        //        throw new ArgumentNullException("cbl");
        //    }
        //    if (data == null)
        //    {
        //        throw new ArgumentNullException("data");
        //    }

        //    for (int i = 0; i < cbl.Items.Count; i++)
        //    {
        //        if (data.IndexOf(cbl.Items[i].Value) >= 0)
        //        {
        //            cbl.Items[i].Selected = true;
        //        }
        //    }
        //}

        ///// <summary>
        ///// 获取CheckBoxList值
        ///// </summary>
        ///// <param name="cbl">CheckBoxList控件</param>
        ///// <returns>数据</returns>
        //public static string GetCheckBoxList(CheckBoxList cbl)
        //{
        //    if (cbl == null)
        //    {
        //        throw new ArgumentNullException("cbl");
        //    }
        //    StringBuilder rets = new StringBuilder();
        //    for (int i = 0; i < cbl.Items.Count; i++)
        //    {
        //        if (cbl.Items[i].Selected)
        //        {
        //            rets.Append(cbl.Items[i].Value);
        //        }
        //    }
        //    return rets.ToString();
        //}

        #endregion
    }
}