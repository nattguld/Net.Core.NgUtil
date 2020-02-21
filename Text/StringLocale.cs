using NgUtil.Debugging.Contracts;
using NgUtil.Systems;
using System;

namespace NgUtil.Text {

    public static class StringLocale {

        public static bool EqualsIgnoreCase(string input, string compare, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(compare));
            return input.Equals(compare, comparison);
        }

        public static bool Equals(string input, string compare, StringComparison comparison = StringComparison.InvariantCulture) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(compare));
            return input.Equals(compare, comparison);
        }

        public static bool ContainsIgnoreCase(string input, string value, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(value));
            return input.Contains(value, comparison);
        }

        public static bool Contains(string input, string value, StringComparison comparison = StringComparison.InvariantCulture) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(value));
            return input.Contains(value, comparison);
        }

        public static bool StartsWithIgnoreCase(string input, string value, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(value));
            return input.StartsWith(value, comparison);
        }

        public static bool StartsWith(string input, string value, StringComparison comparison = StringComparison.InvariantCulture) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(value));
            return input.StartsWith(value, comparison);
        }

        public static bool EndsWithIgnoreCase(string input, string value, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(value));
            return input.EndsWith(value, comparison);
        }

        public static bool EndsWith(string input, string value, StringComparison comparison = StringComparison.InvariantCulture) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(value));
            return input.EndsWith(value, comparison);
        }

        public static string ToLower(string input) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input));
            return input.ToLower(SystemUtil.GetCultureInfo());
        }

        public static string ToUpper(string input) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input));
            return input.ToUpper(SystemUtil.GetCultureInfo());
        }

        public static string ToString(int value) {
            return value.ToString(SystemUtil.GetCultureInfo());
        }

    }

}
