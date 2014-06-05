using System;
using Autofac;
using System.Reflection;
using NFabric.BoundedContext.Persistence;

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

            builder.RegisterType(typeof(Persistence.InMemoryEventStreamRepository)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(Persistence.InMemorySnapshotRepository)).InstancePerLifetimeScope();

            _container = builder.Build();
        }

        public void ExecuteHandleMethod(Type type, Type messageType, object deserializedMessage, Action<Persistence.InMemoryEventStreamRepository> block) {
            using (var threadLifetime = _container.BeginLifetimeScope())
            {
                var service = threadLifetime.Resolve(type);
                var repository = threadLifetime.Resolve<Persistence.InMemoryEventStreamRepository>();
                
                var method = type.GetMethod("Handle", new Type[] {messageType});

                method.Invoke(service, new object[] { deserializedMessage });

                block(repository);
            }
        }
    }
}

