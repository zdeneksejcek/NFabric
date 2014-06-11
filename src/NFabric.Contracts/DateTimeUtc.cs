using System;

namespace NFabric.Contracts
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
