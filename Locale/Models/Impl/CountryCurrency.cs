using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace NgUtil.Locale.Models.Impl {
    public class CountryCurrency : CountryModel {

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; }

        [JsonPropertyName("usd_modifier")]
        public double UsdModifier { get; }

        [JsonPropertyName("currency_symbol")]
        public string CurrencySymbol { get; }

    }
}
