using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlternativeDateTime
{
    public class CustomTimeSpan : IEquatable<CustomTimeSpan>, IComparable<CustomTimeSpan>
    {
        public int Days { get; private set; }
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
        public CustomTimeSpan Time => new CustomTimeSpan(0, Hours, Minutes, Seconds);
        public CustomTimeSpan Zero => new CustomTimeSpan(0, 0, 0, 0);
        public CustomTimeSpan(int day, int hour, int minute, int second)
        {
            ValidateAndThrow(day, hour, minute, second);
            Days = day;
            Hours = hour;
            Minutes = minute;
            Seconds = second;
        }

        private void ValidateAndThrow(params int[] parameters)
        {
            var negativeCount = 0;
            var positiveCount = 0;

            foreach (var parameter in parameters)
            {
                if (parameter <= 0)
                {
                    negativeCount++;
                }

                if (parameter >= 0)
                {
                    positiveCount++;
                }
            }

            if (negativeCount != parameters.Length && positiveCount != parameters.Length)
            {
                throw new ArgumentException("Parameters cannot be positive and negative simultaneously.");
            }
        }

        private static int GetTotalSecond (CustomTimeSpan ts)
        {
            return ts.Days * 86400 + ts.Hours * 3600 + ts.Minutes * 60 + ts.Seconds;
        }

        public static CustomTimeSpan operator +(CustomTimeSpan ts1, CustomTimeSpan ts2)
        {
            var totalSeconds = GetTotalSecond(ts1) + GetTotalSecond(ts2);
            return FromSeconds(totalSeconds);
        }

        public static CustomTimeSpan operator -(CustomTimeSpan ts1, CustomTimeSpan ts2)
        {
            var totalSeconds = GetTotalSecond(ts1) - GetTotalSecond(ts2);
            return FromSeconds(totalSeconds);
        }

        public static CustomTimeSpan FromDays(double value)
        {
            var days = (int)value;
            var remainingHours = (value - days) * 24;
            var ts = FromHours(remainingHours);
            ts.Days = days;
            return ts;
        }

        public static CustomTimeSpan FromHours(double value)
        {
            var days = (int)value / 24;
            var remainingHours = value % 24;
            var hours = (int)remainingHours;
            remainingHours = (remainingHours - hours) * 60;
            var ts = FromMinutes(remainingHours);
            ts.Days = days;
            ts.Hours = hours;
            return ts;
        }

        public static CustomTimeSpan FromMinutes(double value)
        {
            var days = (int)value / (24 * 60);
            var remainingMinutes = value % (24 * 60);
            var hours = (int)remainingMinutes / 60;
            remainingMinutes = value % 60;
            var minutes = (int)remainingMinutes;
            var remainingSeconds = (remainingMinutes - minutes) * 60;
            int seconds = (int)remainingSeconds;
            return new CustomTimeSpan(days, hours, minutes, seconds); 
        }

        public static CustomTimeSpan FromSeconds(int value)
        {
            var days = value / (24 * 3600);
            var remainingSeconds = value % (24 * 3600);
            var hours = remainingSeconds / 3600;
            remainingSeconds = value % 3600;
            var minutes = remainingSeconds / 60;
            var seconds = remainingSeconds % 60;
            return new CustomTimeSpan(days, hours, minutes, seconds);
        }
        public static bool operator <(CustomTimeSpan ts1, CustomTimeSpan ts2)
        {
            return ts1.CompareTo(ts2) < 0;
        }

        public static bool operator >(CustomTimeSpan ts1, CustomTimeSpan ts2)
        {
            return ts1.CompareTo(ts2) > 0;
        }

        public static bool operator ==(CustomTimeSpan ts1, CustomTimeSpan ts2)
        {
            return ts1.Equals(ts2);
        }
        public static bool operator !=(CustomTimeSpan ts1, CustomTimeSpan ts2)
        {
            return !ts1.Equals(ts2);
        }

        public static bool operator <=(CustomTimeSpan ts1, CustomTimeSpan ts2)
        {
            return ts1.CompareTo(ts2) <= 0;
        }

        public static bool operator >=(CustomTimeSpan ts1, CustomTimeSpan ts2)
        {
            return ts1.CompareTo(ts2) >= 0;
        }
        public override string ToString()
        {
            if (Days < 0 || Hours < 0 || Minutes < 0 || Seconds < 0)
            {
                return $"-{Math.Abs(Days)} {Math.Abs(Hours):d2}:{Math.Abs(Minutes):d2}:{Math.Abs(Seconds):d2}";
            }

            return $"{Days} {Hours:d2}:{Minutes:d2}:{Seconds:d2}";
        }

        public override bool Equals(object obj)
        {
            var ts = obj as CustomTimeSpan;
            return Equals(ts);
        }

        public bool Equals(CustomTimeSpan other)
        {
            if (other is null)
            {
                return false;
            }

            return Days == other.Days
                && Hours == other.Hours
                && Minutes == other.Minutes
                && Seconds == other.Seconds;
        }

        public int CompareTo(CustomTimeSpan other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var comparisons = new[]
            {
                CompareRank(Days, other.Days),
                CompareRank(Hours, other.Hours),
                CompareRank(Minutes, other.Minutes),
                CompareRank(Seconds, other.Seconds),
            };

            foreach (var comparison in comparisons)
            {
                if (comparison != 0)
                {
                    return comparison;
                };
            }

            return 0;
        }

        private static int CompareRank(int firstRank, int secondRank)
        {
            if (firstRank > secondRank)
            {
                return 1;
            }
            else if (firstRank < secondRank)
            {
                return -1;
            }

            return 0;
        }

        public CustomTimeSpan Invert()
        {
            return new CustomTimeSpan(-Days, -Hours, -Minutes, -Seconds);
        }
    }
}
