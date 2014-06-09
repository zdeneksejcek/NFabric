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

        private SalesOrderDeliveryAddress Address { get; set; }

        private DateTimeUtc OrderDate { get; set; }

        private DateTimeUtc QuotaExpiryDate { get; set; }

        private DateTimeUtc RequiredDate { get; set; }

        private string Comments { get; set; }

        public SalesOrderLines Lines { get; private set; }

        private Invoices Invoices { get; set; }

        private Shipments Shipments { get; set; }

        #region constructors
        public SalesOrder(CustomerId customer, WarehouseId warehouse, DateTimeUtc orderDate, DateTimeUtc quoteExpiryDate, DateTimeUtc requiredDate)
		{
            Init();

            Events.Update(
                new SalesOrderCreated(
                    Guid.NewGuid(),
                    customer.Id,
                    warehouse.Id,
                    orderDate.Value,
                    quoteExpiryDate.Value,
                    requiredDate.Value));
		}

        public SalesOrder(IEnumerable<SequencedEvent> events) {
            Init();

            Events.UpdateCommited(events);
        }

        private void Init()
        {
            InitializeEventHandlers();

            Address = new SalesOrderDeliveryAddress();
            Lines = new SalesOrderLines(() => this);
            Invoices = new Invoices(() => this);
            Shipments = new Shipments(() => this);
        }
        #endregion

        #region public commands

        public void ChangeWarehouse(WarehouseId warehouse)
        {
            Events.Update(new SalesOrderWarehouseChanged(warehouse.Id));
        }

        public void ChangeComments(string comments)
        {
            Events.Update(new SalesOrderCommentsChanged(comments));
        }

        public void ChangeDeliveryMethod(DeliveryMethodId method)
        {
            Events.Update(new SalesOrderDeliveryMethodChanged(method.Id));
        }

        public void ChangeDeliveryAddress(SalesOrderDeliveryAddress newAddress)
        {
            Events.Update(
                new SalesOrderDeliveryAddressChanged(
                        newAddress.AddressName,
                        newAddress.Street,
                        newAddress.Suburb,
                        newAddress.City,
                        newAddress.StateRegion,
                        newAddress.PostCode,
                        newAddress.Country
                    ));
        }

        public void ChangeOrderDate(DateTimeUtc utc)
        {
            Events.Update(
                new SalesOrderDateChanged(utc.Value));
        }

        public void ChangeQuotaExpiryDate(DateTimeUtc utc)
        {
            Events.Update(
                new SalesOrderQuoteExpiryDateChanged(utc.Value));
        }

        public void ChangeRequiredDate(DateTimeUtc utc)
        {
            Events.Update(
                new SalesOrderRequiredDateChanged(utc.Value));
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

            Events.Handles<SalesOrderDeliveryAddressChanged>(
                e => Address = new SalesOrderDeliveryAddress(e.AddressName, e.Street, e.Suburb, e.City, e.StateRegion, e.PostCode, e.Country));

            Events.Handles<SalesOrderDateChanged>(
                e => OrderDate = new DateTimeUtc(e.RequiredDate));

            Events.Handles<SalesOrderQuoteExpiryDateChanged>(
                e => QuotaExpiryDate = new DateTimeUtc(e.QuotaExpiryDate));

            Events.Handles<SalesOrderRequiredDateChanged>(
                e => RequiredDate = new DateTimeUtc(e.RequiredDate));

            Events.Handles<SalesOrderCommentsChanged>(
                e => Comments = e.Comments);
        }
    }
}