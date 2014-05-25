using System;
using OpenDDD.EventSourcing;
using NFabric.Samples.Sales.Domain.Model.SalesOrders.Events;
using NFabric.Samples.Sales.Port;
using System.Collections.Generic;
using System.Linq;
using NFabric.Samples.Sales.Domain.Model.SalesOrders.Exceptions;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class SalesOrderLines : EntityCollectionWithES<SalesOrderLine,List<SalesOrderLine>>
    {
        private Guid Order { get; set; }

        public SalesOrderLines(Guid order, AggregateEvents events) : base(events) {
            Order = order;
            events.Handles<SalesOrderLineAdded>(order, this.Apply);
        }

        #region line added

        public void Add(ProductId product, LineQuantity quantity) {
            Events.Update(
                new SalesOrderLineAdded(Order, product, quantity));
        }

        private void Apply(SalesOrderLineAdded @event)
        {
            base.Collection.Add(
                new SalesOrderLine(
                    base.Events,
                    new ProductId(@event.ProductId),
                    new LineQuantity(@event.Quantity)));
        }

        #endregion

        #region line removed

        public void Remove(Guid line) {
            Events.Update(new SalesOrderLineRemoved(Order, line));
        }

        private void Apply(SalesOrderLineRemoved @event)
        {
            base.Collection.RemoveAll(p => p.Id == @event.Id);
        }

        #endregion

        #region change quantity

        public void ChangeQuantity(Guid line, int quantity) {
            Events.Update(
                new SalesOrderLineQuantityChanged(line, quantity));
        }

        public void Apply(SalesOrderLineQuantityChanged @event) {
            var line = base.Collection.FirstOrDefault(p => p.Id == @event.Line);

            if (line == null)
                throw new SalesOrderLineNotFound();

            line.ChangeQuantity(@event.Quantity);
        }

        #endregion
    }
}