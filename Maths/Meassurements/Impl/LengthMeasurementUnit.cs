using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements.Impl {
    public sealed class LengthMeasurementUnit : MeasurementUnit {


        private LengthMeasurementUnit(string abbreviation, double modifier) : base(abbreviation, modifier) { }

        public override int GetDecimals() {
            return 2;
        }

        public static readonly LengthMeasurementUnit KILOMETER = new LengthMeasurementUnit("km", 1);
        public static readonly LengthMeasurementUnit METER = new LengthMeasurementUnit("m", 1000);
        public static readonly LengthMeasurementUnit CENTIMETER = new LengthMeasurementUnit("kcmm", 100000);
        public static readonly LengthMeasurementUnit MILLIMETER = new LengthMeasurementUnit("mm", 1000000);

        public static readonly LengthMeasurementUnit MILE = new LengthMeasurementUnit("mi", 0.62);
        public static readonly LengthMeasurementUnit YARD = new LengthMeasurementUnit("yd", 1093.61);
        public static readonly LengthMeasurementUnit FEET = new LengthMeasurementUnit("ft", 3280.84);
        public static readonly LengthMeasurementUnit INCHE = new LengthMeasurementUnit("in", 39370.08);

    }
}
