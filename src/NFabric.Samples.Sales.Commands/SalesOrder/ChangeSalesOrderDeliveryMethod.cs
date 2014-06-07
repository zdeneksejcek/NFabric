using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder
{
    public class ChangeSalesOrderDeliveryMethod
    {
        public Guid SalesOrder { get; private set; }
        public Guid DeliveryMethod { get; private set; }

        public ChangeSalesOrderDeliveryMethod(Guid salesOrder, Guid deliveryMethod)
        {
            SalesOrder = salesOrder;
            DeliveryMethod = deliveryMethod;
        }
    }
}
