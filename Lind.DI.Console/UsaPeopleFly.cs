using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.DI.Console
{
    [Component(Named="UsaPeople")]
    public class UsaPeopleFly : IFly
    {
        [Injection(Named="RunUSA")]
        IRun run;
        public void step1()
        {
            run.Do();
            System.Console.WriteLine("aircraft constituent part. ");
        }
    }
}