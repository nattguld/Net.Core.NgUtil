using NgUtil.Debugging.Contracts;
using System;
using System.Text.Json.Serialization;

namespace NgUtil.Locale.Models.Impl {
    public sealed class Country {

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("iso_code")]
        public string IsoCode { get; set; }


        public bool Equals(Country other) {
            EmptyParamContract.Validate(other != null);
            return Name.Equals(other.Name, StringComparison.Ordinal) 
                && IsoCode.Equals(other.IsoCode, StringComparison.Ordinal);
        }

        public override string ToString() {
            return Name;
        }

    }

}
