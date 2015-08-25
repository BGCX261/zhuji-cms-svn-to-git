using System;
using System.Collections.Generic;
using NHibernate;
using ZhuJi.NH;

namespace ZhuJi.Portal.NHibernateDAL
{
	/// <summary>
	/// 插件数据层
	/// </summary>
    public class Plugin : ZhuJi.NH.BaseDAL<ZhuJi.Portal.Domain.Plugin>, ZhuJi.Portal.IDAL.IPlugin
    {
        private ISession session = NHibernateHelper.GetCurrentSession();

        /// <summary>
        /// 新增插件记录
        /// </summary>
        /// <param name="currentNode">参考节点</param>
        /// <param name="domainPlugin">插件对象</param>
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
                            //更新父节点
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
                            //更新父节点
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
                            //更新父节点
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
        /// 更新插件记录
        /// </summary>
        /// <param name="currentNode">参考节点</param>
        /// <param name="domainPlugin">插件对象</param>
        public void Update(int currentNode, ZhuJi.Portal.Domain.Plugin domainPlugin)
        {
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                //原插件记录
                ZhuJi.Portal.Domain.Plugin oldDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), domainPlugin.Id);

                if (oldDomainPlugin == null)
                {
                    throw new ArgumentException("记录不存在!");
                }
                else
                {
                    string path = "0.";
                    int len = session.CreateQuery(string.Format("select t from Plugin t where t.Path Like '{0}%' And t.Id = {1}", string.Concat(oldDomainPlugin.Path, oldDomainPlugin.Id, "."), domainPlugin.Parent)).List<ZhuJi.Portal.Domain.Plugin>().Count;

                    if (len > 0)
                    {
                        throw new ArgumentException("类别不可以转移到子类别下面!");
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

                            //父插件记录
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
		/// 更新同等级插件记录
		/// </summary>
		/// <param name="domainPlugin">当前插件记录</param>
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
        /// 更新原父插件记录
        /// </summary>
        /// <param name="oldDomainPlugin">原插件记录</param>
        private void UpdateOldParent(ZhuJi.Portal.Domain.Plugin oldDomainPlugin)
        {
            //获取原父插件记录
            ZhuJi.Portal.Domain.Plugin oldparentDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), oldDomainPlugin.Parent);
            if (oldparentDomainPlugin != null)
            {
                oldparentDomainPlugin.Child--;
                session.Update(oldparentDomainPlugin);
            }
        }

        /// <summary>
        /// 更新父插件记录
        /// </summary>
        /// <param name="domainPlugin">当前插件记录</param>
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
        /// 更新子插件记录
        /// </summary>
        /// <param name="oldDomainPlugin">原插件记录</param>
        /// <param name="path">当前节点路径</param>
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
        /// 删除记录
        /// </summary>
        /// <param name="domainPlugin">插件对象</param>
        new public void Delete(ZhuJi.Portal.Domain.Plugin domainPlugin)
        {
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                ZhuJi.Portal.Domain.Plugin currentDomainPlugin = (ZhuJi.Portal.Domain.Plugin)session.Get(typeof(ZhuJi.Portal.Domain.Plugin), domainPlugin.Id);
                if (currentDomainPlugin.Child > 0)
                {
                    throw new ArgumentException("删除类别不可以有子类别，请先删除子类别!");
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
        /// 获取树型插件记录集合
        /// </summary>
        /// <returns>树型插件记录集合</returns>
        public IList<ZhuJi.Portal.Domain.Plugin> TreeNodes()
        {
            IList<ZhuJi.Portal.Domain.Plugin> list = session.CreateQuery("select t from Plugin t order by t.OrderBy desc,t.Id desc").List<ZhuJi.Portal.Domain.Plugin>();
            ZhuJi.Portal.Domain.PluginCollection plugins = new ZhuJi.Portal.Domain.PluginCollection();
            list = plugins.Tree(list);

            return list;
        }
    }
}