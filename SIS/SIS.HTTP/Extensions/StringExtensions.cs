namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string inputString)
        {
            return char.ToUpper(inputString[0]) + inputString.Substring(1).ToLower();
        }
    }
}