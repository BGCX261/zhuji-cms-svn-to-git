using System;
using ZhuJi.Library.Text;

namespace ZhuJi.UUMS.Domain
{
    /// <summary>
    /// 控件信息
    /// </summary>
    public class Controls
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
		
        private string _pageName;
        /// <summary>
        /// 页名称
        /// </summary>
        public virtual string PageName
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("页名称不能大于100字节！", value, value.ToString());
                }
                _pageName = value;
            }
            get { return _pageName; }
        }
		
        private string _controlName;
        /// <summary>
        /// 控件名称
        /// </summary>
        public virtual string ControlName
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("控件名称不能大于30字节！", value, value.ToString());
                }
                _controlName = value;
            }
            get { return _controlName; }
        }
		
        private int _controlType;
        /// <summary>
        /// 控件类型编号
        /// </summary>
        public virtual int ControlType
        {
			set
            {
                _controlType = value;
            }
            get { return _controlType; }
        }
		
        private int _attribute;
        /// <summary>
        /// 控件属性编号
        /// </summary>
        public virtual int Attribute
        {
			set
            {
                _attribute = value;
            }
            get { return _attribute; }
        }

        private int _resourcesId;
        /// <summary>
        /// 资源编号
        /// </summary>
        public virtual int ResourcesId
        {
            set
            {
                _resourcesId = value;
            }
            get { return _resourcesId; }
        }

        private ControlsType _controlsTypeInfo;
        /// <summary>
        /// 控件类型
        /// </summary>
        public virtual ControlsType ControlsTypeInfo
        {
            set
            {
                _controlsTypeInfo = value;
            }
            get { return _controlsTypeInfo; }
        }

        private ControlsAttribute _controlsAttributeInfo;
        /// <summary>
        /// 控件属性
        /// </summary>
        public virtual ControlsAttribute ControlsAttributeInfo
        {
            set
            {
                _controlsAttributeInfo = value;
            }
            get { return _controlsAttributeInfo; }
        }

        private Resources _resourcesInfo;
        /// <summary>
        /// 资源
        /// </summary>
        public virtual Resources ResourcesInfo
        {
            set
            {
                _resourcesInfo = value;
            }
            get { return _resourcesInfo; }
        }
		
    }
}


