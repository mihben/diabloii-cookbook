using DiabloII_Cookbook.Api.Enumerations;
using DiabloII_Cookbook.Application.Entities;
using Netension.Core;
using System.Collections.Generic;

namespace DiabloII_Cookbook.ScriptGenerator
{
    public class RuneWordList
    {
        public IEnumerable<RuneWordEntity> Values => GenerateValues();

        private IEnumerable<RuneWordEntity> GenerateValues()
        {
            var result = new List<RuneWordEntity>();

            result.Add(new RuneWordEntity { Name = "Ancient's Pledge", Level = 21 }
                            .AddItemType(ItemTypeEnumeration.Shield.Name)

                            .AddIngredient("Ral")
                            .AddIngredient("Ort")
                            .AddIngredient("Tal")

                            .AddProperty("+50% Enhanced Defense")
                            .AddProperty("Cold Resist +43%")
                            .AddProperty("Lightning Resist +48%")
                            .AddProperty("Fire Resist +48%")
                            .AddProperty("Poison Resist +48%")
                            .AddProperty("10% Damage Taken Goes to Mana"));

            result.Add(new RuneWordEntity { Name = "Beast", Level = 63, Class = ClassEnumeration.Druid.Name }
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)

                            .AddIngredient("Ber")
                            .AddIngredient("Tir")
                            .AddIngredient("Um")
                            .AddIngredient("Mal")
                            .AddIngredient("Lum")

                            .AddProperty("Level 9 {skill} Aura When Equipped", SkillEnumeration.Fanaticism.Name)
                            .AddProperty("+40% Increased Attack Speed")
                            .AddProperty("+240-270% Enhanced Damage (varies)")
                            .AddProperty("20% Chance of Crushing Blow")
                            .AddProperty("25% Chance of Open Wounds")
                            .AddProperty("+3 To {skill}", SkillEnumeration.Werebear.Name)
                            .AddProperty("+3 To {skill}", SkillEnumeration.Lycanthropy.Name)
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("+25-40 To Strength (varies)")
                            .AddProperty("+10 To Energy")
                            .AddProperty("+2 To Mana After Each Kill")
                            .AddProperty("Level 13 {skill} (5 Charges)", SkillEnumeration.SummonGrizzly.Name));

            result.Add(new RuneWordEntity { Name = "Black", Level = 35 }
                            .AddItemType(ItemTypeEnumeration.Club.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)

                            .AddIngredient("Thul")
                            .AddIngredient("Io")
                            .AddIngredient("Nef")

                            .AddProperty("+15% Increased Attack Speed")
                            .AddProperty("+120% Enhanced Damage")
                            .AddProperty("+200 to Attack Rating")
                            .AddProperty("Adds 3-14 Cold Damage (3 sec)")
                            .AddProperty("40% Chance of Crushing Blow")
                            .AddProperty("Knockback")
                            .AddProperty("+10 to Vitality")
                            .AddProperty("Magic Damage Reduced By 2")
                            .AddProperty("Level 4 {skill} (12 Charges)", SkillEnumeration.CorpseExplosion.Name));

            result.Add(new RuneWordEntity { Name = "Bone", Level = 47, Class = ClassEnumeration.Necromancer.Name }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Sol")
                            .AddIngredient("Um")
                            .AddIngredient("Um")

                            .AddProperty("15% Chance To Cast level 10 {skill} When Struck", SkillEnumeration.BoneArmor.Name)
                            .AddProperty("15% Chance To Cast level 10 {skill} When Striking", SkillEnumeration.BoneSpear.Name)
                            .AddProperty("+2 To Necromancer Skill Levels")
                            .AddProperty("+100-150 To Mana (varies)")
                            .AddProperty("All Resistances +30")
                            .AddProperty("Damage Reduced By 7"));

            result.Add(new RuneWordEntity { Name = "Bramble", Level = 61, }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Ral")
                            .AddIngredient("Ohm")
                            .AddIngredient("Sur")
                            .AddIngredient("Eth")

                            .AddProperty("Level 15-21 {skill} Aura When Equipped (varies)", SkillEnumeration.Thorns.Name)
                            .AddProperty("+50% Faster Hit Recovery")
                            .AddProperty("+25-50% To Poison Skill Damage (varies)")
                            .AddProperty("+300 Defense")
                            .AddProperty("Increase Maximum Mana 5%")
                            .AddProperty("Regenerate Mana 15%")
                            .AddProperty("+5% To Maximum Cold Resist")
                            .AddProperty("Fire Resist +30%")
                            .AddProperty("Poison Resist +100%")
                            .AddProperty("+ 13 Life After Each Kill")
                            .AddProperty("Level 13 {skill} (33 Charges)", SkillEnumeration.SpiritOfBarbs.Name));

            result.Add(new RuneWordEntity { Name = "Brand", Level = 65, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Jah")
                            .AddIngredient("Lo")
                            .AddIngredient("Mal")
                            .AddIngredient("Gul")

                            .AddProperty("35% Chance To Cast Level 14 {skill} When Struck", SkillEnumeration.AmplifyDamage.Name)
                            .AddProperty("100% Chance To Cast Level 18 {skill} On Striking", SkillEnumeration.BoneSpear.Name)
                            .AddProperty("Fires {skill} (15)", SkillEnumeration.ExplodingArrow.Name)
                            .AddProperty("+260-340% Enhanced Damage (varies)")
                            .AddProperty("Ignore Target's Defense")
                            .AddProperty("20% Bonus to Attack Rating")
                            .AddProperty("+280-330% Damage To Demons (varies)")
                            .AddProperty("20% Deadly Strike")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("Knockback"));

            result.Add(new RuneWordEntity { Name = "Breath of the Dying", Level = 69, }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Vex")
                            .AddIngredient("Hel")
                            .AddIngredient("El")
                            .AddIngredient("Eld")
                            .AddIngredient("Eld")
                            .AddIngredient("Zod")
                            .AddIngredient("Eth")

                            .AddProperty("50% Chance To Cast Level 20 {skill} When You Kill An Enemy", SkillEnumeration.PoisonNova.Name)
                            .AddProperty("Indestructible", true)
                            .AddProperty("+60% Increased Attack Speed")
                            .AddProperty("+350-400% Enhanced Damage (varies)")
                            .AddProperty("+200% Damage To Undead")
                            .AddProperty("-25% Target Defense")
                            .AddProperty("+50 To Attack Rating")
                            .AddProperty("+50 To Attack Rating Against Undead")
                            .AddProperty("7% Mana Stolen Per Hit")
                            .AddProperty("12-15% Life Stolen Per Hit")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("+30 To All Attributes")
                            .AddProperty("+1 To Light Radius")
                            .AddProperty("Requirements -20%"));

            result.Add(new RuneWordEntity { Name = "Call to Arm", Level = 57, Class = ClassEnumeration.Barbarian.Name }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Amn")
                            .AddIngredient("Ral")
                            .AddIngredient("Mal")
                            .AddIngredient("Ist")
                            .AddIngredient("Ohm")

                            .AddProperty("+1 To All Skills")
                            .AddProperty("+40% Increased Attack Speed")
                            .AddProperty("+240-290% Enhanced Damage (varies)")
                            .AddProperty("Adds 5-30 Fire Damage")
                            .AddProperty("7% Life Stolen Per Hit")
                            .AddProperty("+2-6 To {skill} (varies)", SkillEnumeration.BattleCommand.Name)
                            .AddProperty("+1-6 To {skill} (varies)", SkillEnumeration.BattleOrders.Name)
                            .AddProperty("+1-4 To {skill} (varies)", SkillEnumeration.BattleCry.Name)
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("Replenish Life +12")
                            .AddProperty("30% Better Chance of Getting Magic Items"));

            result.Add(new RuneWordEntity { Name = "Chains of Honor", Level = 63, }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Dol")
                            .AddIngredient("Um")
                            .AddIngredient("Ber")
                            .AddIngredient("Ist")

                            .AddProperty("+2 To All Skills")
                            .AddProperty("+200% Damage To Demons")
                            .AddProperty("+100% Damage To Undead")
                            .AddProperty("8% Life Stolen Per Hit")
                            .AddProperty("+70% Enhanced Defense")
                            .AddProperty("+20 To Strength")
                            .AddProperty("Replenish Life +7")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("All Resistances +65")
                            .AddProperty("Damage Reduced By 8%")
                            .AddProperty("25% Better Chance of Getting Magic Items"));

            result.Add(new RuneWordEntity { Name = "Chaos", Level = 57, Class = ClassEnumeration.Assassin.Name }
                            .AddItemType(ItemTypeEnumeration.Katar.Name)

                            .AddIngredient("Fal")
                            .AddIngredient("Ohm")
                            .AddIngredient("Um")

                            .AddProperty("9% Chance To Cast Level 11 {skill} On Striking", SkillEnumeration.FrozenOrb.Name)
                            .AddProperty("911% Chance To Cast Level 9 {skill} On Striking", SkillEnumeration.ChargedBolt.Name)
                            .AddProperty("+35% Increased Attacked Speed")
                            .AddProperty("+240-290% Enhanced Damage (varies)")
                            .AddProperty("Adds 216-471 Magic Damage")
                            .AddProperty("25% Chance of Open Wounds")
                            .AddProperty("+1 To {skill}", SkillEnumeration.Whirlwind.Name)
                            .AddProperty("+10 To Strength")
                            .AddProperty("+15 Life After Each Demon Kill"));

            result.Add(new RuneWordEntity { Name = "Crescent Moon", Level = 47, }
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Sword.Name)

                            .AddIngredient("Shael")
                            .AddIngredient("Um")
                            .AddIngredient("Tir")

                            .AddProperty("10% Chance To Cast Level 17 {skill} On Striking", SkillEnumeration.ChainLightning.Name)
                            .AddProperty("7% Chance To Cast Level 13 {skill} On Striking", SkillEnumeration.StaticField.Name)
                            .AddProperty("+20% Increased Attacked Speed")
                            .AddProperty("+180-220% Enhanced Damage (varies)")
                            .AddProperty("Ignore Target's Defense")
                            .AddProperty("-35% To Enemy Lightning Resistance")
                            .AddProperty("25% Chance of Open Wounds")
                            .AddProperty("+9-11 Magic Absorb (varies)")
                            .AddProperty("+2 To Mana After Each Kill")
                            .AddProperty("Level 18 {skill}", SkillEnumeration.SummonSpiritWolf.Name));

            result.Add(new RuneWordEntity { Name = "Death", Level = 55, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Sword.Name)

                            .AddIngredient("Hel")
                            .AddIngredient("El")
                            .AddIngredient("Vex")
                            .AddIngredient("Ort")
                            .AddIngredient("Gul")

                            .AddProperty("Indestructible", true)
                            .AddProperty("100% Chance To Cast Level 44 {skill} When You Die", SkillEnumeration.ChainLightning.Name)
                            .AddProperty("25% Chance To Cast Level 18 {skill} On Attack", SkillEnumeration.GlacialSpike.Name)
                            .AddProperty("+300-385% Enhanced Damage (varies)")
                            .AddProperty("20% Bonus To Attack Rating")
                            .AddProperty("+50 To Attack Rating")
                            .AddProperty("Adds 1-50 Lightning Damage")
                            .AddProperty("7% Mana Stolen Per Hit")
                            .AddProperty("50% Chance of Crushing Blow")
                            .AddProperty("(0.5*Clvl)% Deadly Strike (Based on Character Level)")
                            .AddProperty("+1 To Light Radius")
                            .AddProperty("Level 22 {skill} (15 Charges)", SkillEnumeration.BloodGolem.Name)
                            .AddProperty("Requirements -20% "));

            result.Add(new RuneWordEntity { Name = "Delirium", Level = 51, }
                            .AddItemType(ItemTypeEnumeration.Helmet.Name)

                            .AddIngredient("Lem")
                            .AddIngredient("Ist")
                            .AddIngredient("Io")

                            .AddProperty("1% Chance To Cast lvl 50 Delirium When Struck")
                            .AddProperty("6% Chance To Cast lvl 14 {skill} When Struck", SkillEnumeration.MindBlast.Name)
                            .AddProperty("14% Chance To Cast lvl 13 {skill} When Struck", SkillEnumeration.Terror.Name)
                            .AddProperty("11% Chance To Cast lvl 18 {skill} On Striking", SkillEnumeration.Confuse.Name)
                            .AddProperty("+2 To All Skills")
                            .AddProperty("+261 Defense")
                            .AddProperty("+10 To Vitality")
                            .AddProperty("50% Extra Gold From Monsters")
                            .AddProperty("25% Better Chance of Getting Magic Items")
                            .AddProperty("Level 17 {skill} (60 Charges)", SkillEnumeration.Attract.Name));

            result.Add(new RuneWordEntity { Name = "Destruction", Level = 65, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)

                            .AddIngredient("Vex")
                            .AddIngredient("Lo")
                            .AddIngredient("Ber")
                            .AddIngredient("Jah")
                            .AddIngredient("Ko")

                            .AddProperty("23% Chance To Cast Level 12 {skill} On Striking", SkillEnumeration.Volcano.Name)
                            .AddProperty("5% Chance To Cast Level 23 {skill} On Striking", SkillEnumeration.MoltenBoulder.Name)
                            .AddProperty("100% Chance To Cast level 45 {skill} When You Die", SkillEnumeration.Meteor.Name)
                            .AddProperty("15% Chance To Cast Level 22 {skill} On Attack", SkillEnumeration.Nova.Name)
                            .AddProperty("1% Chance To Cast lvl 50 Delirium When Struck")
                            .AddProperty("+350% Enhanced Damage")
                            .AddProperty("Ignore Target's Defense")
                            .AddProperty("Adds 100-180 Magic Damage")
                            .AddProperty("7% Mana Stolen Per Hit")
                            .AddProperty("20% Chance Of Crushing Blow")
                            .AddProperty("20% Deadly Strike")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("+10 To Dexterity "));

            result.Add(new RuneWordEntity { Name = "Dragon", Level = 61, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)
                            .AddItemType(ItemTypeEnumeration.Shield.Name)
                            .AddItemType(ItemTypeEnumeration.Shield.Name)

                            .AddIngredient("Sur")
                            .AddIngredient("Lo")
                            .AddIngredient("Sol")

                            .AddProperty("20% Chance to Cast Level 18 {skill} When Struck", SkillEnumeration.Venom.Name)
                            .AddProperty("12% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Hydra.Name)
                            .AddProperty("Level 14 {skill} Aura When Equipped", SkillEnumeration.HolyFire.Name)
                            .AddProperty("+360 Defense")
                            .AddProperty("+230 Defense Vs. Missile")
                            .AddProperty("+3-5 To All Attributes (varies)")
                            .AddProperty("+(0.375*Clvl) To Strength (Based on Character Level)")
                            .AddProperty("+5% To Maximum Lightning Resist")
                            .AddProperty("Damage Reduced by 7")
                            .AddProperty("Armor: Increase Maximum Mana 5%")
                            .AddProperty("Shields: +50 To Mana "));

            result.Add(new RuneWordEntity { Name = "Dream", Level = 65, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Helmet.Name)
                            .AddItemType(ItemTypeEnumeration.Shield.Name)

                            .AddIngredient("Io")
                            .AddIngredient("Jah")
                            .AddIngredient("Pul")

                            .AddProperty("10% Chance To Cast Level 15 {skill} When Struck", SkillEnumeration.Confuse.Name)
                            .AddProperty("Level 15 {skill} Aura When Equipped", SkillEnumeration.HolyShock.Name)
                            .AddProperty("+20-30% Faster Hit Recovery (varies)")
                            .AddProperty("+30% Enhanced Defense")
                            .AddProperty("+150-220 Defense (varies)")
                            .AddProperty("+10 To Vitality")
                            .AddProperty("+(0.625*Clvl) To Mana (Based On Character Level)")
                            .AddProperty("All Resistances +5-20 (varies)")
                            .AddProperty("12-25% Better Chance of Getting Magic Items (varies)")
                            .AddProperty("Headgear: Increase Maximum Life 5%")
                            .AddProperty("Shields: +50 To Life "));

            result.Add(new RuneWordEntity { Name = "Duress", Level = 47 }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Shael")
                            .AddIngredient("Um")
                            .AddIngredient("Thul")

                            .AddProperty("40% faster hit Recovery")
                            .AddProperty("+10-20% Enhanced Damage (varies)")
                            .AddProperty("Adds 37-133 Cold Damage")
                            .AddProperty("15% Crushing Blow")
                            .AddProperty("33% Open Wounds")
                            .AddProperty("+150-200% Enhanced Defense (varies)")
                            .AddProperty("-20% Slower Stamina Drain")
                            .AddProperty("Cold Resist +45%")
                            .AddProperty("Lightning Resist +15%")
                            .AddProperty("Fire Resist +15%")
                            .AddProperty("Poison Resist +15% "));

            result.Add(new RuneWordEntity { Name = "Edge", Level = 25, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Tir")
                            .AddIngredient("Tal")
                            .AddIngredient("Amn")

                            .AddProperty("Level 15 {skill} Aura When Equipped", SkillEnumeration.Thorns.Name)
                            .AddProperty("+35% Increased Attack Speed")
                            .AddProperty("+320-380% Damage To Demons (varies)")
                            .AddProperty("+280% Damage To Undead")
                            .AddProperty("+75 Poison Damage Over 5 Seconds")
                            .AddProperty("7% Life Stolen Per Hit")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("+5-10 To All Attributes (varies)")
                            .AddProperty("+2 To Mana After Each Kill")
                            .AddProperty("Reduces All Vendor Prices 15%"));

            result.Add(new RuneWordEntity { Name = "Enigma", Level = 65, }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Jah")
                            .AddIngredient("Ith")
                            .AddIngredient("Ber")

                            .AddProperty("+2 To All Skills")
                            .AddProperty("+45% Faster Run/Walk")
                            .AddProperty("+1 To {skill}", SkillEnumeration.Teleport.Name)
                            .AddProperty("+750-775 Defense (Varies)")
                            .AddProperty("+(0.75*Clvl) To Strength (Based On Character Level)")
                            .AddProperty("Increase Maximum Life 5%")
                            .AddProperty("Damage Reduced By 8%")
                            .AddProperty("14 Life After Each Kill")
                            .AddProperty("15% Damage Taken Goes To Mana")
                            .AddProperty("(1*Clvl)% Better Chance of Getting Magic Items (Based On Character Level)"));

            result.Add(new RuneWordEntity { Name = "Enlightenment", Level = 45, Class = ClassEnumeration.Sorceress.Name }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Pul")
                            .AddIngredient("Ral")
                            .AddIngredient("Sol")

                            .AddProperty("5% Chance To Cast Level 15 {skill} When Struck", SkillEnumeration.Blaze.Name)
                            .AddProperty("5% Chance To Cast level 15 {skill} On Striking", SkillEnumeration.FireBall.Name)
                            .AddProperty("+2 To Sorceress Skills")
                            .AddProperty("+1 To {skill}", SkillEnumeration.Warmth.Name)
                            .AddProperty("+30% Enhanced Defense")
                            .AddProperty("Fire Resist +30%")
                            .AddProperty("Damage Reduced By 7"));

            result.Add(new RuneWordEntity { Name = "Eternity", Level = 63, }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)

                            .AddIngredient("Amn")
                            .AddIngredient("Ber")
                            .AddIngredient("Ist")
                            .AddIngredient("Sol")
                            .AddIngredient("Sur")

                            .AddProperty("Indestructible", true)
                            .AddProperty("+260-310% Enhanced Damage (varies)")
                            .AddProperty("+9 To Minimum Damage")
                            .AddProperty("7% Life Stolen Per Hit")
                            .AddProperty("20% Chance of Crushing Blow")
                            .AddProperty("Hit Blinds Target")
                            .AddProperty("Slows Target By 33%")
                            .AddProperty("Replenish Mana 16%")
                            .AddProperty("Cannot Be Frozen")
                            .AddProperty("30% Better Chance Of Getting Magic Items")
                            .AddProperty("Level 8 {skill} (88 Charges)", SkillEnumeration.Revive.Name));

            result.Add(new RuneWordEntity { Name = "Exile", Level = 57, }
                            .AddItemType(ItemTypeEnumeration.Shield.Name)

                            .AddIngredient("Vex")
                            .AddIngredient("Ohm")
                            .AddIngredient("Ist")
                            .AddIngredient("Dol")

                            .AddProperty("15% Chance To Cast Level 5 {skill} On Striking", SkillEnumeration.LifeTap.Name)
                            .AddProperty("Level 13-16 {skill} Aura When Equipped (varies", SkillEnumeration.Defiance.Name)
                            .AddProperty("+2 To Offensive Auras (Paladin Only)")
                            .AddProperty("+30% Faster Block Rate")
                            .AddProperty("Freezes Target")
                            .AddProperty("+220-260% Enhanced Defense (varies)")
                            .AddProperty("Replenish Life +7")
                            .AddProperty("+5% To Maximum Cold Resist")
                            .AddProperty("+5% To Maximum Fire Resist")
                            .AddProperty("25% Better Chance Of Getting Magic Items")
                            .AddProperty("Repairs 1 Durability every 4 seconds", true));

            result.Add(new RuneWordEntity { Name = "Faith", Level = 65, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Ohm")
                            .AddIngredient("Jah")
                            .AddIngredient("Lem")
                            .AddIngredient("Eld")

                            .AddProperty("Level 12-15 {skill} Aura When Equipped (varies)", SkillEnumeration.Fanaticism.Name)
                            .AddProperty("+1-2 To All Skills (varies)")
                            .AddProperty("+330% Enhanced Damage")
                            .AddProperty("Ignore Target's Defense")
                            .AddProperty("300% Bonus To Attack Rating")
                            .AddProperty("+75% Damage To Undead")
                            .AddProperty("+50 To Attack Rating Against Undead")
                            .AddProperty("+120 Fire Damage")
                            .AddProperty("All Resistances +15")
                            .AddProperty("10% Reanimate As: Returned")
                            .AddProperty("75% Extra Gold From Monsters"));

            result.Add(new RuneWordEntity { Name = "Famine", Level = 65, }
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)

                            .AddIngredient("Fal")
                            .AddIngredient("Ohm")
                            .AddIngredient("Ort")
                            .AddIngredient("Jah")

                            .AddProperty("+30% Increased Attack Speed")
                            .AddProperty("+320-370% Enhanced Damage (varies)")
                            .AddProperty("Ignore Target's Defense")
                            .AddProperty("Adds 180-200 Magic Damage")
                            .AddProperty("Adds 50-200 Fire Damage")
                            .AddProperty("Adds 51-250 Lightning Damage")
                            .AddProperty("Adds 50-200 Cold Damage")
                            .AddProperty("12% Life Stolen Per Hit")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("+10 To Strength"));

            result.Add(new RuneWordEntity { Name = "Fortitude", Level = 59, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Bow.Name)

                            .AddIngredient("El")
                            .AddIngredient("Sol")
                            .AddIngredient("Dol")
                            .AddIngredient("Lo")

                            .AddProperty("20% Chance To Cast Level 15 {skill} when", SkillEnumeration.ChillingArmor.Name)
                            .AddProperty("Struck")
                            .AddProperty("+25% Faster Cast Rate")
                            .AddProperty("+300% Enhanced Damage")
                            .AddProperty("+200% Enhanced Defense")
                            .AddProperty("+((8-12)*0.125*Clvl) To Life (Based on Character Level) (varies)")
                            .AddProperty("All Resistances +25-30 (varies)")
                            .AddProperty("12% Damage Taken Goes To Mana")
                            .AddProperty("+1 To Light Radius")
                            .AddProperty("Weapons: +9 To Minimum Damage")
                            .AddProperty("Weapons: +50 To Attack Rating")
                            .AddProperty("Weapons: 20% Deadly Strike")
                            .AddProperty("Weapons: Hit Causes Monster To Flee 25%")
                            .AddProperty("Armor: +15 Defense")
                            .AddProperty("Armor: Replenish Life +7")
                            .AddProperty("Armor: +5% To Maximum Lightning Resist")
                            .AddProperty("Armor: Damage Reduced By 7"));

            result.Add(new RuneWordEntity { Name = "Fury", Level = 65 }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Dagger.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Club.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)

                            .AddIngredient("Jah")
                            .AddIngredient("Gul")
                            .AddIngredient("Eth")

                            .AddProperty("40% Increased Attack Speed")
                            .AddProperty("+209% Enhanced Damage")
                            .AddProperty("Ignores Target Defense")
                            .AddProperty("-25% Target Defense")
                            .AddProperty("20% Bonus to Attack Rating")
                            .AddProperty("6% Life Stolen Per Hit")
                            .AddProperty("33% Chance Of Deadly Strike")
                            .AddProperty("66% Chance Of Open Wounds")
                            .AddProperty("+5 To {skill} (Barbarian Only)", SkillEnumeration.Frenzy.Name)
                            .AddProperty("Prevent Monster Heal"));

            result.Add(new RuneWordEntity { Name = "Gloom", Level = 47, }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Fal")
                            .AddIngredient("Um")
                            .AddIngredient("Pul")

                            .AddProperty("15% Chance To Cast Level 3 {skill} When Struck", SkillEnumeration.DimVision.Name)
                            .AddProperty("+10% Faster Hit Recovery")
                            .AddProperty("+200-260% Enhanced Defense (varies)")
                            .AddProperty("+10 To Strength")
                            .AddProperty("All Resistances +45")
                            .AddProperty("Half Freeze Duration")
                            .AddProperty("5% Damage Taken Goes To Mana")
                            .AddProperty("-3 To Light Radius"));

            result.Add(new RuneWordEntity { Name = "Grief", Level = 59, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)

                            .AddIngredient("Fal")
                            .AddIngredient("Um")
                            .AddIngredient("Pul")

                            .AddProperty("35% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Venom.Name)
                            .AddProperty("+30-40% Increased Attack Speed (varies)")
                            .AddProperty("Damage +340-400 (varies)")
                            .AddProperty("Ignore Target's Defense")
                            .AddProperty("-25% Target Defense")
                            .AddProperty("+(1.875*Clvl)% Damage To Demons (Based on Character Level)")
                            .AddProperty("Adds 5-30 Fire Damage")
                            .AddProperty("-20-25% To Enemy Poison Resistance (varies)")
                            .AddProperty("20% Deadly Strike")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("+2 To Mana After Each Kill")
                            .AddProperty("+10-15 Life After Each Kill (varies)"));

            result.Add(new RuneWordEntity { Name = "Hand of Justice", Level = 67, IsLadder = false }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Sur")
                            .AddIngredient("Cham")
                            .AddIngredient("Amn")
                            .AddIngredient("Lo")

                            .AddProperty("100% Chance To Cast Level 36 {skill} When You Level-Up", SkillEnumeration.Blaze.Name)
                            .AddProperty("100% Chance To Cast Level 48 {skill} When You Die", SkillEnumeration.Meteor.Name)
                            .AddProperty("Level 16 {skill} Aura When Equipped", SkillEnumeration.HolyFire.Name)
                            .AddProperty("+33 % Increased Attack Speed")
                            .AddProperty("+280-330% Enhanced Damage (varies)")
                            .AddProperty("Ignore Target's Defense")
                            .AddProperty("-20% To Enemy Fire Resistance")
                            .AddProperty("7% Life Stolen Per Hit")
                            .AddProperty("20% Deadly Strike")
                            .AddProperty("Hit Blinds Target")
                            .AddProperty("Freezes Target +3"));

            result.Add(new RuneWordEntity { Name = "Harmony", Level = 39, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Tir")
                            .AddIngredient("Ith")
                            .AddIngredient("Sol")
                            .AddIngredient("Ko")

                            .AddProperty("Level 10 {skill} Aura When Equipped", SkillEnumeration.Vigor.Name)
                            .AddProperty("+200-275% Enhanced Damage (varies)")
                            .AddProperty("+9 To Minimum Damage")
                            .AddProperty("+9 To Maximum Damage")
                            .AddProperty("Adds 55-160 Fire Damage")
                            .AddProperty("Adds 55-160 Lightning Damage")
                            .AddProperty("Adds 55-160 Cold Damage")
                            .AddProperty("+2-6 To {skill} (varies)", SkillEnumeration.Valkyrie.Name)
                            .AddProperty("+10 To Dexterity")
                            .AddProperty("Regenerate Mana 20%")
                            .AddProperty("+2 To Mana After Each Kill")
                            .AddProperty("+2 To Light Radius")
                            .AddProperty("Level 16 {skill} Aura When Equipped", SkillEnumeration.Revive.Name));

            result.Add(new RuneWordEntity { Name = "Heart of the Oak", Level = 55, IsLadder = false }
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)

                            .AddIngredient("Ko")
                            .AddIngredient("Vex")
                            .AddIngredient("Pul")
                            .AddIngredient("Thul")

                            .AddProperty("+3 To All Skills")
                            .AddProperty("+40% Faster Cast Rate")
                            .AddProperty("+75% Damage To Demons")
                            .AddProperty("+100 To Attack Rating Against Demons")
                            .AddProperty("Adds 3-14 Cold Damage")
                            .AddProperty("7% Mana Stolen Per Hit")
                            .AddProperty("+10 To Dexterity")
                            .AddProperty("Replenish Life +20")
                            .AddProperty("Increase Maximum Mana 15%")
                            .AddProperty("All Resistances +30-40 (varies)")
                            .AddProperty("Level 4 {skill} (25 Charges)", SkillEnumeration.OakSage.Name)
                            .AddProperty("Level 14 {skill} (60 Charges)", SkillEnumeration.Raven.Name));

            result.Add(new RuneWordEntity { Name = "Holy Thunder", Level = 23 }
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)

                            .AddIngredient("Eth")
                            .AddIngredient("Ral")
                            .AddIngredient("Ort")
                            .AddIngredient("Tal")

                            .AddProperty("+60% Enhanced Damage")
                            .AddProperty("+10 to Maximum Damage")
                            .AddProperty("-25% Target Defense")
                            .AddProperty("Adds 5-30 Fire Damage")
                            .AddProperty("Adds 21-110 Lightning Damage")
                            .AddProperty("+75 Poison Damage over 5 secs")
                            .AddProperty("+3 to {skill} (Paladin Only)", SkillEnumeration.HolyShock.Name)
                            .AddProperty("+5% to Maximum Lightning Resist")
                            .AddProperty("Lightning Resist +60%")
                            .AddProperty("Level 7 {skill} (60 charges)", SkillEnumeration.ChainLightning.Name));

            result.Add(new RuneWordEntity { Name = "Honor", Level = 27 }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)

                            .AddIngredient("Amn")
                            .AddIngredient("El")
                            .AddIngredient("Ith")
                            .AddIngredient("Tir")
                            .AddIngredient("Sol")

                            .AddProperty("+1 to all skills")
                            .AddProperty("+160% Enhanced Damage")
                            .AddProperty("+9 to Minimum Damage")
                            .AddProperty("+9 to Maximum Damage")
                            .AddProperty("+250 Attack Rating")
                            .AddProperty("7% Life Stolen per Hit")
                            .AddProperty("25% Deadly Strike")
                            .AddProperty("+10 to Strength")
                            .AddProperty("Replenish life +10")
                            .AddProperty("+2 to Mana after each Kill")
                            .AddProperty("+1 to Light Radius "));

            result.Add(new RuneWordEntity { Name = "Ice", Level = 65, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Amn")
                            .AddIngredient("Shael")
                            .AddIngredient("Jah")
                            .AddIngredient("Lo")

                            .AddProperty("100% Chance To Cast Level 40 {skill} When You Level-up", SkillEnumeration.Blizzard.Name)
                            .AddProperty("25% Chance To Cast Level 22 {skill} On Striking", SkillEnumeration.FrostNova.Name)
                            .AddProperty("Level 18 {skill} Aura When Equipped", SkillEnumeration.HolyFreeze.Name)
                            .AddProperty("+20% Increased Attack Speed")
                            .AddProperty("+140-210% Enhanced Damage (varies)")
                            .AddProperty("Ignore Target's Defense")
                            .AddProperty("+25-30% To Cold Skill Damage (varies)")
                            .AddProperty("7% Life Stolen per Hit")
                            .AddProperty("-20% To Enemy Cold Resistance")
                            .AddProperty("20% Deadly Strike")
                            .AddProperty("(3.125*Clvl)% Extra Gold From Monsters (Based on Character Level) "));

            result.Add(new RuneWordEntity { Name = "Infinity", Level = 63, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)

                            .AddIngredient("Ber")
                            .AddIngredient("Mal")
                            .AddIngredient("Ber")
                            .AddIngredient("Ist")

                            .AddProperty("50% Chance To Cast Level 20 {skill} When You Kill An Enemy", SkillEnumeration.ChainLightning.Name)
                            .AddProperty("Level 12 {skill} Aura When Equipped", SkillEnumeration.Conviction.Name)
                            .AddProperty("+35% Faster Run/Walk")
                            .AddProperty("+255-325% Enhanced Damage (varies)")
                            .AddProperty("-(45-55)% To Enemy Lightning Resistance (varies)")
                            .AddProperty("40% Chance of Crushing Blow")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("+(0.5*Clvl) To Vitality (Based on Character Level)")
                            .AddProperty("30% Better Chance of Getting Magic Items")
                            .AddProperty("Level 21 {skill} (30 Charges)", SkillEnumeration.CycloneArmor.Name));

            result.Add(new RuneWordEntity { Name = "Insight", Level = 27, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)

                            .AddIngredient("Ral")
                            .AddIngredient("Tir")
                            .AddIngredient("Tal")
                            .AddIngredient("Sol")

                            .AddProperty("Level 12-17 {skill} Aura When Equipped (varies)", SkillEnumeration.Meditation.Name)
                            .AddProperty("+35% Faster Cast Rate")
                            .AddProperty("+200-260% Enhanced Damage (varies)")
                            .AddProperty("+9 To Minimum Damage")
                            .AddProperty("180-250% Bonus to Attack Rating (varies)")
                            .AddProperty("Adds 5-30 Fire Damage")
                            .AddProperty("+75 Poison Damage Over 5 Seconds")
                            .AddProperty("+1-6 To Critical Strike (varies)")
                            .AddProperty("+5 To All Attributes")
                            .AddProperty("+2 To Mana After Each Kill")
                            .AddProperty("23% Better Chance of Getting Magic Items"));

            result.Add(new RuneWordEntity { Name = "King's Grace", Level = 25 }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)

                            .AddIngredient("Amn")
                            .AddIngredient("Ral")
                            .AddIngredient("Thul")

                            .AddProperty("+100% Enhanced Damage")
                            .AddProperty("+150 to Attack Rating")
                            .AddProperty("+100% Damage to Demons")
                            .AddProperty("+100 to Attack Rating against Demons")
                            .AddProperty("+50% Damage to Undead")
                            .AddProperty("+100 to Attack Rating against Undead")
                            .AddProperty("Adds 5-30 Fire Damage")
                            .AddProperty("Adds 3-14 Cold damage")
                            .AddProperty("7% Life stolen per hit"));

            result.Add(new RuneWordEntity { Name = "Kingslayer", Level = 53, }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)

                            .AddIngredient("Mal")
                            .AddIngredient("Um")
                            .AddIngredient("Gul")
                            .AddIngredient("Fal")

                            .AddProperty("+30% Increased Attack Speed")
                            .AddProperty("+230-270% Enhanced Damage (varies)")
                            .AddProperty("-25% Target Defense")
                            .AddProperty("20% Bonus To Attack Rating")
                            .AddProperty("33% Chance of Crushing Blow")
                            .AddProperty("50% Chance of Open Wounds")
                            .AddProperty("+1 To {skill}", SkillEnumeration.Vengeance.Name)
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("+10 To Strength")
                            .AddProperty("40% Extra Gold From Monsters"));

            result.Add(new RuneWordEntity { Name = "Last Wish", Level = 65, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)

                            .AddIngredient("Jah")
                            .AddIngredient("Mal")
                            .AddIngredient("Jah")
                            .AddIngredient("Sur")
                            .AddIngredient("Jah")
                            .AddIngredient("Ber")

                            .AddProperty("6% Chance To Cast Level 11 {skill} When Struck", SkillEnumeration.Fade.Name)
                            .AddProperty("10% Chance To Cast Level 18 {skill} On Striking", SkillEnumeration.LifeTap.Name)
                            .AddProperty("20% Chance To Cast Level 20 {skill} On Attack", SkillEnumeration.ChargedBolt.Name)
                            .AddProperty("Level 17 {skill} Aura When Equipped", SkillEnumeration.Might.Name)
                            .AddProperty("+330-375% Enhanced Damage (varies)")
                            .AddProperty("Ignore Target's Defense")
                            .AddProperty("60-70% Chance of Crushing Blow (varies)")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("Hit Blinds Target")
                            .AddProperty("(0.5*Clvl)% Chance of Getting Magic Items (Based on Character Level)"));

            result.Add(new RuneWordEntity { Name = "Lawbringer", Level = 43, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)

                            .AddIngredient("Amn")
                            .AddIngredient("Lem")
                            .AddIngredient("Ko")

                            .AddProperty("20% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Decrepify.Name)
                            .AddProperty("Level 16-18 {skill} Aura When Equipped (varies)", SkillEnumeration.Sanctuary.Name)
                            .AddProperty("-50% Target Defense")
                            .AddProperty("Adds 150-210 Fire Damage")
                            .AddProperty("Adds 130-180 Cold Damage")
                            .AddProperty("7% Life Stolen Per Hit")
                            .AddProperty("Slain Monsters Rest In Peace")
                            .AddProperty("+200-250 Defense Vs. Missile (varies)")
                            .AddProperty("+10 To Dexterity")
                            .AddProperty("75% Extra Gold From Monsters"));

            result.Add(new RuneWordEntity { Name = "Leaf", Level = 19 }
                            .AddItemType(ItemTypeEnumeration.Staff.Name)

                            .AddIngredient("Tir")
                            .AddIngredient("Ral")

                            .AddProperty("+3 to Fire Skills")
                            .AddProperty("Adds 5-30 Fire Damage")
                            .AddProperty("+3 to {skill} (Sorceress Only)", SkillEnumeration.Inferno.Name)
                            .AddProperty("+3 to {skill} (Sorceress Only)", SkillEnumeration.Warmth.Name)
                            .AddProperty("+3 to {skill} (Sorceress Only)", SkillEnumeration.FireBolt.Name)
                            .AddProperty("+(2*Clvl) Defence (Based on Character Level)")
                            .AddProperty("Cold Resist +33%")
                            .AddProperty("+2 to Mana after each Kill"));

            result.Add(new RuneWordEntity { Name = "Lionheart", Level = 41 }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Hel")
                            .AddIngredient("Lum")
                            .AddIngredient("Fal")

                            .AddProperty("+20% Enhanced Damage")
                            .AddProperty("+25 To Strength")
                            .AddProperty("+15 To Dexterity")
                            .AddProperty("+20 To Vitality")
                            .AddProperty("+10 To Energy")
                            .AddProperty("+50 To Life")
                            .AddProperty("All Resistances +30")
                            .AddProperty("Requirements -15% "));

            result.Add(new RuneWordEntity { Name = "Lore", Level = 27 }
                            .AddItemType(ItemTypeEnumeration.Helmet.Name)

                            .AddIngredient("Ort")
                            .AddIngredient("Sol")

                            .AddProperty("+1 to All Skills")
                            .AddProperty("+10 To Energy")
                            .AddProperty("Lightning Resist +30%")
                            .AddProperty("Damage Reduced by 7")
                            .AddProperty("+2 to Mana after each Kill")
                            .AddProperty("+2 to Light Radius "));

            result.Add(new RuneWordEntity { Name = "Malice", Level = 15 }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Dagger.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Club.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Katar.Name)

                            .AddIngredient("Ith")
                            .AddIngredient("El")
                            .AddIngredient("Eth")

                            .AddProperty("+33% Enhanced Damage")
                            .AddProperty("+9 to Maximum Damage")
                            .AddProperty("-25% Target Defense")
                            .AddProperty("+50 to Attack Rating")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("-100 to Monster Defense Per Hit")
                            .AddProperty("Drain Life -5 (-1 hp about every 2 seconds)"));

            result.Add(new RuneWordEntity { Name = "Melody", Level = 39 }
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Shael")
                            .AddIngredient("Ko")
                            .AddIngredient("Nef")

                            .AddProperty("+3 To Bow and Crossbow Skills (Amazon Only)")
                            .AddProperty("+20 % Increased Attack Speed")
                            .AddProperty("+50% Enhanced Damage")
                            .AddProperty("+300 % Damage To Undead")
                            .AddProperty("+3 To {skill} (Amazon Only)", SkillEnumeration.SlowMissiles.Name)
                            .AddProperty("+3 To {skill} (Amazon Only)", SkillEnumeration.Dodge.Name)
                            .AddProperty("++3 To {skill} (Amazon Only)", SkillEnumeration.CriticalStrike.Name)
                            .AddProperty("Knockback")
                            .AddProperty("+10 To Dexterity"));

            result.Add(new RuneWordEntity { Name = "Memory", Level = 37 }
                            .AddItemType(ItemTypeEnumeration.Staff.Name)

                            .AddIngredient("Lum")
                            .AddIngredient("Io")
                            .AddIngredient("Sol")
                            .AddIngredient("Eth")

                            .AddProperty("+3 To Sorceress Skill Levels")
                            .AddProperty("+33% Faster Cast Rate")
                            .AddProperty("+9 To Minimum Damage")
                            .AddProperty("-25% Target Defence")
                            .AddProperty("+3 To {skill} (Sorceress Only)", SkillEnumeration.EnergyShield.Name)
                            .AddProperty("+2 To {skill} (Sorceress Only)", SkillEnumeration.StaticField.Name)
                            .AddProperty("+50% Enhanced Defense")
                            .AddProperty("+10 Vitality")
                            .AddProperty("+10 Energy")
                            .AddProperty("Increase Maximum Mana 20%")
                            .AddProperty("Magic Damage Reduced By 7"));

            result.Add(new RuneWordEntity { Name = "Myth", Level = 25, Class = ClassEnumeration.Barbarian.Name }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Hel")
                            .AddIngredient("Amn")
                            .AddIngredient("Nef")

                            .AddProperty("3% Chance To Cast Level 1 {skill} When Struck", SkillEnumeration.Howl.Name)
                            .AddProperty("10% Chance To Cast Level 1 {skill} On Striking", SkillEnumeration.Taunt.Name)
                            .AddProperty("+2 To Barbarian Skill Levels")
                            .AddProperty("+30 Defense Vs. Missile")
                            .AddProperty("Replenish Life +10")
                            .AddProperty("Attacker Takes Damage of 14")
                            .AddProperty("Requirements -15% ")
                            .AddProperty("+10 Vitality")
                            .AddProperty("+10 Energy")
                            .AddProperty("Increase Maximum Mana 20%")
                            .AddProperty("Magic Damage Reduced By 7"));

            result.Add(new RuneWordEntity { Name = "Nadir", Level = 13 }
                            .AddItemType(ItemTypeEnumeration.Helmet.Name)

                            .AddIngredient("Nef")
                            .AddIngredient("Tir")

                            .AddProperty("+50% Enhanced Defense")
                            .AddProperty("+10 Defense")
                            .AddProperty("+30 Defense Vs. Missile")
                            .AddProperty("+5 Strength")
                            .AddProperty("+2 to Mana after each Kill")
                            .AddProperty("-33% Extra Gold from Monsters")
                            .AddProperty("-3 to Light Radius")
                            .AddProperty("Level 13 {skill} (9 charges)", SkillEnumeration.ClockOfShadows.Name));

            result.Add(new RuneWordEntity { Name = "Oath", Level = 59, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Sword.Name)

                            .AddIngredient("Shael")
                            .AddIngredient("Pul")
                            .AddIngredient("Mal")
                            .AddIngredient("Lum")

                            .AddProperty("Indestructible", true)
                            .AddProperty("30% Chance To Cast Level 20 {skill} On Striking", SkillEnumeration.BoneSpirit.Name)
                            .AddProperty("+50% Increased Attack Speed")
                            .AddProperty("+210-340% Enhanced Damage (varies)")
                            .AddProperty("+75% Damage To Demons")
                            .AddProperty("+100 To Attack Rating Against Demons")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("+10 To Energy")
                            .AddProperty("+10-15 Magic Absorb (varies)")
                            .AddProperty("Level 16 {skill} (20 Charges)", SkillEnumeration.HeartOfWolverine.Name)
                            .AddProperty("Level 17 {skill} (14 Charges)", SkillEnumeration.IronGolem.Name));

            result.Add(new RuneWordEntity { Name = "Obedience", Level = 41, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)

                            .AddIngredient("Hel")
                            .AddIngredient("Ko")
                            .AddIngredient("Thul")
                            .AddIngredient("Eth")
                            .AddIngredient("Fal")

                            .AddProperty("30% Chance To Cast Level 21 {skill} When You Kill An Enemy", SkillEnumeration.Enchant.Name)
                            .AddProperty("+40% Faster Hit Recovery")
                            .AddProperty("+370% Enhanced Damage")
                            .AddProperty("25% Target Defense")
                            .AddProperty("Adds 3-14 Cold Damage (3 Seconds Duration,Normal)")
                            .AddProperty("-25% To Enemy Fire Resistance")
                            .AddProperty("40% Chance of Crushing Blow")
                            .AddProperty("+200-300 Defense (varies)")
                            .AddProperty("+10 To Strength")
                            .AddProperty("+10 To Dexterity")
                            .AddProperty("All Resistances +20-30 (varies)")
                            .AddProperty("Requirements -20%"));

            result.Add(new RuneWordEntity { Name = "Passion", Level = 43, }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Dol")
                            .AddIngredient("Ort")
                            .AddIngredient("Eld")
                            .AddIngredient("Lem")

                            .AddProperty("+25% Increased Attack Speed")
                            .AddProperty("+160.210% Enhanced Damage (varies)")
                            .AddProperty("50-80% Bonus To Attack Rating (varies)")
                            .AddProperty("+75% Damage To Undead")
                            .AddProperty("+50 To Attack Rating Against Undead")
                            .AddProperty("Adds 1-50 Lightning Damage")
                            .AddProperty("+1 {skill}", SkillEnumeration.Berserk.Name)
                            .AddProperty("+1 {skill}", SkillEnumeration.Zeal.Name)
                            .AddProperty("Hit Blinds Target + 10")
                            .AddProperty("Hit Causes Monster To Flee 25%")
                            .AddProperty("75% Extra Gold From Monsters")
                            .AddProperty("Level 3 {skill}", SkillEnumeration.HeartOfWolverine.Name));

            result.Add(new RuneWordEntity { Name = "Peace", Level = 29, Class = ClassEnumeration.Amazon.Name }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Shael")
                            .AddIngredient("Thul")
                            .AddIngredient("Amn")

                            .AddProperty("4% Chance To Cast Level 5 {skill} When Struck", SkillEnumeration.SlowMissiles.Name)
                            .AddProperty("2% Chance To Cast level 15 {skill} On Striking", SkillEnumeration.Valkyrie.Name)
                            .AddProperty("+2 To Amazon Skill Levels")
                            .AddProperty("+20% Faster Hit Recovery")
                            .AddProperty("+2 To Critical Strike")
                            .AddProperty("Cold Resist +30%")
                            .AddProperty("Attacker Takes Damage of 14"));

            result.Add(new RuneWordEntity { Name = "Phoenix", Level = 65, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Shield.Name)
                            .AddItemType(ItemTypeEnumeration.Shield.Name)
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Vex")
                            .AddIngredient("Vex")
                            .AddIngredient("Lo")
                            .AddIngredient("Jah")

                            .AddProperty("100% Chance To Cast level 40 {skill} When You Level-up", SkillEnumeration.Blaze.Name)
                            .AddProperty("40% Chance To Cast Level 22 {skill} On Striking", SkillEnumeration.Firestorm.Name)
                            .AddProperty("Level 10-15 {skill} Aura When Equipped (varies)", SkillEnumeration.Redemption.Name)
                            .AddProperty("+350-400% Enhanced Damage (varies)")
                            .AddProperty("-28% To Enemy Fire Resistance")
                            .AddProperty("+350-400 Defense Vs. Missile (varies)")
                            .AddProperty("+15-21 Fire Absorb (varies)")
                            .AddProperty("Weapons: Ignores Target's Defense")
                            .AddProperty("Weapons: 14% Mana Stolen Per Hit")
                            .AddProperty("Weapons: 20% Deadly Strike")
                            .AddProperty("Shields: +50 To Life")
                            .AddProperty("Shields: +5% To Maximum Lightning Resist")
                            .AddProperty("Shields: +10% To Maximum Fire Resist"));

            result.Add(new RuneWordEntity { Name = "Pride", Level = 67, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)

                            .AddIngredient("Cham")
                            .AddIngredient("Sur")
                            .AddIngredient("Io")
                            .AddIngredient("Lo")

                            .AddProperty("25% Chance To Cast Level 17 {skill} When Struck", SkillEnumeration.FireWall.Name)
                            .AddProperty("Level 16-20 {skill} Aura When Equipped (varies)", SkillEnumeration.Concentration.Name)
                            .AddProperty("260-300% Bonus To Attack Rating (varies)")
                            .AddProperty("+(1*Clvl)% Damage To Demons (Based on Character Level)")
                            .AddProperty("Adds 50-280 Lightning Damage")
                            .AddProperty("20% Deadly Strike")
                            .AddProperty("Hit Blinds Target")
                            .AddProperty("Freezes Target +3")
                            .AddProperty("+10 To Vitality")
                            .AddProperty("Replenish Life +8")
                            .AddProperty("(1.875*Clvl)% Extra Gold From Monsters (Based on Character Level)"));

            result.Add(new RuneWordEntity { Name = "Principle", Level = 55, Class = ClassEnumeration.Paladin.Name }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Ral")
                            .AddIngredient("Gul")
                            .AddIngredient("Eld")

                            .AddProperty("100% Chance To Cast Level 5 {skill} On Striking", SkillEnumeration.HolyBolt.Name)
                            .AddProperty("+2 To Paladin Skill Levels")
                            .AddProperty("+50% Damage to Undead")
                            .AddProperty("+100-150 to Life (varies)")
                            .AddProperty("15% Slower Stamina Drain")
                            .AddProperty("+5% To Maximum Poison Resist")
                            .AddProperty("Fire Resist +30%"));

            result.Add(new RuneWordEntity { Name = "Prudence", Level = 49, }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Mal")
                            .AddIngredient("Tir")

                            .AddProperty("+25% Faster Hit Recovery")
                            .AddProperty("+140-170% Enhanced Defense (varies)")
                            .AddProperty("All Resistances +25-35 (varies)")
                            .AddProperty("Damage Reduced by 3")
                            .AddProperty("Magic Damage Reduced by 17")
                            .AddProperty("+2 To Mana After Each Kill")
                            .AddProperty("+1 To Light Radius")
                            .AddProperty("Repairs Durability 1 In 4 Seconds"));

            result.Add(new RuneWordEntity { Name = "Radiance", Level = 27 }
                            .AddItemType(ItemTypeEnumeration.Helmet.Name)

                            .AddIngredient("Nef")
                            .AddIngredient("Sol")
                            .AddIngredient("Ith")

                            .AddProperty("+75% Enhanced Defense")
                            .AddProperty("+30 Defense vs. Missiles")
                            .AddProperty("+10 to Vitality")
                            .AddProperty("+10 to Energy")
                            .AddProperty("+33 to Mana")
                            .AddProperty("Damage Reduced by 7")
                            .AddProperty("+1 To Light Radius")
                            .AddProperty("Magic Damage Reduced by 3")
                            .AddProperty("15% Damage Taken Goes to Mana")
                            .AddProperty("+5 to Light Radius"));

            result.Add(new RuneWordEntity { Name = "Rain", Level = 49, Class = ClassEnumeration.Druid.Name }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Ort")
                            .AddIngredient("Mal")
                            .AddIngredient("Ith")

                            .AddProperty("5% Chance To Cast Level 15 {skill} When Struck", SkillEnumeration.CycloneArmor.Name)
                            .AddProperty("5% Chance To Cast Level 15 {skill} On Striking", SkillEnumeration.Twister.Name)
                            .AddProperty("+2 To Druid Skills")
                            .AddProperty("+100-150 To Mana (varies)")
                            .AddProperty("Lightning Resist +30%")
                            .AddProperty("Magic Damage Reduced By 7")
                            .AddProperty("15% Damage Taken Goes to Mana"));

            result.Add(new RuneWordEntity { Name = "Rhyme", Level = 29 }
                            .AddItemType(ItemTypeEnumeration.Shield.Name)

                            .AddIngredient("Shael")
                            .AddIngredient("Eth")

                            .AddProperty("+40% Faster Block Rate")
                            .AddProperty("20% Increased Chance of Blocking")
                            .AddProperty("Regenerate Mana 15%")
                            .AddProperty("All Resistances +25")
                            .AddProperty("Cannot be Frozen")
                            .AddProperty("50% Extra Gold from Monsters")
                            .AddProperty("25% Better Chance of Getting Magic Items"));

            result.Add(new RuneWordEntity { Name = "Rift", Level = 53, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)

                            .AddIngredient("Hel")
                            .AddIngredient("Ko")
                            .AddIngredient("Lem")
                            .AddIngredient("Gul")

                            .AddProperty("20% Chance To Cast Level 16 {skill} On Striking", SkillEnumeration.Tornado.Name)
                            .AddProperty("16% Chance To Cast Level 21 {skill} On Attack", SkillEnumeration.FrozenOrb.Name)
                            .AddProperty("20% Bonus To Attack Rating")
                            .AddProperty("Adds 160-250 Magic Damage")
                            .AddProperty("Adds 60-180 Fire Damage")
                            .AddProperty("+5-10 To All Attributes (varies)")
                            .AddProperty("+10 To Dexterity")
                            .AddProperty("38% Damage Taken Goes To Mana")
                            .AddProperty("75% Extra Gold From Monsters")
                            .AddProperty("Level 15 {skill} (40 Charges)", SkillEnumeration.IronMaiden.Name)
                            .AddProperty("Requirements -20%"));

            result.Add(new RuneWordEntity { Name = "Sanctuary", Level = 49, IsLadder = false }
                            .AddItemType(ItemTypeEnumeration.Shield.Name)

                            .AddIngredient("Ko")
                            .AddIngredient("Ko")
                            .AddIngredient("Mal")

                            .AddProperty("+20% Faster Hit Recovery")
                            .AddProperty("+20% Faster Block Rate")
                            .AddProperty("20% Increased Chance of Blocking")
                            .AddProperty("+130-160% Enhanced Defense (varies)")
                            .AddProperty("+250 Defense vs. Missile")
                            .AddProperty("+20 To Dexterity")
                            .AddProperty("All Resistances +50-70 (varies)")
                            .AddProperty("Magic Damage Reduced By 7")
                            .AddProperty("Level 12 {skill} (60 Charges) ", SkillEnumeration.SlowMissiles.Name));

            result.Add(new RuneWordEntity { Name = "Silence", Level = 55, IsLadder = false }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Dol")
                            .AddIngredient("Eld")
                            .AddIngredient("Hel")
                            .AddIngredient("Ist")
                            .AddIngredient("Tir")
                            .AddIngredient("Vex")

                            .AddProperty("+2 to All Skills")
                            .AddProperty("+20% Increased Attack Speed")
                            .AddProperty("+20% Faster Hit Recovery")
                            .AddProperty("+200% Enhanced Defense (varies)")
                            .AddProperty("+75% Damage To Undead")
                            .AddProperty("+50 to Attack Rating Against Undead")
                            .AddProperty("Hit Blinds Target +33")
                            .AddProperty("Hit Causes Monster to Flee 25%")
                            .AddProperty("All Resistances +75")
                            .AddProperty("+2 to Mana After Each Kill")
                            .AddProperty("30% Better Chance of Getting Magic Items")
                            .AddProperty("Requirements -20%"));

            result.Add(new RuneWordEntity { Name = "Smoke", Level = 37, IsLadder = false }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Nef")
                            .AddIngredient("Lum")

                            .AddProperty("+20% Faster Hit Recovery")
                            .AddProperty("+75% Enhanced Defense")
                            .AddProperty("+280 Defense vs. Missiles")
                            .AddProperty("+10 to Energy")
                            .AddProperty("All Resistances +50")
                            .AddProperty("-1 to Light Radius")
                            .AddProperty("Level 6 {skill} (18 charges)", SkillEnumeration.Weaken.Name));

            result.Add(new RuneWordEntity { Name = "Spirit", Level = 25, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Shield.Name)
                            .AddItemType(ItemTypeEnumeration.Shield.Name)
                            .AddItemType(ItemTypeEnumeration.Sword.Name)

                            .AddIngredient("Tal")
                            .AddIngredient("Thul")
                            .AddIngredient("Ort")
                            .AddIngredient("Amn")

                            .AddProperty("+2 To All Skills")
                            .AddProperty("+25-35% Faster Cast Rate (varies)")
                            .AddProperty("+55% Faster Hit Recovery")
                            .AddProperty("+250 Defense Vs. Missile")
                            .AddProperty("+22 To Vitality")
                            .AddProperty("+89-112 To Mana (varies)")
                            .AddProperty("+3-8 Magic Absorb (varies)")
                            .AddProperty("Shields: Cold Resist +35%")
                            .AddProperty("Shields: Lightning Resist +35%")
                            .AddProperty("Shields: Poison Resist +35%")
                            .AddProperty("Shields: Attacker Takes Damage of 14")
                            .AddProperty("Swords: Adds 1-50 Lightning Damage")
                            .AddProperty("Swords: Adds 3-14 Cold Damage (3 Sec,Normal)")
                            .AddProperty("Swords: +75 Poison Damage Over 5 Seconds")
                            .AddProperty("Swords: 7% Life Stolen Per Hit"));

            result.Add(new RuneWordEntity { Name = "Splendor", Level = 37, }
                            .AddItemType(ItemTypeEnumeration.Shield.Name)

                            .AddIngredient("Eth")
                            .AddIngredient("Lum")

                            .AddProperty("+1 To All Skills")
                            .AddProperty("+10% Faster Cast Rate")
                            .AddProperty("+20% Faster Block Rate")
                            .AddProperty("+60-100% Enhanced Defense (varies)")
                            .AddProperty("+10 To Energy")
                            .AddProperty("Regenerate Mana 15%")
                            .AddProperty("50% Extra Gold From Monsters")
                            .AddProperty("20% Better Chance of Getting Magic Items")
                            .AddProperty("+3 To Light Radius"));

            result.Add(new RuneWordEntity { Name = "Stealth", Level = 17 }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Tal")
                            .AddIngredient("Eth")

                            .AddProperty("+25% Faster Run/Walk")
                            .AddProperty("+25% Faster Cast Rate")
                            .AddProperty("+25% Faster Hit Recovery")
                            .AddProperty("+6 to Dexterity")
                            .AddProperty("Regenerate Mana 15%")
                            .AddProperty("Poison Resist +30%")
                            .AddProperty("Magic Damage Reduced by 3"));

            result.Add(new RuneWordEntity { Name = "Steel", Level = 13 }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)

                            .AddIngredient("Tir")
                            .AddIngredient("El")

                            .AddProperty("+25% Increased Attack Speed")
                            .AddProperty("+20% Enhanced Damage")
                            .AddProperty("+3 to Minimum Damage")
                            .AddProperty("+3 to Maximum Damage")
                            .AddProperty("+50 to Attack Rating")
                            .AddProperty("50% Chance of Open Wounds")
                            .AddProperty("+2 to Mana after each Kill")
                            .AddProperty("+1 to Light Radius"));

            result.Add(new RuneWordEntity { Name = "Stone", Level = 47, }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Shael")
                            .AddIngredient("Um")
                            .AddIngredient("Pul")
                            .AddIngredient("Lum")

                            .AddProperty("+60% Faster Hit Recovery")
                            .AddProperty("+250-290% Enhanced Defense (varies)")
                            .AddProperty("+300 Defense Vs. Missile")
                            .AddProperty("+16 To Strength")
                            .AddProperty("+16 To Vitality")
                            .AddProperty("+10 To Energy")
                            .AddProperty("All Resistances +15")
                            .AddProperty("Level 16 {skill} (80 Charges)", SkillEnumeration.MoltenBoulder.Name)
                            .AddProperty("Level 16 {skill} (16 Charges) ", SkillEnumeration.ClayGolem.Name));

            result.Add(new RuneWordEntity { Name = "Strength", Level = 25 }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Dagger.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Club.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Wand.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Katar.Name)

                            .AddIngredient("Amn")
                            .AddIngredient("Tir")

                            .AddProperty("+35% Enhanced Damage")
                            .AddProperty("7% Life stolen per hit")
                            .AddProperty("25% Chance of Crushing Blow")
                            .AddProperty("+20 To Strength")
                            .AddProperty("+10 To Vitality")
                            .AddProperty("+2 to Mana after each Kill"));

            result.Add(new RuneWordEntity { Name = "Treachery", Level = 43, Class = ClassEnumeration.Assassin.Name }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Shael")
                            .AddIngredient("Thul")
                            .AddIngredient("Lem")

                            .AddProperty("5% Chance To Cast Level 15 {skill} When Struck", SkillEnumeration.Fade.Name)
                            .AddProperty("25% Chance To Cast level 15 {skill} On Striking", SkillEnumeration.Venom.Name)
                            .AddProperty("+2 To Assassin Skills")
                            .AddProperty("+45% Increased Attack Speed")
                            .AddProperty("+20% Faster Hit Recovery")
                            .AddProperty("Cold Resist +30%")
                            .AddProperty("50% Extra Gold From Monsters"));

            result.Add(new RuneWordEntity { Name = "Venom", Level = 49 }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Dagger.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Club.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)
                            .AddItemType(ItemTypeEnumeration.Katar.Name)
                            .AddItemType(ItemTypeEnumeration.Orb.Name)

                            .AddIngredient("Tal")
                            .AddIngredient("Dol")
                            .AddIngredient("Mal")

                            .AddProperty("Ignore Target's Defense")
                            .AddProperty("+273 Poison Damage Over 6 Seconds")
                            .AddProperty("7% Mana Stolen Per Hit")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("Hit Causes Monster To Flee 25%")
                            .AddProperty("Level 13 {skill} (11 Charges)", SkillEnumeration.PoisonNova.Name)
                            .AddProperty("Level 15 {skill} (27 Charges)", SkillEnumeration.PoisonExplosion.Name));

            result.Add(new RuneWordEntity { Name = "Voice of Reason", Level = 43, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Mace.Name)

                            .AddIngredient("Lem")
                            .AddIngredient("Ko")
                            .AddIngredient("El")
                            .AddIngredient("Eld")

                            .AddProperty("15% Chance To Cast Level 13 {skill} On Striking", SkillEnumeration.FrozenOrb.Name)
                            .AddProperty("18% Chance To Cast Level 20 {skill} On Striking", SkillEnumeration.IceBlast.Name)
                            .AddProperty("+50 To Attack Rating")
                            .AddProperty("+220-350% Damage To Demons (varies)")
                            .AddProperty("+355-375% Damage To Undead (varies)")
                            .AddProperty("+50 To Attack Rating Against Undead")
                            .AddProperty("Adds 100-220 Cold Damage")
                            .AddProperty("-24% To Enemy Cold Resistance")
                            .AddProperty("+10 To Dexterity")
                            .AddProperty("Cannot Be Frozen")
                            .AddProperty("75% Extra Gold From Monsters")
                            .AddProperty("+1 To Light Radius"));

            result.Add(new RuneWordEntity { Name = "Wealth", Level = 43 }
                            .AddItemType(ItemTypeEnumeration.BodyArmor.Name)

                            .AddIngredient("Lem")
                            .AddIngredient("Ko")
                            .AddIngredient("Tir")

                            .AddProperty("+10 to Dexterity")
                            .AddProperty("+2 to Mana After Each Kill")
                            .AddProperty("300% Extra Gold From Monsters")
                            .AddProperty("100% Better Chance of Getting Magic Items"));

            result.Add(new RuneWordEntity { Name = "White", Level = 35, Class = ClassEnumeration.Necromancer.Name }
                            .AddItemType(ItemTypeEnumeration.Wand.Name)

                            .AddIngredient("Dol")
                            .AddIngredient("Io")

                            .AddProperty("+3 to Poison and Bone Skills (Necromancer Only)")
                            .AddProperty("+20% Faster Cast Rate")
                            .AddProperty("+2 to {skill} (Necromancer Only)", SkillEnumeration.BoneSpear.Name)
                            .AddProperty("+4 to {skill} (Necromancer Only)", SkillEnumeration.SkeletonMastery.Name)
                            .AddProperty("+3 to {skill} (Necromancer Only)", SkillEnumeration.BoneArmor.Name)
                            .AddProperty("Hit causes monster to flee 25%")
                            .AddProperty("+10 to vitality")
                            .AddProperty("+13 to mana")
                            .AddProperty("Magic Damage Reduced by 4"));

            result.Add(new RuneWordEntity { Name = "Wind", Level = 61, }
                            .AddItemType(ItemTypeEnumeration.Sword.Name)
                            .AddItemType(ItemTypeEnumeration.Dagger.Name)
                            .AddItemType(ItemTypeEnumeration.Axe.Name)
                            .AddItemType(ItemTypeEnumeration.Club.Name)
                            .AddItemType(ItemTypeEnumeration.Hammer.Name)
                            .AddItemType(ItemTypeEnumeration.Scepter.Name)
                            .AddItemType(ItemTypeEnumeration.Staff.Name)
                            .AddItemType(ItemTypeEnumeration.Wand.Name)
                            .AddItemType(ItemTypeEnumeration.Spear.Name)
                            .AddItemType(ItemTypeEnumeration.Polearm.Name)
                            .AddItemType(ItemTypeEnumeration.Katar.Name)

                            .AddIngredient("Dol")
                            .AddIngredient("Io")

                            .AddProperty("10% Chance To Cast Level 9 {skill} On Striking", SkillEnumeration.Tornado.Name)
                            .AddProperty("+20% Faster Run/Walk")
                            .AddProperty("+40% Increased Attack Speed")
                            .AddProperty("+15% Faster Hit Recovery")
                            .AddProperty("+120-160% Enhanced Damage (varies)")
                            .AddProperty("-50% Target Defense")
                            .AddProperty("+50 To Attack Rating")
                            .AddProperty("Hit Blinds Target")
                            .AddProperty("+1 To Light Radius")
                            .AddProperty("Level 13 {skill} (127 Charges)", SkillEnumeration.Twister.Name));

            result.Add(new RuneWordEntity { Name = "Wrath", Level = 63, IsLadder = true }
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Pul")
                            .AddIngredient("Lum")
                            .AddIngredient("Ber")
                            .AddIngredient("Mal")

                            .AddProperty("30% Chance To Cast Level 1 {skill} On Striking", SkillEnumeration.Decrepify.Name)
                            .AddProperty("5% Chance To Cast Level 10 {skill} On Striking", SkillEnumeration.LifeTap.Name)
                            .AddProperty("+375% Damage To Demons")
                            .AddProperty("+100 To Attack Rating Against Demons")
                            .AddProperty("+250-300% Damage To Undead (varies)")
                            .AddProperty("Adds 85-120 Magic Damage")
                            .AddProperty("Adds 41-240 Lightning Damage")
                            .AddProperty("20% Chance of Crushing Blow")
                            .AddProperty("Prevent Monster Heal")
                            .AddProperty("+10 To Energy")
                            .AddProperty("Cannot Be Frozen"));

            result.Add(new RuneWordEntity { Name = "Zephyr", Level = 21 }
                            .AddItemType(ItemTypeEnumeration.Bow.Name)
                            .AddItemType(ItemTypeEnumeration.Crossbow.Name)

                            .AddIngredient("Ort")
                            .AddIngredient("Eth")

                            .AddProperty("7% Chance to Cast Level 1 {skill} When Struck", SkillEnumeration.Twister.Name)
                            .AddProperty("+25% Faster Run/Walk")
                            .AddProperty("+25% Increased Attack Speed")
                            .AddProperty("+33% Enhanced Damage")
                            .AddProperty("-25% Target Defense")
                            .AddProperty("+66 to Attack Rating")
                            .AddProperty("Adds 1-50 lightning damage")
                            .AddProperty("+25 Defense"));

            return result;
        }
    }

    public static class RuneWordExtension
    {
        public static RuneWordEntity AddProperty(this RuneWordEntity entity, string description)
        {
            return entity.AddProperty(description, null);
        }
        public static RuneWordEntity AddProperty(this RuneWordEntity entity, string description, bool isIndestructibleOrSelfRepair)
        {
            return entity.AddProperty(description, null);
        }
        public static RuneWordEntity AddProperty(this RuneWordEntity entity, string description, string skill)
        {
            entity.Properties.Add(new RuneWordPropertyEntity { RuneWord = entity, Description = description, Skill = new SkillEntity { Name = skill } });
            return entity;
        }
        public static RuneWordEntity AddIngredient(this RuneWordEntity entity, string rune)
        {
            entity.Ingredients.Add(new RuneWordIngredientEntity { RuneWord = entity, Rune = new RuneEntity { Name = rune }, Order = entity.Ingredients.Count });
            return entity;
        }
        public static RuneWordEntity AddItemType(this RuneWordEntity entity, string itemType)
        {
            entity.ItemTypes.Add(new RuneWordItemTypeEntity { RuneWord = entity, ItemType = new ItemTypeEntity { Name = itemType } });
            return entity;
        }
    }

    public class ItemTypeEnumeration : Enumeration
    {
        private static int _count = 0;

        public static ItemTypeEnumeration BodyArmor => new ItemTypeEnumeration(_count++, "Body armor");
        public static ItemTypeEnumeration Shield => new ItemTypeEnumeration(_count++, "Shield");
        public static ItemTypeEnumeration Helmet => new ItemTypeEnumeration(_count++, "Helmet");

        public static ItemTypeEnumeration Sword => new ItemTypeEnumeration(_count++, "Sword");
        public static ItemTypeEnumeration Dagger => new ItemTypeEnumeration(_count++, "Dagger");
        public static ItemTypeEnumeration Axe => new ItemTypeEnumeration(_count++, "Axe");
        public static ItemTypeEnumeration Club => new ItemTypeEnumeration(_count++, "Club");
        public static ItemTypeEnumeration Mace => new ItemTypeEnumeration(_count++, "Mace");
        public static ItemTypeEnumeration Hammer => new ItemTypeEnumeration(_count++, "Hammer");
        public static ItemTypeEnumeration Scepter => new ItemTypeEnumeration(_count++, "Scepter");
        public static ItemTypeEnumeration Staff => new ItemTypeEnumeration(_count++, "Staff");
        public static ItemTypeEnumeration Wand => new ItemTypeEnumeration(_count++, "Wand");
        public static ItemTypeEnumeration Spear => new ItemTypeEnumeration(_count++, "Spear");
        public static ItemTypeEnumeration Polearm => new ItemTypeEnumeration(_count++, "Polearm");
        public static ItemTypeEnumeration Bow => new ItemTypeEnumeration(_count++, "Bow");
        public static ItemTypeEnumeration Crossbow => new ItemTypeEnumeration(_count++, "Crossbow");
        public static ItemTypeEnumeration Katar => new ItemTypeEnumeration(_count++, "Katar");
        public static ItemTypeEnumeration Orb => new ItemTypeEnumeration(_count++, "Orb");

        public ItemTypeEnumeration(int id, string flag)
            : base(id, flag)
        {
        }
    }
}
