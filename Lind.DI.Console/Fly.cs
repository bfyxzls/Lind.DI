using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.DI.Console
{
    [Component]
    public class Fly
    {
        [Injection]
        Run run;
        public void step1()
        {
            run.Do();
            System.Console.WriteLine("飞行第一步!");
        }
    }
}