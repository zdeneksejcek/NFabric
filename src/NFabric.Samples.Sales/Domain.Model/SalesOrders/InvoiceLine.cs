﻿using System;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    [Serializable]
    public class InvoiceLine : EntityWithES
    {
        public InvoiceLine(AggregateEvents events, Guid id) : base(events, id)
        {
        }

        protected override void InitializeEventHandlers()
        {
            throw new NotImplementedException();
        }
    }
}