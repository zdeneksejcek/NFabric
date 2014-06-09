using System;

namespace NFabric.Samples.Sales.Commands
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
