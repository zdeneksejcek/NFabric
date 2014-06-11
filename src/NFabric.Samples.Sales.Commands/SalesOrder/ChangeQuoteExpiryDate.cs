using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Commands.SalesOrder
{
    public class ChangeQuoteExpiryDate
    {
        public Guid SalesOrder { get; private set; }

        public DateTimeUtc ExpiryDate { get; private set; }

        public ChangeQuoteExpiryDate(Guid salesOrder, DateTimeUtc expiryDate)
        {
            SalesOrder = salesOrder;
            ExpiryDate = expiryDate;
        }
    }
}
