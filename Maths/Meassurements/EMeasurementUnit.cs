using NgUtil.Generics.Enums;

namespace NgUtil.Maths.Meassurements {
    public abstract class EMeasurementUnit : ExtendedEnum<EMeasurementUnit> {

        public string Abbreviation { get; }

        public double Modifier { get; }


        public EMeasurementUnit(string name, string abbreviation, double modifier) : base(name) {
            Abbreviation = abbreviation;
            Modifier = modifier;
        }
        
        public double Convert(double sourceValue, EMeasurementUnit targetUnit) {
            return MeasurementCalculator.Convert(this, sourceValue, targetUnit, GetDecimals());
        }

        public abstract int GetDecimals();

    }
}
