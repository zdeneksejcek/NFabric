using System;
using NFabric.Samples.Sales.Events.SalesOrder;
using NFabric.Samples.Sales.Port;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    [Serializable]
    public class SalesOrderLine : EntityWithES
    {
        public ProductId Product { get; private set; }

        public LineQuantity Quantity { get; private set; }

        private string Comments { get; set; }

        public SalesOrderLine(AggregateEvents events, ProductId product, LineQuantity quantity, string comments) : base(events)
        {
            Product = product;
            Quantity = quantity;
            Comments = comments;
        }

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
            throw new NotImplementedException();
            //GetExistingLine(@event.Line).ChangePrices(@event.UnitPrice, @event.Discount, @event.DiscountedPrice);
        }

        #endregion

        protected override void InitializeEventHandlers()
        {
            throw new NotImplementedException();
        }
    }
}