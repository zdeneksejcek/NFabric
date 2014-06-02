using System;
using NFabric.BoundedContext;
using System.Collections.Generic;
using System.Threading;

namespace NFabric.Samples.Sales
{
    public class BoundedContext : IBoundedContext
    {
        public string GetName()
        {
            return "Sales";
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