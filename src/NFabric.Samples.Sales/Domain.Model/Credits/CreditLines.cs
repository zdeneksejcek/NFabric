using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.Credits
{
    public class CreditLines : EntityCollectionWithES<CreditLine>
    {
        public CreditLines(Func<AggregateWithES> getAggregate) : base(getAggregate) { }

        protected override void InitializeEventHandlers()
        {
            
        }
    }
}