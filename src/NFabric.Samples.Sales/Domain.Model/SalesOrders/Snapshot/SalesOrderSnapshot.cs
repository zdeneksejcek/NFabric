using System;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders.Snapshot
{
    public class SalesOrderSnapshot
    {
        public Guid OrderId { get; private set; }

        public SalesOrderSnapshot(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}