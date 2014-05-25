using System;
using NFabric.Samples.Sales.Domain.Model.SalesOrders;

namespace NFabric.Samples.Sales.Port.Infrastructure
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        public SalesOrderRepository()
        {

        }

        public SalesOrder GetBy(Guid id)
        {
            //var so = new SalesOrder(id

            throw new NotImplementedException();
        }

        public void Save(SalesOrder order)
        {
            throw new NotImplementedException();
        }
    }
}