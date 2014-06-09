using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder
{
    public class AssignSalesGroup
    {
        public Guid SalesOrder { get; private set; }
        public Guid SalesGroup { get; private set; }
        
        public AssignSalesGroup(Guid salesOrder, Guid salesGroup)
        {
            SalesOrder = salesOrder;
            SalesGroup = salesGroup;
        }

    }
}
