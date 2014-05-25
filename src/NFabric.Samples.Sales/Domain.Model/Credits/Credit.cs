using System;
using OpenDDD.EventSourcing;

namespace NFabric.Samples.Sales.Domain.Model.Credits
{
    public class Credit : AggregateWithES
    {
        public CreditLines Lines { get; private set; }

        public Credit()
        {
        }
    }
}

