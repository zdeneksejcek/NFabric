using System;
using OpenDDD.Common;

namespace NFabric.Samples.Sales.Domain.Model
{
    public class LineQuantity : GenericValueObject<int>
    {
        public int Quantity { get { return base.Value; } }

        public LineQuantity(int quantity) : base(quantity)
        {
            if (quantity < 1)
                throw new LineMustbePositive();
        }
    }

    public class LineMustbePositive : Exception {

    }
}