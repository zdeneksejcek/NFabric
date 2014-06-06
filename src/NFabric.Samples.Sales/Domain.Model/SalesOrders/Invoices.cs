using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class Invoices : EntityCollectionWithES<Invoice,List<Invoice>>
    {
        public Invoices(AggregateEvents events, Func<Guid> getAggregateIdMethod) : base(events, getAggregateIdMethod)
        {

        }
    }
}