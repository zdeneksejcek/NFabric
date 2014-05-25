using System;
using NFabric.Samples.Sales.Domain.Model.Customers;

namespace NFabric.Samples.Sales.Port.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository()
        {
        }

        public Customer GetBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}

