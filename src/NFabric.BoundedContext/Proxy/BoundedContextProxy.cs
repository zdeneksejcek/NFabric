using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NFabric.BoundedContext.Proxy
{
    public class BoundedContextProxy : MarshalByRefObject
    {
        private IBoundedContext Context { get; set; }

        public BoundedContextProxy(string bcAssembly) {
            AppDomainLoader loader = new AppDomainLoader(bcAssembly);
            Context = loader.Context;
        }

        public NFabric.Common.Messaging.UncommitedMessage[] ExecuteMessage(NFabric.Common.Messaging.Message message)
        {
            return Context.ExecuteMessage(message);
        }

        public string GetName() {
            return Context.GetName();
        }
    }
}