using System;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;
using NFabric.BoundedContext.Persistence;

namespace NFabric.Samples.Sales.Port.Infrastructure
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private IEventStreamRepository _events;
        private ISnapshotsRepository _snapshots;

        public SalesOrderRepository(IEventStreamRepository repository, ISnapshotsRepository snapshots)
        {
            _events = repository;
            _snapshots = snapshots;
        }

        public SalesOrder GetBy(Guid id)
        {
            var snapshot = _snapshots.GetBy(id);

            var events = _events.GetStream(id);

            throw new NotImplementedException();
        }

        public void Save(SalesOrder order)
        {
            throw new NotImplementedException();
        }
    }
}