using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SharpUtils;

/// <summary>Helpful extension methods for <see cref="string"/>.</summary>
public static class StringExtensions
{
    /// <summary>Returns true when the string is null, empty, or whitespace only.</summary>
    public static bool IsNullOrWhiteSpace(this string? value) => string.IsNullOrWhiteSpace(value);

    /// <summary>Removes leading/trailing whitespace and collapses runs of inner whitespace to a single space.</summary>
    public static string NormalizeSpaces(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        return Regex.Replace(value.Trim(), "\\s+", " ");
    }

    /// <summary>Converts text to a URL-friendly slug, e.g. "Hello World!" becomes "hello-world".</summary>
    public static string ToSlug(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        var normalized = value.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder();
        foreach (var c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark)
                continue;
            if (char.IsLetterOrDigit(c))
                builder.Append(char.ToLowerInvariant(c));
            else if (builder.Length > 0 && builder[^1] != '-')
                builder.Append('-');
        }
        return builder.ToString().Trim('-');
    }

    /// <summary>Shortens a string to at most <paramref name="maxLength"/> characters, adding an ellipsis when truncated.</summary>
    public static string Truncate(this string value, int maxLength, string ellipsis = "…")
    {
        ArgumentNullException.ThrowIfNull(value);
        if (maxLength < 0) throw new ArgumentOutOfRangeException(nameof(maxLength));
        if (value.Length <= maxLength) return value;
        if (maxLength <= ellipsis.Length) return ellipsis[..maxLength];
        return value[..(maxLength - ellipsis.Length)] + ellipsis;
    }

    /// <summary>Counts the words in a string. Words are separated by any whitespace.</summary>
    public static int CountWords(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        var trimmed = value.Trim();
        return trimmed.Length == 0 ? 0 : Regex.Split(trimmed, "\\s+").Length;
    }

    /// <summary>Reverses the order of words, e.g. "one two three" becomes "three two one".</summary>
    public static string ReverseWords(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        var words = Regex.Split(value.Trim(), "\\s+");
        Array.Reverse(words);
        return string.Join(" ", words.Where(w => w.Length > 0));
    }

    /// <summary>Returns true when the string reads the same forwards and backwards, ignoring case, spaces and punctuation.</summary>
    public static bool IsPalindrome(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        var cleaned = new string(value.Where(char.IsLetterOrDigit).Select(char.ToLowerInvariant).ToArray());
        return cleaned.Length > 0 && cleaned.SequenceEqual(cleaned.Reverse());
    }

    /// <summary>Converts "hello_world" or "hello-world" style text to camelCase: "helloWorld".</summary>
    public static string ToCamelCase(this string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        var parts = value.Split(new[] { '_', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return string.Empty;
        var builder = new StringBuilder(parts[0].ToLowerInvariant());
        foreach (var part in parts.Skip(1))
        {
            builder.Append(char.ToUpperInvariant(part[0]));
            builder.Append(part[1..].ToLowerInvariant());
        }
        return builder.ToString();
    }
}
