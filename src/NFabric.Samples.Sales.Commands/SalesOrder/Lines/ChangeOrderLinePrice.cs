using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder.Lines
{
    public class ChangeOrderLinePrice
    {
        public Guid SalesOrder { get; private set; }

        public Guid Line { get; private set; }

        public MonetaryValue UnitPrice { get; private set; }

        public decimal Discount { get; private set; }

        public MonetaryValue DiscountedPrice { get; private set; }

        public ChangeOrderLinePrice(Guid salesOrder, Guid line, MonetaryValue unitPrice, decimal discount, MonetaryValue discountedPrice)
        {
            SalesOrder = salesOrder;
            Line = line;
            UnitPrice = unitPrice;
            Discount = discount;
            DiscountedPrice = discountedPrice;
        }
    }
}