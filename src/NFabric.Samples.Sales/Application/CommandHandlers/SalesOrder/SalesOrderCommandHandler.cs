﻿using NFabric.Samples.Sales.Domain.Model.DeliveryMethods;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;
using NFabric.Samples.Sales.Port;
using NFabric.Samples.Sales.Domain.Model.Customers;
using NFabric.BoundedContext;
using NFabric.Samples.Sales.Commands.SalesOrder;

namespace NFabric.Samples.Sales.Application.CommandHandlers.SalesOrder
{
    public class SalesOrderCommandHandler : BaseSalesOrderCommandHandler,
                                            ICommandHandler<CreateSalesOrder>,
                                            ICommandHandler<ChangeSalesOrderWarehouse>,
                                            ICommandHandler<ChangeSalesOrderDeliveryMethod>
    {

        public SalesOrderCommandHandler(ISalesOrderRepository repository) : base(repository) { }

        public void Handle(CreateSalesOrder command) {
            var order = new Domain.Model.SalesOrders.SalesOrder(
                            new CustomerId(command.Customer),
                            new WarehouseId(command.Warehouse));

            _repository.Save(order);
        }

        public void Handle(ChangeSalesOrderWarehouse command)
        {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.Object.ChangeWarehouse(
                    new WarehouseId(command.Warehouse));
            }
        }

        public void Handle(ChangeSalesOrderDeliveryMethod command)
        {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.Object.ChangeDeliveryMethod(new DeliveryMethodId(command.DeliveryMethod));
            }
        }

    }
}