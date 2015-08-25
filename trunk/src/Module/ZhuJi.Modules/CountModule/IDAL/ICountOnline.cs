using System;
using System.Data;

namespace ZhuJi.Modules.CountModule.IDAL
{
    /// <summary>
	/// 统计在线人数数据层接口
    /// </summary>
    public interface ICountOnline
    {
		/// <summary>
		/// 获取记录集合
		/// </summary>
		/// <param name="onlineTime">在线时间（单位分钟）</param>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <returns>记录集合</returns>
		DataSet GetObjects(int onlineTime, DateTime beginTime, DateTime endTime);
    }
}


