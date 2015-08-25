using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;

namespace ZhuJi.Library.Data
{
	/// <summary>
	/// 数据管理类
	/// </summary>
	public class DbManager
	{
		/// <summary>
		/// 绑定数据到实体
		/// </summary>
		/// <param name="reader">数据源</param>
		/// <param name="obj">实体</param>
		public static void BindIDataReaderToObject(IDataReader r, object o)
		{
			for (int i = 0; i < r.FieldCount; i++)
			{
				try
				{
					PropertyInfo propertyInfo = o.GetType().GetProperty(r.GetName(i));
					if (propertyInfo != null)
					{
						if (r.GetValue(i) != DBNull.Value)
						{
							if (propertyInfo.PropertyType.IsEnum)
							{
								propertyInfo.SetValue(o, Enum.ToObject(propertyInfo.PropertyType, r.GetValue(i)), null);
							}
							else
							{
								propertyInfo.SetValue(o, r.GetValue(i), null);
							}
						}
					}
				}
				catch
				{
				}
			}
		}
	}
}
