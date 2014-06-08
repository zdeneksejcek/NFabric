using System;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderWarehouseChanged
    {
        public Guid Warehouse { get; private set; }

        public SalesOrderWarehouseChanged(Guid warehouse)
        {
            Warehouse = warehouse;
        }
    }
}