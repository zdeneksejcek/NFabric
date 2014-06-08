using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    [Serializable]
    public class Shipments : EntityCollectionWithES<SalesOrderLine,List<SalesOrderLine>>
    {
        private Guid Order { get; set; }

        public Shipments(Func<AggregateWithES> getAggregate) : base(getAggregate)
        {

        }

        protected override void InitializeEventHandlers()
        {
            
        }
    }
}