using NgUtil.Debugging.Contracts;
using NgUtil.Maths.Ranges.Impl;
using NgUtil.Systems;
using System;
using System.Globalization;

namespace NgUtil.Maths {
    public static class MathUtil {


        public static string GetUniqueId() {
            return Guid.NewGuid().ToString();
        }

        public static double FormatDoubleDecimals(double value, int decimals) {
            return Math.Round(value, decimals);
        }

        public static string FormatDoubleAsString(double value, int decimals = 2) {
            return value.ToString($"F{decimals}", SystemUtil.GetCultureInfo());
        }

        public static float ParseFloat(string value, bool allowFallback = false, float defaultValue = 0f) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(value));

            if (float.TryParse(value, NumberStyles.None, SystemUtil.GetCultureInfo(), out float result)) {
                return result;
            }
            if (!allowFallback) {
                throw new FormatException("Failed to parse float: " + value);
            }
            return defaultValue;
        }

        public static bool IsFloat(string value) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(value));
            return float.TryParse(value, NumberStyles.None, SystemUtil.GetCultureInfo(), out _);
        }

        public static double ParseDouble(string value, bool allowFallback = false, double defaultValue = 0d) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(value));

            if (double.TryParse(value, NumberStyles.None, SystemUtil.GetCultureInfo(), out double result)) {
                return result;
            }
            if (!allowFallback) {
                throw new FormatException("Failed to parse double: " + value);
            }
            return defaultValue;
        }

        public static bool IsDouble(string value) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(value));
            return double.TryParse(value, NumberStyles.None, SystemUtil.GetCultureInfo(), out _);
        }

        public static int ParseInt(string value, bool allowFallback = false, int defaultValue = 0) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(value));

            if (int.TryParse(value, NumberStyles.None, SystemUtil.GetCultureInfo(), out int result)) {
                return result;
            }
            if (!allowFallback) {
                throw new FormatException("Failed to parse integer: " + value);
            }
            return defaultValue;
        }

        public static bool IsInteger(string value) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(value));
            return int.TryParse(value, NumberStyles.None, SystemUtil.GetCultureInfo(), out _);
        }

        public static long ParseLong(string value, bool allowFallback = false, long defaultValue = 0L) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(value));

            if (long.TryParse(value, NumberStyles.None, SystemUtil.GetCultureInfo(), out long result)) {
                return result;
            }
            if (!allowFallback) {
                throw new FormatException("Failed to parse long: " + value);
            }
            return defaultValue;
        }

        public static bool IsLong(string value) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(value));
            return long.TryParse(value, NumberStyles.None, SystemUtil.GetCultureInfo(), out _);
        }

        public static int HexToInteger(string hex) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(hex));
            return Convert.ToInt32(hex, 16);
        }

        public static int NoPrefixHexToInteger(string hex) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(hex));
            return int.Parse(hex, NumberStyles.HexNumber, SystemUtil.GetCultureInfo());
        }

        public static int Random(int range) {
            return new IntRange(0, range).GetRandom();
        }

    }

}
