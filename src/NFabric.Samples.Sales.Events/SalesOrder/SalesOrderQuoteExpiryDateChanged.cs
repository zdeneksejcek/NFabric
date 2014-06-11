using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderQuoteExpiryDateChanged : IAggregateEvent
    {
        public DateTime QuotaExpiryDate { get; private set; }

        public SalesOrderQuoteExpiryDateChanged(DateTime quotaExpiryDate)
        {
            QuotaExpiryDate = quotaExpiryDate;
        }
    }
}
