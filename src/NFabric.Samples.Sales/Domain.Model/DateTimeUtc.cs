using System;

namespace NFabric.Samples.Sales.Domain.Model
{
    public class DateTimeUtc
    {
        public DateTime Value { get; private set; }

        public DateTimeUtc(DateTime dt)
        {
            if (dt.Kind != DateTimeKind.Utc)
                throw new Exception();

            Value = dt;
        }

    }
}
