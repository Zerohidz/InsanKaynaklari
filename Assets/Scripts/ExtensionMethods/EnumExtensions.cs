using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumExtensions
{
    public static T Clamped<T>(this T self) where T : Enum
    {
        var values = (T[])Enum.GetValues(typeof(T));
        var min = values[0];
        var max = values[^1];

        if (self.CompareTo(min) < 0)
            return min;

        if (self.CompareTo(max) > 0)
            return max;

        return self;
    }
}
