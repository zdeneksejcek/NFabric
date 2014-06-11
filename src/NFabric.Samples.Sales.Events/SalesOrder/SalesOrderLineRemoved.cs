using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderLineRemoved : IAggregateEvent
    {
        public Guid LineId { get; private set; }

        public SalesOrderLineRemoved(Guid lineId)
        {
            LineId = lineId;
        }
    }
}
