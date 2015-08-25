using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZhuJi.Library.Globalization;
using ZhuJi.Library.Web;

namespace ZhuJi.Portal.WebUI.Admin
{
    public partial class AddIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (ViewState["PluginId"] != null)
                {
                    ShowControl((int)ViewState["PluginId"]);
                }
            }
            else
            {
                ViewState["PluginId"] = int.Parse(RequestHelper.Param("PluginId"));
                ShowControl((int)ViewState["PluginId"]);
            }
        }

        private void ShowControl(int id)
        {
            ZhuJi.Portal.IDAL.IPlugin plugin = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Plugin)) as ZhuJi.Portal.IDAL.IPlugin;
            ZhuJi.Portal.Domain.Plugin domainPlugin = plugin.GetObject(id);
            if (domainPlugin != null)
            {
                string configPath = HttpContext.Current.Server.MapPath(domainPlugin.Configure);
                ZhuJi.Plugins.IAddIn addin = new ZhuJi.Plugins.AddIn();
                addin.Init(configPath);
                Control control = addin.GetControl(domainPlugin.Keyword);
                phContent.Controls.Add(control);
            }
        }
    }
}
