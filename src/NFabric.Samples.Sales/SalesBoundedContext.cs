using System;
using NFabric.BoundedContext;
using System.Collections.Generic;
using System.Linq;

namespace NFabric.Samples.Sales
{
    public class SalesBoundedContext : IBoundedContextDescriptor
    {
        private const string BC_NAME = "Sales";

        public IList<MessageDescriptorWithType> GetMessageDescriptors()
        {
            var eventTypes = typeof(NFabric.Samples.Sales.Events.SalesOrder.SalesOrderCreated).Assembly.GetExportedTypes();
            var commandTypes = typeof(NFabric.Samples.Sales.Commands.SalesOrder.CreateSalesOrder).Assembly.GetExportedTypes();

            var eventDescriptions = eventTypes.Select(p => Create("event", p));
            var commandDescriptions = commandTypes.Select(p => Create("command", p));

            return eventDescriptions.Concat(commandDescriptions).ToList();
        }

        private static MessageDescriptorWithType Create(string messageName, Type type) {
            return new MessageDescriptorWithType(messageName, type.Name, BC_NAME, type);
        }

    }
}