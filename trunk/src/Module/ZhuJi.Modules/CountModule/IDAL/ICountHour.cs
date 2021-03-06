﻿using System;
using System.Data;

namespace ZhuJi.Modules.CountModule.IDAL
{
    /// <summary>
	/// 统计时段数据层接口
    /// </summary>
    public interface ICountHour
    {
		/// <summary>
		/// 获取记录集合
		/// </summary>
		/// <param name="beginTime">开始时间</param>
		/// <param name="endTime">结束时间</param>
		/// <returns>记录集合</returns>
		DataSet GetObjects(DateTime beginTime, DateTime endTime);
    }
}


