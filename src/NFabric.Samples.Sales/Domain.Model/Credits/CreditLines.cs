using System;
using OpenDDD.EventSourcing;
using System.Collections.Generic;

namespace NFabric.Samples.Sales.Domain.Model.Credits
{
    public class CreditLines : EntityCollectionWithES<CreditLine,List<CreditLine>>
    {
        public CreditLines(AggregateEvents events) : base(events)
        {
        }
    }
}