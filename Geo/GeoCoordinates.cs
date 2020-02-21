using NgUtil.Debugging.Contracts;
using NgUtil.Maths;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Geo {
    public sealed class GeoCoordinates {

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }


        public GeoCoordinates(double latitude, double longitude) {
            SetLatitude(latitude);
            SetLongitude(longitude);
        }

        public GeoCoordinates SetLatitude(double latitude) {
            Latitude = MathUtil.FormatDoubleDecimals(latitude, 6);
            return this;
        }

        public GeoCoordinates SetLongitude(double longitude) {
            Longitude = MathUtil.FormatDoubleDecimals(longitude, 6);
            return this;
        }

        public bool Equals(GeoCoordinates other) {
            EmptyParamContract.Validate(other);
            return other.Latitude == Latitude && other.Longitude == Longitude;
        }

        public override string ToString() {
            return "[Lat: " + Latitude + ", Lon: " + Longitude + "]";
        }

    }
}
