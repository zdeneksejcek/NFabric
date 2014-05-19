using System;
using OpenDDD;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrder.Events
{
    public class SalesOrderCreated : Event
    {
        public SalesOrderId Id { get; private set;}
        public CustomerId Customer { get; private set;}

        public SalesOrderCreated(SalesOrderId id, CustomerId customer)
        {
            Id = id;
            Customer = customer;
        }
    }
}