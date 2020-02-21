namespace Swanker.Helpers
{
    internal static class StringExtensions
    {
        public static string f2l(this string str)
        {
            return char.ToLower(str[0]) + str.Substring(1);
        }
    }
}
