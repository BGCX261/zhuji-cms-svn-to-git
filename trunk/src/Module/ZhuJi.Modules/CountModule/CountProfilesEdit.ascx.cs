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
using ZhuJi.Library.Web;

namespace ZhuJi.Modules.CountModule.WebUI
{
    public partial class CountProfilesEdit : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!Page.IsPostBack)
			{
				Edit();
			}
        }


        /// <summary>
        /// 初始化编辑表单
        /// </summary>
        private void Edit()
        {
            try
            {
				ZhuJi.Modules.CountModule.Domain.CountProfiles domainCountProfiles = new ZhuJi.Modules.CountModule.Domain.CountProfiles();

				ZhuJi.Modules.CountModule.IDAL.ICountProfiles countProfiles = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.CountModule.SQLServerDAL.CountProfiles)) as ZhuJi.Modules.CountModule.IDAL.ICountProfiles;
				DataSet ds = countProfiles.GetObjects();
				DataRow dr;
				if (ds.Tables[0].Rows.Count > 0)
				{
					dr = ds.Tables[0].Rows[0];
					domainCountProfiles.Todaypvs = (int)dr["Pvs"];
					domainCountProfiles.Todayips = (int)dr["Ips"];
					domainCountProfiles.Totalcookies = (int)dr["Cookies"];
				}
				if (ds.Tables[1].Rows.Count > 0)
				{
					dr = ds.Tables[1].Rows[0];
					domainCountProfiles.Yesterdaypvs = (int)dr["Pvs"];
					domainCountProfiles.Yesterdayips = (int)dr["Ips"];
					domainCountProfiles.Yesterdaycookies = (int)dr["Cookies"];
				}
				if (ds.Tables[2].Rows.Count > 0)
				{
					dr = ds.Tables[2].Rows[0];
					domainCountProfiles.Maxpvs = (int)dr["Pvs"];
					domainCountProfiles.Maxips = (int)dr["Ips"];
					domainCountProfiles.Maxcookies = (int)dr["Cookies"];
				}
				if (ds.Tables[3].Rows.Count > 0)
				{
					dr = ds.Tables[3].Rows[0];
					domainCountProfiles.Totalpvs = (int)dr["Pvs"];
					domainCountProfiles.Totalips = (int)dr["Ips"];
					domainCountProfiles.Totalcookies = (int)dr["Cookies"];
				}
				if (ds.Tables[4].Rows.Count > 0)
				{
					dr = ds.Tables[4].Rows[0];
					domainCountProfiles.BeginDate = (DateTime)dr["BeginDate"];
					int days = DateTime.Today.DayOfYear - domainCountProfiles.BeginDate.DayOfYear;
					if (days > 0)
					{
						domainCountProfiles.Averagepvs = domainCountProfiles.Totalpvs / days;
						domainCountProfiles.Averageips = domainCountProfiles.Totalips / days;
						domainCountProfiles.Averagecookies = domainCountProfiles.Totalcookies / days;
					}
				}
                UIMapping.BindObjectToControls(domainCountProfiles, this);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
        }
    }
}

