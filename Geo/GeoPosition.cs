using NgUtil.Geo.Location;
using NgUtil.Locale.Models.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Geo {
    public sealed class GeoPosition {

        public Country Country { get; }

        public City City { get; }

        public GeoCoordinates GeoCoords { get; }


        public GeoPosition(Country country, City city, GeoCoordinates geoCoords) {
            Country = country;
            City = city;
            GeoCoords = geoCoords;
        }

    }
}
