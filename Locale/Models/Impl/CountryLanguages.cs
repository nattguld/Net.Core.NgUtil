using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace NgUtil.Locale.Models.Impl {
    public class CountryLanguages : CountryModel {

        [JsonPropertyName("languages")]
#pragma warning disable CA1819 // Properties should not return arrays
        public Language[] Languages {
#pragma warning restore CA1819 // Properties should not return arrays
            get {
                return (Language[])Languages.Clone();
            }
            private set {
                Languages = value;
            }
        }

        /*public Language[] GetLanguages() {
             return (Language[])Languages.Clone();
         }*/

    }
}
