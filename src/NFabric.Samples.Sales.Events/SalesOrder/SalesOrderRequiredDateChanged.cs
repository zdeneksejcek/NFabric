
using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderRequiredDateChanged : IAggregateEvent
    {
        public DateTime RequiredDate { get; private set; }

        public SalesOrderRequiredDateChanged(DateTime requiredDate)
        {
            RequiredDate = requiredDate;
        }
    }
}
