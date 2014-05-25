using System;
using NFabric.Samples.Sales.Domain.Model.Credits;

namespace NFabric.Samples.Sales.Port.Infrastructure
{
    public class CreditRepository : ICreditRepository
    {
        public CreditRepository()
        {
        }

        public Credit GetBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Credit credit)
        {
            throw new NotImplementedException();
        }
    }
}