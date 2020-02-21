using NgUtil.Debugging.Contracts;
using NgUtil.Files.IO;
using NgUtil.Locale.Models.Impl;
using NgUtil.Maths;
using System;
using System.Collections.Generic;

namespace NgUtil.Locale {
    public static class LocaleManager {

        private static readonly List<Language> Languages = new List<Language>();

        private static readonly List<Country> Countries = new List<Country>();

        private static readonly List<CountryLanguages> CountryLanguages = new List<CountryLanguages>();

        private static readonly List<CountryCurrency> CountryCurrencies = new List<CountryCurrency>();

        private static readonly List<CountryPhoneCode> CountryPhoneCodes = new List<CountryPhoneCode>();


        public static Language GetLanguageByIsoCode(string isoCode) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(isoCode));

            if (Languages.Count == 0) {
                LoadLanguages();
            }
            foreach (Language lang in Languages) {
                if (lang.IsoCode.Equals(isoCode, StringComparison.OrdinalIgnoreCase)) {
                    return lang;
                }
            }
            throw new Exception("Language not found for ISO code: " + isoCode);
        }

        public static Language GetLanguageByName(string name) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(name));

            if (Languages.Count == 0) {
                LoadLanguages();
            }
            foreach (Language lang in Languages) {
                if (lang.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) {
                    return lang;
                }
            }
            throw new Exception("Language not found for name: " + name);
        }

        public static Country GetCountryByIsoCode(string isoCode) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(isoCode));

            if (Countries.Count == 0) {
                LoadCountries();
            }
            foreach (Country cr in Countries) {
                if (cr.IsoCode.Equals(isoCode, StringComparison.OrdinalIgnoreCase)) {
                    return cr;
                }
            }
            throw new Exception("Language not found for ISO code: " + isoCode);
        }

        public static Country GetCountryByName(string name) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(name));

            if (Countries.Count == 0) {
                LoadCountries();
            }
            foreach (Country cr in Countries) {
                if (cr.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) {
                    return cr;
                }
            }
            throw new Exception("Language not found for name: " + name);
        }

        public static Language[] GetCountryLanguages(Country cr) {
            EmptyParamContract.Validate(cr != null);

            if (CountryLanguages.Count == 0) {
                LoadCountryLanguages();
            }
            foreach (CountryLanguages cls in CountryLanguages) {
                if (cls.CountryCode.Equals(cr.IsoCode, StringComparison.OrdinalIgnoreCase)) {
                    return cls.Languages;
                }
            }
            throw new Exception("No country languages found for country: " + cr.Name);
        }

        public static bool CountryHasLanguage(Country cr, Language lang) {
            EmptyParamContract.Validate(cr != null && lang != null);

            foreach (Language crLang in GetCountryLanguages(cr)) {
                if (crLang == lang) {
                    return true;
                }
            }
            return false;
        }

        public static Language GetRandomCountryLanguage(Country cr) {
            EmptyParamContract.Validate(cr != null);

            Language[] langs = GetCountryLanguages(cr);
            return langs[MathUtil.Random(langs.Length)];
        }

        public static List<Country> GetCountriesUsingLanguage(Language lang) {
            EmptyParamContract.Validate(lang != null);

            List<Country> crs = new List<Country>();

            foreach (Country cr in Countries) {
                if (CountryHasLanguage(cr, lang)) {
                    crs.Add(cr);
                }
            }
            return crs;
        }

        public static string GetLocaleCode(Country cr, Language lang) {
            EmptyParamContract.Validate(cr != null && lang != null);
            return lang.IsoCode + "-" + cr.IsoCode;
        }

        public static string GetRandomBrowserLocaleValue(Country cr) {
            EmptyParamContract.Validate(cr != null);
            return GetBrowserLocaleValue(cr, GetRandomCountryLanguage(cr));
        }

        public static string GetBrowserLocaleValue(Country cr, Language lang) {
            EmptyParamContract.Validate(cr != null && lang != null);
            return GetLocaleCode(cr, lang) + "," + lang.IsoCode + ";q=0.9";
        }

        public static CountryPhoneCode GetCountryPhoneCode(Country cr) {
            EmptyParamContract.Validate(cr != null);

            if (CountryPhoneCodes.Count == 0) {
                LoadCountryPhoneCodes();
            }
            foreach (CountryPhoneCode cpc in CountryPhoneCodes) {
                if (cpc.CountryCode.Equals(cr.IsoCode, StringComparison.OrdinalIgnoreCase)) {
                    return cpc;
                }
            }
            throw new Exception("No country phone code found for country: " + cr.Name);
        }

        public static CountryCurrency GetCountryCurrency(Country cr) {
            EmptyParamContract.Validate(cr != null);

            if (CountryCurrencies.Count == 0) {
                LoadCountryCurrencies();
            }
            foreach (CountryCurrency cc in CountryCurrencies) {
                if (cc.CountryCode.Equals(cr.IsoCode, StringComparison.OrdinalIgnoreCase)) {
                    return cc;
                }
            }
            throw new Exception("No country currency found for country: " + cr.Name);
        }

        private static void LoadCountryPhoneCodes() {
            //LoadJsonResource("country_phone_codes.json", COUNTRY_PHONE_CODES);
            JsonIO.LoadJsonResources(Resources.country_phone_codes, CountryPhoneCodes);
        }

        private static void LoadCountryCurrencies() {
            //LoadJsonResource("country_currencies.json", COUNTRY_CURRENCIES);
            JsonIO.LoadJsonResources(Resources.country_currencies, CountryCurrencies);
        }

        private static void LoadCountries() {
            //LoadJsonResource("countries.json", COUNTRIES);
            JsonIO.LoadJsonResources(Resources.countries, Countries);
        }

        private static void LoadLanguages() {
            //LoadJsonResource("languages.json", LANGUAGES);
            JsonIO.LoadJsonResources(Resources.languages, Languages);
        }

        private static void LoadCountryLanguages() {
            JsonIO.LoadJsonResources(Resources.country_languages, CountryLanguages);
        }

    }
}
