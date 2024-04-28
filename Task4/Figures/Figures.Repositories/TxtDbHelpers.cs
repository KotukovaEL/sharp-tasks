using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories
{
    public static class TxtDbHelpers
    {
        public static bool TryParseDbRecord(string? str, out string key, out string value)
        {
            key = string.Empty;
            value = string.Empty;
            const string separator = ": ";

            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            var separatorIndex = str.IndexOf(separator);

            if (separatorIndex < 0)
            {
                return false;
            }

            key = str.Substring(0, separatorIndex);
            value = str.Substring(separatorIndex + separator.Length);
            return true;

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
