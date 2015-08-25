using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.SqlClient;
using ZhuJi.Library.Data;

namespace ZhuJi.Modules.RssModule.SQLServerDAL
{
	/// <summary>
	/// 频道数据层
	/// </summary>
	public class RssChannel : ZhuJi.Modules.RssModule.IDAL.IRssChannel
	{
		private const string SQL_SELECT_RSSCHANNEL = "select * from dbo.V_RssChannel WHERE Id = @ChannelId";
		private const string SQL_SELECT_RSSITEM = "select * from dbo.V_RssItem WHERE ChannelId = @ChannelId";

		private const string PARM_CHANNELID = "@ChannelId";

		/// <summary>
		/// 获取频道
		/// </summary>
		/// <param name="channelId">频道ID</param>
		/// <returns>频道</returns>
		public ZhuJi.Modules.RssModule.Domain.RssChannel GetObject(int channelId)
		{
			ZhuJi.Modules.RssModule.Domain.RssChannel domainRssChannel = null;

			SqlParameter parm = new SqlParameter(PARM_CHANNELID, SqlDbType.Int);
			parm.Value = channelId;

			using (SqlDataReader rdr = SqlHelper.ExecuteReader(DBFactory.DBConnectionString, CommandType.Text, SQL_SELECT_RSSCHANNEL, parm))
			{
				if (rdr.Read())
				{
					domainRssChannel = new ZhuJi.Modules.RssModule.Domain.RssChannel();
					DbManager.BindIDataReaderToObject(rdr, domainRssChannel);

					using (SqlDataReader rdrItem = SqlHelper.ExecuteReader(DBFactory.DBConnectionString, CommandType.Text, SQL_SELECT_RSSITEM, parm))
					{
						while (rdrItem.Read())
						{
							ZhuJi.Modules.RssModule.Domain.RssItem domainRssItem = new ZhuJi.Modules.RssModule.Domain.RssItem();
							DbManager.BindIDataReaderToObject(rdrItem, domainRssItem);
							domainRssChannel.RssItems.Add(domainRssItem);
						}
					}
				}
			}
			return domainRssChannel;
		}
	}
}
