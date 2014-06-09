using NFabric.BoundedContext;
using NFabric.Samples.Sales.Commands.SalesOrder;
using NFabric.Samples.Sales.Commands.SalesOrder.Lines;
using NFabric.Samples.Sales.Domain.Model;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;
using NFabric.Samples.Sales.Port;

namespace NFabric.Samples.Sales.Application.CommandHandlers.SalesOrder
{
    public class SalesOrderLinesCommandHandler :    BaseSalesOrderCommandHandler,
                                                    ICommandHandler<AddSalesOrderLine>,
                                                    ICommandHandler<ChangeOrderLineQuantity>,
                                                    ICommandHandler<RemoveSalesOrderLine>,
                                                    ICommandHandler<ReorderSalesOrderLines>

    {
        public SalesOrderLinesCommandHandler(ISalesOrderRepository repository) : base(repository) { }

        public void Handle(AddSalesOrderLine command) {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.SavableObject.Lines.Add(
                    new ProductId(command.Product),
                    new LineQuantity(command.Quantity),
                    command.Comments);
            }
        }

        public void Handle(ChangeOrderLineQuantity command) {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.SavableObject.Lines.ChangeQuantity(
                    command.Line,
                    new LineQuantity(command.Quantity));
            }
        }

        public void Handle(RemoveSalesOrderLine command)
        {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.SavableObject.Lines.Remove(command.Line);
            }
        }

        public void Handle(ReorderSalesOrderLines command)
        {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.SavableObject.Lines.Reorder(command.OrderChanges);
            }
        }

        public void Handle(ChangeOrderLinePrice command)
        {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                //order.SavableObject.Lines.
            }
        }

    }
}