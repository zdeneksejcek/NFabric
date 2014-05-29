using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderLineRemoved
    {
        public Guid LineId { get; private set; }

        public SalesOrderLineRemoved(Guid lineId)
        {
            LineId = lineId;
        }
    }
}

