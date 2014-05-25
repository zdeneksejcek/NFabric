using System;

namespace NFabric.Samples.Sales.Domain.Model.Customers
{
    public interface ICustomerRepository
    {
        Customer GetBy(Guid id);
        void Save(Customer customer);
    }
}