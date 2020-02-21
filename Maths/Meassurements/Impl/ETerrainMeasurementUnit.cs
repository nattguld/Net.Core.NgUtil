using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements.Impl {
    public sealed class ETerrainMeasurementUnit : EMeasurementUnit {


        private ETerrainMeasurementUnit(string name, string abbreviation, double modifier) 
            : base(name, abbreviation, modifier) { }

        public override int GetDecimals() {
            return 3;
        }

        public static readonly ETerrainMeasurementUnit SquareKilometer = new ETerrainMeasurementUnit("SquareKilometer", "km²", 0.000001);
        public static readonly ETerrainMeasurementUnit Hectare = new ETerrainMeasurementUnit("Hectare", "ha", 0.0001);
        public static readonly ETerrainMeasurementUnit Are = new ETerrainMeasurementUnit("Are", "a", 0.01);
        public static readonly ETerrainMeasurementUnit SquareMeter = new ETerrainMeasurementUnit("SquareMeter", "m²", 1);
        public static readonly ETerrainMeasurementUnit SquareDecimeter = new ETerrainMeasurementUnit("SquareDecimeter", "dm²", 100);
        public static readonly ETerrainMeasurementUnit SquareCentimeter = new ETerrainMeasurementUnit("SquareCentimeter", "cm²", 100000);
        public static readonly ETerrainMeasurementUnit SquareMillimeter = new ETerrainMeasurementUnit("SquareMillimeter", "mm²", 1000000);

        public static readonly ETerrainMeasurementUnit SquareYard = new ETerrainMeasurementUnit("SquareYard", "yr²", 1.1959900463);
        public static readonly ETerrainMeasurementUnit SquareFeet = new ETerrainMeasurementUnit("SquareFeet", "ft²", 10.763910417);
        public static readonly ETerrainMeasurementUnit SquareInch = new ETerrainMeasurementUnit("SquareInch", "in²", 1550.0031);
        public static readonly ETerrainMeasurementUnit Acre = new ETerrainMeasurementUnit("Acre", "ac", 0.0002471054);
        public static readonly ETerrainMeasurementUnit SquareMile = new ETerrainMeasurementUnit("SquareMile", "mi²", 0.000000386);

    }
}
