using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder
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

        /*
        public static string GetString(CreateSalesOrder command)
        {
            
        }

        public static CreateSalesOrder GetObject(string @string)
        {
        }
        */
    }
}