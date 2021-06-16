using DiabloII_Cookbook.Api.DataTransferObjects;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class RuneExtensions
    {
        public static string GetImage(this Rune rune)
        {
            return $"/assets/classic/runes/{rune.Name}.png";
        }

        public static string IsApplicable(this Rune rune, int level)
        {
            return rune.Level <= level ? "level-applicable" : "level-unapplicable";
        }
    }
}
