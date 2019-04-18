using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.DI.Console
{
    [Component(Named="ChinaPeople")]
    public class PeopleFly : IFly
    {
        [Injection(Named="RunChina")]
        IRun run;
        public void step1()
        {
            run.Do();
            System.Console.WriteLine("飞机的元件也就这些了!"+DateTime.Now);
        }
    }
}