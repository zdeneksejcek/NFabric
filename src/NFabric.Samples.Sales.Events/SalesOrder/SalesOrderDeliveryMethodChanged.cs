using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderDeliveryMethodChanged : IAggregateEvent
    {
        public Guid DeliveryMethod { get; private set; }

        public SalesOrderDeliveryMethodChanged(Guid deliveryMethod)
        {
            DeliveryMethod = deliveryMethod;
        }
    }
}
