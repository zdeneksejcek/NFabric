using System;
using System.Collections.Generic;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderLinesReordered
    {
        public IDictionary<Guid, int> OrderChanges;

        public SalesOrderLinesReordered(IDictionary<Guid, int> orderChanges)
        {
            OrderChanges = orderChanges;
        }
    }
}
