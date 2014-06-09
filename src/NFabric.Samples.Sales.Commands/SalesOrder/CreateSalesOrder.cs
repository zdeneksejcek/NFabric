using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder
{
    [Serializable]
    public class CreateSalesOrder
    {
        public Guid Customer { get; private set; }

        public Guid Warehouse { get; private set; }

        public DateTimeUtc OrderDate { get; private set; }

        public DateTimeUtc QuotaExpiryDate { get; private set; }

        public DateTimeUtc RequiredDate { get; private set; }

        public CreateSalesOrder(Guid customer, Guid warehouse, DateTimeUtc orderDate, DateTimeUtc quotaExpiryDate, DateTimeUtc requiredDate)
        {
            Customer = customer;
            Warehouse = warehouse;

            OrderDate = orderDate;
            QuotaExpiryDate = quotaExpiryDate;
            RequiredDate = requiredDate;
        }
    }
}