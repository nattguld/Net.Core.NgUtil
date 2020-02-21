
namespace NgUtil.Geo.Location {
    public sealed class City {

        public string Name { get; }

        public GeoCoordinates GeoCoords { get; }

        public EAreaSize AreaSize { get; }

        public StateRegion StateRegion { get; }

        public string PostalCode { get; }


        public City(string name, GeoCoordinates geoCoords, StateRegion stateRegion, string postalCode) 
            : this (name, geoCoords, stateRegion, postalCode, EAreaSize.Village) { }

        public City(string name, GeoCoordinates geoCoords, StateRegion stateRegion, string postalCode, EAreaSize areaSize) {
            Name = name;
            GeoCoords = geoCoords;
            StateRegion = stateRegion;
            PostalCode = postalCode;
            AreaSize = areaSize;
        }

        public override string ToString() {
            return Name;
        }

    }
}
