using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements.Impl {
    public sealed class ESpeedMeasurementUnit : EMeasurementUnit {


        private ESpeedMeasurementUnit(string name, string abbreviation, double modifier) 
            : base(name, abbreviation, modifier) { }

        public override int GetDecimals() {
            return 1;
        }

        public static readonly ESpeedMeasurementUnit Kmh = new ESpeedMeasurementUnit("Kmh", "km/h", 1);
        public static readonly ESpeedMeasurementUnit MeterPerSecond = new ESpeedMeasurementUnit("MeterPerSecond", "m/s", 0.28);
        public static readonly ESpeedMeasurementUnit Knop = new ESpeedMeasurementUnit("Knop", "k", 0.54);
        public static readonly ESpeedMeasurementUnit Mph = new ESpeedMeasurementUnit("Mph", "mp/h", 0.62);
        public static readonly ESpeedMeasurementUnit FeetPerSecond = new ESpeedMeasurementUnit("FeetPerSecond", "f/s", 0.91);

    }
}
