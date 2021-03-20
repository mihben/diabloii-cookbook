using Netension.Core;

namespace DiabloII_Cookbook.Application.Enumerations
{
    public class ClassEnumeration : Enumeration
    {
        public static ClassEnumeration Amazon => new ClassEnumeration(0, "Amazon");
        public static ClassEnumeration Assassin => new ClassEnumeration(1, "Assassin");
        public static ClassEnumeration Barbarian => new ClassEnumeration(2, "Barbarian");
        public static ClassEnumeration Druid => new ClassEnumeration(3, "Druid");
        public static ClassEnumeration Necromancer => new ClassEnumeration(4, "Necromancer");
        public static ClassEnumeration Paladin => new ClassEnumeration(5, "Paladin");
        public static ClassEnumeration Sorceress => new ClassEnumeration(6, "Sorceress");

        public ClassEnumeration(int id, string name) 
            : base(id, name)
        {
        }
    }
}
