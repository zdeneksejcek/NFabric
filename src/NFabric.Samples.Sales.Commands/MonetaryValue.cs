using System;
using System.Diagnostics;

namespace NFabric.Samples.Sales.Commands
{
    public class MonetaryValue
    {
        public decimal Amount { get; private set; }

        public string Currency { get; private set; }

        public MonetaryValue(decimal amount, string currency)
        {
            Validate(currency);

            Amount = amount;
            Currency = currency;
        }

        private void Validate(string currency)
        {
            if (currency == null && currency.Length != 3 && currency.ToUpper() != currency)
                throw new CurrencyNameExpected();
        }

        public class CurrencyNameExpected : Exception
        {
            
        }
    }
}
