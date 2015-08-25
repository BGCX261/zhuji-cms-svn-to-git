using System.Collections.Generic;

namespace ZhuJi.Portal.IDAL
{
    /// <summary>
	/// ������ݲ�ӿ�
    /// </summary>
    public interface IPlugin : ZhuJi.NH.IBaseDAL<ZhuJi.Portal.Domain.Plugin>
    {
        /// <summary>
        /// ���������¼
        /// </summary>
        /// <param name="currentNode">�ο��ڵ�</param>
        /// <param name="domainPlugin">�������</param>
        void Insert(int currentNode, ZhuJi.Portal.Domain.Plugin domainPlugin);

        /// <summary>
        /// ���²����¼
        /// </summary>
        /// <param name="currentNode">�ο��ڵ�</param>
        /// <param name="domainPlugin">�������</param>
        void Update(int currentNode, ZhuJi.Portal.Domain.Plugin domainPlugin);

        /// <summary>
        /// ��ȡ���Ͳ����¼����
        /// </summary>
        /// <returns>���Ͳ����¼����</returns>
        IList<ZhuJi.Portal.Domain.Plugin> TreeNodes();
    }
}