using NgUtil.Debugging.Contracts;
using NgUtil.Systems;
using System;
using System.Globalization;

namespace NgUtil.Chrono {
    public static class DateTimeUtil {

        public const string DayNotation = "dd";
        public const string MonthNotation = "MM";
        public const string YearNotation = "yyyy";
        public const string HourNotation = "HH";
        public const string MinutesNotation = "mm";
        public const string SecondsNotation = "ss";
        public const string MillisecondsNotation = "SSS";


        public static DateTime GetCurrentDateTime() {
            return DateTime.Now;
        }

        public static string GetCurrentDateTimeAsString() {
            return DateTimeToString(GetCurrentDateTime());
        }

        public static DateTime GetToday() {
            return DateTime.Today;
        }

        public static DateTime GetCurrentUtcDateTime() {
            return DateTime.UtcNow;
        }

        public static double GetCurrentTimeSeconds() {
            return DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 00)).TotalSeconds;
        }

        public static TimeSpan ParseTime(string input) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input));
            return TimeSpan.Parse(input, CultureInfo.InvariantCulture);
        }

        public static DateTime ParseDateTime(string input, string format) {
            EmptyParamContract.Validate(!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(format));
            return DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
        }

        public static string DateTimeToString(DateTime dt) {
            return DateTimeToString(dt, DateTimeFormat.ShortDateShortTime);
        }

        public static string DateTimeToString(DateTime dt, DateTimeFormat dtf) {
            EmptyParamContract.Validate(dtf != null);
            return DateTimeToString(dt, dtf.Format);
        }

        public static string DateTimeToString(DateTime dt, string format) {
            EmptyParamContract.Validate(dt != null && !string.IsNullOrEmpty(format));
            return dt.ToString(format, SystemUtil.GetCultureInfo());
        }

        public static bool IsBetweenDates(DateTime dt, DateTime dt1, DateTime dt2) {
            DateTime smallest = dt1 < dt2 ? dt1 : dt2;

            if (dt < smallest) {
                return false;
            }
            DateTime biggest = dt1 > dt2 ? dt1 : dt2;
            return dt < biggest;
        }

        public static bool IsBetweenTimes(TimeSpan ts, TimeSpan ts1, TimeSpan ts2) {
            TimeSpan smallest = ts1 < ts2 ? ts1 : ts2;

            if (ts < smallest) {
                return false;
            }
            TimeSpan biggest = ts1 > ts2 ? ts1 : ts2;
            return ts < biggest;
        }

        public static bool DateIsAfter(DateTime dt, DateTime after) {
            return dt > after;
        }

        public static bool DateIfBefore(DateTime dt, DateTime before) {
            return dt < before;
        }

        public static bool TimeIsAfter(TimeSpan ts, TimeSpan after) {
            return ts > after;
        }

        public static bool TimeIsBefore(TimeSpan ts, TimeSpan before) {
            return ts < before;
        }

        public static bool IsSameDay(DateTime dt1, DateTime dt2) {
            return dt1.Year == dt2.Year && dt1.DayOfYear == dt2.DayOfYear;
        }

    }
}
