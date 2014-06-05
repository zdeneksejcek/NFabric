using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderLineAdded
    {
        public Guid LineId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public SalesOrderLineAdded(Guid lineId, Guid productId, int quantity)
        {
            LineId = lineId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}