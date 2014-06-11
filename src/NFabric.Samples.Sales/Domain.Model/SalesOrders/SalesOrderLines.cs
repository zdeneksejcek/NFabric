using System;
using System.Linq;
using NFabric.Samples.Sales.Domain.Model.SalesOrders.Exceptions;
using NFabric.Samples.Sales.Port;
using System.Collections.Generic;
using NFabric.Samples.Sales.Events.SalesOrder;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    [Serializable]
    public class SalesOrderLines : EntityCollectionWithES<SalesOrderLine>
    {
        private Guid Order { get { return base.AggregateId; }}

        public SalesOrderLines(Func<AggregateWithES> getAggregate) : base(getAggregate) { }

        #region line added

        public void Add(ProductId product, LineQuantity quantity, string comments) {
            Events.Update(
                new SalesOrderLineAdded(Order, product.Id, quantity.Quantity, comments));
        }

        private void Apply(SalesOrderLineAdded @event)
        {
            Add(
                new SalesOrderLine(
                    Events,
                    @event.LineId,
                    new ProductId(@event.ProductId),
                    new LineQuantity(@event.Quantity),
                    @event.Comments));
        }

        #endregion

        public SalesOrderLine GetExistingLine(Guid lineId)
        {
            var line = this.FirstOrDefault(p => p.Id == lineId);

            if (line == null)
                throw new SalesOrderLineNotFound();

            return line;
        }

        #region line removed

        public void Remove(Guid line) {
            Events.Update(new SalesOrderLineRemoved(line));
        }

        private void Apply(SalesOrderLineRemoved @event)
        {
            RemoveAll(p => p.Id == @event.LineId);
        }

        #endregion

        #region change quantity

        public void ChangeQuantity(Guid line, LineQuantity quantity)
        {
            Events.Update(
                new SalesOrderLineQuantityChanged(line, quantity.Quantity));
        }

        #endregion

        #region reorder

        public void Reorder(IDictionary<Guid, int> orderChanges)
        {
            Events.Update(
                new SalesOrderLinesReordered(orderChanges));
        }

        private void Apply(SalesOrderLinesReordered @event)
        {
            Utils.LinesReorderer.Reorder(this, @event.OrderChanges);
        }

        #endregion

        protected override void InitializeEventHandlers()
        {
            Events.Handles<SalesOrderLineAdded>(Apply);
            Events.Handles<SalesOrderLineRemoved>(Apply);
            Events.Handles<SalesOrderLinesReordered>(Apply);
        }
    }
}