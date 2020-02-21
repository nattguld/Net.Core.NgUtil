using NgUtil.Text.Formatting;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Chrono {
    public sealed class DateTimeFormat : ETextFormat {


        private DateTimeFormat(string name, string format) : base(name, format) {}

        public static readonly DateTimeFormat ShortDate = new DateTimeFormat("ShortDate", "d");
        public static readonly DateTimeFormat ShortDateShortTime = new DateTimeFormat("ShortDateShortTime", "g");
        public static readonly DateTimeFormat ShortDateLongTime = new DateTimeFormat("ShortDateLongTime", "G");
        public static readonly DateTimeFormat LongDate = new DateTimeFormat("LongDate", "D");
        public static readonly DateTimeFormat LongDateShortTime = new DateTimeFormat("LongDateShortTime", "f");
        public static readonly DateTimeFormat LongDateLongTime = new DateTimeFormat("LongDateLongTime", "F");

        public static readonly DateTimeFormat LongDayMonth = new DateTimeFormat("LongDayMonth", "m");
        public static readonly DateTimeFormat LongMonthYear = new DateTimeFormat("LongMonthYear", "y");
        public static readonly DateTimeFormat ShortTime = new DateTimeFormat("ShortTime", "t");
        public static readonly DateTimeFormat LongTime = new DateTimeFormat("LongTime", "M");

    }
}
