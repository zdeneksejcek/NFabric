using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderLineAdded : IAggregateEvent
    {
        public Guid LineId { get; private set; }

        public Guid ProductId { get; private set; }

        public int Quantity { get; private set; }

        public string Comments { get; private set; }

        public SalesOrderLineAdded(Guid lineId, Guid productId, int quantity, string comments)
        {
            LineId = lineId;
            ProductId = productId;
            Quantity = quantity;
            Comments = comments;
        }
    }
}