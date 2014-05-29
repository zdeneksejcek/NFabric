using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class Shipments : EntityCollectionWithES<SalesOrderLine,List<SalesOrderLine>>
    {
        private Guid Order { get; set; }

        public Shipments(Guid order, AggregateEvents events) : base(events)
        {
            Order = order;
        }



    }
}