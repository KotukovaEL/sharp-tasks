﻿using System;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;

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
        public CustomTimeSpan Time => new CustomTimeSpan(0, Hour, Minute, Second);

        public CustomDateTime (int year, int month, int day, int hour, int minute, int second)
        {
            ValidateAndThrow(year, month, day, hour, minute, second);
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        private void ValidateAndThrow(params int[] parameters)
        {
            var positiveCount = 0;

            foreach (var parameter in parameters)
            {
                if (parameter >= 0)
                {
                    positiveCount++;
                }
            }

            if (positiveCount != parameters.Length)
            {
                throw new ArgumentException("Parameters cannot be negative simultaneously.");
            }
        }

        public static CustomDateTime operator + (CustomDateTime dt, CustomTimeSpan ts)
        {
            //if (ts.Time < dt.Time)
            //{
            //    var totalSeconds = dt.Second + ts.Seconds;
            //    var totalMinutes = dt.Minute + ts.Minutes;
            //    var totalHours = dt.Hour + ts.Hours;
            //}

            var totalTime = dt.Time + ts.Time;
            var result = new CustomDateTime(dt.Year, dt.Month, dt.Day, totalTime.Hours, totalTime.Minutes, totalTime.Seconds);
            var daysInMonth = GetDaysInMonth(dt.Year, dt.Month);

            if (dt.Day + ts.Days + totalTime.Days > daysInMonth)
            {
                result = result.AddDays(totalTime.Days + ts.Days);
            }
            else
            {
                result = result.AddDays(totalTime.Days + ts.Days);
            }


            return new CustomDateTime(result.Year, result.Month, result.Day, result.Hour, result.Minute, result.Second);
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
            var timeSpan = dt1.Time - dt2.Time;

            return timeSpanFromDays + timeSpan;
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