using System;
using ZhuJi.Library.Globalization;

namespace ZhuJi.Log.NHibernateDAL
{
	/// <summary>
	/// ��־���ݲ�
	/// </summary>
    public class Logging : ZhuJi.NH.BaseDAL<ZhuJi.Log.Domain.Logging>, ZhuJi.Log.IDAL.ILogging
    {
		/// <summary>
		/// ���쳣��Ϣ��¼��
		/// </summary>
		/// <param name="ex">Ҫ��¼���쳣��</param>
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
		/// ����Ϣ��¼��
		/// </summary>
		/// <param name="message">����Ϣ��¼��</param>
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
