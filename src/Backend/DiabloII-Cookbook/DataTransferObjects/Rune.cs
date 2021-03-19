using System;

namespace DiabloII_Cookbook.Api.DataTransferObjects
{
    public class Rune
    {
        public Guid Id { get; }
        public string Name { get; }
        public int Order { get; }
        public int Level { get; }
        public string InWeapon { get; }
        public string InHelm { get; }
        public string InArmor { get; }
        public string InShield { get; }

        public Rune(Guid id, string name, int order, int level, string inWeapon, string inHelm, string inArmor, string inShield)
        {
            Id = id;
            Name = name;
            Order = order;
            Level = level;
            InWeapon = inWeapon;
            InHelm = inHelm;
            InArmor = inArmor;
            InShield = inShield;
        }
    }
}
