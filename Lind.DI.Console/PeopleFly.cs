using System;
using System.Collections.Generic;
using System.Text;
using Lind.Logger;

namespace Lind.DI.Console
{
    [Component(Named="ChinaPeople")]
    public class PeopleFly : IFly
    {
        [Injection]
        ILogger logger;

        [Injection(Named="RunChina")]
        IRun run;
        public void step1()
        {
            run.Do();
            logger.Info("飞机的元件也就这些了!"+DateTime.Now);
        }
    }
}