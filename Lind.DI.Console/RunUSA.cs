using System;
using System.Collections.Generic;
using System.Text;
using Lind.Logger;

namespace Lind.DI.Console
{
    [Component(Named = "RunUSA")]
    public class RunUSA : IRun
    {
        [Injection]
        ILogger logger;

        public void Do()
        {
            logger.Info("美国产的发动机!");
        }
    }
}