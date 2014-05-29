using System;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;
using NFabric.Samples.Sales.Port;
using NFabric.Samples.Sales.Domain.Model.Customers;
using NFabric.Samples.Sales.Domain.Model;
using NFabric.BoundedContext;
using NFabric.Samples.Sales.Commands.SalesOrder;

namespace NFabric.Samples.Sales.Application.CommandHandlers.SalesOrder
{
    public class SalesOrderCommandHandler : ICommandHandler<CreateSalesOrder>
    {
        ISalesOrderRepository _repository;

        public SalesOrderCommandHandler(ISalesOrderRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateSalesOrder command) {
            var order = new Domain.Model.SalesOrders.SalesOrder(
                            new CustomerId(command.Customer),
                            new WarehouseId(command.Warehouse));

            _repository.Save(order);
        }

        public void Handle(AddSalesOrderLine command) {
            var order = _repository.GetBy(command.SalesOrder);

            if (order == null)
                throw new SalesOrderNotFound();

            order.Lines.Add(
                new ProductId(command.Product),
                new LineQuantity(command.Quantity));

            _repository.Save(order);
        }

        public void Handle(ChangeOrderLineQuantity command) {
            var order = _repository.GetBy(command.SalesOrder);

            if (order == null)
                throw new SalesOrderNotFound();

            order.Lines.ChangeQuantity(command.Line, command.Quantity);

            _repository.Save(order);
        }
    }
}