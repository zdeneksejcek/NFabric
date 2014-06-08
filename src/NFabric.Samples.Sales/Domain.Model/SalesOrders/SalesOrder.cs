using System;
using System.Collections.Generic;
using NFabric.Samples.Sales.Domain.Model.DeliveryMethods;
using NFabric.Samples.Sales.Port;
using NFabric.Samples.Sales.Domain.Model.Customers;
using NFabric.Samples.Sales.Events.SalesOrder;
using NFabric.BoundedContext.Domain;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrders
{
    [Serializable]
    public class SalesOrder : AggregateWithES
	{
		private CustomerId Customer { get; set; }

        private WarehouseId Warehouse { get; set; }

        private DeliveryMethodId DeliveryMethod { get; set; }

        public SalesOrderLines Lines { get; private set; }

        //public Invoices Invoices { get; private set; }

        //public Shipments Shipments { get; private set; }

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

            Events.UpdateCommited(events);
        }

        public SalesOrder(IEnumerable<SequencedEvent> events) {
            Init();

            Events.UpdateCommited(events);
        }

        private void Init()
        {
            InitializeEventHandlers();

            Lines = new SalesOrderLines(() => this);
            //Invoices = new Invoices(() => this);
            //Shipments = new Shipments(() => this);
        }
        #endregion

        #region event handlers

        public void ChangeWarehouse(WarehouseId warehouse)
        {
            Events.Update(new SalesOrderWarehouseChanged(warehouse.Id));
        }

        public void ChangeDeliveryMethod(DeliveryMethodId method)
        {
            Events.Update(new SalesOrderDeliveryMethodChanged(method.Id));
        }

        #endregion

        protected override void InitializeEventHandlers()
        {
            Events.Handles<SalesOrderCreated>(e =>
            {
                Id = e.SalesOrderId;
                Customer = new CustomerId(e.Customer);
                Warehouse = new WarehouseId(e.Warehouse);
            });

            Events.Handles<SalesOrderWarehouseChanged>(
                e => Warehouse = new WarehouseId(e.Warehouse));

            Events.Handles<SalesOrderDeliveryMethodChanged>(
                e => DeliveryMethod = new DeliveryMethodId(e.DeliveryMethod));
        }
    }
}