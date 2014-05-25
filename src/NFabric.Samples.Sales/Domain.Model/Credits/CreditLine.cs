using System;
using OpenDDD.EventSourcing;

namespace NFabric.Samples.Sales.Domain.Model.Credits
{
    public class CreditLine : EntityWithES
    {
        public CreditLine(AggregateEvents events) : base(events)
        {
        }
    }
}

