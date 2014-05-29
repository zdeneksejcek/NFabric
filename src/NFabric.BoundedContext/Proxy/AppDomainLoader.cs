using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace NFabric.BoundedContext.Proxy
{
    public class AppDomainLoader : MarshalByRefObject
    {
        private IBoundedContext Context { get; set; }

        public IList<string> GetEventNames() {
            return Context.ListensToEventsProvider.GetEvents().ToList();
        }

        public IList<object> ExecuteCommand(object command) {
            return Context.ExecuteCommand(command);
        }

        public AppDomainLoader(object assemblyName) {
            var assembly = Assembly.Load((string)assemblyName);
            InitializeAppDomain(assembly);

            System.Console.WriteLine("AppDomain loaded: "+assembly.FullName);
        }

        public void InitializeAppDomain(Assembly assembly) {
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