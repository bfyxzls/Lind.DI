using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.Logger
{
    /// <summary>
    /// 日志级别
    /// </summary>
    public enum Level
    {
        /// <summary>
        /// 所有日志，记录DEBUG|INFO|WARN|ERROR|FATAL级别的日志
        /// </summary>
        DEBUG,

        /// <summary>
        /// 记录INFO|WARN|ERROR|FATAL级别的日志
        /// </summary>
        INFO,

        /// <summary>
        /// 记录WARN|ERROR|FATAL级别的日志
        /// </summary>
        WARN,

        /// <summary>
        /// 记录ERROR|FATAL级别的日志
        /// </summary>
        ERROR,

        /// <summary>
        /// 记录FATAL级别的日志
        /// </summary>
        FATAL,

        /// <summary>
        /// 关闭日志功能
        /// </summary>
        OFF,
    }
}
