using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Proxy
{
    public class AppDomainLoader
    {
        public IBoundedContext Context { get; private set; }

        public AppDomainLoader(object assemblyName) {
            var assembly = Assembly.Load((string)assemblyName);

            InitializeAppDomain(assembly);

            System.Console.WriteLine("AppDomain loaded: "+assembly.FullName);
        }

        private void InitializeAppDomain(Assembly assembly) {
            var interf = typeof(IBoundedContext);
            var bcObjType = assembly.GetTypes().FirstOrDefault(p => interf.IsAssignableFrom(p));
            if (bcObjType != null)
            {
                    Context = Activator.CreateInstance(bcObjType) as IBoundedContext;

                    System.Console.WriteLine("Bounded Context: " + Context.Name);
            }
        }
    }
}