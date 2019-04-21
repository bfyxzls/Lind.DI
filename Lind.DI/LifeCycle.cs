using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.DI
{
    /// <summary>
    /// 组件生命周期
    /// </summary>
    public enum LifeCycle
    {
        /// <summary>
        /// 瞬息对象，使用完就释放
        /// </summary>
        CurrentScope,
        /// <summary>
        /// 当前请求单例对像，当前http请求结束后，自动释放
        /// </summary>
        CurrentRequest,
        /// <summary>
        /// 全局的单例对象，当应用程序重新启动时，自动创建，应用程序进程销毁后，它自动释放
        /// </summary>
        Global,
    }
}
