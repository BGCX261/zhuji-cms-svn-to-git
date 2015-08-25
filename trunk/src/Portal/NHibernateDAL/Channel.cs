using System;
using System.Collections.Generic;
using NHibernate;
using ZhuJi.NH;

namespace ZhuJi.Portal.NHibernateDAL
{
	/// <summary>
	/// 网站栏目数据层
	/// </summary>
    public class Channel : ZhuJi.NH.BaseDAL<ZhuJi.Portal.Domain.Channel>, ZhuJi.Portal.IDAL.IChannel
    {
        private ISession session = NHibernateHelper.GetCurrentSession();

        /// <summary>
        /// 新增栏目记录
        /// </summary>
        /// <param name="currentNode">参考节点</param>
        /// <param name="domainChannel">栏目对象</param>
        public void Insert(int currentNode, ZhuJi.Portal.Domain.Channel domainChannel)
        {
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                ZhuJi.Portal.Domain.Channel parentDomainChannel = (ZhuJi.Portal.Domain.Channel)session.Get(typeof(ZhuJi.Portal.Domain.Channel), domainChannel.Parent);

                if (parentDomainChannel != null)
                {
                    ZhuJi.Portal.Domain.Channel tmpDomainChannel = null;
                    switch (currentNode)
                    {
                        case 0:
                            //更新父节点
                            tmpDomainChannel = (ZhuJi.Portal.Domain.Channel)session.Get(typeof(ZhuJi.Portal.Domain.Channel), parentDomainChannel.Parent);

                            if (tmpDomainChannel != null)
                            {
                                tmpDomainChannel.Child++;
                                session.Update(tmpDomainChannel);
                            }

                            domainChannel.Parent = parentDomainChannel.Parent;
                            domainChannel.OrderBy = parentDomainChannel.OrderBy - 1;
                            domainChannel.Depth = parentDomainChannel.Depth;
                            domainChannel.Path = parentDomainChannel.Path;
                            break;
                        case 1:
                            //更新父节点
                            tmpDomainChannel = (ZhuJi.Portal.Domain.Channel)session.Get(typeof(ZhuJi.Portal.Domain.Channel), parentDomainChannel.Parent);
                            if (tmpDomainChannel != null)
                            {
                                tmpDomainChannel.Child++;
                                session.Update(tmpDomainChannel);
                            }

                            domainChannel.Parent = parentDomainChannel.Parent;
                            domainChannel.OrderBy = parentDomainChannel.OrderBy + 1;
                            domainChannel.Depth = parentDomainChannel.Depth;
                            domainChannel.Path = parentDomainChannel.Path;
                            break;
                        case 2:
                            //更新父节点
                            parentDomainChannel.Child++;
                            session.Update(parentDomainChannel);

                            domainChannel.Depth = parentDomainChannel.Depth + 1;
                            domainChannel.Path = string.Concat(parentDomainChannel.Path, domainChannel.Parent, ".");
                            break;
                    }
                }

                session.Save(domainChannel);

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
        /// 更新栏目记录
        /// </summary>
        /// <param name="currentNode">参考节点</param>
        /// <param name="domainChannel">栏目对象</param>
        public void Update(int currentNode, ZhuJi.Portal.Domain.Channel domainChannel)
        {
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                //原栏目记录
                ZhuJi.Portal.Domain.Channel oldDomainChannel = (ZhuJi.Portal.Domain.Channel)session.Get(typeof(ZhuJi.Portal.Domain.Channel), domainChannel.Id);

                if (oldDomainChannel == null)
                {
                    throw new ArgumentException("记录不存在!");
                }
                else
                {
                    string path = "0.";
                    int len = session.CreateQuery(string.Format("select t from Channel t where t.Path Like '{0}%' And t.Id = {1}", string.Concat(oldDomainChannel.Path, oldDomainChannel.Id, "."), domainChannel.Parent)).List<ZhuJi.Portal.Domain.Channel>().Count;

                    if (len > 0)
                    {
                        throw new ArgumentException("类别不可以转移到子类别下面!");
                    }
                    else
                    {
                        UpdateOldParent(oldDomainChannel);
                    }

                    switch (currentNode)
                    {
                        case 0:
                            domainChannel = UpdateCurrent(domainChannel, -1);
                            break;
                        case 1:
                            domainChannel = UpdateCurrent(domainChannel, 1);
                            break;
                        case 2:

                            //父栏目记录
                            ZhuJi.Portal.Domain.Channel parentDomainChannel = UpdateParent(domainChannel);
                            if (parentDomainChannel != null)
                            {
                                path = string.Concat(parentDomainChannel.Path, domainChannel.Parent, ".");
                            }

                            UpdateChild(oldDomainChannel, path);

                            domainChannel.Path = path;
                            domainChannel.Depth = path.Split('.').Length - 1;

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

            base.Update(domainChannel);
        }

        #region Update
		/// <summary>
		/// 更新同等级栏目记录
		/// </summary>
		/// <param name="domainChannel">当前栏目记录</param>
		/// <param name="i"></param>
		/// <returns></returns>
        private ZhuJi.Portal.Domain.Channel UpdateCurrent(ZhuJi.Portal.Domain.Channel domainChannel, int i)
        {
            ZhuJi.Portal.Domain.Channel parentDomainChannel = (ZhuJi.Portal.Domain.Channel)session.Get(typeof(ZhuJi.Portal.Domain.Channel),domainChannel.Parent);
            if (parentDomainChannel != null)
            {
                ZhuJi.Portal.Domain.Channel tmpDomainChannel = (ZhuJi.Portal.Domain.Channel)session.Get(typeof(ZhuJi.Portal.Domain.Channel),parentDomainChannel.Parent);
                if (tmpDomainChannel != null)
                {
                    tmpDomainChannel.Child++;
                    session.Update(tmpDomainChannel);
                }

                domainChannel.Parent = parentDomainChannel.Parent;
                domainChannel.Depth = parentDomainChannel.Depth;
                domainChannel.Path = parentDomainChannel.Path;
                domainChannel.OrderBy = parentDomainChannel.OrderBy + i;
            }
            return domainChannel;
        }

        /// <summary>
        /// 更新原父栏目记录
        /// </summary>
        /// <param name="oldDomainChannel">原栏目记录</param>
        private void UpdateOldParent(ZhuJi.Portal.Domain.Channel oldDomainChannel)
        {
            //获取原父栏目记录
            ZhuJi.Portal.Domain.Channel oldparentDomainChannel = (ZhuJi.Portal.Domain.Channel)session.Get(typeof(ZhuJi.Portal.Domain.Channel),oldDomainChannel.Parent);
            if (oldparentDomainChannel != null)
            {
                oldparentDomainChannel.Child--;
                session.Update(oldparentDomainChannel);
            }
        }

        /// <summary>
        /// 更新父栏目记录
        /// </summary>
        /// <param name="domainChannel">当前栏目记录</param>
        private ZhuJi.Portal.Domain.Channel UpdateParent(ZhuJi.Portal.Domain.Channel domainChannel)
        {
            ZhuJi.Portal.Domain.Channel parentDomainChannel = (ZhuJi.Portal.Domain.Channel)session.Get(typeof(ZhuJi.Portal.Domain.Channel),domainChannel.Parent);
            if (parentDomainChannel != null)
            {
                parentDomainChannel.Child = session.CreateQuery(string.Format("select t from Channel t where t.Parent = {0}", domainChannel.Parent)).List<ZhuJi.Portal.Domain.Channel>().Count + 1;
                session.Update(parentDomainChannel);
            }
            return parentDomainChannel;
        }

        /// <summary>
        /// 更新子栏目记录
        /// </summary>
        /// <param name="oldDomainChannel">原栏目记录</param>
        /// <param name="path">当前节点路径</param>
        private void UpdateChild(ZhuJi.Portal.Domain.Channel oldDomainChannel, string path)
        {
            IList<ZhuJi.Portal.Domain.Channel> list = session.CreateQuery(string.Format("select t from Channel t where t.Path Like '{0}%'", string.Concat(oldDomainChannel.Path, oldDomainChannel.Id, "."))).List<ZhuJi.Portal.Domain.Channel>();
            foreach (ZhuJi.Portal.Domain.Channel p in list)
            {
                p.Path = string.Concat(path, p.Path.Substring(oldDomainChannel.Path.Length));
                p.Depth = p.Path.Split('.').Length - 1;
                session.Update(p);
            }
        }
        #endregion

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="domainChannel">栏目对象</param>
        new public void Delete(ZhuJi.Portal.Domain.Channel domainChannel)
        {
            ITransaction tx = null;
            try
            {
                tx = session.BeginTransaction();

                ZhuJi.Portal.Domain.Channel currentDomainChannel = (ZhuJi.Portal.Domain.Channel)session.Get(typeof(ZhuJi.Portal.Domain.Channel), domainChannel.Id);
                if (currentDomainChannel.Child > 0)
                {
                    throw new ArgumentException("删除类别不可以有子类别，请先删除子类别!");
                }
                else
                {

                    ZhuJi.Portal.Domain.Channel parentDomainChannel = (ZhuJi.Portal.Domain.Channel)session.Get(typeof(ZhuJi.Portal.Domain.Channel), currentDomainChannel.Parent);
                    if (parentDomainChannel != null)
                    {
                        parentDomainChannel.Child--;
                        session.Update(parentDomainChannel);
                    }

                    session.Delete(domainChannel);
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
        /// 获取树型栏目记录集合
        /// </summary>
        /// <returns>树型栏目记录集合</returns>
        public IList<ZhuJi.Portal.Domain.Channel> TreeNodes()
        {
            IList<ZhuJi.Portal.Domain.Channel> list = session.CreateQuery("select t from Channel t order by t.OrderBy desc,t.Id desc").List<ZhuJi.Portal.Domain.Channel>();
            ZhuJi.Portal.Domain.ChannelCollection channels = new ZhuJi.Portal.Domain.ChannelCollection();
            list = channels.Tree(list);

            return list;
        }
    }
}

