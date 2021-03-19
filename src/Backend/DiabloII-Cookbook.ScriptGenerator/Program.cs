using System;
using System.Collections.Generic;
using System.IO;

namespace DiabloII_Cookbook.ScriptGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var scripts = new List<string>();
            foreach (var rune in new RuneList().Values)
            {
                scripts.Add($"INSERT INTO runes(id, name, \"level\", \"order\", in_weapon, in_helm, in_armor, in_shield) VALUES('{Guid.NewGuid()}', '{rune.Name}', {rune.Level}, {rune.Order}, '{rune.InWeapon}', '{rune.InHelm}', '{rune.InArmor}', '{rune.InShield}');");
            }

            File.AppendAllLines(@"c:\Projects\mihben\diabloii-cookbook\src\Backend\runes_insert.sql", scripts);
        }


    }
}
