using SharpUtils;
using Xunit;

namespace SharpUtils.Tests;

public class ValidationHelperTests
{
    [Theory]
    [InlineData("daim@example.com", true)]
    [InlineData("first.last+tag@university.edu.pk", true)]
    [InlineData("not-an-email", false)]
    [InlineData("missing@dot", false)]
    [InlineData(null, false)]
    public void IsValidEmail_Checks(string? input, bool expected) =>
        Assert.Equal(expected, ValidationHelper.IsValidEmail(input));

    [Theory]
    [InlineData("https://github.com", true)]
    [InlineData("http://example.org/page", true)]
    [InlineData("ftp://example.org", false)]
    [InlineData("just text", false)]
    public void IsValidUrl_Checks(string? input, bool expected) =>
        Assert.Equal(expected, ValidationHelper.IsValidUrl(input));

    [Theory]
    [InlineData("Str0ngPass", true)]
    [InlineData("weakpass", false)]
    [InlineData("NoDigitsHere", false)]
    [InlineData("Sh0rt", false)]
    public void IsStrongPassword_Checks(string? input, bool expected) =>
        Assert.Equal(expected, ValidationHelper.IsStrongPassword(input));

    [Theory]
    [InlineData("+92 300 1234567", true)]
    [InlineData("(042) 3577-1234", true)]
    [InlineData("123", false)]
    [InlineData("call-me-now", false)]
    public void IsValidPhoneNumber_Checks(string? input, bool expected) =>
        Assert.Equal(expected, ValidationHelper.IsValidPhoneNumber(input));
}
