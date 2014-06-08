using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    [Serializable]
    public class Invoices : EntityCollectionWithES<Invoice,List<Invoice>>
    {
        public Invoices(Func<AggregateWithES> getAggregate) : base(getAggregate) { }

        protected override void InitializeEventHandlers()
        {
            
        }
    }
}