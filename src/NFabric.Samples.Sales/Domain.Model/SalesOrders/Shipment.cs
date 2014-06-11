using System;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    [Serializable]
    public class Shipment : EntityWithES
    {
        public Shipment(AggregateEvents events, Guid id) : base(events, id)
        {
            
        }

        protected override void InitializeEventHandlers()
        {
            throw new NotImplementedException();
        }
    }
}