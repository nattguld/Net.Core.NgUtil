using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Locale {
    public class Country {

        public string Name { get; }

        public string IsoCode { get; }


        public Country(string name, string isoCode) {
            Name = name;
            IsoCode = isoCode;
        }

    }

}
