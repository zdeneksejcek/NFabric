using System;
using NFabric.BoundedContext;

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
    }
}