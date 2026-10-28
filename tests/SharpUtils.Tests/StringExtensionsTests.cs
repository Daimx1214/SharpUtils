using SharpUtils;
using Xunit;

namespace SharpUtils.Tests;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("Hello World!", "hello-world")]
    [InlineData("  ASP.NET Core 8  ", "asp-net-core-8")]
    [InlineData("Café Menu", "cafe-menu")]
    public void ToSlug_ConvertsText(string input, string expected) =>
        Assert.Equal(expected, input.ToSlug());

    [Fact]
    public void NormalizeSpaces_CollapsesWhitespace() =>
        Assert.Equal("a b c", "  a   b\tc ".NormalizeSpaces());

    [Theory]
    [InlineData("short", 10, "short")]
    [InlineData("a very long sentence", 8, "a very …")]
    public void Truncate_ShortensWithEllipsis(string input, int max, string expected) =>
        Assert.Equal(expected, input.Truncate(max));

    [Theory]
    [InlineData("", 0)]
    [InlineData("one", 1)]
    [InlineData("one  two   three", 3)]
    public void CountWords_CountsCorrectly(string input, int expected) =>
        Assert.Equal(expected, input.CountWords());

    [Fact]
    public void ReverseWords_ReversesOrder() =>
        Assert.Equal("three two one", "one two three".ReverseWords());

    [Theory]
    [InlineData("Racecar", true)]
    [InlineData("A man a plan a canal Panama", true)]
    [InlineData("hello", false)]
    public void IsPalindrome_Detects(string input, bool expected) =>
        Assert.Equal(expected, input.IsPalindrome());

    [Theory]
    [InlineData("hello_world", "helloWorld")]
    [InlineData("my-variable-name", "myVariableName")]
    public void ToCamelCase_Converts(string input, string expected) =>
        Assert.Equal(expected, input.ToCamelCase());
}
