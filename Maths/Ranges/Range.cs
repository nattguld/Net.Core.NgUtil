using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Maths.Ranges {
    public abstract class Range<T> where T : IConvertible {

        public T Min { get; }

        public T Max { get; }


        public Range(T min, T max) {
            Min = min;
            Max = max;
        }

        public abstract bool IsInRange(T value);

        public abstract T GetRandom();

        public override string ToString() {
            return "Range (" + Min + ", " + Max + ")";
        }

    }

}
