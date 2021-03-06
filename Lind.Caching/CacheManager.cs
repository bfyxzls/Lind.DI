﻿using System;

namespace Lind.Caching
{
	/// <summary>
	/// 缓存持久化工厂类
	/// 可以由多种持久化的策略
	/// 策略模式和工厂模式的体现
	/// </summary>
	public sealed class CacheManager
	{
		#region Private Fields
		private readonly ICache _cacheProvider;
		private static readonly CacheManager _instance;
		#endregion

		#region Ctor
		static CacheManager() { _instance = new CacheManager(); }

		/// <summary>
		/// 对外不能创建类的实例
		/// </summary>
		private CacheManager()
		{
			_cacheProvider = new RuntimeCache();

		}
		#endregion

		#region Public Properties
		/// <summary>
		/// 获取<c>CacheManager</c>类型的单件（Singleton）实例。
		/// </summary>
		public static CacheManager Instance
		{
			get { return _instance; }
		}
		#endregion

		#region ICacheProvider Members
		/// <summary>
		/// 向缓存中添加一个对象。
		/// </summary>
		/// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
		/// <param name="valKey">缓存值的键值，该值通常是由使用缓存机制的方法的参数值所产生。</param>
		/// <param name="value">需要缓存的对象。</param>
		public void Add(string key, string valKey, object value)
		{
			_cacheProvider.Put(key + ":" + valKey, value);
		}
		/// <summary>
		/// 向缓存中更新一个对象。
		/// </summary>
		/// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
		/// <param name="valKey">缓存值的键值，该值通常是由使用缓存机制的方法的参数值所产生。</param>
		/// <param name="value">需要缓存的对象。</param>
		public void Put(string key, string valKey, object value)
		{
			_cacheProvider.Put(key + ":" + valKey, value);
		}
		/// <summary>
		/// 从缓存中读取对象。
		/// </summary>
		/// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
		/// <param name="valKey">缓存值的键值，该值通常是由使用缓存机制的方法的参数值所产生。</param>
		/// <returns>被缓存的对象。</returns>
		public object Get(string key, string valKey)
		{
			return _cacheProvider.Get(key + ":" + valKey);
		}
		/// <summary>
		/// 从缓存中移除对象。
		/// </summary>
		/// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
		public void Remove(string key)
		{
			_cacheProvider.Delete(key);
		}
		/// <summary>
		/// 从缓存中移除对象。
		/// </summary>
		/// <param name="key">缓存的键值，该值通常是使用缓存机制的方法的名称。</param>
		public void Remove(string key, string valKey)
		{
			_cacheProvider.Delete(key + ":" + valKey);
		}
		/// <summary>
		/// 获取一个<see cref="Boolean"/>值，该值表示拥有指定键值的缓存是否存在。
		/// </summary>
		/// <param name="key">指定的键值。</param>
		/// <returns>如果缓存存在，则返回true，否则返回false。</returns>
		public bool Exists(string key)
		{
			return _cacheProvider.isExist(key);
		}
		/// <summary>
		/// 获取一个<see cref="Boolean"/>值，该值表示拥有指定键值和缓存值键的缓存是否存在。
		/// </summary>
		/// <param name="key">指定的键值。</param>
		/// <param name="valKey">缓存值键。</param>
		/// <returns>如果缓存存在，则返回true，否则返回false。</returns>
		public bool Exists(string key, string valKey)
		{
			return _cacheProvider.isExist(key + ":" + valKey);
		}


		#endregion
	}
}
