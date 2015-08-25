using System;
using System.Data;
using System.Data.SqlClient;
using ZhuJi.Library.Data;

namespace ZhuJi.Modules.CountModule.SQLServerDAL
{
	/// <summary>
	/// 统计概况数据层
	/// </summary>
	public class CountProfiles : ZhuJi.Modules.CountModule.IDAL.ICountProfiles
	{
		/// <summary>
		/// 获取记录集合
		/// </summary>
		/// <returns>记录集合</returns>
		public virtual DataSet GetObjects()
		{
			SqlParameter[] cmdParms = new SqlParameter[] {};

			return SqlHelper.ExecuteDataSet(DBFactory.DBConnectionString, CommandType.StoredProcedure, "CountProfiles_Query", "CountProfiles", cmdParms);
		}
	}
}
