
using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderDateChanged : IAggregateEvent
    {
        public DateTime RequiredDate { get; private set; }

        public SalesOrderDateChanged(DateTime requiredDate)
        {
            RequiredDate = requiredDate;
        }
    }
}
