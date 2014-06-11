using System;
using NFabric.Contracts;

namespace NFabric.Samples.Sales.Events.SalesOrder
{
    [Serializable]
    public class SalesOrderDeliveryAddressChanged : IAggregateEvent
    {
        public string AddressName { get; private set; }

        public string Street { get; private set; }

        public string Suburb { get; private set; }

        public string City { get; private set; }

        public string StateRegion { get; private set; }

        public string PostCode { get; private set; }

        public string Country { get; private set; }

        public SalesOrderDeliveryAddressChanged(string addressName, string street, string suburb, string city, string stateRegion, string postCode, string country)
        {
            AddressName = addressName;
            Street = street;
            Suburb = suburb;
            City = city;
            StateRegion = stateRegion;
            PostCode = postCode;
            Country = country;
        }
    }
}
