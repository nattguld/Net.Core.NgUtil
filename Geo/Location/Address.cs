using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Geo.Location {
    public sealed class Address {

        public City City { get; }

        public string Street { get; }

        public string StreetNumber { get; }


        public Address(City city, string street, string streetNumber) {
            City = city;
            Street = street;
            StreetNumber = streetNumber;
        }

        public override string ToString() {
            return Street + " " + StreetNumber + ", " + City.PostalCode + " " + City.Name + ", " + City.StateRegion.Name;
        }

    }

}
