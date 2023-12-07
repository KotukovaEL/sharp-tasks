using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeDateTime
{
    public class CustomTimeZone
    {
        private readonly static List<CustomTimeZone> _timeZones = new List<CustomTimeZone>() { Saratov, Moscow, Utc };
        public static CustomTimeZone Utc => new CustomTimeZone("Utc", CustomTimeSpan.FromHours(0));
        public static CustomTimeZone Moscow => new CustomTimeZone("Moscow", CustomTimeSpan.FromHours(3));
        public static CustomTimeZone Saratov => new CustomTimeZone("Saratov", CustomTimeSpan.FromHours(4));
        public string Id { get; }
        public CustomTimeSpan BaseUtcOffset { get; }
        public CustomTimeZone(string id, CustomTimeSpan baseUtcOffset)
        {
            Id = id;
            BaseUtcOffset = baseUtcOffset;
        }

        public static CustomDateTime ConvertTime(CustomDateTime dateTime, CustomTimeZone sourceTimeZone, CustomTimeZone destinationTimeZone)
        {
            var timeDifference = destinationTimeZone.BaseUtcOffset - sourceTimeZone.BaseUtcOffset;
            var res = dateTime + timeDifference;
            return res;
        }

        public static CustomDateTime ConvertTimeToUtc(CustomDateTime dateTime, CustomTimeZone sourceTimeZone)
        {
            return ConvertTime(dateTime, sourceTimeZone, Utc);
        }
        public static CustomDateTime ConvertTimeBySystemTimeZoneId(CustomDateTime dateTime, string sourceTimeZoneId, string destinationTimeZoneId)
        {
            var sourceTimeZone= FindTimeZoneById(sourceTimeZoneId);
            var destinationTimeZone = FindTimeZoneById(destinationTimeZoneId);
            return ConvertTime(dateTime, sourceTimeZone, destinationTimeZone);
        }

        public static CustomTimeZone FindTimeZoneById(string id)
        {
            foreach (var timeZone in _timeZones)
            {
                if (timeZone.Id == id)
                {
                    return timeZone;
                }
            }
            throw new ArgumentException($"Id '{id}' was not found.");    
        }
    }
}
