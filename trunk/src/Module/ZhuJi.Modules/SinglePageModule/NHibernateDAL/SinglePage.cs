using System.Collections.Generic;

namespace ZhuJi.Modules.SinglePageModule.NHibernateDAL
{
	/// <summary>
	/// ��ҳ���ݲ�
	/// </summary>
    public class SinglePage : ZhuJi.NH.BaseDAL<ZhuJi.Modules.SinglePageModule.Domain.SinglePage>, ZhuJi.Modules.SinglePageModule.IDAL.ISinglePage
    {
		/// <summary>
		/// ͨ����վ��ĿID��ȡ��ҳ��Ϣ
		/// </summary>
		/// <param name="channelId">��վ��ĿID</param>
		/// <returns>��ҳ��Ϣ</returns>
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

