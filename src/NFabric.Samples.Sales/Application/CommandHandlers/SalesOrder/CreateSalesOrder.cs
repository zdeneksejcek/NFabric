using System;

namespace NFabric.Samples.Sales.Application.CommandHandlers.SalesOrder
{
    public class CreateSalesOrder
    {
        public Guid Customer { get; private set; }
        public Guid Warehouse { get; private set; }

        public CreateSalesOrder(Guid customer, Guid warehouse)
        {
            Customer = customer;
            Warehouse = warehouse;
        }
    }
}

