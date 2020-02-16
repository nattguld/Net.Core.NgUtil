using NgUtil.Maths.Ranges.Impl;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NgUtil.Maths {
    public static class MathUtil {


        public static string GetUniqueId() {
            return Guid.NewGuid().ToString();
        }

        public static double FormatDoubleDecimals(double value, int decimals) {
            return Math.Round(value, decimals);
        }

        public static string FormatDoubleAsString(double value, int decimals = 2) {
            return value.ToString($"F{decimals}");
        }

        public static float ParseFloat(string value, float defaultValue = 0f) {
            if (float.TryParse(value, out float result)) {
                return result;
            }
            return defaultValue;
        }

        public static bool IsFloat(string value) {
            return float.TryParse(value, NumberStyles.None, null, out _);
        }

        public static double ParseDouble(string value, double defaultValue = 0d) {
            if (double.TryParse(value, out double result)) {
                return result;
            }
            return defaultValue;
        }

        public static bool IsDouble(string value) {
            return double.TryParse(value, NumberStyles.None, null, out _);
        }

        public static int ParseInt(string value, int defaultValue = 0) {
            if (int.TryParse(value, out int result)) {
                return result;
            }
            return defaultValue;
        }

        public static bool IsInteger(string value) {
            return int.TryParse(value, NumberStyles.None, null, out _);
        }

        public static long ParseLong(string value, long defaultValue = 0L) {
            if (long.TryParse(value, out long result)) {
                return result;
            }
            return defaultValue;
        }

        public static bool IsLong(string value) {
            return long.TryParse(value, NumberStyles.None, null, out _);
        }

        public static int HexToInteger(string hex) {
            return Convert.ToInt32(hex, 16);
        }

        public static int NoPrefixHexToInteger(string hex) {
            return int.Parse(hex, NumberStyles.HexNumber);
        }

        public static int Random(int range) {
            return new IntRange(0, range).GetRandom();
        }

    }

}
