using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderDeliveryMethodChanged
    {
        public Guid DeliveryMethod { get; private set; }

        public SalesOrderDeliveryMethodChanged(Guid deliveryMethod)
        {
            DeliveryMethod = deliveryMethod;
        }
    }
}
