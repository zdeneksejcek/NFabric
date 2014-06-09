using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderQuoteExpiryDateChanged
    {
        public DateTime QuotaExpiryDate { get; private set; }

        public SalesOrderQuoteExpiryDateChanged(DateTime quotaExpiryDate)
        {
            QuotaExpiryDate = quotaExpiryDate;
        }
    }
}
