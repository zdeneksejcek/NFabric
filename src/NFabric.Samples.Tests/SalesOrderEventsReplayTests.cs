using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;
using NFabric.Samples.Sales.Events.SalesOrder;
using NUnit.Framework;

namespace NFabric.Samples.Tests
{
    [TestFixture]
    public class SalesOrderEventsReplayTests
    {
        private IEnumerable<SequencedEvent> GetEvents()
        {
            var aggId = Guid.NewGuid();
            var line1Id = Guid.NewGuid();

            var list = new List<SequencedEvent>();
            
            list.Add(new SequencedEvent(aggId, 0, new SalesOrderCreated(aggId, Guid.NewGuid(), Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow), DateTime.UtcNow));
            list.Add(new SequencedEvent(aggId, 1, new SalesOrderLineAdded(line1Id, Guid.NewGuid(), 5, "some stupid comments"), DateTime.UtcNow));
            list.Add(new SequencedEvent(aggId, 2, new SalesOrderLineQuantityChanged(line1Id, 6), DateTime.UtcNow));
            //list.Add(new SequencedEvent(aggId, 1, new SalesOrderLinePricesChanged(line1Id, 50, 0, 50), DateTime.UtcNow));
            
            return list;
        }

        [Test]
        public void Replay()
        {
            var os = new SalesOrder(GetEvents());
        }
    }
}