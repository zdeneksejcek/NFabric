using System;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.Credits
{
    public class CreditLine : EntityWithES
    {
        public CreditLine(AggregateEvents events) : base(events)
        {
        }

        protected override void InitializeEventHandlers()
        {
            throw new NotImplementedException();
        }
    }
}