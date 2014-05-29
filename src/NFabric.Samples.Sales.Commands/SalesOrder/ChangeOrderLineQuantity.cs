using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder
{
    public class ChangeOrderLineQuantity
    {
        public Guid SalesOrder { get; private set; }
        public Guid Line { get; private set; }
        public int Quantity { get; private set; }

        public ChangeOrderLineQuantity(Guid salesOrder, Guid line, int quantity)
        {
            SalesOrder = salesOrder;
            Line = line;
            Quantity = quantity;
        }
    }
}

