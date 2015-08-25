using System;
using System.Collections.Generic;
using System.Text;

namespace ZhuJi.Modules.CountModule.IDAL
{
	/// <summary>
	/// 统计记录数据层接口
	/// </summary>
	public interface ICountStat
	{
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
		void Insert(int id, string ip, int pvs, int ips, int cookies, string area, string province, string city, int visits, DateTime addTime, string referSite, string referUrl, string os, string browser, string resolution, string respondents);
	}
}
