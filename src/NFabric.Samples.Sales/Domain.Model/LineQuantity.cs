using System;

namespace NFabric.Samples.Sales.Domain.Model
{
    public class LineQuantity
    {
        public int Quantity { get; private set;}

        public LineQuantity(int quantity)
        {
            if (quantity < 1)
                throw new LineMustbePositive();
        }
    }

    public class LineMustbePositive : Exception {

    }
}