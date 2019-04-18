using System;

namespace Lind.DI
{
    /// <summary>
    /// 注册组件特性.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentAttribute : Attribute
    {
        public ComponentAttribute(string named = null)
        {
            this.Named = named;
        }
        public LifeCycle LifeCycle { get; set; } = LifeCycle.CurrentScope;

        public string Named { get; set; }

        public Type Intercepted { get; set; }

        public InterceptType InterceptType { get; set; } = InterceptType.Interface;

        public bool IsInjectionClass { get; set; } = false;
    }
    public enum InterceptType
    {
        /// <summary>
        /// 类拦截
        /// </summary>
        Class,
        /// <summary>
        /// 接口拦截
        /// </summary>
        Interface,
    }
}