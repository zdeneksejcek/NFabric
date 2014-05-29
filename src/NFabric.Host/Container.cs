using System;
using System.Security.Policy;
using System.Collections.Generic;

namespace NFabric.Host
{
    public class Container
    {
        private AppDomain Domain { get; set; }
        private object BCObject { get; set; }

        private IList<string> _events;
        public IList<string> ListenedEvents { get { return _events; } }

        public Container(string bcAssembly, string nFabricBCAssembly)
        {
            Domain = AppDomainFactory.CreateDomain(bcAssembly, nFabricBCAssembly);

            LoadContext(bcAssembly, nFabricBCAssembly);
        }

        private void LoadContext(string bcAssembly, string nFabricBCAssembly) {
            BCObject = Domain.CreateInstanceAndUnwrap(nFabricBCAssembly, "NFabric.BoundedContext.Proxy.AppDomainLoader", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { bcAssembly }, null, null);

            _events = ExecuteMethod<IList<string>>("GetEventNames");
        }

        private T ExecuteMethod<T>(string name, object[] parameters = null) where T: class {
            var method = BCObject.GetType().GetMethod(name);

            return method.Invoke(BCObject, parameters) as T;
        }

        public IList<object> ExecuteCommand(object obj) {
            return ExecuteMethod<IList<object>>("ExecuteCommand", new object[] { obj });
        }
    }
}

