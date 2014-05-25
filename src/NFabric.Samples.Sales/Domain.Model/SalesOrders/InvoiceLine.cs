using System;
using OpenDDD.EventSourcing;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class InvoiceLine : EntityWithES
    {
        public InvoiceLine(AggregateEvents events) : base(events)
        {
        }
    }
}