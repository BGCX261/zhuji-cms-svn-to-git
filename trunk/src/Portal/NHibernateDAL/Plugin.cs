using System;
using System.Collections.Generic;
using NHibernate;
using ZhuJi.NH;

namespace ZhuJi.Portal.NHibernateDAL
{
	/// <summary>
	/// ������ݲ�
	/// </summary>
    public class Plugin : ZhuJi.NH.BaseDAL<ZhuJi.Portal.Domain.Plugin>, ZhuJi.Portal.IDAL.IPlugin
    {
        private ISession session = NHibernateHelper.GetCurrentSession();

        /// <summary>
        /// ���������¼
        /// </summary>
        /// <param name="currentNode">�ο��ڵ�</param>
        /// <param name="domainPlugin">�������</param>
        public void Insert(int currentNode, ZhuJi.Portal.Domain.Plugin domainPlugin)
        {
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                ZhuJi.Portal.Domain.Plugin parentDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), domainPlugin.Parent);

                if (parentDomainPlugin != null)
                {
                    ZhuJi.Portal.Domain.Plugin tmpDomainPlugin = null;
                    switch (currentNode)
                    {
                        case 0:
                            //���¸��ڵ�
                            tmpDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), parentDomainPlugin.Parent);

                            if (tmpDomainPlugin != null)
                            {
                                tmpDomainPlugin.Child++;
                                session.Update(tmpDomainPlugin);
                            }

                            domainPlugin.Parent = parentDomainPlugin.Parent;
                            domainPlugin.OrderBy = parentDomainPlugin.OrderBy - 1;
                            domainPlugin.Depth = parentDomainPlugin.Depth;
                            domainPlugin.Path = parentDomainPlugin.Path;
                            break;
                        case 1:
                            //���¸��ڵ�
                            tmpDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), parentDomainPlugin.Parent);
                            if (tmpDomainPlugin != null)
                            {
                                tmpDomainPlugin.Child++;
                                session.Update(tmpDomainPlugin);
                            }

                            domainPlugin.Parent = parentDomainPlugin.Parent;
                            domainPlugin.OrderBy = parentDomainPlugin.OrderBy + 1;
                            domainPlugin.Depth = parentDomainPlugin.Depth;
                            domainPlugin.Path = parentDomainPlugin.Path;
                            break;
                        case 2:
                            //���¸��ڵ�
                            parentDomainPlugin.Child++;
                            session.Update(parentDomainPlugin);

                            domainPlugin.Depth = parentDomainPlugin.Depth + 1;
                            domainPlugin.Path = string.Concat(parentDomainPlugin.Path, domainPlugin.Parent, ".");
                            break;
                    }
                }

                session.Save(domainPlugin);

                tx.Commit();
            }
            catch (HibernateException ex)
            {
                if (tx != null) tx.Rollback();
                throw ex;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }
        /// <summary>
        /// ���²����¼
        /// </summary>
        /// <param name="currentNode">�ο��ڵ�</param>
        /// <param name="domainPlugin">�������</param>
        public void Update(int currentNode, ZhuJi.Portal.Domain.Plugin domainPlugin)
        {
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                //ԭ�����¼
                ZhuJi.Portal.Domain.Plugin oldDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), domainPlugin.Id);

                if (oldDomainPlugin == null)
                {
                    throw new ArgumentException("��¼������!");
                }
                else
                {
                    string path = "0.";
                    int len = session.CreateQuery(string.Format("select t from Plugin t where t.Path Like '{0}%' And t.Id = {1}", string.Concat(oldDomainPlugin.Path, oldDomainPlugin.Id, "."), domainPlugin.Parent)).List<ZhuJi.Portal.Domain.Plugin>().Count;

                    if (len > 0)
                    {
                        throw new ArgumentException("��𲻿���ת�Ƶ����������!");
                    }
                    else
                    {
                        UpdateOldParent(oldDomainPlugin);
                    }

                    switch (currentNode)
                    {
                        case 0:
                            domainPlugin = UpdateCurrent(domainPlugin, -1);
                            break;
                        case 1:
                            domainPlugin = UpdateCurrent(domainPlugin, 1);
                            break;
                        case 2:

                            //�������¼
                            ZhuJi.Portal.Domain.Plugin parentDomainPlugin = UpdateParent(domainPlugin);
                            if (parentDomainPlugin != null)
                            {
                                path = string.Concat(parentDomainPlugin.Path, domainPlugin.Parent, ".");
                            }

                            UpdateChild(oldDomainPlugin, path);

                            domainPlugin.Path = path;
                            domainPlugin.Depth = path.Split('.').Length - 1;
                            break;
                    }

                }

                tx.Commit();

            }
            catch (HibernateException ex)
            {
                if (tx != null) tx.Rollback();
                throw ex;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
            
            base.Update(domainPlugin);
        }

        #region Update
		/// <summary>
		/// ����ͬ�ȼ������¼
		/// </summary>
		/// <param name="domainPlugin">��ǰ�����¼</param>
        /// <param name="i"></param>
        /// <returns></returns>
        private ZhuJi.Portal.Domain.Plugin UpdateCurrent(ZhuJi.Portal.Domain.Plugin domainPlugin, int i)
        {
            ZhuJi.Portal.Domain.Plugin parentDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), domainPlugin.Parent);
            if (parentDomainPlugin != null)
            {
                ZhuJi.Portal.Domain.Plugin tmpDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), parentDomainPlugin.Parent);
                if (tmpDomainPlugin != null)
                {
                    tmpDomainPlugin.Child++;
                    session.Update(tmpDomainPlugin);
                }

                domainPlugin.Parent = parentDomainPlugin.Parent;
                domainPlugin.Depth = parentDomainPlugin.Depth;
                domainPlugin.Path = parentDomainPlugin.Path;
                domainPlugin.OrderBy = parentDomainPlugin.OrderBy + i;
            }
            return domainPlugin;
        }

        /// <summary>
        /// ����ԭ�������¼
        /// </summary>
        /// <param name="oldDomainPlugin">ԭ�����¼</param>
        private void UpdateOldParent(ZhuJi.Portal.Domain.Plugin oldDomainPlugin)
        {
            //��ȡԭ�������¼
            ZhuJi.Portal.Domain.Plugin oldparentDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), oldDomainPlugin.Parent);
            if (oldparentDomainPlugin != null)
            {
                oldparentDomainPlugin.Child--;
                session.Update(oldparentDomainPlugin);
            }
        }

        /// <summary>
        /// ���¸������¼
        /// </summary>
        /// <param name="domainPlugin">��ǰ�����¼</param>
        private ZhuJi.Portal.Domain.Plugin UpdateParent(ZhuJi.Portal.Domain.Plugin domainPlugin)
        {
            ZhuJi.Portal.Domain.Plugin parentDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), domainPlugin.Parent);
            if (parentDomainPlugin != null)
            {
                parentDomainPlugin.Child = session.CreateQuery(string.Format("select t from Plugin t where t.Parent = {0}", domainPlugin.Parent)).List<ZhuJi.Portal.Domain.Plugin>().Count + 1;
                session.Update(parentDomainPlugin);
            }
            return parentDomainPlugin;
        }

        /// <summary>
        /// �����Ӳ����¼
        /// </summary>
        /// <param name="oldDomainPlugin">ԭ�����¼</param>
        /// <param name="path">��ǰ�ڵ�·��</param>
        private void UpdateChild(ZhuJi.Portal.Domain.Plugin oldDomainPlugin, string path)
        {
            IList<ZhuJi.Portal.Domain.Plugin> list = session.CreateQuery(string.Format("select t from Plugin t where t.Path Like '{0}%'", string.Concat(oldDomainPlugin.Path, oldDomainPlugin.Id, "."))).List<ZhuJi.Portal.Domain.Plugin>();
            foreach (ZhuJi.Portal.Domain.Plugin p in list)
            {
                p.Path = string.Concat(path, p.Path.Substring(oldDomainPlugin.Path.Length));
                p.Depth = p.Path.Split('.').Length - 1;
                session.Update(p);
            }
        }
        #endregion

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="domainPlugin">�������</param>
        new public void Delete(ZhuJi.Portal.Domain.Plugin domainPlugin)
        {
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                ZhuJi.Portal.Domain.Plugin currentDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), domainPlugin.Id);
                if (currentDomainPlugin.Child > 0)
                {
                    throw new ArgumentException("ɾ����𲻿��������������ɾ�������!");
                }
                else
                {

                    ZhuJi.Portal.Domain.Plugin parentDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), currentDomainPlugin.Parent);
                    if (parentDomainPlugin != null)
                    {
                        parentDomainPlugin.Child--;
                        session.Update(parentDomainPlugin);
                    }

                    session.Delete(domainPlugin);
                }

                tx.Commit();
            }
            catch (HibernateException ex)
            {
                if (tx != null) tx.Rollback();
                throw ex;
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }

        /// <summary>
        /// ��ȡ���Ͳ����¼����
        /// </summary>
        /// <returns>���Ͳ����¼����</returns>
        public IList<ZhuJi.Portal.Domain.Plugin> TreeNodes()
        {
            IList<ZhuJi.Portal.Domain.Plugin> list = session.CreateQuery("select t from Plugin t order by t.OrderBy desc,t.Id desc").List<ZhuJi.Portal.Domain.Plugin>();
            ZhuJi.Portal.Domain.PluginCollection plugins = new ZhuJi.Portal.Domain.PluginCollection();
            list = plugins.Tree(list);

            return list;
        }
    }
}