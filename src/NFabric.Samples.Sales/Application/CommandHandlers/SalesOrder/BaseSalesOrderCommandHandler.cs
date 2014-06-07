using System;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;
using NFabric.Samples.Sales.Application.CommandHandlers.SalesOrder.Exceptions;

namespace NFabric.Samples.Sales.Application.CommandHandlers.SalesOrder
{
    public abstract class BaseSalesOrderCommandHandler
    {
        protected ISalesOrderRepository _repository;

        protected BaseSalesOrderCommandHandler(ISalesOrderRepository repository)
        {
            _repository = repository;
        }

        protected Savable<Domain.Model.SalesOrders.SalesOrder> GetExistingSalesOrder(Guid salesOrder)
        {
            var order = _repository.GetBy(salesOrder);

            if (order == null)
                throw new SalesOrderNotFound();

            return new Savable<Domain.Model.SalesOrders.SalesOrder>(order, _repository.Save);
        }
    }
}
