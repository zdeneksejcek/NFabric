using System;
using OpenDDD.Common;

namespace NFabric.Samples.Sales.Domain.Model.Customers
{
    public class CustomerId : IdValueObject
    {
        public CustomerId(Guid id) : base(id) {}
    }
}