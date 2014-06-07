using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderCreated
    {
        public Guid SalesOrderId { get; private set; }
        public Guid Customer { get; private set;}
        public Guid Warehouse { get; private set; }

        public SalesOrderCreated(Guid salesOrderId, Guid customer, Guid warehouse)
        {
            SalesOrderId = salesOrderId;
            Customer = customer;
            Warehouse = warehouse;
        }
    }
}