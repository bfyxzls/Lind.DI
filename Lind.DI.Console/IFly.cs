using Lind.Caching;

namespace Lind.DI.Console
{
    public interface IFly
    {
        [Caching(CachingMethod.Get)]
        void step1();
    }
}