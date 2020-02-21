using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace NgUtil.Locale.Models.Impl {
    public class CountryPhoneCode : CountryModel {

        [JsonPropertyName("phone_code")]
        public int PhoneCode { get; }

    }
}
