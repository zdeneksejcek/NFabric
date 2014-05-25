using System;
using OpenDDD.EventSourcing;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class Invoice : EntityWithES
    {
        public Invoice(AggregateEvents events) : base(events)
        {
        }
    }
}