namespace SharpUtils;

/// <summary>Helpful extension methods for numbers.</summary>
public static class NumericExtensions
{
    /// <summary>Returns true when the number is even.</summary>
    public static bool IsEven(this int value) => value % 2 == 0;

    /// <summary>Returns true when the number is odd.</summary>
    public static bool IsOdd(this int value) => value % 2 != 0;

    /// <summary>Returns true when the value lies between min and max, inclusive.</summary>
    public static bool IsInRange(this int value, int min, int max)
    {
        if (min > max) throw new ArgumentException("min cannot be greater than max.", nameof(min));
        return value >= min && value <= max;
    }

    /// <summary>Clamps the value to the inclusive range [min, max].</summary>
    public static double Clamp(this double value, double min, double max)
    {
        if (min > max) throw new ArgumentException("min cannot be greater than max.", nameof(min));
        return Math.Min(Math.Max(value, min), max);
    }

    /// <summary>Returns what percentage <paramref name="value"/> is of <paramref name="total"/>.</summary>
    public static double PercentageOf(this double value, double total)
    {
        if (total == 0) throw new DivideByZeroException("Total cannot be zero.");
        return value / total * 100.0;
    }

    /// <summary>Rounds the value to the nearest multiple, e.g. 17 rounded to the nearest 5 is 20.</summary>
    public static int RoundToNearest(this int value, int multiple)
    {
        if (multiple <= 0) throw new ArgumentOutOfRangeException(nameof(multiple));
        return (int)(Math.Round(value / (double)multiple) * multiple);
    }

    /// <summary>Formats a byte count as a human-readable string, e.g. 1536 becomes "1.5 KB".</summary>
    public static string ToFileSize(this long bytes)
    {
        if (bytes < 0) throw new ArgumentOutOfRangeException(nameof(bytes));
        string[] units = { "B", "KB", "MB", "GB", "TB" };
        var size = (double)bytes;
        var unit = 0;
        while (size >= 1024 && unit < units.Length - 1)
        {
            size /= 1024;
            unit++;
        }
        return unit == 0 ? $"{bytes} B" : $"{size:0.#} {units[unit]}";
    }
}
