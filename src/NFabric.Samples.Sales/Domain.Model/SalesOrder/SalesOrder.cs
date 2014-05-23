using System;
using OpenDDD.EventSourcing;
using System.Collections.Generic;
using OpenDDD;
using NFabric.Samples.Sales.Domain.Model.SalesOrder.Events;
using NFabric.Samples.Sales.Port;

namespace NFabric.Samples.Sales.Domain.Model.SalesOrder
{
	public class SalesOrder : AggregateWithES
	{
		private CustomerId Customer { get; set; }

        public SalesOrder(CustomerId customer)
		{
            Id = Guid.NewGuid();
            InitHandlers();

            Events.Update(
                new SalesOrderCreated(
                    new SalesOrderId(),
                    customer
            ));
		}

        public SalesOrder(Guid id, IEnumerable<Event> events) {
            Id = id;
            InitHandlers();

            base.Events.UpdateCommited(events);
        }

        public void AddLine(ProductId product, SalesOrderLineQuantity quantity) {
            base.Events.Update(
                new SalesOrderLineAdded(Id, product, quantity));
        }

        #region event handlers

        private void InitHandlers() {
            base.Events.Handles<SalesOrderCreated>(Id,this.Apply);
        }

		private void Apply(SalesOrderCreated @event)
        {
            Customer = @event.Customer;
		}

        private void Apply(SalesOrderLineAdded @event)
        {

        }

        #endregion
	}
}