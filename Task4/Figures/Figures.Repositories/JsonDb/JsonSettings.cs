using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Figures.Repositories.JsonDb
{
    public static class JsonSettings
    {
        public static JsonSerializerOptions JsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.General)
        {
            WriteIndented = true,
        };
    }
}
