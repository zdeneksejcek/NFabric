using System;
using OpenDDD.Common;

namespace NFabric.Samples.Sales
{
    public class SalesOrderId : IdValueObject
    {
        public SalesOrderId() : base() { }
        public SalesOrderId(Guid id) : base(id) { }
    }
}