using System.Text.RegularExpressions;

namespace SharpUtils;

/// <summary>Small, dependency-free validators for common input.</summary>
public static class ValidationHelper
{
    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    /// <summary>Returns true when the value looks like a valid email address.</summary>
    public static bool IsValidEmail(string? value) =>
        value is not null && EmailRegex.IsMatch(value.Trim());

    /// <summary>Returns true when the value is an absolute http or https URL.</summary>
    public static bool IsValidUrl(string? value) =>
        Uri.TryCreate(value, UriKind.Absolute, out var uri) &&
        (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);

    /// <summary>
    /// Returns true when a password is at least 8 characters and contains
    /// an uppercase letter, a lowercase letter, and a digit.
    /// </summary>
    public static bool IsStrongPassword(string? value)
    {
        if (string.IsNullOrEmpty(value) || value.Length < 8) return false;
        var hasUpper = value.Any(char.IsUpper);
        var hasLower = value.Any(char.IsLower);
        var hasDigit = value.Any(char.IsDigit);
        return hasUpper && hasLower && hasDigit;
    }

    /// <summary>
    /// Returns true when the value contains 7–15 digits, allowing a leading +,
    /// spaces, dashes and parentheses — a pragmatic phone-number check, not a carrier lookup.
    /// </summary>
    public static bool IsValidPhoneNumber(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;
        var digits = value.Count(char.IsDigit);
        var allowed = value.All(c => char.IsDigit(c) || c is '+' or ' ' or '-' or '(' or ')');
        return allowed && digits is >= 7 and <= 15;
    }
}
