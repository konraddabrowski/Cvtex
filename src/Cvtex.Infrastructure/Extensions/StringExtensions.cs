namespace Cvtex.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
            => string.IsNullOrWhiteSpace(value);

        public static byte[] GetBytes(this string value)
            => System.Text.Encoding.UTF8.GetBytes(value);
    }
}