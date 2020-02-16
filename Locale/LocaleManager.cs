using NgUtil.Locale.Models.Impl;
using NgUtil.Maths;
using NgUtil.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utf8Json;

namespace NgUtil.Locale {
    public static class LocaleManager {

        private static readonly List<Language> LANGUAGES = new List<Language>();

        private static readonly List<Country> COUNTRIES = new List<Country>();

        private static readonly List<CountryLanguages> COUNTRY_LANGUAGES = new List<CountryLanguages>();

        private static readonly List<CountryCurrency> COUNTRY_CURRENCIES = new List<CountryCurrency>();

        private static readonly List<CountryPhoneCode> COUNTRY_PHONE_CODES = new List<CountryPhoneCode>();


        public static Language GetLanguageByIsoCode(string isoCode) {
            if (LANGUAGES.Count == 0) {
                LoadLanguages();
            }
            foreach (Language lang in LANGUAGES) {
                if (TextUtil.EqualsIgnoreCase(lang.IsoCode, isoCode)) {
                    return lang;
                }
            }
            throw new Exception("Language not found for ISO code: " + isoCode);
        }

        public static Language GetLanguageByName(string name) {
            if (LANGUAGES.Count == 0) {
                LoadLanguages();
            }
            foreach (Language lang in LANGUAGES) {
                if (TextUtil.EqualsIgnoreCase(lang.Name, name)) {
                    return lang;
                }
            }
            throw new Exception("Language not found for name: " + name);
        }

        public static Country GetCountryByIsoCode(string isoCode) {
            if (COUNTRIES.Count == 0) {
                LoadCountries();
            }
            foreach (Country cr in COUNTRIES) {
                if (TextUtil.EqualsIgnoreCase(cr.IsoCode, isoCode)) {
                    return cr;
                }
            }
            throw new Exception("Language not found for ISO code: " + isoCode);
        }

        public static Country GetCountryByName(string name) {
            if (COUNTRIES.Count == 0) {
                LoadCountries();
            }
            foreach (Country cr in COUNTRIES) {
                if (TextUtil.EqualsIgnoreCase(cr.Name, name)) {
                    return cr;
                }
            }
            throw new Exception("Language not found for name: " + name);
        }

        public static Language[] GetCountryLanguages(Country cr) {
            if (COUNTRY_LANGUAGES.Count == 0) {
                LoadCountryLanguages();
            }
            foreach (CountryLanguages cls in COUNTRY_LANGUAGES) {
                if (TextUtil.EqualsIgnoreCase(cls.CountryCode, cr.IsoCode)) {
                    return cls.Languages;
                }
            }
            throw new Exception("No country languages found for country: " + cr.Name);
        }

        public static bool CountryHasLanguage(Country cr, Language lang) {
            foreach (Language crLang in GetCountryLanguages(cr)) {
                if (crLang == lang) {
                    return true;
                }
            }
            return false;
        }

        public static Language GetRandomCountryLanguage(Country cr) {
            Language[] langs = GetCountryLanguages(cr);
            return langs[MathUtil.Random(langs.Length)];
        }

        public static List<Country> GetCountriesUsingLanguage(Language lang) {
            List<Country> crs = new List<Country>();

            foreach (Country cr in COUNTRIES) {
                if (CountryHasLanguage(cr, lang)) {
                    crs.Add(cr);
                }
            }
            return crs;
        }

        public static string GetLocaleCode(Country cr, Language lang) {
            return lang.IsoCode + "-" + cr.IsoCode;
        }

        public static string GetRandomBrowserLocaleValue(Country cr) {
            return GetBrowserLocaleValue(cr, GetRandomCountryLanguage(cr));
        }

        public static string GetBrowserLocaleValue(Country cr, Language lang) {
            return GetLocaleCode(cr, lang) + "," + lang.IsoCode + ";q=0.9";
        }

        public static CountryPhoneCode GetCountryPhoneCode(Country cr) {
            if (COUNTRY_PHONE_CODES.Count == 0) {
                LoadCountryPhoneCodes();
            }
            foreach (CountryPhoneCode cpc in COUNTRY_PHONE_CODES) {
                if (TextUtil.EqualsIgnoreCase(cpc.CountryCode, cr.IsoCode)) {
                    return cpc;
                }
            }
            throw new Exception("No country phone code found for country: " + cr.Name);
        }

        public static CountryCurrency GetCountryCurrency(Country cr) {
            if (COUNTRY_CURRENCIES.Count == 0) {
                LoadCountryCurrencies();
            }
            foreach (CountryCurrency cc in COUNTRY_CURRENCIES) {
                if (TextUtil.EqualsIgnoreCase(cc.CountryCode, cr.IsoCode)) {
                    return cc;
                }
            }
            throw new Exception("No country currency found for country: " + cr.Name);
        }

        private static void LoadCountryPhoneCodes() {
            //LoadJsonResource("country_phone_codes.json", COUNTRY_PHONE_CODES);
            LoadJsonResource(NgUtil.Resources.country_phone_codes, COUNTRY_PHONE_CODES);
        }

        private static void LoadCountryCurrencies() {
            //LoadJsonResource("country_currencies.json", COUNTRY_CURRENCIES);
            LoadJsonResource(NgUtil.Resources.country_currencies, COUNTRY_CURRENCIES);
        }

        private static void LoadCountries() {
            //LoadJsonResource("countries.json", COUNTRIES);
            //LoadJsonResource(NgUtil.Resources.countries, COUNTRIES);
        }

        private static void LoadLanguages() {
            //LoadJsonResource("languages.json", LANGUAGES);
            //LoadJsonResource(NgUtil.Resources.languages, LANGUAGES);
        }

        private static void LoadCountryLanguages() {
            //LoadJsonResource("country_languages.json", COUNTRY_LANGUAGES);
            LoadJsonResource(NgUtil.Resources.country_languages, COUNTRY_LANGUAGES);
        }

        private static void LoadJsonResource<T>(byte[] resource, List<T> list) {
           /* string savePath = Path.Combine(Environment.CurrentDirectory, @"Resources\Data\", fileName);

            if (!File.Exists(savePath)) {
                throw new Exception("Json resource not found: " + savePath);
            }
            string json = File.ReadAllText(savePath);

            if (string.IsNullOrEmpty(json)) {
                throw new Exception("Json resource has no content: " + savePath);
            }*/
            list.Clear();

            foreach (T element in JsonSerializer.Deserialize<T[]>(resource)) {
                list.Add(element);
            }
        }

    }
}
