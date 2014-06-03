using System;
using NFabric.BoundedContext;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;

namespace NFabric.Samples.Sales
{
    public class BoundedContext : IBoundedContext
    {
        public BoundedContext() {

        }

        public string GetName()
        {
            return "Sales";
        }

        public HandledMessages GetHandledMessages()
        {
            return new Inspector(Assembly.GetExecutingAssembly()).GetHandledMessages();
        }

        public IList<object> ExecuteCommand(object command) {
            System.Console.WriteLine("Command executed: " + command.ToString());

            return null;
        }

        public IList<object> ExecuteEvent(object @event) {
            System.Console.WriteLine("Command event: " + @event.ToString());
            return null;
        }
    }
}