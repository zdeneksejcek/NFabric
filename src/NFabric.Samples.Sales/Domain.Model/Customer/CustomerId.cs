using System;
using OpenDDD.Common;

namespace NFabric.Samples.Sales
{
    public class CustomerId : IdValueObject
    {
        public CustomerId(Guid id) : base(id) {}
    }
}