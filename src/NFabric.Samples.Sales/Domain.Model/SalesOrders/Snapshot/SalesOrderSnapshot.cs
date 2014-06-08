using System;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders.Snapshot
{
    public class SalesOrderSnapshot
    {
        public Guid OrderId { get; private set; }

        public Guid CustomerId { get; private set; }

        public Guid WarehouseId { get; private set; }

        public Guid DeliveryMethod { get; private set; }

        public SalesOrderSnapshot(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}