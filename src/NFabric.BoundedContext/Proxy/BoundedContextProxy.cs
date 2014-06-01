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

        public IList<object> ExecuteCommand(dynamic message)
        {
            var commandMessage = new CommandMessage(message);

            System.Console.WriteLine(commandMessage.Type);

            return null;
            //return Context.ExecuteCommand(commandMessage);
        }

        public IList<string> GetEventNames() {
            return Context.ListensToEventsProvider.GetEvents().ToList();
        }

        public IList<object> ExecuteEvent(object @event)
        {
            throw new NotImplementedException();
        }
    }
}