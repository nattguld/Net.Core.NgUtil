using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements.Impl {
    public sealed class MassMeasurementUnit : MeasurementUnit {


        private MassMeasurementUnit(string abbreviation, double modifier) : base(abbreviation, modifier) { }

        public override int GetDecimals() {
            return 2;
        }

        public static readonly MassMeasurementUnit TONS = new MassMeasurementUnit("t", 0.0001);
        public static readonly MassMeasurementUnit KILOGRAM = new MassMeasurementUnit("kg", 1);
        public static readonly MassMeasurementUnit GRAM = new MassMeasurementUnit("g", 1000);
        public static readonly MassMeasurementUnit MILLIGRAM = new MassMeasurementUnit("mg", 1000000);

        public static readonly MassMeasurementUnit USA_OUNCE = new MassMeasurementUnit("ounce", 35.2739619);
        public static readonly MassMeasurementUnit USA_POUND = new MassMeasurementUnit("lbs", 2.20462262);

        public static readonly MassMeasurementUnit UK_OUNCE = new MassMeasurementUnit("ounce", 32.15);
        public static readonly MassMeasurementUnit UK_POUND = new MassMeasurementUnit("lbs", 2.68);

    }
}
