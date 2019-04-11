using Autofac;
using System;
using System.Linq;

namespace Lind.DI
{
    public class DIFactory
    {

        static IContainer container;
        public static T Resolve<T>()
        {
            if (container == null)
                throw new ArgumentException("please run DIFactory.Init().");
            return container.Resolve<T>();
        }
        public static void Init()
        {
            var builder = new ContainerBuilder();
            var arr = AppDomain.CurrentDomain.GetAssemblies().Where(
                 x => !x.FullName.StartsWith("Dapper")
                 && !x.FullName.StartsWith("System")
                 && !x.FullName.StartsWith("AspNet")
                 && !x.FullName.StartsWith("Microsoft"))
                 .SelectMany(x => x.DefinedTypes)
                 .Where(i => i.IsPublic && i.IsClass)
                 .ToList();
            foreach (var type in arr)
            {
                try
                {
                    if (type.GetCustomAttributes(false).Select(i => i.GetType()).Contains(typeof(ComponentAttribute)))
                    {
                        ComponentAttribute componentAttribute = (ComponentAttribute)type.GetCustomAttributes(false).FirstOrDefault(o => o.GetType() == typeof(ComponentAttribute));

                        if (type.GetInterfaces() != null && type.GetInterfaces().Any())
                        {
                            type.GetInterfaces().ToList().ForEach(o =>
                            {
                                registor(builder, type, o, componentAttribute);

                            });
                        }
                        else
                        {
                            registor(builder, type, type, componentAttribute);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception($"Lind.DI init {type.Name} error.");
                }
            }
            var container = builder.Build();
        }
        static void registor(ContainerBuilder builder, Type typeImpl, Type type, ComponentAttribute componentAttribute)
        {
            if (componentAttribute.LifeCycle == LifeCycle.Global)
            {
                if (componentAttribute.Named != null)
                    builder.RegisterType(typeImpl).Named(componentAttribute.Named, type).SingleInstance();
                else
                    builder.RegisterType(typeImpl).As(type).SingleInstance();
            }
            else if (componentAttribute.LifeCycle == LifeCycle.CurrentScope)
            {
                if (componentAttribute.Named != null)
                    builder.RegisterType(typeImpl).Named(componentAttribute.Named, type).InstancePerLifetimeScope();
                else
                    builder.RegisterType(typeImpl).As(type).InstancePerLifetimeScope();
            }
            else
            {
                if (componentAttribute.Named != null)
                    builder.RegisterType(typeImpl).Named(componentAttribute.Named, type).InstancePerRequest();
                else
                    builder.RegisterType(typeImpl).As(type).InstancePerRequest();
            }
        }
    }
}
