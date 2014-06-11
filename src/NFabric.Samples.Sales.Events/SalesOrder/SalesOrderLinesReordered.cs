using System;
using System.Collections.Generic;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderLinesReordered : IAggregateEvent
    {
        public IDictionary<Guid, int> OrderChanges;

        public SalesOrderLinesReordered(IDictionary<Guid, int> orderChanges)
        {
            OrderChanges = orderChanges;
        }
    }
}
