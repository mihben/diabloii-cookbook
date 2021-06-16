using System;
using System.Collections.Generic;
using System.IO;

namespace DiabloII_Cookbook.ScriptGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var scripts = new List<string>();
            foreach (var runeWord in new RuneWordList().Values)
            {
                var runeWordId = Guid.NewGuid();
                scripts.Add($"INSERT INTO rune_words(id, name, class, level, is_ladder) VALUES('{runeWordId}', '{runeWord.Name.Replace("\'", "\'\'")}', '{runeWord.Class}', {runeWord.Level}, {runeWord.IsLadder});");

                foreach (var itemType in runeWord.ItemTypes)
                {
                    scripts.Add($"INSERT INTO rune_word_item_type_switch(id, rune_word_id, item_type_id) VALUES('{Guid.NewGuid()}', '{runeWordId}', (SELECT it.id FROM item_types it WHERE it.name = '{itemType.ItemType.Name}'));");
                }

                foreach (var ingredient in runeWord.Ingredients)
                {
                    scripts.Add($"INSERT INTO rune_word_ingredients(id, ingredient_order, rune_word_id, rune_id) VALUES('{Guid.NewGuid()}', {ingredient.Order}, '{runeWordId}', (SELECT r.id FROM runes r WHERE r.name = '{ingredient.Rune.Name}'));");
                }

                foreach (var property in runeWord.Properties)
                {
                    scripts.Add($"INSERT INTO rune_word_properties(id, description, rune_word_id, skill_id) VALUES('{Guid.NewGuid()}', '{property.Description.Replace("\'", "\'\'")}', '{runeWordId}', {GetSQL(property)});");
                }

                scripts.Add(Environment.NewLine);
            }

            File.Delete(@"h:\mihben\diabloii-cookbook\src\Backend\rune_word_insert.sql");
            File.AppendAllLines(@"h:\mihben\diabloii-cookbook\src\Backend\rune_word_insert.sql", scripts);
        }

        private static string GetSQL(Application.Entities.RuneWordPropertyEntity property)
        {
            if (property.Skill.Name != null) return $"(SELECT s.id FROM skills s WHERE s.name = '{property.Skill.Name}')";
            else return "null";
        }
    }
}
