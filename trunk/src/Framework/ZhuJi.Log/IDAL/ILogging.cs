using System;
using System.Collections.Generic;

namespace ZhuJi.Log.IDAL
{
    /// <summary>
	/// ��־���ݲ�ӿ�
    /// </summary>
    public interface ILogging : ZhuJi.NH.IBaseDAL<ZhuJi.Log.Domain.Logging>
	{
		/// <summary>
		/// ���쳣��Ϣ��¼��
		/// </summary>
		/// <param name="ex">Ҫ��¼���쳣��</param>
		void WriteException(Exception ex);

		/// <summary>
		/// ����Ϣ��¼��
		/// </summary>
		/// <param name="message">����Ϣ��¼��</param>
		void WriteEntry(string message);

	}
}