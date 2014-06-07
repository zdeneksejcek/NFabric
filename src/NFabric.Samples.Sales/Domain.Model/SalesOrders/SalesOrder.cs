using System;
using System.Collections.Generic;
using NFabric.Samples.Sales.Domain.Model.DeliveryMethods;
using NFabric.Samples.Sales.Port;
using NFabric.Samples.Sales.Domain.Model.Customers;
using NFabric.Samples.Sales.Domain.Model.SalesOrders.Snapshot;
using NFabric.Samples.Sales.Events.SalesOrder;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    public class SalesOrder : AggregateWithES
	{
		private CustomerId Customer { get; set; }

        private WarehouseId Warehouse { get; set; }

        private DeliveryMethodId DeliveryMethod { get; set; }

        public SalesOrderLines Lines { get; private set; }

        public Invoices Invoices { get; private set; }

        public Shipments Shipments { get; private set; }

        #region constructors
        public SalesOrder(CustomerId customer, WarehouseId warehouse)
		{
            Id = Guid.NewGuid();
            Init();
            Events.Update(
                new SalesOrderCreated(Id, customer.Id, warehouse.Id));
		}

        public SalesOrder(Guid id, IEnumerable<SequencedEvent> events) {
            Id = id;
            Init();

            base.Events.UpdateCommited(events);
        }

        public SalesOrder(SalesOrderSnapshot snapshot, IEnumerable<SequencedEvent> events) {
            Init();

            base.Events.UpdateCommited(events);
        }

        private void Init() {
            InitHandlers();

            Lines = new SalesOrderLines(base.Events, () => base.Id);
            Invoices = new Invoices(base.Events, () => base.Id);
            Shipments = new Shipments(base.Events, () => base.Id);
        }
        #endregion

        #region event handlers

        private void InitHandlers() {
            Events.Handles<SalesOrderCreated>(e => {
                Id = e.SalesOrderId;
                Customer = new CustomerId(e.Customer);
                Warehouse = new WarehouseId(e.Warehouse);
            });

            Events.Handles<SalesOrderWarehouseChanged>(
                e => Warehouse = new WarehouseId(e.Warehouse));

            Events.Handles<SalesOrderDeliveryMethodChanged>(
                e => DeliveryMethod = new DeliveryMethodId(e.DeliveryMethod));
        }

        public void ChangeWarehouse(WarehouseId warehouse)
        {
            Events.Update(new SalesOrderWarehouseChanged(warehouse.Id));
        }

        public void ChangeDeliveryMethod(DeliveryMethodId method)
        {
            Events.Update(new SalesOrderDeliveryMethodChanged(method.Id));
        }

        #endregion
	}
}