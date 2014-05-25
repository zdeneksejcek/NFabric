using System;
using OpenDDD;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders.Events
{
    public class SalesOrderLineQuantityChanged : Event
    {
        public Guid Line { get; private set; }
        public int Quantity { get; private set; }

        public SalesOrderLineQuantityChanged(Guid line, int quantity) : base(line)
        {
            Line = line;
            Quantity = quantity;
        }
    }
}