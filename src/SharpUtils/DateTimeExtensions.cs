namespace SharpUtils;

/// <summary>Helpful extension methods for <see cref="DateTime"/>.</summary>
public static class DateTimeExtensions
{
    /// <summary>Returns midnight (00:00:00) at the start of the given day.</summary>
    public static DateTime StartOfDay(this DateTime value) => value.Date;

    /// <summary>Returns the last tick of the given day (23:59:59.9999999).</summary>
    public static DateTime EndOfDay(this DateTime value) => value.Date.AddDays(1).AddTicks(-1);

    /// <summary>Returns midnight on the Monday of the week containing the given date.</summary>
    public static DateTime StartOfWeek(this DateTime value)
    {
        var diff = ((int)value.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
        return value.Date.AddDays(-diff);
    }

    /// <summary>Returns true when the date falls on a Saturday or Sunday.</summary>
    public static bool IsWeekend(this DateTime value) =>
        value.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

    /// <summary>Adds the given number of business days (Mon–Fri), skipping weekends.</summary>
    public static DateTime AddBusinessDays(this DateTime value, int businessDays)
    {
        var result = value;
        var step = Math.Sign(businessDays);
        var remaining = Math.Abs(businessDays);
        while (remaining > 0)
        {
            result = result.AddDays(step);
            if (!result.IsWeekend()) remaining--;
        }
        return result;
    }

    /// <summary>Calculates a person's age in whole years on the given date (defaults to today).</summary>
    public static int Age(this DateTime birthDate, DateTime? onDate = null)
    {
        var today = (onDate ?? DateTime.Today).Date;
        if (birthDate.Date > today)
            throw new ArgumentException("Birth date cannot be in the future.", nameof(birthDate));
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }

    /// <summary>Returns the number of whole days between two dates, ignoring time of day.</summary>
    public static int DaysBetween(this DateTime start, DateTime end) =>
        Math.Abs((end.Date - start.Date).Days);
}
