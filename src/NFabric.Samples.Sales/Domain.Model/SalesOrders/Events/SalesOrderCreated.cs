using System;
using OpenDDD;
using NFabric.Samples.Sales.Domain.Model.Customers;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders.Events
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