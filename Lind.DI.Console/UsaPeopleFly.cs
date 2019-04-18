using System;
using System.Collections.Generic;
using System.Text;
using Lind.Caching;

namespace Lind.DI.Console
{
    /**
     * 美国发动机，使用了缓存. 
     */
    [Component(Named="UsaPeople",Intercepted=typeof(CachingBehavior))]
    public class UsaPeopleFly : IFly
    {
        [Injection(Named="RunUSA")]
        IRun run;
        public void step1()
        {
            run.Do();
            System.Console.WriteLine("aircraft constituent part. "+DateTime.Now);
        }
    }
}