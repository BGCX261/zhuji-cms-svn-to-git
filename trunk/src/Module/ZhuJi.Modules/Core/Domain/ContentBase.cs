using System;
using ZhuJi.Library.Text;
using ZhuJi.Modules.SinglePageModule.Domain;
using ZhuJi.Modules.ArticleModule.Domain;

namespace ZhuJi.Modules.Core.Domain
{
    /// <summary>
    /// 基本内容
    /// </summary>
    public class ContentBase
    {
        private int _id;
        /// <summary>
        /// 基本内容标识
        /// </summary>
        public virtual int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        private int _channelId;
        /// <summary>
        /// 网站栏目标识
        /// </summary>
        public virtual int ChannelId
        {
            set { _channelId = value; }
            get { return _channelId; }
        }

        private int _skinId;
        /// <summary>
        /// 皮肤标识
        /// </summary>
        public virtual int SkinId
        {
            set { _skinId = value; }
            get { return _skinId; }
        }

        private int _hits;
        /// <summary>
        /// 点击数
        /// </summary>
        public virtual int Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }

        private int _comments;
        /// <summary>
        /// 评论数
        /// </summary>
        public virtual int Comments
        {
            set { _comments = value; }
            get { return _comments; }
        }

        private int _recommends;
        /// <summary>
        /// 推荐数
        /// </summary>
        public virtual int Recommends
        {
            set { _recommends = value; }
            get { return _recommends; }
        }

        private string _keyword;
        /// <summary>
        /// 关键字
        /// </summary>
        public virtual string Keyword
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("关键字不能大于100字节！", value, value.ToString());
                }
                _keyword = value;
            }
            get { return _keyword; }
        }

        private int _collections;
        /// <summary>
        /// 收藏数
        /// </summary>
        public virtual int Collections
        {
            set { _collections = value; }
            get { return _collections; }
        }

        private int _votes;
        /// <summary>
        /// 评论数
        /// </summary>
        public virtual int Votes
        {
            set { _votes = value; }
            get { return _votes; }
        }

        private string _picture;
        /// <summary>
        /// 首页图片
        /// </summary>
        public virtual string Picture
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("首页图片不能大于100字节！", value, value.ToString());
                }
                _picture = value;
            }
            get { return _picture; }
        }

        private bool _passed;
        /// <summary>
        /// 通过验证
        /// </summary>
        public virtual bool Passed
        {
            set { _passed = value; }
            get { return _passed; }
        }

        private string _createdByUser;
        /// <summary>
        /// 提交用户
        /// </summary>
        public virtual string CreatedByUser
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("提交用户不能大于30字节！", value, value.ToString());
                }
                _createdByUser = value;
            }
            get { return _createdByUser; }
        }

        private string _createdByIp;
        /// <summary>
        /// 提交IP
        /// </summary>
        public virtual string CreatedByIp
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 15)
                {
                    throw new ArgumentOutOfRangeException("提交IP不能大于15字节！", value, value.ToString());
                }
                _createdByIp = value;
            }
            get { return _createdByIp; }
        }

        private DateTime _createdByDate;
        /// <summary>
        /// 提交时间
        /// </summary>
        public virtual DateTime CreatedByDate
        {
            set { _createdByDate = value; }
            get { return _createdByDate; }
        }

        private SinglePage _singlePageInto;
        /// <summary>
        /// 单页
        /// </summary>
        public virtual SinglePage SinglePageInfo
        {
            set { _singlePageInto = value; }
            get { return _singlePageInto; }
        }

        private Article _articleInto;
        /// <summary>
        /// 文章
        /// </summary>
        public virtual Article ArticleInfo
        {
            set { _articleInto = value; }
            get { return _articleInto; }
        }

    }
}