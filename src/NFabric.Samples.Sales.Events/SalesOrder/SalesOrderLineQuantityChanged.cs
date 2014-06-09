using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderLineQuantityChanged
    {
        public Guid Line { get; private set; }
        public int Quantity { get; private set; }

        public SalesOrderLineQuantityChanged(Guid line, int quantity)
        {
            Line = line;
            Quantity = quantity;
        }
    }
}