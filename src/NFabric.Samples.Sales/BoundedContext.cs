using System;
using NFabric.BoundedContext;
using System.Collections.Generic;
using System.Threading;

namespace NFabric.Samples.Sales
{
    public class BoundedContext : DefaultBoundedContext
    {
        public override string Name
        {
            get { return "Sales"; }
        }

        public override IListensToEvents ListensToEventsProvider
        {
            get { return new ListensToEvents(); }
        }

        public override IList<object> ExecuteCommand(object obj) {
            System.Console.WriteLine("Command executed: " + obj.ToString());

            return null;
        }
    }
}