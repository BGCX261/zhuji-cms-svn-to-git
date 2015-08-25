using System;
using System.Data;
using System.Data.SqlClient;
using ZhuJi.Library.Data;

namespace ZhuJi.Modules.CountModule.SQLServerDAL
{
	/// <summary>
	/// 统计在线人数数据层
	/// </summary>
    public class CountOnline : ZhuJi.Modules.CountModule.IDAL.ICountOnline
    {
		/// <summary>
		/// 获取记录集合
		/// </summary>
		/// <param name="onlineTime">在线时间（单位分钟）</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <returns>记录集合</returns>
		public virtual DataSet GetObjects(int onlineTime, DateTime beginTime, DateTime endTime)
		{
			SqlParameter[] cmdParms = new SqlParameter[] {
					new SqlParameter("@OnlineTime", SqlDbType.Int),
					new SqlParameter("@BeginTime", SqlDbType.SmallDateTime),
					new SqlParameter("@EndTime", SqlDbType.SmallDateTime),
				};

			cmdParms[0].Value = onlineTime;
			cmdParms[1].Value = beginTime;
			cmdParms[2].Value = endTime;

			return SqlHelper.ExecuteDataSet(DBFactory.DBConnectionString, CommandType.StoredProcedure, "CountOnline_Query", "CountOnline", cmdParms);
		}
    }
}


