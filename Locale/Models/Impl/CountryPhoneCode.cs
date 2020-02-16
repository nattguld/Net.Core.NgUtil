using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NgUtil.Locale.Models.Impl {
    public class CountryPhoneCode : CountryModel {

        [DataMember(Name = "phone_code")]
        public int PhoneCode { get; }


        public CountryPhoneCode(string countryCode, string countryName, int phoneCode) : base(countryCode, countryName) {
            PhoneCode = phoneCode;
        }

    }
}
