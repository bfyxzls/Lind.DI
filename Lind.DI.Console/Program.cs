using System;

namespace Lind.DI.Console
{
    class Program
    {
        [Injection(Named="UsaPeople")]
        IFly flyObj;

        [Injection(Named = "ChinaPeople")]
        IFly flyObjChina;
        void print(){
            DIFactory.Init();//全局注册所有组件
            DIFactory.InjectFromObject(this);//拦截当前对象，并注入
            flyObj.step1();
            flyObjChina.step1();
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            new Program().print();
        }
    }
}
