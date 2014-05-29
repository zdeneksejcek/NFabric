using System;

namespace NFabric.Samples.Sales.Port
{
    public class WarehouseId
    {
        public Guid Id { get; private set; }

        public WarehouseId(Guid id) {
            Id = id;
        }
    }
}

