using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Client.Models;
using System.Collections.Generic;
using System.Linq;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class RuneExtensions
    {
        public static string GetImage(this Rune rune)
        {
            return $"/assets/classic/runes/{rune.Name.ToLower()}.png";
        }

        public static string IsApplicable(this Rune rune, int level)
        {
            return rune.Level <= level ? "level-applicable" : "level-unapplicable";
        }

        public static IEnumerable<SelectModel<Rune>> MakeSelectable(this IEnumerable<Rune> runes)
        {
            return runes.Select(r => new SelectModel<Rune>(r)).ToList();
        }
    }
}
