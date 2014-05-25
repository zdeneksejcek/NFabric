using System;

namespace NFabric.Samples.Sales.Domain.Model.Credits
{
    public interface ICreditRepository
    {
        Credit GetBy(Guid id);
        void Save(Credit credit);
    }
}