using System;
using System.Collections.Generic;
using System.Text;
using Lind.Logger;

namespace Lind.DI.Console
{
    [Component(Named = "RunChina")]
    public class RunChina : IRun
    {
        [Injection]
        ILogger logger;
        public void Do()
        {
            logger.Info("国产的发动机!");
        }
    }
}