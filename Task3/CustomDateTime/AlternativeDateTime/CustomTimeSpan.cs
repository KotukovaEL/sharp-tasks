using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlternativeDateTime
{
    public class CustomTimeSpan : IEquatable<CustomTimeSpan>, IComparable<CustomTimeSpan>
    {
        public int Days { get; }
        public int Hours { get; }
        public int Minutes { get; }
        public int Seconds { get; }
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

        private static CustomTimeSpan Aggregate(char operators, CustomTimeSpan ts1, CustomTimeSpan ts2)
        {
            var totalSecondsTs1 = ts1.Days * 86400 + ts1.Hours * 3600 + ts1.Minutes * 60 + ts1.Seconds;
            var totalSecondsTs2 = ts2.Days * 86400 + ts2.Hours * 3600 + ts2.Minutes * 60 + ts2.Seconds;

            switch (operators)
            {
                case '+':
                    return ConversionUnitsOfTime(totalSecondsTs1 + totalSecondsTs2);


                case '-':
                    return ConversionUnitsOfTime(totalSecondsTs1 - totalSecondsTs2);

                default: throw new ArgumentException($"Unknown operation {(operators)}");
            }
        }

        public static CustomTimeSpan ConversionUnitsOfTime(int result)
        {
            var totalDays = (int)result / 86400;
            var totalHours = (int)result / 3600 - totalDays * 24;
            var totalMinutes = (int)(result - result / 3600 * 3600) / 60;
            var totalSeconds = (int)(result - result / 3600 * 3600) - totalMinutes * 60;
            return new CustomTimeSpan(totalDays, totalHours, totalMinutes, totalSeconds);
        }

        public static CustomTimeSpan operator +(CustomTimeSpan ts1, CustomTimeSpan ts2)
        {
            return Aggregate('+', ts1, ts2);
        }

        public static CustomTimeSpan operator -(CustomTimeSpan ts1, CustomTimeSpan ts2)
        {
            return Aggregate('-', ts1, ts2);
        }

        public static CustomTimeSpan FromDays(double value)
        {
            var days = (int)value;
            var remainingHours = (value - days) * 24;
            var hours = (int)remainingHours;
            var remainingMinutes = (remainingHours - hours) * 60;
            var minutes = (int)remainingMinutes;
            var remainingSeconds = (remainingMinutes - minutes) * 60;
            var seconds = (int)remainingSeconds;
            return new CustomTimeSpan(days, hours, minutes, seconds);
        }

        public static CustomTimeSpan FromHours(double value)
        {
            var hours = (int)value;
            var remainingMinutes = (value - hours) * 60;
            var minutes = (int)remainingMinutes;
            var remainingSeconds = (remainingMinutes - minutes) * 60;
            var seconds = (int)remainingSeconds;
            return new CustomTimeSpan(0, hours, minutes, seconds);
        }

        public static CustomTimeSpan FromMinutes(double value)
        {
            var hours = (int)value / 60;
            var remainingMinutes = value % 60;
            var minutes = (int)remainingMinutes;
            var remainingSeconds = (remainingMinutes - minutes) * 60;
            int seconds = (int)remainingSeconds;
            return new CustomTimeSpan(0, hours, minutes, seconds);
        }

        public static CustomTimeSpan FromSeconds(int value)
        {
            var hours = (int)value / 3600;
            var remainingSeconds = value % 3600;
            var minutes = remainingSeconds / 60;
            var seconds = remainingSeconds % 60;
            return new CustomTimeSpan(0, hours, minutes, seconds);
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
