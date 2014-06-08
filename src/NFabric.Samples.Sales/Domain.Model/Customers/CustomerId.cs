using System;

namespace NFabric.Samples.Sales.Domain.Model.Customers
{
    [Serializable]
    public class CustomerId
    {
        public Guid Id { get; private set; }

        public CustomerId(Guid id) {
            Id = id;
        }
    }
}