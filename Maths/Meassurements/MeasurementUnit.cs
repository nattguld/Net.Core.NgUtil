using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Meassurements {
    public abstract class MeasurementUnit {

        public string Abbreviation { get; }

        public double Modifier { get; }


        public MeasurementUnit(string abbreviation, double modifier) {
            Abbreviation = abbreviation;
            Modifier = modifier;
        }
        
        public double Convert(double sourceValue, MeasurementUnit targetUnit) {
            return MeasurementCalculator.Convert(this, sourceValue, targetUnit, GetDecimals());
        }

        public abstract int GetDecimals();

    }
}
