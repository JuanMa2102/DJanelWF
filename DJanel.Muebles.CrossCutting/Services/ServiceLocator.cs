using Autofac;
using System;

namespace DJanel.Muebles.CrossCutting.Services
{
    public class ServiceLocator
    {
        private IContainer Container { get; set; }
        private ContainerBuilder ContainerBuilder { get; set; }
        public static ServiceLocator Instance { get; } = new ServiceLocator();
        public ServiceLocator()
        {
            ContainerBuilder = new ContainerBuilder();
        }

        public static bool ContainerIsBuild { get { return Instance.Container != null; } }

        public T Resolve<T>() => Container.Resolve<T>();

        public void Build() => Container = ContainerBuilder.Build();

        public object Resolve(Type type) => Container.Resolve(type);

        public void Register<T>() where T : class => ContainerBuilder.RegisterType<T>();

        public void Register<TImplementation, TInterface>() where TImplementation : TInterface => ContainerBuilder.RegisterType<TImplementation>().As<TInterface>();
    }
}
