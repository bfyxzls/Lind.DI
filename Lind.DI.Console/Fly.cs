using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.DI.Console
{
    [Component]
    public class Fly
    {
        public void step1()
        {
            System.Console.WriteLine("飞行第一步!");
        }
    }
}
