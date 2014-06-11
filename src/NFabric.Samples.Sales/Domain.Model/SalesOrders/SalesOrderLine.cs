using System;
using NFabric.Samples.Sales.Events.SalesOrder;
using NFabric.Samples.Sales.Port;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    [Serializable]
    public class SalesOrderLine : EntityWithES
    {
        private ProductId Product { get; set; }

        private LineQuantity Quantity { get; set; }

        private LinePrices Prices { get; set; }

        private string Comments { get; set; }

        public SalesOrderLine(AggregateEvents events, Guid lineId, ProductId product, LineQuantity quantity, string comments) : base(events, lineId)
        {
            Id = lineId;
            Product = product;
            Quantity = quantity;
            Comments = comments;
        }

        #region line price changed
        public void ChangePrices(LinePrices prices)
        {
            Events.Update(
                new SalesOrderLinePricesChanged(
                    this.Id,
                    prices.UnitPrice.Amount,
                    prices.Discount,
                    prices.DiscountedPrice.Amount));
        }

        private void Apply(SalesOrderLinePricesChanged @event)
        {
            //@event.UnitPrice.
            //this.Prices = new LinePrices(@event.UnitPrice, @);
        }

        private void Apply(SalesOrderLineQuantityChanged @event)
        {
            this.Quantity = new LineQuantity(@event.Quantity);
        }

        #endregion

        protected override void InitializeEventHandlers()
        {
            Events.Handles<SalesOrderLineQuantityChanged>(this.Id, Apply);
        }
    }
}