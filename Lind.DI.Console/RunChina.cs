using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.DI.Console
{
    [Component(Named = "RunChina")]
    public class RunChina : IRun
    {
        public void Do()
        {
            System.Console.WriteLine("国产的发动机!");
        }
    }
}