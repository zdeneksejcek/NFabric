using System;
using OpenDDD.Common;

namespace NFabric.Samples.Sales.Port
{
    public class ProductId : IdValueObject
    {
        public ProductId(Guid id) : base(id) { }
    }
}