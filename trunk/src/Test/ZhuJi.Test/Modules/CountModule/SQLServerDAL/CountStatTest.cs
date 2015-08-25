// 以下代码由 Microsoft Visual Studio 2005 生成。
// 测试所有者应该检查每个测试的有效性。
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using ZhuJi.Modules.CountModule.SQLServerDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
namespace ZhuJi.Test.Modules.CountModule.SQLServerDAL
{
	/// <summary>
	///这是 ZhuJi.Modules.CountModule.SQLServerDAL.CountStat 的测试类，旨在
	///包含所有 ZhuJi.Modules.CountModule.SQLServerDAL.CountStat 单元测试
	///</summary>
	[TestClass()]
	public class CountStatTest
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
		///Insert (int, string, int, int, int, string, string, string, int, DateTime, string, string, string, string, string, string) 的测试
		///</summary>
		[TestMethod()]
		public void InsertTest()
		{
			CountStat target = new CountStat();

			int id = 0; // TODO: 初始化为适当的值

			string ip = "127.0.0.1"; // TODO: 初始化为适当的值

			int pvs = 1; // TODO: 初始化为适当的值

			int ips = 1; // TODO: 初始化为适当的值

			int cookies = 1; // TODO: 初始化为适当的值

			string area = string.Empty; // TODO: 初始化为适当的值

			string province = string.Empty; // TODO: 初始化为适当的值

			string city = string.Empty; // TODO: 初始化为适当的值

			int visits = 1; // TODO: 初始化为适当的值

			DateTime addTime = DateTime.Now; // TODO: 初始化为适当的值

			string referSite = "www.zj55.com"; // TODO: 初始化为适当的值

			string referUrl = "www.zj55.com/count"; // TODO: 初始化为适当的值

			string os = "win98"; // TODO: 初始化为适当的值

			string browser = "ie6"; // TODO: 初始化为适当的值

			string resolution = "800x600"; // TODO: 初始化为适当的值

			string respondents = "www.zj55.com/t"; // TODO: 初始化为适当的值

			target.Insert(id, ip, pvs, ips, cookies, area, province, city, visits, addTime, referSite, referUrl, os, browser, resolution, respondents);

			Assert.Inconclusive("无法验证不返回值的方法。");

		}

	}


}
