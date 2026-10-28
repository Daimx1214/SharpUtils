using SharpUtils;
using Xunit;

namespace SharpUtils.Tests;

public class DateTimeExtensionsTests
{
    [Fact]
    public void StartOfDay_IsMidnight()
    {
        var dt = new DateTime(2026, 10, 28, 15, 42, 10);
        Assert.Equal(new DateTime(2026, 10, 28), dt.StartOfDay());
    }

    [Fact]
    public void StartOfWeek_IsMonday()
    {
        var wednesday = new DateTime(2026, 10, 28); // Wednesday
        Assert.Equal(new DateTime(2026, 10, 26), wednesday.StartOfWeek());
        Assert.Equal(new DateTime(2026, 10, 26), new DateTime(2026, 10, 26).StartOfWeek());
        Assert.Equal(new DateTime(2026, 10, 26), new DateTime(2026, 11, 1).StartOfWeek()); // Sunday
    }

    [Theory]
    [InlineData(2026, 10, 31, true)]  // Saturday
    [InlineData(2026, 10, 28, false)] // Wednesday
    public void IsWeekend_Detects(int y, int m, int d, bool expected) =>
        Assert.Equal(expected, new DateTime(y, m, d).IsWeekend());

    [Fact]
    public void AddBusinessDays_SkipsWeekend()
    {
        var friday = new DateTime(2026, 10, 30);
        Assert.Equal(new DateTime(2026, 11, 2), friday.AddBusinessDays(1)); // Monday
        Assert.Equal(new DateTime(2026, 11, 4), friday.AddBusinessDays(3));
    }

    [Fact]
    public void Age_CalculatesWholeYears()
    {
        var born = new DateTime(2000, 6, 15);
        Assert.Equal(26, born.Age(new DateTime(2026, 10, 28)));
        Assert.Equal(25, born.Age(new DateTime(2026, 6, 14)));
        Assert.Equal(26, born.Age(new DateTime(2026, 6, 15)));
    }

    [Fact]
    public void DaysBetween_IgnoresTime()
    {
        var a = new DateTime(2026, 10, 1, 23, 0, 0);
        var b = new DateTime(2026, 10, 11, 1, 0, 0);
        Assert.Equal(10, a.DaysBetween(b));
    }
}
