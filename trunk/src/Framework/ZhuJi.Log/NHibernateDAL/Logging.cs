using System;
using ZhuJi.Library.Globalization;

namespace ZhuJi.Log.NHibernateDAL
{
	/// <summary>
	/// 日志数据层
	/// </summary>
    public class Logging : ZhuJi.NH.BaseDAL<ZhuJi.Log.Domain.Logging>, ZhuJi.Log.IDAL.ILogging
    {
		/// <summary>
		/// 将异常信息记录。
		/// </summary>
		/// <param name="ex">要记录的异常。</param>
		public void WriteException(Exception ex)
		{
			ZhuJi.Log.Domain.Logging domainLogging = new ZhuJi.Log.Domain.Logging();
			domainLogging.Type = 0;
			domainLogging.Source = ex.Source;
			domainLogging.Description = ex.ToString();
			domainLogging.CreatedByUser = GlobalHelper.User;
			domainLogging.CreatedByIp = GlobalHelper.IP;
			domainLogging.CreatedByDate = GlobalHelper.Time;

			base.Insert(domainLogging);
		}

		/// <summary>
		/// 将消息记录。
		/// </summary>
		/// <param name="message">将消息记录。</param>
		public void WriteEntry(string message)
		{
			ZhuJi.Log.Domain.Logging domainLogging = new ZhuJi.Log.Domain.Logging();
			domainLogging.Type = 1;
			domainLogging.Source = string.Empty;
			domainLogging.Description = message;
			domainLogging.CreatedByUser = GlobalHelper.User;
			domainLogging.CreatedByIp = GlobalHelper.IP;
			domainLogging.CreatedByDate = GlobalHelper.Time;

			base.Insert(domainLogging);
		}
    }
}
