using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements.Impl {
    public sealed class ELengthMeasurementUnit : EMeasurementUnit {


        private ELengthMeasurementUnit(string name, string abbreviation, double modifier) 
            : base(name, abbreviation, modifier) { }

        public override int GetDecimals() {
            return 2;
        }

        public static readonly ELengthMeasurementUnit Kilometer = new ELengthMeasurementUnit("Kilometer", "km", 1);
        public static readonly ELengthMeasurementUnit Meter = new ELengthMeasurementUnit("Meter", "m", 1000);
        public static readonly ELengthMeasurementUnit Centimeter = new ELengthMeasurementUnit("Centimeter", "kcmm", 100000);
        public static readonly ELengthMeasurementUnit Millimeter = new ELengthMeasurementUnit("Millimeter", "mm", 1000000);

        public static readonly ELengthMeasurementUnit Mile = new ELengthMeasurementUnit("Mile", "mi", 0.62);
        public static readonly ELengthMeasurementUnit Yard = new ELengthMeasurementUnit("Yard", "yd", 1093.61);
        public static readonly ELengthMeasurementUnit Feet = new ELengthMeasurementUnit("Feet", "ft", 3280.84);
        public static readonly ELengthMeasurementUnit Inche = new ELengthMeasurementUnit("Inche", "in", 39370.08);

    }
}
