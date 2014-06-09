using NFabric.Samples.Sales.Domain.Model;
using NFabric.Samples.Sales.Domain.Model.DeliveryMethods;
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
                                            ICommandHandler<ChangeSalesOrderDeliveryMethod>,
                                            ICommandHandler<ChangeSalesOrderDeliveryAddress>
    {

        public SalesOrderCommandHandler(ISalesOrderRepository repository) : base(repository) { }

        public void Handle(CreateSalesOrder command) {
            var order = new Domain.Model.SalesOrders.SalesOrder(
                            new CustomerId(command.Customer),
                            new WarehouseId(command.Warehouse),
                            new DateTimeUtc(command.OrderDate.Value),
                            new DateTimeUtc(command.QuotaExpiryDate.Value),
                            new DateTimeUtc(command.RequiredDate.Value));

            _repository.Save(order);
        }

        public void Handle(ChangeSalesOrderWarehouse command)
        {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.SavableObject.ChangeWarehouse(
                    new WarehouseId(command.Warehouse));
            }
        }

        public void Handle(ChangeSalesOrderDeliveryMethod command)
        {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.SavableObject.ChangeDeliveryMethod(
                    new DeliveryMethodId(command.DeliveryMethod));
            }
        }

        public void Handle(ChangeSalesOrderComments command)
        {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.SavableObject.ChangeComments(command.Comments);
            }
        }

        public void Handle(ChangeSalesOrderDeliveryAddress command)
        {
            using (var order = GetExistingSalesOrder(command.SalesOrder))
            {
                order.SavableObject.ChangeDeliveryAddress(
                    new SalesOrderDeliveryAddress(
                        command.AddressName,
                        command.Street,
                        command.Suburb,
                        command.City,
                        command.StateRegion,
                        command.PostCode,
                        command.Country
                        ));
            }
        }
    }
}