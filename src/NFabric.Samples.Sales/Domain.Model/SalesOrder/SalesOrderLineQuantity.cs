using System;
using OpenDDD.Common;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrder
{
    public class SalesOrderLineQuantity : GenericValueObject<int>
    {
        public int Quantity { get { return base.Value; }}

        public SalesOrderLineQuantity(int quantity) : base(quantity) { }
    }
}

