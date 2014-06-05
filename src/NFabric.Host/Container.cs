using System;
using System.Security.Policy;
using System.Collections.Generic;
using NFabric.Common.Messaging;

namespace NFabric.Host
{
    public class Container
    {
        private AppDomain Domain { get; set; }
        private object BCProxy { get; set; }

        public string Name { get; private set; }

        public Container(string bcAssembly, string nFabricBCAssembly)
        {
            Domain = AppDomainFactory.CreateDomain();

            LoadContext(bcAssembly, nFabricBCAssembly);
        }

        public void Unload() {
            AppDomain.Unload(Domain);
        }

        private void LoadContext(string bcAssembly, string nFabricBCAssembly) {
            BCProxy = Domain.CreateInstanceAndUnwrap(
                nFabricBCAssembly,
                "NFabric.BoundedContext.Proxy.BoundedContextProxy", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { bcAssembly }, null, null);

            Name = ExecuteMethod<string>("GetName");
        }

        private T ExecuteMethod<T>(string name, object[] parameters = null) where T: class {
            var method = BCProxy.GetType().GetMethod(name);
            var invokeResult = method.Invoke(BCProxy, parameters);

            return invokeResult as T;
        }

        public NFabric.Common.Messaging.UncommitedMessage[] Execute(Message message) {
            return ExecuteMethod<NFabric.Common.Messaging.UncommitedMessage[]>("ExecuteMessage", new object[] { message });
        }
    }
}