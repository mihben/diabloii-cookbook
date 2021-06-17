using DiabloII_Cookbook.Api.DataTransferObjects;
using DynamicExpresso;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class RuneWordExtensions
    {
        public static string GetItemTypes(this RuneWord runeWord) => string.Join(", ", runeWord.ItemTypes.Select(it => it.Name));

        public static string GetDescription(this RuneWordProperty property, int level) => property.Description.ReplaceSkill(property.Skill, level);
        public static string ReplaceSkill(this string description, Skill skill, int level) => description.Replace("{skill}", skill?.Name).CalculateFormulas(level);
        public static string CalculateFormulas(this string description, int level)
        {
            var regex = new Regex(@"\d[.]?[\d]*[*][C][l][v][l]");
            var match = regex.Match(description);
            while (match.Success)
            {
                var result = Math.Floor(new Interpreter().Eval<double>(match.Value, new Parameter("Clvl", level)));
                description = description.Replace($"({match.Value})", result.ToString());

                match = match.NextMatch();
            }

            return description;
        }

        public static string IsApplicable(this RuneWord runeWord, int level) => runeWord.Level <= level ? "applicable" : "unapplicable";
    }
}
