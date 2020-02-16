using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NgUtil.Locale.Models {
    public abstract class CountryModel {

        [DataMember(Name = "country_code")]
        public string CountryCode { get; }

        [DataMember(Name = "country_name")]
        public string CountryName { get; }


        public CountryModel(string countryCode, string countryName) {
            CountryCode = countryCode;
            CountryName = countryName;
        }

    }
}
