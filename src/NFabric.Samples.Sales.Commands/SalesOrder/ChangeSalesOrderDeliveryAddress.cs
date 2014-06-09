using System;

namespace NFabric.Samples.Sales.Commands.SalesOrder
{
    [Serializable]
    public class ChangeSalesOrderDeliveryAddress
    {
        public Guid SalesOrder { get; private set; }

        public string AddressName { get; private set; }

        public string Street { get; private set; }

        public string Suburb { get; private set; }

        public string City { get; private set; }

        public string StateRegion { get; private set; }

        public string PostCode { get; private set; }

        public string Country { get; private set; }

        public ChangeSalesOrderDeliveryAddress(Guid salesOrder, string addressName, string street, string suburb, string city, string stateRegion, string postCode, string country)
        {
            SalesOrder = salesOrder;

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
