using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderLineQuantityChanged
    {
        public Guid LineId { get; private set; }
        public int Quantity { get; private set; }

        public SalesOrderLineQuantityChanged(Guid lineId, int quantity)
        {
            LineId = lineId;
            Quantity = quantity;
        }
    }
}