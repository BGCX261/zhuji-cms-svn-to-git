using System;
using System.Collections.Generic;

namespace ZhuJi.Log.IDAL
{
    /// <summary>
	/// 日志数据层接口
    /// </summary>
    public interface ILogging : ZhuJi.NH.IBaseDAL<ZhuJi.Log.Domain.Logging>
	{
		/// <summary>
		/// 将异常信息记录。
		/// </summary>
		/// <param name="ex">要记录的异常。</param>
		void WriteException(Exception ex);

		/// <summary>
		/// 将消息记录。
		/// </summary>
		/// <param name="message">将消息记录。</param>
		void WriteEntry(string message);

	}
}