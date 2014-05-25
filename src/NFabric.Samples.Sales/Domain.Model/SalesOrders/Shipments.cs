using System;
using OpenDDD.EventSourcing;
using System.Collections.Generic;

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