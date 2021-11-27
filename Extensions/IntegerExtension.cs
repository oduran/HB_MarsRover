using System;
using System.Collections.Generic;
using System.Text;

namespace HB_MarsRover.Extensions
{
    public static class IntegerExtension
    {
        // Nullable string to int
        public static int? ToNullableInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

        public static int ToInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return 0;
        }
    }
}
