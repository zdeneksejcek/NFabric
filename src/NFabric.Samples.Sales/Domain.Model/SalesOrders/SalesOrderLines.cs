using System;
using NFabric.Samples.Sales.Port;
using System.Collections.Generic;
using System.Linq;
using NFabric.Samples.Sales.Domain.Model.SalesOrders.Exceptions;
using NFabric.Samples.Sales.Events.SalesOrder;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class SalesOrderLines : EntityCollectionWithES<SalesOrderLine,List<SalesOrderLine>>
    {
        private Guid Order { get { return base.AggregateId; }}

        public SalesOrderLines(AggregateEvents events, Func<Guid> getAggregateIdMethod) : base(events, getAggregateIdMethod) {
            events.Handles<SalesOrderLineAdded>(this.Apply);
        }

        #region line added

        public void Add(ProductId product, LineQuantity quantity) {
            Events.Update(
                new SalesOrderLineAdded(Order, product.Id, quantity.Quantity));
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
            Events.Update(new SalesOrderLineRemoved(line));
        }

        private void Apply(SalesOrderLineRemoved @event)
        {
            base.Collection.RemoveAll(p => p.Id == @event.LineId);
        }

        #endregion

        #region change quantity

        public void ChangeQuantity(Guid line, int quantity) {
            Events.Update(
                new SalesOrderLineQuantityChanged(line, quantity));
        }

        public void Apply(SalesOrderLineQuantityChanged @event) {
            var line = base.Collection.FirstOrDefault(p => p.Id == @event.LineId);

            if (line == null)
                throw new SalesOrderLineNotFound();

            line.ChangeQuantity(@event.Quantity);
        }

        #endregion
    }
}