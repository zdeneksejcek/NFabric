using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder
{
    [Serializable]
    public class ChangeSalesOrderWarehouse
    {
        public Guid SalesOrder { get; private set; }
        public Guid Warehouse { get; private set; }

        public ChangeSalesOrderWarehouse(Guid salesOrder, Guid warehouse)
        {
            Warehouse = warehouse;
            SalesOrder = salesOrder;
        }
    }
}
