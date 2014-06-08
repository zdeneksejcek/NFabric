using System;
using NFabric.Samples.Sales.Port;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    [Serializable]
    public class SalesOrderLine : EntityWithES
    {
        public ProductId Product { get; private set; }
        public LineQuantity Quantity { get; private set; }

        public SalesOrderLine(AggregateEvents events, ProductId product, LineQuantity quantity) : base(events)
        {
            Product = product;
            Quantity = quantity;
        }

        public void ChangeQuantity(int quantity) {
            this.Quantity = new LineQuantity(quantity);
        }
    }
}