using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Commands.SalesOrder
{
    public class ChangeOrderDate
    {
        public Guid SalesOrder { get; private set; }
        public DateTimeUtc OrderDate { get; private set; }

        public ChangeOrderDate(Guid salesOrder, DateTimeUtc orderDate)
        {
            SalesOrder = salesOrder;
            OrderDate = orderDate;
        }

    }
}
