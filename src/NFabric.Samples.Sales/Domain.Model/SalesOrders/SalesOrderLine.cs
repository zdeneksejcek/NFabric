using System;
using OpenDDD;
using OpenDDD.EventSourcing;
using NFabric.Samples.Sales.Port;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
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