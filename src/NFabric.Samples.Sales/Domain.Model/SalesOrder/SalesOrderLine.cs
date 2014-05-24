using System;
using OpenDDD;
using OpenDDD.EventSourcing;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrder
{
    public class SalesOrderLine : EntityWithES
    {
        public SalesOrderLine(AggregateEvents events) : base(events)
        {
        }
    }
}