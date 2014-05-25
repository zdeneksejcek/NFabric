using System;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public interface ISalesOrderRepository
    {
        SalesOrder GetBy(Guid id);
        void Save(SalesOrder order);
    }
}