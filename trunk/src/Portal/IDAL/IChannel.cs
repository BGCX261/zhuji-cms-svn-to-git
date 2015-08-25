using System.Collections.Generic;

namespace ZhuJi.Portal.IDAL
{
    /// <summary>
	/// ��վ��Ŀ���ݲ�ӿ�
    /// </summary>
    public interface IChannel : ZhuJi.NH.IBaseDAL<ZhuJi.Portal.Domain.Channel>
    {
        /// <summary>
        /// ������Ŀ��¼
        /// </summary>
        /// <param name="currentNode">�ο��ڵ�</param>
        /// <param name="domainChannel">��Ŀ����</param>
        void Insert(int currentNode, ZhuJi.Portal.Domain.Channel domainChannel);

        /// <summary>
        /// ������Ŀ��¼
        /// </summary>
        /// <param name="currentNode">�ο��ڵ�</param>
        /// <param name="domainChannel">��Ŀ����</param>
        void Update(int currentNode, ZhuJi.Portal.Domain.Channel domainChannel);

        /// <summary>
        /// ��ȡ������Ŀ��¼����
        /// </summary>
        /// <returns>������Ŀ��¼����</returns>
        IList<ZhuJi.Portal.Domain.Channel> TreeNodes();
    }
}