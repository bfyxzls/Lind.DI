using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lind.Caching
{
	/// <summary>
	/// 运行时缓存，基于服务端内存存储
	/// </summary>
	public class RuntimeCache : ICache
	{
		readonly static Dictionary<String, Object> httpRuntimeCache = new Dictionary<String, Object>();

		#region ICache 成员

		public void Put(string key, object obj)
		{
			httpRuntimeCache.Add(key, obj);
		}

		public object Get(string key)
		{
			return httpRuntimeCache[key];
		}

		public void Delete(string key)
		{
			httpRuntimeCache.Remove(key);
		}
		public bool isExist(string key)
		{
			return httpRuntimeCache.ContainsKey(key);
		}
		#endregion
	}
}
