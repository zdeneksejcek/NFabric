using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class Shipments : EntityCollectionWithES<SalesOrderLine,List<SalesOrderLine>>
    {
        private Guid Order { get; set; }

        public Shipments(AggregateEvents events, Func<Guid> getAggregateIdMethod) : base(events,getAggregateIdMethod)
        {

        }



    }
}