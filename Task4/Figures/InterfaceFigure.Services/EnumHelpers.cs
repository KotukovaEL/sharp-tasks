﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceFigure.Services
{
    public static class EnumHelpers
    {
        public static bool TryReadEnum<T>(string str, out T type) where T : struct, Enum
        {
            if (!Enum.TryParse(str, out type))
            {
                return false;
            }

            if (!Enum.IsDefined(typeof(T), type.ToString()))
            {
                return false;
            }

            return true;
        }
    }
}
