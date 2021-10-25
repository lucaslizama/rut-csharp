namespace Rut.Utils
{
    public static class Cleaner
    {
        public static string CleanRutString(string rut)
        {
            return rut
                .Trim()
                .TrimStart('0')
                .Replace(".", string.Empty)
                .ToUpper();
        }
    }
}