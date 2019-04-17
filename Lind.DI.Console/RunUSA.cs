using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.DI.Console
{
    [Component(Named = "RunUSA")]
    public class RunUSA : IRun
    {
        public void Do()
        {
            System.Console.WriteLine("美国产的发动机!");
        }
    }
}