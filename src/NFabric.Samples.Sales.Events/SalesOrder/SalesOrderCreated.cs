using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderCreated
    {
        public Guid SalesOrderId { get; private set; }
        public Guid Customer { get; private set;}
        public Guid Warehouse { get; private set; }

        public DateTime OrderDate { get; private set; }
        
        public DateTime QuotaExpiryDate { get; private set; }
        
        public DateTime RequiredDate { get; private set; }

        public SalesOrderCreated(Guid salesOrderId, Guid customer, Guid warehouse, DateTime orderDate, DateTime quotaExpiryDate, DateTime requiredDate)
        {
            SalesOrderId = salesOrderId;
            Customer = customer;
            Warehouse = warehouse;

            OrderDate = orderDate;
            QuotaExpiryDate = quotaExpiryDate;
            RequiredDate = requiredDate;
        }
    }
}