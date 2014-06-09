using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder
{
    public class ChangeRequiredDate
    {
        public Guid SalesOrder { get; private set; }

        public DateTimeUtc RequiredDate { get; private set; }

        public ChangeRequiredDate(Guid salesOrder, DateTimeUtc requiredDate)
        {
            SalesOrder = salesOrder;
            RequiredDate = requiredDate;
        }
    }
}
