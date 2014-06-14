using NFabric.Contracts;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class LinePrices
    {
        public MonetaryValue UnitPrice { get; private set; }

        public decimal Discount { get; private set; }

        public MonetaryValue DiscountedPrice { get; private set; }

        public LinePrices(MonetaryValue unitPrice, decimal discount, MonetaryValue discountedPrice)
        {
            UnitPrice = unitPrice;
            Discount = discount;
            DiscountedPrice = discountedPrice;
        }

    }
}
