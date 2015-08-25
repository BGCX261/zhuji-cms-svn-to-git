using System.Collections.Generic;

namespace ZhuJi.Modules.SinglePageModule.NHibernateDAL
{
	/// <summary>
	/// 单页数据层
	/// </summary>
    public class SinglePage : ZhuJi.NH.BaseDAL<ZhuJi.Modules.SinglePageModule.Domain.SinglePage>, ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage
    {
		/// <summary>
		/// 通过网站栏目ID获取单页信息
		/// </summary>
		/// <param name="channelId">网站栏目ID</param>
		/// <returns>单页信息</returns>
		public ZhuJi.Modules.SinglePageModule.Domain.SinglePage GetObjectByChannelId(int channelId)
		{
			IList<ZhuJi.Modules.SinglePageModule.Domain.SinglePage> list = base.GetObjects(string.Format("tmp.ContentBaseInfo.ChannelId = {0}", channelId), string.Empty);

			if (list.Count > 0)
			{
				return list[0];
			}
			else
			{
				return null;
			}
		}
    }
}

