using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder.Lines
{
    [Serializable]
    public class AddSalesOrderLine
    {
        public Guid SalesOrder { get; private set; }
        public Guid Product { get; private set; }
        public int Quantity { get; private set; }
        public string Comments { get; private set; }

        public AddSalesOrderLine(Guid salesOrder, Guid product, int quantity, string comments)
        {
            SalesOrder = salesOrder;
            Product = product;
            Quantity = quantity;
            Comments = comments;
        }
    }
}