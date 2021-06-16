namespace DiabloII_Cookbook.Client.Extensions
{
    public static class BoolExtensions
    {
        public static string ToReadable(this bool value)
        {
            if (value) return "Yes";
            else return "No";
        }
    }
}
