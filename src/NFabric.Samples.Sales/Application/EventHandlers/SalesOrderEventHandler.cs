using System;
using NFabric.Samples.Sales.Events.SalesOrder;
using NFabric.BoundedContext;

namespace NFabric.Samples.Sales.Application.EventHandlers
{
    public class SalesOrderEventHandler : IEventHandler<SalesOrderCreated>
    {
        public void Handle(SalesOrderCreated @event)
        {
            // just for testing Inspector
            throw new NotImplementedException();
        }
    }
}

