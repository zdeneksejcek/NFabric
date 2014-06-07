using NFabric.BoundedContext;
using NFabric.Samples.Sales.Commands.SalesOrder;
using NFabric.Samples.Sales.Domain.Model;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;
using NFabric.Samples.Sales.Port;

namespace NFabric.Samples.Sales.Application.CommandHandlers.SalesOrder
{
    public class SalesOrderLinesCommandHandler :    BaseSalesOrderCommandHandler,
                                                    ICommandHandler<AddSalesOrderLine>,
                                                    ICommandHandler<ChangeOrderLineQuantity>

    {

        public SalesOrderLinesCommandHandler(ISalesOrderRepository repository) : base(repository) { }

        public void Handle(AddSalesOrderLine command) {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.Object.Lines.Add(
                    new ProductId(command.Product),
                    new LineQuantity(command.Quantity));
            }
        }

        public void Handle(ChangeOrderLineQuantity command) {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.Object.Lines.ChangeQuantity(command.Line, command.Quantity);
            }
        }
    }
}
