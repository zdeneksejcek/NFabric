using System;
using System.Collections.Generic;

namespace NFabric.Samples.Sales.Commands.SalesOrder.Lines
{
    public class ReorderSalesOrderLines
    {
        public Guid SalesOrder { get; private set; }

        public IDictionary<Guid, int> OrderChanges;

        public ReorderSalesOrderLines(Guid salesOrder, IDictionary<Guid, int> orderChanges)
        {
            SalesOrder = salesOrder;
            OrderChanges = orderChanges;
        }
    }
}
