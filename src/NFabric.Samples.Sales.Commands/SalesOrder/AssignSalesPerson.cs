using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder
{
    public class AssignSalesPerson
    {
        public Guid SalesOrder { get; private set; }
        public Guid SalesPerson { get; private set; }

        public AssignSalesPerson(Guid salesOrder, Guid salesPerson)
        {
            SalesOrder = salesOrder;
            SalesPerson = salesPerson;
        }
    }
}
