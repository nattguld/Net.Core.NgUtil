using System;

namespace NgUtil.Maths.Ranges.Impl {
    public class ByteRange : Range<byte> {


        public ByteRange(byte min, byte max) : base(min, max) { }

        public override bool IsInRange(byte value) {
            return value >= Min && value <= Max;
        }

        public override byte GetRandom() {
            if (Min == Max) {
                return Min;
            }
            if (Max < Min) {
                throw new ArgumentOutOfRangeException("Range can't be less than minimum => " + ToString());
            }
            byte[] buffer = new byte[1];
            new Random().NextBytes(buffer);
            return (byte)(Min + (Max - buffer[0]));
        }

    }
}
