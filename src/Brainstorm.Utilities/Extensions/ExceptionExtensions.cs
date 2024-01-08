using System.Text;


namespace ErikTheCoder.Brainstorm.Utilities.Extensions;


public static class ExceptionExtensions
{
    public static string GetSummary(this Exception exception, bool includeStackTrace = false, bool recurseInnerExceptions = false)
    {
        var stringBuilder = new StringBuilder();
        var ex = exception;

        while (ex != null)
        {
            // Include spaces to align text.
            stringBuilder.AppendLine($"Exception Type =             {exception.GetType().FullName}");
            stringBuilder.AppendLine($"Exception Message =          {exception.Message}");
            if (includeStackTrace) stringBuilder.AppendLine($"Exception StackTrace =       {exception.StackTrace?.TrimStart(' ')}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            ex = recurseInnerExceptions ? ex.InnerException : null;
        }

        return stringBuilder.ToString();
    }
}
