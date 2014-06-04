using System;
using Autofac;
using System.Reflection;

namespace NFabric.BoundedContext
{
    public class ServiceActivator
    {
        Autofac.IContainer _container;

        public ServiceActivator(params Assembly[] assemblies)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(assemblies).InstancePerDependency();
            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType(typeof(Persistence.InMemoryEventStreamRepository)).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType(typeof(Persistence.InMemorySnapshotRepository)).AsImplementedInterfaces().InstancePerLifetimeScope();

            _container = builder.Build();
        }

        public void ExecuteHandleMethod(Type type, Type messageType, Action<Persistence.IEventStreamRepository> block) {
            using (var threadLifetime = _container.BeginLifetimeScope())
            {
                var service = _container.Resolve(type);
                var repository = _container.Resolve<Persistence.IEventStreamRepository>();
                
                var method = type.GetMethod("Handle", new Type[] {messageType});

                method.Invoke(service, new object[] { null });

                block(repository);
            }
        }

    }
}

