namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(string inputString)
        {
            var result = string.Empty;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (i == 0)
                {
                    result += inputString[i].ToString().ToUpper();
                }

                result += inputString[i].ToString().ToLower();
            }

            return result;
        }
    }
}