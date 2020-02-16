using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements.Impl {
    public sealed class HeightMeasurementUnit : MeasurementUnit {


        private HeightMeasurementUnit(string abbreviation, double modifier) : base(abbreviation, modifier) { }

        public override int GetDecimals() {
            return 1;
        }

        public String ToFeetAndInchesString(double sourceValue) {
            int[] fi = ToFeetAndInches(sourceValue);
            return fi[0] + "'" + fi[1] + "\"";
        }

        public int[] ToFeetAndInches(double sourceValue) {
            double converted = Convert(sourceValue, INCHES);
            int feet = (int)Math.Floor(converted / 12);
            int rest = (int)(converted % 12);
            return new int[] { feet, rest };
        }

        public static int FeetAndInchesToInches(int feet, int inches) {
            return (feet * 12) + inches;
        }

        public static readonly HeightMeasurementUnit METER = new HeightMeasurementUnit("m", 1.0);
        public static readonly HeightMeasurementUnit CENTIMETER = new HeightMeasurementUnit("cm", 100.0);
        public static readonly HeightMeasurementUnit INCHES = new HeightMeasurementUnit("in", 39.37008);

    }
}
