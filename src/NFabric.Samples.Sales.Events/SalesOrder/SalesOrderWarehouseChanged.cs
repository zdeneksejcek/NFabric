using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderWarehouseChanged : IAggregateEvent
    {
        public Guid Warehouse { get; private set; }

        public SalesOrderWarehouseChanged(Guid warehouse)
        {
            Warehouse = warehouse;
        }
    }
}