namespace Utilities.Extensions
{
    public static class ArrayExtensions
    {
        public static string ConvertToString<T>(this T[] array)
        {
            return $"[ {string.Join(", ", array)} ]";
        }
    }
}