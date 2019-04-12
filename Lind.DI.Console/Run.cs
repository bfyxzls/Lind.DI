using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.DI.Console
{
    [Component]
    public class Run
    {
        public void Do()
        {
            System.Console.WriteLine("跑起来!");
        }
    }
}