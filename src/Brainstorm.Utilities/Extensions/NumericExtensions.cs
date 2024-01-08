namespace ErikTheCoder.Brainstorm.Utilities.Extensions;


public static class NumericExtensions
{
    public static string GetNumberWithSuffix(this int number, string format = null)
    {
        if (number == 12) return $"{number.ToString(format)}th";

        var digitInOnesColumn = number % 10;
        return digitInOnesColumn switch
        {
            1 => $"{number.ToString(format)}st",
            2 => $"{number.ToString(format)}nd",
            3 => $"{number.ToString(format)}rd",
            _ => $"{number.ToString(format)}th"
        };
    }
}