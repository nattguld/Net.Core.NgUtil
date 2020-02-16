using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Ranges.Impl {
    public class IntRange : Range<int> {


        public IntRange(int min, int max) : base(min, max) { }

        public override bool IsInRange(int value) {
            return value >= Min && value <= Max;
        }

        public override int GetRandom() {
            if (Min == Max) {
                return Min;
            }
            if (Max < Min) {
                throw new ArgumentOutOfRangeException("Range can't be less than minimum => " + ToString());
            }
            return Min + new Random().Next(Max - Min);
        }

    }
}
