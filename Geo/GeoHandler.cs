using NgUtil.Debugging.Contracts;
using NgUtil.Files.IO;
using NgUtil.Geo.Location;
using NgUtil.Geo.Models;
using NgUtil.Locale;
using NgUtil.Locale.Models.Impl;
using NgUtil.Maths.Ranges.Impl;
using NgUtil.Text;
using System;
using System.Collections.Generic;

namespace NgUtil.Geo {
    public static class GeoHandler {

        public static readonly Country DefaultCountry = LocaleManager.GetCountryByIsoCode("us");
        public static readonly GeoCoordinates DefaultGeoCoords = new GeoCoordinates(34.033470, -118.245853); //LA
        public static readonly StateRegion DefaultState = new StateRegion("California", "CA");
        public static readonly City DefaultCity = new City("Los Angeles", DefaultGeoCoords, DefaultState, "90002", EAreaSize.Metropol);
        public static readonly GeoPosition DefaultGeoPos = new GeoPosition(DefaultCountry, DefaultCity, DefaultGeoCoords);

        private static readonly List<CountryCities> CountryCities = new List<CountryCities>();


        public static GeoCoordinates Shift(GeoCoordinates geoCoords, double shiftRadius, bool returnNewInstance = false) {
            return Shift(geoCoords, -shiftRadius, shiftRadius, returnNewInstance);
        }

        public static GeoCoordinates Shift(GeoCoordinates geoCoords, double minShift, double maxShift, bool returnNewInstance = false) {
            EmptyParamContract.Validate(geoCoords);

            double shiftedLat = geoCoords.Latitude + new DoubleRange(minShift, maxShift).GetRandom();
            double shiftedLon = geoCoords.Longitude + new DoubleRange(minShift, maxShift).GetRandom();
            
            if (returnNewInstance) {
                return new GeoCoordinates(shiftedLat, shiftedLon);
            }
            geoCoords.SetLatitude(shiftedLat);
            geoCoords.SetLongitude(shiftedLon);
            return geoCoords;
        }

        public static City GetCityFormName(Country country, string cityName) {
            EmptyParamContract.Validate(cityName);
            return GetCityForName(country, cityName, DefaultGeoCoords);
        }

        public static City GetCityForName(Country country, string cityName, GeoCoordinates fallbackCoords) {
            CountryCities cs = GetCountryCities(country);

            EmptyParamContract.Validate(cs);
            EmptyParamContract.Validate(cityName);

            foreach (City city in cs.Cities) {
                if (StringLocale.EqualsIgnoreCase(city.Name, cityName)) {
                    return city;
                }
            }
            Console.WriteLine("City not found => [City: " + cityName + "][Country: " + country.Name + "]");
            return new City(cityName, fallbackCoords, DefaultState, "90002", EAreaSize.Village);
        }

        public static CountryCities GetCountryCities(Country country) {
            EmptyParamContract.Validate(country);

            if (CountryCities.Count == 0) {
                JsonIO.LoadJsonResources(Resources.country_cities, CountryCities);
            }
            foreach (CountryCities cc in CountryCities) {
                if (cc.CountryCode.Equals(country.IsoCode, StringComparison.OrdinalIgnoreCase)) {
                    return cc;
                }
            }
            Console.WriteLine("No cities found for country => " + country.Name);
            return null;
        }

    }
}
