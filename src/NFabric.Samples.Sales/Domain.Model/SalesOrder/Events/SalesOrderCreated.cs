using System;
using OpenDDD;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrder.Events
{
    public class SalesOrderCreated : Event
    {
        public CustomerId Customer { get; private set;}

        public SalesOrderCreated(Guid id, CustomerId customer) : base(id)
        {
            Customer = customer;
        }
    }
}