using System;

namespace Lind.DI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DIFactory.Init();
            Fly fly = DIFactory.Resolve<Fly>();
            fly.step1();
            System.Console.WriteLine("Hello World!");
            System.Console.ReadKey();
        }
    }
}
