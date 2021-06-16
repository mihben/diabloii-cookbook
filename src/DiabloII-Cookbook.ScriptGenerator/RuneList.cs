using DiabloII_Cookbook.Application.Entities;
using System.Collections.Generic;

namespace DiabloII_Cookbook.ScriptGenerator
{
    public class RuneList
    {
        public IEnumerable<RuneEntity> Values => new List<RuneEntity> {
            CreateRune("El", 1, "+50 Attack Rating, +1 Light Radius", "+1 Light Radius, +15 Defense", 11),
            CreateRune("Eld", 2, "+75% Damage vs. Undead, +50 Attack Rating vs. Undead", "Lowers Stamina drain by 15%", "Lowers Stamina drain by 15%", "+7% Blocking", 11),
            CreateRune("Tir", 3, "+2 Mana Per Kill", "+2 Mana Per Kill.", 13),
            CreateRune("Nef", 4, "Knockback", "+30 Defense vs. Missile", 13),
            CreateRune("Eth", 5, "-25% Target Defense", "Regenerate Mana 15%", 15),
            CreateRune("Ith", 6, "+9 to Maximum Damage", "15% Damage Taken Goes to Mana", 15),
            CreateRune("Tal", 7, "75 Poison damage over 5 seconds", "+35% Poison Resistance", 17),
            CreateRune("Ral", 8, "+5-30 Fire Damage", "+35% Fire Resistance", 19),
            CreateRune("Ort", 9, "+1-50 Lightning Damage", "+35% Lightning Resistance", 21),
            CreateRune("Thul", 10, "+3-14 Cold Damage (Cold Length 3 seconds)", "+35% Cold Resistance", 23),
            CreateRune("Amn", 11, "7% Life Stolen Per Hit", "Attacker takes 14 damage", 25),

            CreateRune("Sol", 12, "+9 to Minimum Damage", "-7 Damage Taken", 27),
            CreateRune("Shael", 13, "Faster Attack Rate (+20)", "Faster Hit Recovery (+20)", "Faster Hit Recovery (+20)", "Faster Block Rate (+20)", 29),
            CreateRune("Dol", 14, "25% Chance that Hit Causes Monster to Flee", "+7 Replenish Life", 21),
            CreateRune("Hel", 15, "-20% Requirements", "-15% Requirements", 0),
            CreateRune("Io", 16, "+10 Vitality", "+10 Vitality", 35),
            CreateRune("Lum", 17, "+10 Energy", "+10 Energy", 37),
            CreateRune("Ko", 18, "+10 Dexterity", "+10 Dexterity", 39),
            CreateRune("Fal", 19, "+10 Strength", "+10 Strength", 41),
            CreateRune("Lem", 20, "+75% Extra Gold from Monsters", "+50% Extra Gold from Monsters", 43),
            CreateRune("Pul", 21, "+75% Damage to Demons, +100 AR against Demons", "+30% Defense", 45),
            CreateRune("Um", 22, "25% Chance of Open Wounds", "+15% Resist All", "+15% Resist All", "+22% Resist All", 47),

            CreateRune("Mal", 23, "Prevent Monster Healing", "Reduce Magic Damage by 7", 49),
            CreateRune("Ist", 24, "+30% Better Chance of Finding Magical Items", "+25% Better Chance of Finding Magical Items", 51),
            CreateRune("Gul", 25, "+20% Attack Rating", "+5 to Max Resist Poison", 53),
            CreateRune("Vex", 26, "7% Mana Leech", "+5 to Max Fire Resist", 55),
            CreateRune("Ohm", 27, "+50% Damage", "+5 to Max. Resist Cold", 57),
            CreateRune("Lo", 28, "20% Chance of Deadly Strike", "+5 to Max. Resist Lightning", 59),
            CreateRune("Sur", 29, "20% Chance of Hit Blinds Target", "+5% total Mana", "+5% total Mana", "+50 Mana", 61),
            CreateRune("Ber", 30, "20% Chance of Crushing Blow", "Damage Reduced by 8%", 63),
            CreateRune("Jah", 31, "Ignores Target Defense", "+5% of total Hit Points", "+5% of total Hit Points", "+50 Hit Points", 65),
            CreateRune("Cham", 32, "32% Chance of Hit Freezing Target for 3 seconds", "Cannot be Frozen", 67),
            CreateRune("Zod", 33, "Indestructible", "Indestructible", 69)
        };

        private RuneEntity CreateRune(string name, int order, string inWeapon, string inArmorHelmShield, int level)
        {
            return CreateRune(name, order, inWeapon, inArmorHelmShield, inArmorHelmShield, inArmorHelmShield, level);
        }

        private RuneEntity CreateRune(string name, int order, string inWeapon, string isArmor, string inHelm, string inShield, int level)
        {
            return new RuneEntity
            {
                Order = order,
                Name = name,
                InWeapon = inWeapon,
                InArmor = isArmor,
                InHelm = inHelm,
                InShield = inShield,
                Level = level
            };
        }
    }
}
