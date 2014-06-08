using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;
using NFabric.BoundedContext.Persistence;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Port.Infrastructure
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private InMemoryEventsRepository _events;
        private InMemorySnapshotRepository _snapshots;
        private ISequencedEventsReader _reader;

        public SalesOrderRepository(
            InMemoryEventsRepository repository,
            ISequencedEventsReader reader,
            InMemorySnapshotRepository snapshots)
        {
            _reader = reader;
            _events = repository;
            _snapshots = snapshots;
        }

        public SalesOrder GetBy(Guid id)
        {
            var events = _reader.GetEvents(id);

            return new SalesOrder(events);
        }

        public void Save(SalesOrder order)
        {
            var uncommitedEvents = ((IProducesEvents)order).GetUncommitedSequencedEvents();

            _events.Append(uncommitedEvents);
        }

        //var formatter = new BinaryFormatter();
        //var stream = new MemoryStream();

        //formatter.Serialize(stream, order);
            
        //stream.Position = 0;

        //var newSO = formatter.Deserialize(stream);
    }
}