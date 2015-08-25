using System;
using ZhuJi.Library.Text;
using ZhuJi.Modules.SinglePageModule.Domain;
using ZhuJi.Modules.ArticleModule.Domain;

namespace ZhuJi.Modules.Core.Domain
{
    /// <summary>
    /// ��������
    /// </summary>
    public class ContentBase
    {
        private int _id;
        /// <summary>
        /// �������ݱ�ʶ
        /// </summary>
        public virtual int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        private int _channelId;
        /// <summary>
        /// ��վ��Ŀ��ʶ
        /// </summary>
        public virtual int ChannelId
        {
            set { _channelId = value; }
            get { return _channelId; }
        }

        private int _skinId;
        /// <summary>
        /// Ƥ����ʶ
        /// </summary>
        public virtual int SkinId
        {
            set { _skinId = value; }
            get { return _skinId; }
        }

        private int _hits;
        /// <summary>
        /// �����
        /// </summary>
        public virtual int Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }

        private int _comments;
        /// <summary>
        /// ������
        /// </summary>
        public virtual int Comments
        {
            set { _comments = value; }
            get { return _comments; }
        }

        private int _recommends;
        /// <summary>
        /// �Ƽ���
        /// </summary>
        public virtual int Recommends
        {
            set { _recommends = value; }
            get { return _recommends; }
        }

        private string _keyword;
        /// <summary>
        /// �ؼ���
        /// </summary>
        public virtual string Keyword
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("�ؼ��ֲ��ܴ���100�ֽڣ�", value, value.ToString());
                }
                _keyword = value;
            }
            get { return _keyword; }
        }

        private int _collections;
        /// <summary>
        /// �ղ���
        /// </summary>
        public virtual int Collections
        {
            set { _collections = value; }
            get { return _collections; }
        }

        private int _votes;
        /// <summary>
        /// ������
        /// </summary>
        public virtual int Votes
        {
            set { _votes = value; }
            get { return _votes; }
        }

        private string _picture;
        /// <summary>
        /// ��ҳͼƬ
        /// </summary>
        public virtual string Picture
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("��ҳͼƬ���ܴ���100�ֽڣ�", value, value.ToString());
                }
                _picture = value;
            }
            get { return _picture; }
        }

        private bool _passed;
        /// <summary>
        /// ͨ����֤
        /// </summary>
        public virtual bool Passed
        {
            set { _passed = value; }
            get { return _passed; }
        }

        private string _createdByUser;
        /// <summary>
        /// �ύ�û�
        /// </summary>
        public virtual string CreatedByUser
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("�ύ�û����ܴ���30�ֽڣ�", value, value.ToString());
                }
                _createdByUser = value;
            }
            get { return _createdByUser; }
        }

        private string _createdByIp;
        /// <summary>
        /// �ύIP
        /// </summary>
        public virtual string CreatedByIp
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 15)
                {
                    throw new ArgumentOutOfRangeException("�ύIP���ܴ���15�ֽڣ�", value, value.ToString());
                }
                _createdByIp = value;
            }
            get { return _createdByIp; }
        }

        private DateTime _createdByDate;
        /// <summary>
        /// �ύʱ��
        /// </summary>
        public virtual DateTime CreatedByDate
        {
            set { _createdByDate = value; }
            get { return _createdByDate; }
        }

        private SinglePage _singlePageInto;
        /// <summary>
        /// ��ҳ
        /// </summary>
        public virtual SinglePage SinglePageInfo
        {
            set { _singlePageInto = value; }
            get { return _singlePageInto; }
        }

        private Article _articleInto;
        /// <summary>
        /// ����
        /// </summary>
        public virtual Article ArticleInfo
        {
            set { _articleInto = value; }
            get { return _articleInto; }
        }

    }
}