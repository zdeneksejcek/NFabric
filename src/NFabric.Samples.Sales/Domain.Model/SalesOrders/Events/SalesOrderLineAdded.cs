using System;
using OpenDDD;
using NFabric.Samples.Sales.Port;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders.Events
{
    public class SalesOrderLineAdded : Event
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public SalesOrderLineAdded(Guid salesOrder, ProductId productId, LineQuantity quantity) : base(salesOrder)
        {
            AssertArgumentNotNull(quantity, "Quantity cannot be null");

            ProductId = productId;
            Quantity = quantity.Quantity;
        }
    }
}