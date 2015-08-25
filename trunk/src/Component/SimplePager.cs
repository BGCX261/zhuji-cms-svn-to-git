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
    /// ��ҳ�ؼ�
    /// </summary>
    [ParseChildren(true)]
    [ToolboxData("<{0}:SimplePager runat=server> </{0}:SimplePager>")]
    public class SimplePager : WebControl
    {


        private ITemplate _itemTemplate;
        /// <summary>
        /// ָ�����ģ��������ؼ�
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
        /// ҳ��
        /// </summary>
        public int PageSize
        {
            set { _pageSize = value; }
            get { return _pageSize; }
        }

        private int _currentPage = 1;
        /// <summary>
        /// ��ǰҳ
        /// </summary>
        public int CurrentPage
        {
            set { _currentPage = value; }
            get { return _currentPage; }
        }

        private int _recordCount;
        /// <summary>
        /// �ܼ�¼
        /// </summary>
        public int RecordCount
        {
            set { _recordCount = value; }
            get { return _recordCount; }
        }

        private string _pageUrl;
        /// <summary>
        /// ҳ��ַ
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
        /// ��������м�鲢����ģ��
        /// </summary>
        /// <param name="e">�����¼����ݵ���Ļ���</param>
        protected override void OnDataBinding(EventArgs e)
        {
            EnsureChildControls(); //ȷ���Ƿ�����ӿؼ�,���򴴽�
            base.OnDataBinding(e);
        }

        /// <summary>
        /// �����ӿؼ�
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
    /// ��ģ�������
    /// </summary>
    [ToolboxItem(false)]
    public class ContainerControl : WebControl, INamingContainer
    {
        #region ��ʼ�����ڲ�����

        private string _pageUrl;
        private const string URL_STRING = "<a href='{0}{1}'>{2}</a>";

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="pageSize">ҳ��</param>
        /// <param name="currentPage">��ǰҳ</param>
        /// <param name="recordCount">ҳ��¼</param>
        /// <param name="pageUrl">ҳ��ַ</param>
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
        /// ��ȡҳ�б���[1][2]...[10]
        /// </summary>
        /// <param name="count">ҳ�б���</param>
        /// <returns>����ҳ�б�</returns>
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
        /// ��ҳ
        /// </summary>
        public string FirstPage
        {
            set { _firstPage = value; }
            get { return _firstPage; }
        }

        /// <summary>
        /// ��һҳ
        /// </summary>
        public string PrevPage
        {
            set { _prevPage = value; }
            get { return _prevPage; }
        }

        /// <summary>
        /// ��һҳ
        /// </summary>
        public string NextPage
        {
            set { _nextPage = value; }
            get { return _nextPage; }
        }

        /// <summary>
        /// βҳ
        /// </summary>
        public string LastPage
        {
            set { _lastPage = value; }
            get { return _lastPage; }
        }

        /// <summary>
        /// ҳ�б�
        /// </summary>
        public string ListPages
        {
            set { _listPages = value; }
            get { return _listPages; }
        }

        /// <summary>
        /// ��ҳ��
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
        }

        /// <summary>
        /// ҳ��
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
        }

        /// <summary>
        /// ��ǰҳ
        /// </summary>
        public int CurrentPage
        {
            get { return _currentPage; }
        }

        /// <summary>
        /// �ܼ�¼
        /// </summary>
        public int RecordCount
        {
            get { return _recordCount; }
        }

        /// <summary>
        /// ��ʾҳ
        /// </summary>
        public void ShowPage()
        {
            _pageCount = _recordCount/_pageSize + OverPage();

            if (_currentPage > 1)
            {
                _firstPage = string.Format(CultureInfo.InvariantCulture, URL_STRING, _pageUrl, 1, "��ҳ");
                _prevPage = string.Format(CultureInfo.InvariantCulture, URL_STRING, _pageUrl, _currentPage - 1, "��һҳ");
            }
            else
            {
                _firstPage = "��ҳ";
                _prevPage = "��һҳ";
            }

            if (_currentPage < _pageCount)
            {
                _nextPage = string.Format(CultureInfo.InvariantCulture, URL_STRING, _pageUrl, _currentPage + 1, "��һҳ");
                _lastPage = string.Format(CultureInfo.InvariantCulture, URL_STRING, _pageUrl, _pageCount, "βҳ");
            }
            else
            {
                _nextPage = "��һҳ";
                _lastPage = "βҳ";
            }

            _listPages = GetListPages(10);
        }
    }
}