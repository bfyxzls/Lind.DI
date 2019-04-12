using System;

namespace Lind.DI.Console
{
    class Program
    {
        [Injection]
        Fly flyObj;
        void print(){
            DIFactory.Init();
            DIFactory.InjectFromObject(this);
            flyObj.step1();
        }
        static void Main(string[] args)
        {
            DIFactory.Init();
            System.Console.WriteLine("Hello World!");
            new Program().print();
        }
    }
}
