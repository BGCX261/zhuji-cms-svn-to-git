namespace ZhuJi.Modules.SinglePageModule.IDAL
{
    /// <summary>
	/// 单页数据层接口
    /// </summary>
    public interface ISinglePage : ZhuJi.NH.IBaseDAL<ZhuJi.Modules.SinglePageModule.Domain.SinglePage>
    {
		/// <summary>
		/// 通过网站栏目ID获取单页信息
		/// </summary>
		/// <param name="channelId">网站栏目ID</param>
		/// <returns>单页信息</returns>
		ZhuJi.Modules.SinglePageModule.Domain.SinglePage GetObjectByChannelId(int channelId);
    }
}
