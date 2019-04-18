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
        protected string FormatStr(string level, string message, Exception ex)
        {
            var json = JsonConvert.SerializeObject(new
            {
                target_index = this.GetType().Name,
                timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff+0800"),
                Level = level.ToString(),
                Message = message,
                StackTrace = ex?.StackTrace
            });
            json = json.Replace("target_index", "@target_index").Replace("timestamp", "@timestamp");
            return json;
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
            Trace.WriteLine(message);
        }

        public virtual void Error(string message, Exception ex)
        {
            InputLogger(Level.ERROR, message + ex.ToString());
            Trace.WriteLine(message + ex.ToString());
        }

        public virtual void Fatal(string message)
        {
            InputLogger(Level.FATAL, message);
            Trace.WriteLine(message);
        }

        public virtual void Info(string message)
        {
            InputLogger(Level.INFO, message);
            Trace.WriteLine(message);
        }

        public virtual void Warn(string message)
        {
            InputLogger(Level.FATAL, message);
            Trace.WriteLine(message);
        }

        #endregion ILogger 成员
    }
}