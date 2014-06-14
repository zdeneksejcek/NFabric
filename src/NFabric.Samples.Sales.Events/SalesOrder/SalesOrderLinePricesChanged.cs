using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderLinePricesChanged : IEntityEvent
    {
        public Guid Line { get; private set; }

        public MonetaryValue UnitPrice { get; private set; }

        public decimal Discount { get; private set; }

        public MonetaryValue DiscountedPrice { get; private set; }

        public SalesOrderLinePricesChanged(Guid line, MonetaryValue unitPrice, decimal discount, MonetaryValue discountedPrice)
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