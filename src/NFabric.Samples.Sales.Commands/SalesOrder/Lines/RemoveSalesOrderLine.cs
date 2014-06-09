using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder.Lines
{
    public class RemoveSalesOrderLine
    {
        public Guid SalesOrder { get; private set; }

        public Guid Line { get; private set; }

        public RemoveSalesOrderLine(Guid salesOrder, Guid line)
        {
            SalesOrder = salesOrder;
            Line = line;
        }

    }
}
