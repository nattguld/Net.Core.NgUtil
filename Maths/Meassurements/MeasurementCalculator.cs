using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements {
    public static class MeasurementCalculator {

        public static double Convert(MeasurementUnit sourceUnit, double sourceValue, MeasurementUnit targetUnit, int decimals) {
            double baseValue = ToBaseUnit(sourceValue, sourceUnit);
            double converted = baseValue * targetUnit.Modifier;
            return MathUtil.FormatDoubleDecimals(converted, decimals);
        }

        public static double ToBaseUnit(double sourceValue, MeasurementUnit sourceUnit) {
            return ToBaseUnit(sourceValue, sourceUnit.Modifier);
        }

        public static double ToBaseUnit(double sourceValue, double modifier) {
            return modifier > 1d ? (sourceValue / modifier) : (sourceValue * modifier);
        }

    }
}
