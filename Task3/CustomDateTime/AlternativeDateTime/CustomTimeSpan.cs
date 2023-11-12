using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlternativeDateTime
{
    public class CustomTimeSpan : IEquatable<CustomTimeSpan>
    {
        public int Days { get; }
        public int Hours { get; }
        public int Minutes { get; }
        public int Seconds { get; }

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
            
            switch(operators)
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
            int days = (int)value;
            double hours = (value - days) * 24;
            int hoursInt = (int)hours;
            double minutes = (hours - hoursInt) * 60;
            int minutesInt = (int)minutes;
            double seconds = (minutes - minutesInt) * 60;
            int secondsInt = (int)Math.Round(seconds);
            return new CustomTimeSpan(days, hoursInt, minutesInt, secondsInt); 
        }

        public static CustomTimeSpan FromHours(double value)
        {
            int hours = (int)value;
            double minutes = (value - hours) * 60;
            int minutesInt = (int)minutes;
            double seconds = (minutes - minutesInt) * 60;
            int secondsInt = (int)Math.Round(seconds);
            return new CustomTimeSpan(0, hours, minutesInt, secondsInt);
        }

        public static CustomTimeSpan FromMinutes(double value)
        {
            int minutes = (int)value;
            double seconds = (value - minutes) * 60;
            int secondsInt = (int)Math.Round(seconds);
            return new CustomTimeSpan(0, 0, minutes, secondsInt);
        }

        public static CustomTimeSpan FromSeconds(double value)
        {
            int seconds = (int)Math.Round(value);
            return new CustomTimeSpan(0, 0, 0, seconds);
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
    }
}
