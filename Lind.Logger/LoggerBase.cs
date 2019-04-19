using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Lind.Logger
{
    /// <summary>
    /// 日志核心基类
    /// 模版方法模式，对InputLogger开放，对其它日志逻辑隐藏，InputLogger可以有多种实现
    /// </summary>
    public abstract class LoggerBase : ILogger
    {
        #region Protected Methods

        /// <summary>
        /// 格式化字符
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        protected string FormatStr(string level, string message)
        {
            string id = "[" + Thread.CurrentThread.ManagedThreadId + "]";
            return string.Format("{0} {1} {2} {3}"
            , DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff+0800")
            , level.PadLeft(5, ' ')
            , id.PadLeft(2, ' ')
            , message);
        }

        /// <summary>
        /// 日志持久化的方法，派生类必须要实现自己的方式
        /// </summary>
        /// <param name="message"></param>
        protected abstract void InputLogger(Level level, string message);

        #endregion Protected Methods

        #region ILogger 成员

        public virtual void Debug(string message)
        {
            InputLogger(Level.DEBUG, message);
        }

        public virtual void Error(string message, Exception ex)
        {
            InputLogger(Level.ERROR, message + ex.ToString());
        }

        public virtual void Fatal(string message)
        {
            InputLogger(Level.FATAL, message);
        }

        public virtual void Info(string message)
        {
            InputLogger(Level.INFO, message);
        }

        public virtual void Warn(string message)
        {
            InputLogger(Level.FATAL, message);
        }

        #endregion ILogger 成员
    }
}