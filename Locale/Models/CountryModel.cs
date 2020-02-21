using NgUtil.Debugging.Contracts;
using System;
using System.Text.Json.Serialization;

namespace NgUtil.Locale.Models {
    public abstract class CountryModel {

        [JsonPropertyName("country_code")]
        public string CountryCode { get; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; }


        public bool Equals(CountryModel other) {
            EmptyParamContract.Validate(other != null);
            return CountryCode.Equals(other.CountryCode, StringComparison.Ordinal)
                && CountryName.Equals(other.CountryName, StringComparison.Ordinal);
        }

    }
}
