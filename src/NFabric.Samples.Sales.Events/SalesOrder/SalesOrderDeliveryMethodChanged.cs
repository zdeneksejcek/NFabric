using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    public class SalesOrderDeliveryMethodChanged
    {
        public Guid DeliveryMethod { get; private set; }

        public SalesOrderDeliveryMethodChanged(Guid deliveryMethod)
        {
            DeliveryMethod = deliveryMethod;
        }
    }
}
