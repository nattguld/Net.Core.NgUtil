using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NgUtil.Locale.Models.Impl {
    public class CountryLanguages : CountryModel {

        [DataMember(Name = "languages")]
        public Language[] Languages { get; }


        public CountryLanguages(string countryCode, string countryName, Language[] languages) : base(countryCode, countryName) {
            Languages = languages;
        }

    }
}
