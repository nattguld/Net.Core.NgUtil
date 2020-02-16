using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements.Impl {
    public sealed class SpeedMeasurementUnit : MeasurementUnit {


        private SpeedMeasurementUnit(string abbreviation, double modifier) : base(abbreviation, modifier) { }

        public override int GetDecimals() {
            return 1;
        }

        public static readonly SpeedMeasurementUnit KMH = new SpeedMeasurementUnit("km/h", 1);
        public static readonly SpeedMeasurementUnit METER_PER_SECOND = new SpeedMeasurementUnit("m/s", 0.28);
        public static readonly SpeedMeasurementUnit KNOP = new SpeedMeasurementUnit("k", 0.54);
        public static readonly SpeedMeasurementUnit MPH = new SpeedMeasurementUnit("mp/h", 0.62);
        public static readonly SpeedMeasurementUnit FEET_PER_SECOND = new SpeedMeasurementUnit("f/s", 0.91);

    }
}
