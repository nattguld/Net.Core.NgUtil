using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Chrono {
    public class Timestamp {

        public double Seconds { get; }


        public Timestamp() : this(DateTimeUtil.GetCurrentTimeSeconds()) { }

        public Timestamp(double seconds) {
            Seconds = seconds;
        }

    }
}
