using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NFabric.BoundedContext.Proxy
{
    public class BoundedContextProxy : MarshalByRefObject, IBoundedContextProxy
    {
        private IBoundedContext Context { get; set; }

        public BoundedContextProxy(string bcAssembly) {
            AppDomainLoader loader = new AppDomainLoader(bcAssembly);
            Context = loader.Context;
        }

        public NFabric.Common.Messaging.Message[] ExecuteMessage(NFabric.Common.Messaging.Message message)
        {
            switch (message.Type)
            {
                case "event":

                case "command":

                    break;
            }

            //System.Console.WriteLine("{0} {1}.{2} {3}", message.Type, message.BoundedContext, message.Name, message.Body);

            return new NFabric.Common.Messaging.Message[]
            {
                new NFabric.Common.Messaging.Message("event", "Sales", "SalesOrderCreated", "body")
            };
        }

        public string GetName() {
            return Context.GetName();
        }
    }
}