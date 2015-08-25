using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using ZhuJi.Library.Data;

namespace ZhuJi.Modules.CountModule.SQLServerDAL
{
	/// <summary>
	/// 统计记录
	/// </summary>
	public class CountStat : ZhuJi.Modules.CountModule.IDAL.ICountStat
	{
		private const string SQL_INSERT = "CountInsert";
		private const int SQL_ONLINETIME = 15;

		/// <summary>
		/// 新增统计记录
		/// </summary>
		/// <param name="id">标识</param>
		/// <param name="ip">IP地址</param>
		/// <param name="pvs">PV访客</param>
		/// <param name="ips">IP访客</param>
		/// <param name="cookies">获立访客</param>
		/// <param name="area">地区</param>
		/// <param name="province">省</param>
		/// <param name="city">市</param>
		/// <param name="visits">访问量（现类同于获立访客）</param>
		/// <param name="addTime">更新时间</param>
		/// <param name="referSite">来路站点</param>
		/// <param name="referUrl">来路页</param>
		/// <param name="os">操作系统</param>
		/// <param name="browser">浏览器</param>
		/// <param name="resolution">分辨率</param>
		/// <param name="respondents">受访页</param>
		public void Insert(int id, string ip, int pvs, int ips, int cookies, string area, string province, string city, int visits, DateTime addTime, string referSite, string referUrl, string os, string browser, string resolution, string respondents)
		{
			SqlParameter[] cmdParms = GetInsertParameters();

			cmdParms[0].Direction = ParameterDirection.Output;
			cmdParms[1].Value = ip;
			cmdParms[2].Value = pvs;
			cmdParms[3].Value = ips;
			cmdParms[4].Value = cookies;
			cmdParms[5].Value = area;
			cmdParms[6].Value = province;
			cmdParms[7].Value = city;
			cmdParms[8].Value = visits;
			cmdParms[9].Value = addTime;
			cmdParms[10].Value = referSite;
			cmdParms[11].Value = referUrl;
			cmdParms[12].Value = os;
			cmdParms[13].Value = browser;
			cmdParms[14].Value = resolution;
			cmdParms[15].Value = respondents;
			cmdParms[16].Value = SQL_ONLINETIME;

			SqlHelper.ExecuteNonQuery(DBFactory.DBConnectionString, CommandType.StoredProcedure, SQL_INSERT, cmdParms);
		}

		private static SqlParameter[] GetInsertParameters()
		{
			SqlParameter[] parms = SqlHelper.GetCachedParameters(SQL_INSERT);

			if (parms == null)
			{
				parms = new SqlParameter[] {
					new SqlParameter("@Id", SqlDbType.Int),
					new SqlParameter("@Ip", SqlDbType.VarChar,15),
					new SqlParameter("@Pvs", SqlDbType.Int),
					new SqlParameter("@Ips", SqlDbType.Int),
					new SqlParameter("@Cookies", SqlDbType.Int),
					new SqlParameter("@Area", SqlDbType.VarChar,50),
					new SqlParameter("@Province", SqlDbType.VarChar,50),
					new SqlParameter("@City", SqlDbType.VarChar,50),
					new SqlParameter("@Visits", SqlDbType.Int),
					new SqlParameter("@AddTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ReferSite", SqlDbType.VarChar,100),
					new SqlParameter("@ReferUrl", SqlDbType.VarChar,100),
					new SqlParameter("@Os", SqlDbType.VarChar,100),
					new SqlParameter("@Browser", SqlDbType.VarChar,100),
					new SqlParameter("@Resolution", SqlDbType.VarChar,100),
					new SqlParameter("@Respondents", SqlDbType.VarChar,100),
					new SqlParameter("@OnlineTime", SqlDbType.Int),
				};

				SqlHelper.CacheParameters(SQL_INSERT, parms);
			}

			return parms;
		}
	}
}
