using System;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;
using NFabric.BoundedContext;

namespace NFabric.Samples.Sales.Port.Infrastructure
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private IEventStreamRepository _repository;

        public SalesOrderRepository(IEventStreamRepository repository)
        {
            _repository = repository;
        }

        public SalesOrder GetBy(Guid id)
        {
            var events = _repository.GetStream(id);
            //var so = new SalesOrder(id

            throw new NotImplementedException();
        }

        public void Save(SalesOrder order)
        {
            throw new NotImplementedException();
        }
    }
}