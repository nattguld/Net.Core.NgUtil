using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Locale {
    public class Language {

        public string Name { get; }

        public string IsoCode { get; }


        public Language(string name, string isoCode) {
            Name = name;
            IsoCode = isoCode;
        }

    }
}
