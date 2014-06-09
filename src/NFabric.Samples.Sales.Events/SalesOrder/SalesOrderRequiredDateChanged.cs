
using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderRequiredDateChanged
    {
        public DateTime RequiredDate { get; private set; }

        public SalesOrderRequiredDateChanged(DateTime requiredDate)
        {
            RequiredDate = requiredDate;
        }
    }
}
