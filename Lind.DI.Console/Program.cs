using Lind.Logger;
using System;
using System.Threading;

namespace Lind.DI.Console
{
    class Program
    {
        [Injection]
        ILogger logger;

        [Injection(Named = "UsaPeople")]
        IFly flyObj;

        [Injection(Named = "ChinaPeople")]
        IFly flyObjChina;

        void print()
        {
            DIFactory.Init();//全局注册所有组件
            DIFactory.InjectFromObject(this);//拦截当前对象，并注入
            logger.Info("ioc组件化和缓存拦截器");
            logger.Debug("logger is start.");
            flyObj.step1();
            flyObjChina.step1();
        }
        static void Main(string[] args)
        {
            var program = new Program();
            program.print();
            Thread.Sleep(1000);
            program.print();

        }
    }
}
