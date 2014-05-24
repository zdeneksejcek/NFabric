using System;
using OpenDDD.Common;

namespace NFabric.Samples.Sales.Port
{
    public class WarehouseId : IdValueObject
    {
        public WarehouseId() : base() { }

        public WarehouseId(Guid id) : base(id) { }
    }
}

