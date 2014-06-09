using System;
using NFabric.Samples.Sales.Commands;
using NFabric.Samples.Sales.Port;
using System.Collections.Generic;
using System.Linq;
using NFabric.Samples.Sales.Domain.Model.SalesOrders.Exceptions;
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
                    new ProductId(@event.ProductId),
                    new LineQuantity(@event.Quantity),
                    @event.Comments));
        }

        #endregion

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

        public void Apply(SalesOrderLineQuantityChanged @event)
        {
            GetExistingLine(@event.Line).ChangeQuantity(@event.Quantity);
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

        #region line price changed

        public void ChangePrice(Guid line, LinePrices prices)
        {
            Events.Update(
                new SalesOrderLinePricesChanged(
                    line,
                    prices.UnitPrice.Amount,
                    prices.Discount,
                    prices.DiscountedPrice.Amount));
        }

        private void Apply(SalesOrderLinePricesChanged @event)
        {
            GetExistingLine(@event.Line).ChangePrices(@event.UnitPrice, @event.Discount, @event.DiscountedPrice);
        }

        #endregion


        private SalesOrderLine GetExistingLine(Guid guid)
        {
            var line = this.FirstOrDefault(p => p.Id == guid);

            if (line == null)
                throw new SalesOrderLineNotFound();

            return line;
        }


        protected override void InitializeEventHandlers()
        {
            Events.Handles<SalesOrderLineAdded>(Apply);
            Events.Handles<SalesOrderLineRemoved>(Apply);
            Events.Handles<SalesOrderLinesReordered>(Apply);
        }
    }
}