﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Lind.Caching
{
    /// <summary>
    /// 表示用于方法缓存功能的拦截行为。
    /// </summary>
    [Lind.DI.Component(IsInjectionClass = true)]
    public class CachingBehavior : IInterceptor
    {
        /// <summary>
        /// 缓存项目名称，每个项目有自己的名称
        /// 避免缓存键名重复
        /// </summary>
        static readonly string cacheProjectName = "LindDataSetCache";
        static readonly string splitStr = "_";

        /// <summary>
        /// 获取与某一特定参数值相关的键名。
        /// </summary>
        private string GetValueKey(CachingAttribute cachingAttribute, IInvocation input)
        {
            List<object> inputArguments = input.Arguments.ToList();

            List<ParameterInfo> parameters = input.Method.GetParameters().ToList();
            if (cachingAttribute.paramsCacheKey != null)
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    if (!cachingAttribute.paramsCacheKey.Contains(parameters[i].Name))
                    {
                        parameters.RemoveAt(i);
                        inputArguments.RemoveAt(i);
                    }
                }

            }
            if (inputArguments != null && inputArguments.Any())
            {
                var sb = new StringBuilder();
                for (int i = 0; i < inputArguments.Count; i++)
                {
                    if (input.Arguments[i] == null)
                        break;

                    if (input.Arguments[i].GetType().BaseType == typeof(LambdaExpression))//lambda处理
                    {
                        throw new ArgumentException("目前不支持lambda的参数");
                    }
                    else if (inputArguments[i].GetType() != typeof(string)//类和结构体处理
                             && inputArguments[i].GetType().IsClass)
                    {
                        var obj = input.Arguments[i];
                        Type t = obj.GetType();
                        var result = new StringBuilder();
                        #region 提取类中的字段
                        result.Append(parameters[i].Name).Append(splitStr);
                        foreach (var member in t.GetProperties())//公开属性
                        {
                            result.Append(member.Name)
                                  .Append(splitStr)
                                  .Append(t.GetProperty(member.Name).GetValue(obj, null))
                                  .Append(splitStr);
                        }
                        #endregion
                        sb.Append(result.ToString().Remove(result.Length - 1));
                    }
                    else//简单值类型处理
                    {
                        sb.Append(parameters[i].Name + splitStr + inputArguments[i].ToString());
                    }

                    if (i != inputArguments.Count - 1)
                        sb.Append(splitStr);
                }
                return sb.ToString();
            }
            else
                return "";
        }

        #region IInterceptionBehavior Members

        /// <summary>
        /// 通过实现此方法来拦截调用并执行所需的拦截行为.
        /// </summary>
        /// <param name="input">input.</param>
        public void Intercept(IInvocation input)
        {
            //注入拦截对象需要的组件（拦截对象与初始对象是两个不同的对象，所以在被拦截时，应该从新注入）
            Lind.DI.DIFactory.InjectFromObject(input.InvocationTarget);
            var method = input.Method;
            //键值前缀
            string key = cacheProjectName + splitStr + method.DeclaringType.Name + splitStr;

            if (method.IsDefined(typeof(CachingAttribute), false))
            {
                var cachingAttribute = (CachingAttribute)method.GetCustomAttributes(typeof(CachingAttribute), false)[0];
                key = key + cachingAttribute.value;
                string valKey = GetValueKey(cachingAttribute, input);
                switch (cachingAttribute.Method)
                {
                    case CachingMethod.Get:
                        if (CacheManager.Instance.Exists(key, valKey))
                        {
                            var obj = CacheManager.Instance.Get(key, valKey);
                            input.ReturnValue = obj;
                        }
                        else
                        {
                            input.Proceed();
                            CacheManager.Instance.Add(key, valKey, input.ReturnValue);
                        }
                        break;
                    case CachingMethod.Remove:
                        CacheManager.Instance.Remove(key, valKey);
                        break;

                }
            }

        }

        #endregion
    }
}
