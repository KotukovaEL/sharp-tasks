using System;
using System.Globalization;

namespace AlternativeDateTime
{
    public class CustomDateTime : IEquatable<CustomDateTime>, IComparable<CustomDateTime>
    {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public int Second { get; private set; }

        public CustomDateTime Date => new CustomDateTime(Year, Month, Day, 0, 0, 0);

        public CustomDateTime (int year, int month, int day, int hour, int minute, int second)
        {
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public static CustomDateTime operator + (CustomDateTime dt, CustomTimeSpan ts)
        {
            int totalSeconds = dt.Second + ts.Seconds;
            int totalMinutes = dt.Minute + ts.Minutes;
            int totalHours = dt.Hour + ts.Hours;
            int totalDays = dt.Day + ts.Days;
            int totalMonth = dt.Month;
            int totalYear = dt.Year;
            var daysInMonth = GetDaysInMonth(totalYear, totalMonth);



            if (totalSeconds >= 60)
            {
                totalSeconds -= 60;
                totalMinutes++;
            }

            if (totalSeconds < 0)
            {
                totalSeconds += 60;
                totalMinutes--;
            }

            if (totalMinutes >= 60 )
            {
                totalMinutes -= 60;
                totalHours++;
            }

            if (totalMinutes < 0)
            {
                totalMinutes += 60;
                totalHours--;
            }

            if (totalHours >= 24)
            {
                totalHours -= 24;
                totalDays++;
            }

            if (totalHours < 0)
            {
                totalHours += 24;
                totalDays--;
            }

            if (totalDays >= daysInMonth)
            {
                totalDays -= daysInMonth;
                totalMonth++;
            }

            if (totalDays < 0)
            {
                totalMonth--;
                if (totalMonth <1)
                {
                    totalMonth += 12;
                    totalYear--;
                }

                daysInMonth = GetDaysInMonth(totalYear, totalMonth);
                totalDays += daysInMonth;
            }

            if (totalMonth > 12)
            {
                totalMonth -= 12;
                totalYear++;
            }

            return new CustomDateTime(totalYear, totalMonth, totalDays, totalHours, totalMinutes, totalSeconds);
        }

        public static CustomDateTime operator -(CustomDateTime dt, CustomTimeSpan ts)
        {
            var totalSeconds = dt.Second - ts.Seconds;
            var totalMinutes = dt.Minute - ts.Minutes;
            var totalHours = dt.Hour - ts.Hours;
            var totalDays = dt.Day - ts.Days;
            var totalMonth = dt.Month;
            var totalYear = dt.Year;
            


            if (totalSeconds < 0)
            {
                totalSeconds += 60;
                totalMinutes--;
            }

            if (totalMinutes < 0)
            {
                totalMinutes += 60;
                totalHours--;
            }

            if (totalHours < 0)
            {
                totalHours += 24;
                totalDays--;
            }

            if (totalDays < 0)
            {
                totalMonth--;

                if (totalMonth < 1)
                {
                    totalMonth += 12;
                    totalYear--;
                }

                var daysInMonth = GetDaysInMonth(totalYear, totalMonth);
                totalDays += daysInMonth;
            }


            return new CustomDateTime(totalYear, totalMonth, totalDays, totalHours, totalMinutes, totalSeconds);
        }

        public static CustomTimeSpan operator -(CustomDateTime dt1, CustomDateTime dt2)
        {
            var daysMultiplier = -1;
            var daysCount = 0;
            var minDt = dt1;
            var maxDt = dt2;

            if (dt1 > dt2)
            {
                minDt = dt2;
                maxDt = dt1;
                daysMultiplier = 1;
            }

            var currentDate = minDt.Date;
            var maxDate = maxDt.Date;

            while (currentDate < maxDate)
            {
                currentDate = currentDate.AddDays(1);
                daysCount++;
            }

            var timeSpanFromDays = CustomTimeSpan.FromDays(daysMultiplier * daysCount);

            var totalSecondsTd1 = dt1.Hour * 3600 + dt1.Minute * 60 + dt1.Second;
            var totalSecondsTd2 = dt2.Hour * 3600 + dt2.Minute * 60 + dt2.Second;
            long totalSeconds = totalSecondsTd1 - totalSecondsTd2;
            var timeSpanFromSeconds = CustomTimeSpan.FromSeconds(totalSeconds);

            return timeSpanFromDays + timeSpanFromSeconds;
        }

        public CustomDateTime AddDays(int days)
        {
            var result = new CustomDateTime(Year, Month, Day, Hour, Minute, Second);

            for (var i = 0; i < days; i++)
            {
                var daysInMonth = GetDaysInMonth(result.Year, result.Month);

                if (result.Day + 1 <= daysInMonth)
                {
                    result.Day++;
                    continue;
                }

                result.Day = 1;

                if (result.Month + 1 > 12)
                {
                    result.Month = 1;
                    result.Year++;
                }
                else
                {
                    result.Month += 1;
                }
            }

            return result;
        }
        public static bool operator <(CustomDateTime dt1, CustomDateTime dt2)
        {
            return dt1.CompareTo(dt2) < 0;
        }

        public static bool operator >(CustomDateTime dt1, CustomDateTime dt2)
        {
            return dt1.CompareTo(dt2) > 0;
        }

        public static bool operator ==(CustomDateTime dt1, CustomDateTime dt2)
        {
            return dt1.Equals(dt2);
        }
        public static bool operator !=(CustomDateTime dt1, CustomDateTime dt2)
        {
            return !dt1.Equals(dt2);
        }

        public static bool operator <=(CustomDateTime dt1, CustomDateTime dt2)
        {
            return dt1.CompareTo(dt2) <= 0;
        }

        public static bool operator >=(CustomDateTime dt1, CustomDateTime dt2)
        {
            return dt1.CompareTo(dt2) >= 0;
        }

        public static long GetSeconds(CustomDateTime dt)
        {
            var daysInYear = dt.GetDaysInYear(dt.Year);
            var daysInMonth = GetDaysInMonth(dt.Year, dt.Month);
            return (daysInYear + daysInMonth + dt.Day) * 24 * 60 * 60 + dt.Hour * 60 * 60 + dt.Minute * 60 + dt.Second;
        }

        public static int GetDaysInMonth(int year, int month)
        {
            var calendar = new GregorianCalendar();
            return calendar.GetDaysInMonth(year, month);
        }

        public int GetDaysInYear(int year)
        {
            if (IsLeapYear(year)) 
            {
                return 366;
            }

            return 365;

        }

        public bool IsLeapYear(int year)
        {
            bool isLeapYear = false;

            if (year % 4 == 0)
            {
                isLeapYear = true;
            }
            else
            {
                return isLeapYear;
            }

            if (year % 100 == 0)
            {
                if (year % 400 != 0)
                {
                    isLeapYear = false;
                }
            }

            return isLeapYear;
        }


        public override string ToString()
        {
            return $"{Year}-{Month:d2}-{Day:d2} {Hour:d2}:{Minute:d2}:{Second:d2}";
        }

        public override bool Equals(object? obj)
        {
            var dt = obj as CustomDateTime;
            return Equals(dt);
        }

        public bool Equals(CustomDateTime other)
        {
            if (other is null)
            {
                return false;
            }

            return Year == other.Year
                && Month == other.Month
                && Day == other.Day
                && Hour == other.Hour
                && Minute == other.Minute
                && Second == other.Second;
        }

        public int CompareTo(CustomDateTime other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var comparisons = new[]
            {
                CompareRank(Year, other.Year),
                CompareRank(Month, other.Month),
                CompareRank(Day, other.Day),
                CompareRank(Hour, other.Hour),
                CompareRank(Minute, other.Minute),
                CompareRank(Second, other.Second),
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
    }
}
