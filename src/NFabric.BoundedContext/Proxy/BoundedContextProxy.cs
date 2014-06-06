using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NFabric.BoundedContext.Persistence;

namespace NFabric.BoundedContext.Proxy
{
    public class BoundedContextProxy : MarshalByRefObject, IBoundedContext
    {
        private IBoundedContext Context { get; set; }

        public BoundedContextProxy(string bcAssembly, IEventsReader reader) {
            AppDomainLoader loader = new AppDomainLoader(bcAssembly, reader);
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