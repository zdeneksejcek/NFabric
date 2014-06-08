using System;

namespace NFabric.Samples.Sales.Port
{
    [Serializable]
    public class ProductId
    {
        public Guid Id { get; private set; }

        public ProductId(Guid id) {
            Id = id;
        }
    }
}