using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using NFabric.BoundedContext.Persistence;

namespace NFabric.BoundedContext.Proxy
{
    public class AppDomainLoader
    {
        public IBoundedContext Context { get; private set; }

        public AppDomainLoader(object assemblyName, IEventsReader reader) {
            var assembly = Assembly.Load((string)assemblyName);

            this.Context = new AutoBoundedContext(assembly, reader);

            //InitializeAppDomain(assembly);

            System.Console.WriteLine("AppDomain loaded: "+assembly.FullName);
        }

        private void InitializeAppDomain(Assembly assembly) {
            var interf = typeof(IBoundedContext);
            var bcObjType = assembly.GetTypes().FirstOrDefault(p => interf.IsAssignableFrom(p));
            if (bcObjType != null)
            {
                    Context = Activator.CreateInstance(bcObjType) as IBoundedContext;

                    System.Console.WriteLine("Bounded Context: " + Context.GetName());
            }
        }
    }
}