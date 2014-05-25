using System;
using OpenDDD.EventSourcing;
using System.Collections.Generic;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class Invoices : EntityCollectionWithES<Invoice,List<Invoice>>
    {
        public Invoices(Guid order, AggregateEvents events) : base(events)
        {

        }
    }
}