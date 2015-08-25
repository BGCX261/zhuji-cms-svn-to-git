using System.Web.UI;

namespace ZhuJi.Plugins
{
	/// <summary>
	/// �������ӿ�
	/// </summary>
    public interface IAddIn
    {
        /// <summary>
        /// ��ʼ�����
        /// </summary>
        /// <param name="configPath">�����ļ�·��</param>
        void Init(string configPath);

        /// <summary>
        /// ��ȡ�û��ؼ�
        /// </summary>
        /// <param name="key">�ؼ���</param>
        /// <returns>�����û��ؼ�</returns>
        Control GetControl(string key);
    }
}
