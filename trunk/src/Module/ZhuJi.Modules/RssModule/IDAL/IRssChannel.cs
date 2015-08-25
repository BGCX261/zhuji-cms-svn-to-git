using System.Collections.Generic;

namespace ZhuJi.Modules.RssModule.IDAL
{
    /// <summary>
	/// 频道数据层接口
    /// </summary>
	public interface IRssChannel
    {
		/// <summary>
		/// 获取频道
		/// </summary>
		/// <param name="channelId">频道ID</param>
		/// <returns>频道</returns>
		ZhuJi.Modules.RssModule.Domain.RssChannel GetObject(int channelId);
    }
}


