// 以下代码由 Microsoft Visual Studio 2005 生成。
// 测试所有者应该检查每个测试的有效性。
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using ZhuJi.Modules.RssModule.SQLServerDAL;
using ZhuJi.Modules.RssModule.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
namespace ZhuJi.Test.Modules.RssModule.SQLServerDAL
{
	/// <summary>
	///这是 ZhuJi.Modules.RssModule.SQLServerDAL.RssChannel 的测试类，旨在
	///包含所有 ZhuJi.Modules.RssModule.SQLServerDAL.RssChannel 单元测试
	///</summary>
	[TestClass()]
	public class RssChannelTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///获取或设置测试上下文，上下文提供
		///有关当前测试运行及其功能的信息。
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}
		#region 附加测试属性
		// 
		//编写测试时，可使用以下附加属性:
		//
		//使用 ClassInitialize 在运行类中的第一个测试前先运行代码
		//
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//使用 ClassCleanup 在运行完类中的所有测试后再运行代码
		//
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//使用 TestInitialize 在运行每个测试前先运行代码
		//
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//使用 TestCleanup 在运行完每个测试后运行代码
		//
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///GetObject (int) 的测试
		///</summary>
		[TestMethod()]
		public void GetObjectTest()
		{
			ZhuJi.Modules.RssModule.SQLServerDAL.RssChannel target = new ZhuJi.Modules.RssModule.SQLServerDAL.RssChannel();

			int channelId = 10; // TODO: 初始化为适当的值

			ZhuJi.Modules.RssModule.Domain.RssChannel actual;

			actual = target.GetObject(channelId);

			Assert.Inconclusive("验证此测试方法的正确性。");

		}

	}


}
