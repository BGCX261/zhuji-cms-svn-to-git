namespace ZhuJi.Modules.SinglePageModule.IDAL
{
    /// <summary>
	/// ��ҳ���ݲ�ӿ�
    /// </summary>
    public interface ISinglePage : ZhuJi.NH.IBaseDAL<ZhuJi.Modules.SinglePageModule.Domain.SinglePage>
    {
		/// <summary>
		/// ͨ����վ��ĿID��ȡ��ҳ��Ϣ
		/// </summary>
		/// <param name="channelId">��վ��ĿID</param>
		/// <returns>��ҳ��Ϣ</returns>
		ZhuJi.Modules.SinglePageModule.Domain.SinglePage GetObjectByChannelId(int channelId);
    }
}
