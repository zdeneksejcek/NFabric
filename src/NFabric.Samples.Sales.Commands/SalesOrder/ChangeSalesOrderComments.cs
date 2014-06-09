
using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder
{
    public class ChangeSalesOrderComments
    {
        public Guid SalesOrder { get; private set; }
        public string Comments { get; private set; }

        public ChangeSalesOrderComments(Guid salesOrder, string comments)
        {
            SalesOrder = salesOrder;
            Comments = comments;
        }

    }
}
