using System;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class Shipment : EntityWithES
    {
        public Shipment(AggregateEvents events) : base(events)
        {
        }
    }
}