using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements.Impl {
    public sealed class VolumeMeasurementUnit : MeasurementUnit {


        private VolumeMeasurementUnit(string abbreviation, double modifier) : base(abbreviation, modifier) { }

        public override int GetDecimals() {
            return 2;
        }

        public static readonly VolumeMeasurementUnit LITER = new VolumeMeasurementUnit("l", 1);
        public static readonly VolumeMeasurementUnit DECILITER = new VolumeMeasurementUnit("dl", 10);
        public static readonly VolumeMeasurementUnit CENTILITER = new VolumeMeasurementUnit("cl", 100);
        public static readonly VolumeMeasurementUnit MILLILITER = new VolumeMeasurementUnit("ml", 1000);
        public static readonly VolumeMeasurementUnit TABLESPOON = new VolumeMeasurementUnit("tbsp", 66.67);
        public static readonly VolumeMeasurementUnit TEASPOON = new VolumeMeasurementUnit("tsp", 200);

        public static readonly VolumeMeasurementUnit USA_LIQUID_BARREL = new VolumeMeasurementUnit("bar", 0.01);
        public static readonly VolumeMeasurementUnit USA_LIQUID_GALLON = new VolumeMeasurementUnit("gal", 0.26);
        public static readonly VolumeMeasurementUnit USA_LIQUID_QUART = new VolumeMeasurementUnit("qt", 1.06);
        public static readonly VolumeMeasurementUnit USA_LIQUID_PINT = new VolumeMeasurementUnit("pt", 2.11);
        public static readonly VolumeMeasurementUnit USA_SOLID_BARREL = new VolumeMeasurementUnit("bar", 0.01);
        public static readonly VolumeMeasurementUnit USA_SOLID_GALLON = new VolumeMeasurementUnit("gal", 0.23);
        public static readonly VolumeMeasurementUnit USA_SOLID_QUART = new VolumeMeasurementUnit("qt", 0.91);
        public static readonly VolumeMeasurementUnit USA_SOLID_PINT = new VolumeMeasurementUnit("pt", 1.82);
        public static readonly VolumeMeasurementUnit USA_TABLESPOON = new VolumeMeasurementUnit("tbsp", 67.63);
        public static readonly VolumeMeasurementUnit USA_TEASPOON = new VolumeMeasurementUnit("tsp", 202.88);
        public static readonly VolumeMeasurementUnit USA_CUP = new VolumeMeasurementUnit("cup", 4.23);

        public static readonly VolumeMeasurementUnit UK_BARREL = new VolumeMeasurementUnit("bar", 0.01);
        public static readonly VolumeMeasurementUnit UK_GALLON = new VolumeMeasurementUnit("gal", 0.22);
        public static readonly VolumeMeasurementUnit UK_PINT = new VolumeMeasurementUnit("pt", 1.76);

    }
}
