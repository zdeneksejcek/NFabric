﻿using System;
using OpenDDD;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders.Events
{
    public class SalesOrderLineRemoved : Event
    {
        public Guid Line { get; private set; }

        public SalesOrderLineRemoved(Guid salesOrder, Guid line) : base(salesOrder)
        {
            Line = line;
        }
    }
}
