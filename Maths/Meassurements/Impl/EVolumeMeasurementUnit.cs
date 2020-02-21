using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements.Impl {
    public sealed class EVolumeMeasurementUnit : EMeasurementUnit {


        private EVolumeMeasurementUnit(string name, string abbreviation, double modifier) 
            : base(name, abbreviation, modifier) { }

        public override int GetDecimals() {
            return 2;
        }

        public static readonly EVolumeMeasurementUnit Liter = new EVolumeMeasurementUnit("Liter", "l", 1);
        public static readonly EVolumeMeasurementUnit Deciliter = new EVolumeMeasurementUnit("Deciliter", "dl", 10);
        public static readonly EVolumeMeasurementUnit Centiliter = new EVolumeMeasurementUnit("Centiliter", "cl", 100);
        public static readonly EVolumeMeasurementUnit Milliliter = new EVolumeMeasurementUnit("Milliliter", "ml", 1000);
        public static readonly EVolumeMeasurementUnit Tablespoon = new EVolumeMeasurementUnit("Tablespoon", "tbsp", 66.67);
        public static readonly EVolumeMeasurementUnit Teaspoon = new EVolumeMeasurementUnit("Teaspoon", "tsp", 200);

        public static readonly EVolumeMeasurementUnit UsaLiquidBarrel = new EVolumeMeasurementUnit("UsaLiquidBarrel", "bar", 0.01);
        public static readonly EVolumeMeasurementUnit UsaLiquidGallon = new EVolumeMeasurementUnit("UsaLiquidGallon", "gal", 0.26);
        public static readonly EVolumeMeasurementUnit UsaLiquidQuart = new EVolumeMeasurementUnit("UsaLiquidQuart", "qt", 1.06);
        public static readonly EVolumeMeasurementUnit UsaLiquidPint = new EVolumeMeasurementUnit("UsaLiquidPint", "pt", 2.11);
        public static readonly EVolumeMeasurementUnit UsaSolidBarrel = new EVolumeMeasurementUnit("UsaSolidBarrel", "bar", 0.01);
        public static readonly EVolumeMeasurementUnit UsaSolidGallon = new EVolumeMeasurementUnit("UsaSolidGallon", "gal", 0.23);
        public static readonly EVolumeMeasurementUnit UsaSolidQuart = new EVolumeMeasurementUnit("UsaSolidQuart", "qt", 0.91);
        public static readonly EVolumeMeasurementUnit UsaSolidPint = new EVolumeMeasurementUnit("UsaSolidPint", "pt", 1.82);
        public static readonly EVolumeMeasurementUnit UsaTablespoon = new EVolumeMeasurementUnit("UsaTablespoon", "tbsp", 67.63);
        public static readonly EVolumeMeasurementUnit UsaTeaspoon = new EVolumeMeasurementUnit("UsaTeaspoon", "tsp", 202.88);
        public static readonly EVolumeMeasurementUnit UsaCup = new EVolumeMeasurementUnit("UsaCup", "cup", 4.23);

        public static readonly EVolumeMeasurementUnit UkBarrel = new EVolumeMeasurementUnit("UkBarrel", "bar", 0.01);
        public static readonly EVolumeMeasurementUnit UkGallon = new EVolumeMeasurementUnit("UkGallon", "gal", 0.22);
        public static readonly EVolumeMeasurementUnit UkPint = new EVolumeMeasurementUnit("UkPint", "pt", 1.76);
        
    }
}
