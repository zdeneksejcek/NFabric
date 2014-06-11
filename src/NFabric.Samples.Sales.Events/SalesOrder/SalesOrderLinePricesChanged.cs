using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderLinePricesChanged : IEntityEvent
    {
        public Guid Line { get; private set; }

        public decimal UnitPrice { get; private set; }

        public decimal Discount { get; private set; }

        public decimal DiscountedPrice { get; private set; }

        public SalesOrderLinePricesChanged(Guid line, decimal unitPrice, decimal discount, decimal discountedPrice)
        {
            Line = line;
            UnitPrice = unitPrice;
            Discount = discount;
            DiscountedPrice = discountedPrice;
        }

        Guid IEntityEvent.EntityId
        {
            get { return Line; }
        }
    }
}