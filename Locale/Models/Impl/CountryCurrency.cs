using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NgUtil.Locale.Models.Impl {
    public class CountryCurrency : CountryModel {

        [DataMember(Name = "currency_code")]
        public string CurrencyCode { get; }

        [DataMember(Name = "usd_modifier")]
        public double UsdModifier { get; }

        [DataMember(Name = "currency_symbol")]
        public string CurrencySymbol { get; }


        public CountryCurrency(string countryCode, string countryName, string currencyCode
            , double usdModifier, string currencySymbol) : base(countryCode, countryName) {
            CurrencyCode = currencyCode;
            UsdModifier = usdModifier;
            CurrencySymbol = currencySymbol;
        }

    }
}
