using System;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;
using NFabric.BoundedContext.Persistence;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Port.Infrastructure
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private InMemoryEventStreamRepository _events;
        private InMemorySnapshotRepository _snapshots;

        public SalesOrderRepository(InMemoryEventStreamRepository repository, InMemorySnapshotRepository snapshots)
        {
            _events = repository;
            _snapshots = snapshots;
        }

        public SalesOrder GetBy(Guid id)
        {
            //var snapshot = _snapshots.GetBy(id);

            var events = _events.GetStream(id);

            //throw new NotImplementedException();

            return new SalesOrder(new NFabric.Samples.Sales.Domain.Model.Customers.CustomerId(Guid.NewGuid()), new WarehouseId(Guid.NewGuid()));
        }

        public void Save(SalesOrder order)
        {
            var uncommitedEvents = ((IProducesEvents)order).GetUncommitedSequencedEvents();
            
            _events.Append(uncommitedEvents);
            //throw new NotImplementedException();
        }
    }
}