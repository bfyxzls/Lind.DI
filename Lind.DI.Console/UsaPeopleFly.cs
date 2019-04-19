using System;
using System.Collections.Generic;
using System.Text;
using Lind.Caching;
using Lind.Logger;

namespace Lind.DI.Console
{
    /**
     * 美国发动机，使用了缓存. 
     */
    [Component(Named="UsaPeople",Intercepted=typeof(CachingBehavior))]
    public class UsaPeopleFly : IFly
    {
        [Injection]
        ILogger logger;
        
        [Injection(Named="RunUSA")]
        IRun run;
        public void step1()
        {
            run.Do();
            logger.Info("aircraft constituent part. "+DateTime.Now);
        }
    }
}