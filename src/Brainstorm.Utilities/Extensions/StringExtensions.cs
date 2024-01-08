using JetBrains.Annotations;
using System.Text.RegularExpressions;


namespace ErikTheCoder.Brainstorm.Utilities.Extensions;


public static partial class StringExtensions
{
    private static readonly Regex _controlCharactersRegex = ControlCharactersRegex();


    [ContractAnnotation("text: null => true")]
    public static bool IsNullOrEmpty(this string text) => string.IsNullOrEmpty(text);


    public static bool IsNullOrWhiteSpace(this string text) => string.IsNullOrWhiteSpace(text);

    
    public static string Truncate(this string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text)) return text;
        return text.Length <= maxLength ? text : text[..maxLength];
    }


    public static string RemoveControlCharacters(this string text) => _controlCharactersRegex.Replace(text, string.Empty);

    
    [GeneratedRegex(@"[\p{C}-[\r\n\t]]+")]
    private static partial Regex ControlCharactersRegex();
}
