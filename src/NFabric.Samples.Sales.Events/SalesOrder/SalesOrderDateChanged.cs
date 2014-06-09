
using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderDateChanged
    {
        public DateTime RequiredDate { get; private set; }

        public SalesOrderDateChanged(DateTime requiredDate)
        {
            RequiredDate = requiredDate;
        }
    }
}
