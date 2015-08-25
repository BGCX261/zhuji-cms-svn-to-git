using System;
using System.Data;

namespace ZhuJi.Modules.CountModule.IDAL
{
    /// <summary>
	/// 统计概况数据层接口
    /// </summary>
    public interface ICountProfiles
    {
		/// <summary>
		/// 获取记录集合
		/// </summary>
		/// <returns>记录集合</returns>
		DataSet GetObjects();
    }
}


