using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.AdsModule.Domain
{
    /// <summary>
	/// 广告版位
    /// </summary>
    public class AdsLocation
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
		
        private string _name;
        /// <summary>
		/// 版位名称
        /// </summary>
        public virtual string Name
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
					throw new ArgumentOutOfRangeException("版位名称不能大于50字节！", value, value.ToString());
                }
                _name = value;
            }
            get { return _name; }
        }
		
        private int _type;
        /// <summary>
		/// 版位类型
        /// </summary>
        public virtual int Type
        {
			set
            {
                _type = value;
            }
            get { return _type; }
        }
		
        private int _width;
        /// <summary>
		/// 版位宽
        /// </summary>
        public virtual int Width
        {
			set
            {
                _width = value;
            }
            get { return _width; }
        }
		
        private int _height;
        /// <summary>
		/// 版位高
        /// </summary>
        public virtual int Height
        {
			set
            {
                _height = value;
            }
            get { return _height; }
        }
		
        private bool _ispass;
        /// <summary>
		/// 版位状态
        /// </summary>
        public virtual bool Ispass
        {
			set
            {
                _ispass = value;
            }
            get { return _ispass; }
        }

		private AdsLocationType _adsLocationTypeInfo;
		/// <summary>
		/// 版位类型
		/// </summary>
		public virtual AdsLocationType AdsLocationTypeInfo
		{
			set
			{
				_adsLocationTypeInfo = value;
			}
			get { return _adsLocationTypeInfo; }
		}
    }
}


