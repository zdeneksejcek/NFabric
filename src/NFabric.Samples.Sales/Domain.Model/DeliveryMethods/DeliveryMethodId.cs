using System;

namespace NFabric.Samples.Sales.Domain.Model.DeliveryMethods
{
    [Serializable]
    public class DeliveryMethodId
    {
        public Guid Id { get; private set; }

        public DeliveryMethodId(Guid id)
        {
            Id = id;
        }
    }
}
