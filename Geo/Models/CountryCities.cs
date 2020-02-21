using NgUtil.Debugging.Contracts;
using NgUtil.Geo.Location;
using NgUtil.Locale.Models;
using NgUtil.Maths;
using System.Text.Json.Serialization;

namespace NgUtil.Geo.Models {
    public sealed class CountryCities : CountryModel {

        [JsonPropertyName("cities")]
#pragma warning disable CA1819 // Properties should not return arrays
        public City[] Cities {
#pragma warning restore CA1819 // Properties should not return arrays
            get {
                return (City[])Cities.Clone();
            }
            private set {
                Cities = value;
            }
        }

        public City GetRandomCity() {
            EmptyParamContract.Validate(Cities != null && Cities.Length > 0);
            return Cities[MathUtil.Random(Cities.Length)];
        }

    }
}
