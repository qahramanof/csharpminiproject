
using System.Text.RegularExpressions;

namespace CodeProject1.Helpers;

public static class Extensions
{
    public static bool IsOnlyLetter(this string value)
    {
        return Regex.IsMatch(value, @"^[a-zA-Z]+$");
    }
}
