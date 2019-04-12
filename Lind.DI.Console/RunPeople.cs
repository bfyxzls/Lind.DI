using System;
using System.Collections.Generic;
using System.Text;

namespace Lind.DI.Console
{
    [Component(Named="RunPeople")]
    public class RunPeople : IRun
    {
        public void Do()
        {
            System.Console.WriteLine("人类跑起来!");
        }
    }
}