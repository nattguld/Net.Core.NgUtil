using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Ranges.Impl {
    public class DoubleRange : Range<double> {


        public DoubleRange(double min, double max) : base(min, max) { }

        public override bool IsInRange(double value) {
            return value >= Min && value <= Max;
        }

        public override double GetRandom() {
            if (Min == Max) {
                return Min;
            }
            if (Max < Min) {
                throw new ArgumentOutOfRangeException("Range can't be less than minimum => " + ToString());
            }
            Random random = new Random();
            double range = (double)(Max - Min);
            double rand;

            do {
                byte[] buf = new byte[8];
                random.NextBytes(buf);
                rand = (ulong)BitConverter.ToDouble(buf, 0);
            } while (rand > double.MaxValue - ((double.MaxValue % range) + 1) % range);

            return (double)(rand % range) + Min;
        }

    }
}
