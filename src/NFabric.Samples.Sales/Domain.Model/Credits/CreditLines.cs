using System;
using System.Collections.Generic;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.Credits
{
    public class CreditLines : EntityCollectionWithES<CreditLine,List<CreditLine>>
    {
        public CreditLines(AggregateEvents events) : base(events)
        {
        }
    }
}