using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderCreated
    {
        public Guid SalesOrderId { get; private set; }
        public Guid Customer { get; private set;}

        public SalesOrderCreated(Guid salesOrderId, Guid customer)
        {
            SalesOrderId = salesOrderId;
            Customer = customer;
        }
    }
}