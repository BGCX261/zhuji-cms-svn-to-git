using System;
using System.Data;
using System.Data.SqlClient;
using ZhuJi.Library.Data;

namespace ZhuJi.Modules.CountModule.SQLServerDAL
{
	/// <summary>
	/// 统计回头率数据层
	/// </summary>
    public class CountBack : ZhuJi.Modules.CountModule.IDAL.ICountBack
    {
		/// <summary>
		/// 获取记录集合
		/// </summary>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <returns>记录集合</returns>
		public virtual DataSet GetObjects(DateTime beginTime, DateTime endTime)
		{
			SqlParameter[] cmdParms = new SqlParameter[] {
					new SqlParameter("@BeginTime", SqlDbType.SmallDateTime),
					new SqlParameter("@EndTime", SqlDbType.SmallDateTime),
				};

			cmdParms[0].Value = beginTime;
			cmdParms[1].Value = endTime;

			return SqlHelper.ExecuteDataSet(DBFactory.DBConnectionString, CommandType.StoredProcedure, "CountBack_Query", "CountBack", cmdParms);
		}
    }
}


