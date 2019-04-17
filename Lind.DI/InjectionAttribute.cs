using System;

namespace Lind.DI
{
    /// <summary>
    /// 注入一对象.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class InjectionAttribute : Attribute
    {
        public InjectionAttribute(string named=null)
        {
            this.Named=named;
        }
        public string Named{get;set;}
    }
}