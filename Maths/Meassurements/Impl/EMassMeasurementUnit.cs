using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements.Impl {
    public sealed class EMassMeasurementUnit : EMeasurementUnit {


        private EMassMeasurementUnit(string name, string abbreviation, double modifier) 
            : base(name, abbreviation, modifier) { }

        public override int GetDecimals() {
            return 2;
        }

        public static readonly EMassMeasurementUnit Tons = new EMassMeasurementUnit("Tons", "t", 0.0001);
        public static readonly EMassMeasurementUnit Kilogram = new EMassMeasurementUnit("Kilogram", "kg", 1);
        public static readonly EMassMeasurementUnit Gram = new EMassMeasurementUnit("Gram", "g", 1000);
        public static readonly EMassMeasurementUnit Milligram = new EMassMeasurementUnit("Milligram", "mg", 1000000);

        public static readonly EMassMeasurementUnit UsaOunce = new EMassMeasurementUnit("UsaOunce", "ounce", 35.2739619);
        public static readonly EMassMeasurementUnit UsaPound = new EMassMeasurementUnit("UsaPound", "lbs", 2.20462262);

        public static readonly EMassMeasurementUnit UkOunce = new EMassMeasurementUnit("UkOunce", "ounce", 32.15);
        public static readonly EMassMeasurementUnit UkPound = new EMassMeasurementUnit("UkPound", "lbs", 2.68);

    }
}
