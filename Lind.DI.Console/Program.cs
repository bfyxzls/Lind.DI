using System;

namespace Lind.DI.Console
{
    class Program
    {
        [Injection]
        IFly flyObj;
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
