using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Ranges.Impl {
    public class LongRange : Range<long> {


        public LongRange(long min, long max) : base(min, max) { }

        public override bool IsInRange(long value) {
            return value >= Min && value <= Max;
        }

        public override long GetRandom() {
            if (Min == Max) {
                return Min;
            }
            if (Max < Min) {
                throw new ArgumentOutOfRangeException("Range can't be less than minimum => " + ToString());
            }
            Random random = new Random();
            ulong uRange = (ulong)(Max - Min);
            ulong ulongRand;

            do {
                byte[] buf = new byte[8];
                random.NextBytes(buf);
                ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
            } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);

            return (long)(ulongRand % uRange) + Min;
        }

    }
}
