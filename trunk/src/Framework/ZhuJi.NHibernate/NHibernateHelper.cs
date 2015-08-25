using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace ZhuJi.NH
{
	/// <summary>
	/// NHibernate������
	/// </summary>
    public sealed class NHibernateHelper
    {
        private const string CurrentSessionKey = "hibernate-configuration";
        private static readonly ISessionFactory sessionFactory;

        static NHibernateHelper()
        {
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

		/// <summary>
		/// �򿪵�ǰSession
		/// </summary>
		/// <returns>Session</returns>
        public static ISession GetCurrentSession()
        {
            HttpContext context = HttpContext.Current;
            ISession currentSession;
			if (context != null)
			{
				currentSession = context.Items[CurrentSessionKey] as ISession;
				if (currentSession == null)
				{
					currentSession = sessionFactory.OpenSession();
					context.Items[CurrentSessionKey] = currentSession;
				}
			}
			else
			{
				currentSession = sessionFactory.OpenSession();
			}

            return currentSession;
        }

		/// <summary>
		/// �ر�Session
		/// </summary>
        public static void CloseSession()
        {
            HttpContext context = HttpContext.Current;
			if (context != null)
			{
				ISession currentSession = context.Items[CurrentSessionKey] as ISession;

				if (currentSession == null)
				{
					return;
				}

				currentSession.Close();
				context.Items.Remove(CurrentSessionKey);
			}

        }

		/// <summary>
		/// �ر�Session����
		/// </summary>
        public static void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }
    }
}
