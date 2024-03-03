using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories
{
    public static class TxtDbHelpers
    {
        public static (string key, string value) ParseDbRecord(string str)
        {
            const string separator = ": ";
            var separatorIndex = str.IndexOf(separator);
            var key = str.Substring(0, separatorIndex);
            var value = str.Substring(separatorIndex + separator.Length);
            return (key, value);
        }

        public static string GetFieldValue(Dictionary<string, string> map, string key)
        {
            if (!map.TryGetValue(key, out var value))
            {
                throw new ArgumentException($"Field {key} was not found.");
            }

            return value;
        }
    }
}
