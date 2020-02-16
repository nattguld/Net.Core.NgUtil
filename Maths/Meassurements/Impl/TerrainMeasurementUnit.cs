using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements.Impl {
    public sealed class TerrainMeasurementUnit : MeasurementUnit {


        private TerrainMeasurementUnit(string abbreviation, double modifier) : base(abbreviation, modifier) { }

        public override int GetDecimals() {
            return 3;
        }

        public static readonly TerrainMeasurementUnit SQUARE_KILOMETER = new TerrainMeasurementUnit("km²", 0.000001);
        public static readonly TerrainMeasurementUnit HECTARE = new TerrainMeasurementUnit("ha", 0.0001);
        public static readonly TerrainMeasurementUnit ARE = new TerrainMeasurementUnit("a", 0.01);
        public static readonly TerrainMeasurementUnit SQUARE_METER = new TerrainMeasurementUnit("m²", 1);
        public static readonly TerrainMeasurementUnit SQUARE_DECIMETER = new TerrainMeasurementUnit("dm²", 100);
        public static readonly TerrainMeasurementUnit SQUARE_CENTIMETER = new TerrainMeasurementUnit("cm²", 100000);
        public static readonly TerrainMeasurementUnit SQUARE_MILLIMETER = new TerrainMeasurementUnit("mm²", 1000000);

        public static readonly TerrainMeasurementUnit SQUARE_YARD = new TerrainMeasurementUnit("yr²", 1.1959900463);
        public static readonly TerrainMeasurementUnit SQUARE_FEET = new TerrainMeasurementUnit("ft²", 10.763910417);
        public static readonly TerrainMeasurementUnit SQUARE_INCH = new TerrainMeasurementUnit("in²", 1550.0031);
        public static readonly TerrainMeasurementUnit ACRE = new TerrainMeasurementUnit("ac", 0.0002471054);
        public static readonly TerrainMeasurementUnit SQUARE_MILE = new TerrainMeasurementUnit("mi²", 0.000000386);

    }
}
