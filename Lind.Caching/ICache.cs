﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lind.Caching
{
	/// <summary>
	/// 缓存所需要的方法
	/// </summary>
	public interface ICache
	{
		/// <summary>
		/// 数据加入缓存，并使用全局配置的过期时间
		/// </summary>
		/// <param name="key">键</param>
		/// <param name="obj">数据</param>
		void Put(string key, object obj);
		/// <summary>
		/// 拿出缓存数据
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		object Get(string key);
		/// <summary>
		/// 手动删除缓存数据
		/// </summary>
		/// <param name="key"></param>
		void Delete(string key);
		// <summary>
		/// 缓存是否存在
		/// </summary>
		/// <returns><c>true</c>, if exist was ised, <c>false</c> otherwise.</returns>
		/// <param name="key">Key.</param>/
		bool isExist(string key);
	}
}
