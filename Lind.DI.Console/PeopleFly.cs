using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.DI.Console
{
    [Component]
    public class PeopleFly : IFly
    {
        [Injection(Named="RunPeople")]
        IRun run;
        public void step1()
        {
            run.Do();
            System.Console.WriteLine("飞行第一步!");
        }
    }
}