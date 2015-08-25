using System;
using ZhuJi.Library.Text;

namespace ZhuJi.UUMS.Domain
{
    /// <summary>
    /// 方法信息
    /// </summary>
    public class Methods
    {
        private int _id;
        /// <summary>
        /// 标识
        /// </summary>
        public virtual int Id
        {
			set
            {
                _id = value;
            }
            get { return _id; }
        }
		
        private string _methodName;
        /// <summary>
        /// 方法名
        /// </summary>
        public virtual string MethodName
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("方法名不能大于50字节！", value, value.ToString());
                }
                _methodName = value;
            }
            get { return _methodName; }
        }
		
        private string _className;
        /// <summary>
        /// 类名
        /// </summary>
        public virtual string ClassName
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 250)
                {
                    throw new ArgumentOutOfRangeException("类名不能大于250字节！", value, value.ToString());
                }
                _className = value;
            }
            get { return _className; }
        }

        private int _explainId;
        /// <summary>
        /// 方法说明编号
        /// </summary>
        public virtual int ExplainId
        {
            set
            {
                _explainId = value;
            }
            get { return _explainId; }
        }

        private MethodExplain _explainInfo;
        /// <summary>
        /// 方法说明
        /// </summary>
        public virtual MethodExplain ExplainInfo
        {
            set
            {
                _explainInfo = value;
            }
            get { return _explainInfo; }
        }
		
    }
}


