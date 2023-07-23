using System;
using System.Linq;

public static class StringExtensions
{
    public static int Count(this string input, char c)
    {
        return input.Count(ch => ch == c);
    }
}
