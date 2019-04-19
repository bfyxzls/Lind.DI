using Lind.DI;
using System;

namespace Lind.Logger
{
    /// <summary>
    /// 控制台日志
    /// </summary>
    [Component]
    public class ConsoleLogger : LoggerBase
    {
        protected override void InputLogger(Level level, string message)
        {
            System.Console.WriteLine( FormatStr(level.ToString(),message));
        }
    }
}