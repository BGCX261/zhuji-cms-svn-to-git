using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly : CLSCompliant(true)]

namespace ZhuJi.Component
{
    /// <summary>
    /// 分页控件
    /// </summary>
    [ParseChildren(true)]
    [ToolboxData("<{0}:SimplePager runat=server> </{0}:SimplePager>")]
    public class SimplePager : WebControl
    {


        private ITemplate _itemTemplate;
        /// <summary>
        /// 指定存放模板的容器控件
        /// </summary>
        [TemplateContainer(typeof (ContainerControl))]
        [Browsable(false)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public virtual ITemplate ItemTemplate
        {
            get { return _itemTemplate; }
            set { _itemTemplate = value; }
        }

        private int _pageSize = 10;
        /// <summary>
        /// 页长
        /// </summary>
        public int PageSize
        {
            set { _pageSize = value; }
            get { return _pageSize; }
        }

        private int _currentPage = 1;
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            set { _currentPage = value; }
            get { return _currentPage; }
        }

        private int _recordCount;
        /// <summary>
        /// 总记录
        /// </summary>
        public int RecordCount
        {
            set { _recordCount = value; }
            get { return _recordCount; }
        }

        private string _pageUrl;
        /// <summary>
        /// 页地址
        /// </summary>
        public string PageUrl
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                Regex r = new Regex(@"PageNo=");
                Match m = r.Match(value);
                if (m.Success)
                {
                    _pageUrl = value.Substring(0, m.Index + 7);
                }
                else
                {
                    if (Regex.IsMatch(value, @"\?"))
                    {
                        _pageUrl = string.Concat(value, "&PageNo=");
                    }
                    else
                    {
                        _pageUrl = string.Concat(value, "?PageNo=");
                    }
                }
            }
            get { return _pageUrl; }
        }

        /// <summary>
        /// 在这里进行检查并创建模板
        /// </summary>
        /// <param name="e">包含事件数据的类的基类</param>
        protected override void OnDataBinding(EventArgs e)
        {
            EnsureChildControls(); //确定是否包含子控件,否则创建
            base.OnDataBinding(e);
        }

        /// <summary>
        /// 创建子控件
        /// </summary>
        protected override void CreateChildControls()
        {
            if (_itemTemplate != null)
            {
                ContainerControl cc = new ContainerControl(_pageSize, _currentPage, _recordCount, _pageUrl);
                cc.ShowPage();
                _itemTemplate.InstantiateIn(cc);
                Controls.Add(cc);
            }
            else
            {
                Controls.Add(new LiteralControl(" NO TEMPLATE"));
                base.CreateChildControls();
            }
        }
    }

    /// <summary>
    /// 放模板的容器
    /// </summary>
    [ToolboxItem(false)]
    public class ContainerControl : WebControl, INamingContainer
    {
        #region 初始化及内部方法

        private string _pageUrl;
        private const string URL_STRING = "<a href='{0}{1}'>{2}</a>";

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="pageSize">页长</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="recordCount">页记录</param>
        /// <param name="pageUrl">页地址</param>
        public ContainerControl(int pageSize, int currentPage, int recordCount, string pageUrl)
        {
            _pageSize = pageSize;
            _currentPage = currentPage;
            _recordCount = recordCount;
            _pageUrl = pageUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int OverPage()
        {
            int pages;
            if (_recordCount%_pageSize != 0)
                pages = 1;
            else
                pages = 0;
            return pages;
        }

        /// <summary>
        /// 获取页列表如[1][2]...[10]
        /// </summary>
        /// <param name="count">页列表长度</param>
        /// <returns>返回页列表</returns>
        private string GetListPages(int count)
        {
            StringBuilder rets = new StringBuilder();
            int j = _currentPage - count/2;
            if (j < count/2)
            {
                j = 0;
            }
            for (int i = 1; i <= count; i++)
            {
                int currentPage = i + j;
                if (currentPage <= _pageCount)
                {
                    if (_currentPage == currentPage)
                    {
                        rets.AppendFormat(string.Format(CultureInfo.InvariantCulture, "[{0}]", currentPage));
                    }
                    else
                    {
                        rets.AppendFormat(URL_STRING, _pageUrl, currentPage,
                                          string.Format(CultureInfo.InvariantCulture, "[{0}]", currentPage));
                    }
                }
                else
                {
                    break;
                }
            }
            return rets.ToString();
        }

        #endregion

        private int _currentPage;
        private string _firstPage;
        private string _lastPage;
        private string _listPages;
        private string _nextPage;
        private int _pageCount;
        private int _pageSize;

        private string _prevPage;
        private int _recordCount;

        /// <summary>
        /// 首页
        /// </summary>
        public string FirstPage
        {
            set { _firstPage = value; }
            get { return _firstPage; }
        }

        /// <summary>
        /// 上一页
        /// </summary>
        public string PrevPage
        {
            set { _prevPage = value; }
            get { return _prevPage; }
        }

        /// <summary>
        /// 下一页
        /// </summary>
        public string NextPage
        {
            set { _nextPage = value; }
            get { return _nextPage; }
        }

        /// <summary>
        /// 尾页
        /// </summary>
        public string LastPage
        {
            set { _lastPage = value; }
            get { return _lastPage; }
        }

        /// <summary>
        /// 页列表
        /// </summary>
        public string ListPages
        {
            set { _listPages = value; }
            get { return _listPages; }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
        }

        /// <summary>
        /// 页长
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            get { return _currentPage; }
        }

        /// <summary>
        /// 总记录
        /// </summary>
        public int RecordCount
        {
            get { return _recordCount; }
        }

        /// <summary>
        /// 显示页
        /// </summary>
        public void ShowPage()
        {
            _pageCount = _recordCount/_pageSize + OverPage();

            if (_currentPage > 1)
            {
                _firstPage = string.Format(CultureInfo.InvariantCulture, URL_STRING, _pageUrl, 1, "首页");
                _prevPage = string.Format(CultureInfo.InvariantCulture, URL_STRING, _pageUrl, _currentPage - 1, "上一页");
            }
            else
            {
                _firstPage = "首页";
                _prevPage = "上一页";
            }

            if (_currentPage < _pageCount)
            {
                _nextPage = string.Format(CultureInfo.InvariantCulture, URL_STRING, _pageUrl, _currentPage + 1, "下一页");
                _lastPage = string.Format(CultureInfo.InvariantCulture, URL_STRING, _pageUrl, _pageCount, "尾页");
            }
            else
            {
                _nextPage = "下一页";
                _lastPage = "尾页";
            }

            _listPages = GetListPages(10);
        }
    }
}