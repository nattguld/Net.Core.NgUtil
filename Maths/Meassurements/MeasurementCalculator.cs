using NgUtil.Debugging.Contracts;

namespace NgUtil.Maths.Meassurements {
    public static class MeasurementCalculator {

        public static double Convert(EMeasurementUnit sourceUnit, double sourceValue, EMeasurementUnit targetUnit, int decimals) {
            EmptyParamContract.Validate(sourceUnit != null && targetUnit != null);

            double baseValue = ToBaseUnit(sourceValue, sourceUnit);
            double converted = baseValue * targetUnit.Modifier;
            return MathUtil.FormatDoubleDecimals(converted, decimals);
        }

        public static double ToBaseUnit(double sourceValue, EMeasurementUnit sourceUnit) {
            EmptyParamContract.Validate(sourceUnit != null);
            return ToBaseUnit(sourceValue, sourceUnit.Modifier);
        }

        public static double ToBaseUnit(double sourceValue, double modifier) {
            return modifier > 1d ? (sourceValue / modifier) : (sourceValue * modifier);
        }

    }
}
