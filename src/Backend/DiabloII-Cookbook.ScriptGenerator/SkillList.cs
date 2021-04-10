using DiabloII_Cookbook.Api.Enumerations;
using DiabloII_Cookbook.Application.Entities;
using Netension.Core;
using System.Collections.Generic;

namespace DiabloII_Cookbook.ScriptGenerator
{
    public class SkillList
    {
        public IEnumerable<SkillEntity> Values => GenerateValues();

        private IEnumerable<SkillEntity> GenerateValues()
        {
            var result = new List<SkillEntity>();

            result.Add(new SkillEntity { Name = SkillEnumeration.Fanaticism.Name, Class = ClassEnumeration.Paladin.Name, Description = "Fanaticism increases the damage, attack speed, and attack rating of the Paladin and everyone in his party." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Thorns.Name, Class = ClassEnumeration.Paladin.Name, Description = "Creates a spiky barrier around the Paladin and all in his party, reflecting huge damage back against melee, physical attackers. Has no effect against ranged or elemental attacks." });
            result.Add(new SkillEntity { Name = SkillEnumeration.HolyFreeze.Name, Class = ClassEnumeration.Paladin.Name, Description = "This aura chills and slows the movement and attack speed of all enemies within range." });
            result.Add(new SkillEntity { Name = SkillEnumeration.HolyFire.Name, Class = ClassEnumeration.Paladin.Name, Description = "Holy Fire adds fire damage to the Paladin's attacks, as well as dealing a few points of fire damage to every monster in range." });
            result.Add(new SkillEntity { Name = SkillEnumeration.HolyShock.Name, Class = ClassEnumeration.Paladin.Name, Description = "Holy Shock adds lightning damage to the Paladin's attacks, as well as dealing a few points of lightning damage to every monster in range." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Defiance.Name, Class = ClassEnumeration.Paladin.Name, Description = "This aura boosts the defense of the Paladin and all characters and minions in his party." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Vigor.Name, Class = ClassEnumeration.Paladin.Name, Description = "Vigor boosts the running speed, maximum stamina, and stamina regeneration rate for the Paladin and all in his party." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Conviction.Name, Class = ClassEnumeration.Paladin.Name, Description = "This aura lowers the defense and fire, lightning, and cold resistances of monsters, making it ideal to pair with an elemental weapon or skill, such as Vengeance." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Meditation.Name, Class = ClassEnumeration.Paladin.Name, Description = "Boosts the mana regeneration rate for the Paladin and all his party members." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Might.Name, Class = ClassEnumeration.Paladin.Name, Description = "Might increases the output of all physical damage attacks by the Paladin or his party." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Sanctuary.Name, Class = ClassEnumeration.Paladin.Name, Description = "This aura only works against the Undead, but provides the Paladin with a substantial damage bonus, as well as working to push back and constantly deal holy damage to all Undead in range." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Redemption.Name, Class = ClassEnumeration.Paladin.Name, Description = "Redemption uses up corpses, making them vanish with a lovely rising spirit graphic (also seen coming up from the skeletons after Radament is defeated in the Act Two Sewers), and transferring substantial mana and life to the Paladin." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Concentration.Name, Class = ClassEnumeration.Paladin.Name, Description = "Concentration greatly increases the physical damage of the Paladin and all in his party." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Vengeance.Name, Class = ClassEnumeration.Paladin.Name, Description = "A powerful single-hit attack that adds fire, lightning, and cold damage." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Zeal.Name, Class = ClassEnumeration.Paladin.Name, Description = "Zeal is a rapid, multi-strike attack with substantial bonuses to attack rating, attack speed, and damage." });
            result.Add(new SkillEntity { Name = SkillEnumeration.HolyBolt.Name, Class = ClassEnumeration.Paladin.Name, Description = "A glowing, magical projectile is fired out at a medium rate of speed. This projectile will damage enemy undead monsters, and heal friends." });

            result.Add(new SkillEntity { Name = SkillEnumeration.Werebear.Name, Class = ClassEnumeration.Druid.Name, Description = "This skill enables the Druid to transform into a Werebear. It includes substantial bonuses to his defense, damage, and life." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Lycanthropy.Name, Class = ClassEnumeration.Druid.Name, Description = "This skill adds a passive bonus that allows the Druid to remain in fur form much longer. There is also a substantial hit point boost." });
            result.Add(new SkillEntity { Name = SkillEnumeration.SummonGrizzly.Name, Class = ClassEnumeration.Druid.Name, Description = "Summoned Grizzlies are fierce minions, capable of inflicting heavy damage. Grizzlies move slowly, but have strong attacks that stun and knock back their targets." });
            result.Add(new SkillEntity { Name = SkillEnumeration.SpiritOfBarbs.Name, Class = ClassEnumeration.Druid.Name, Description = "This spirit bestows a Thorns aura on the Druid and all in his party. This skill is largely ignored since the damage reflected is woefully inadequate to make it viable past normal difficulty." });
            result.Add(new SkillEntity { Name = SkillEnumeration.SummonSpiritWolf.Name, Class = ClassEnumeration.Druid.Name, Description = "This gift of Nature allows the Druid to conjure forth one or more wolf allies who, with their mystical powers, provide the Druid a potent and ferocious colleague." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Volcano.Name, Class = ClassEnumeration.Druid.Name, Description = "A more powerful version of Fissure, the Volcano erupts from one point and deals substantial fire damage to everything in the vicinity." });
            result.Add(new SkillEntity { Name = SkillEnumeration.MoltenBoulder.Name, Class = ClassEnumeration.Druid.Name, Description = "A fun skill to use, this one sends forth a rolling boulder of molten stone." });
            result.Add(new SkillEntity { Name = SkillEnumeration.OakSage.Name, Class = ClassEnumeration.Druid.Name, Description = "The Oak Sage spirit floats around, radiating a hit point enhancing aura that affects the Druid and all characters and minions in his party. Spirits are living things, and if killed their enhancing aura vanishes." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Raven.Name, Class = ClassEnumeration.Druid.Name, Description = "Ravens swarm in a cloud and look nifty, but their damage is negligible and their AI is lacking. This skill is useful only as a prerequisite or a novelty." });
            result.Add(new SkillEntity { Name = SkillEnumeration.CycloneArmor.Name, Class = ClassEnumeration.Druid.Name, Description = "This shielding spell is essentially an elemental version of the Necromancer's Bone Shield. It absorbs a set amount of elemental damage, but has no effect against physical attacks." });
            result.Add(new SkillEntity { Name = SkillEnumeration.HeartOfWolverine.Name, Class = ClassEnumeration.Druid.Name, Description = "This spirit's aura provides a hearty attack rating and damage bonus to the Druid and all players and minions in his party." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Firestorm.Name, Class = ClassEnumeration.Druid.Name, Description = "Wielding this ability, the Druid projects waves of molten earth that spread outward and burn a wide swath of destruction through his foes." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Twister.Name, Class = ClassEnumeration.Druid.Name, Description = "Each cast of Twister sets up a small tornado that stuns and deals physical damage to any enemies in the area." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Tornado.Name, Class = ClassEnumeration.Druid.Name, Description = "An upgraded version of Twister, a Tornado is much larger and more powerful, but lacks the stunning effect of the smaller Twisters." });

            result.Add(new SkillEntity { Name = SkillEnumeration.CorpseExplosion.Name, Class = ClassEnumeration.Necromancer.Name, Description = "One of the messiest and most fun skills in the game, Corpse Explosion detonates fallen monster corpses in messy sprays of bone and blood, striking all nearby enemies for substantial fire and physical damage." });
            result.Add(new SkillEntity { Name = SkillEnumeration.BoneArmor.Name, Class = ClassEnumeration.Necromancer.Name, Description = "An orbiting shield that absorbs a set amount of physical damage before vanishing." });
            result.Add(new SkillEntity { Name = SkillEnumeration.BoneSpear.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Bone Spear fires a straight shot of magical damage bone that can pass through any number of targets. It does less damage to each target than Bone Spirit (until very high levels), but can hit multiple enemies, and is very effective against large mobs, or in narrow hallways, such as inside the Maggot Lair. Their damage is magical so only by raise skill levels can you increase it." });
            result.Add(new SkillEntity { Name = SkillEnumeration.AmplifyDamage.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Amplify damage greatly increases the physical damage taken by any afflicted target. Use this on monsters that are being beaten on by minions or other players." });
            result.Add(new SkillEntity { Name = SkillEnumeration.PoisonNova.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Poison Nova sends out an expanding circle of toxic bolts, poisoning everything within range, and virtually everything on the screen." });
            result.Add(new SkillEntity { Name = SkillEnumeration.BloodGolem.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Blood Golems are linked to the Necromancer who casts them. As the Blood Golem damages the target it leeches life, and shares this with the Necromancer. Before v1.13, the Necromancer would also lose life as the golem took damage, but this is no longer the case." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Terror.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Cursed monsters run away at very high speed." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Confuse.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Confused monsters attack whatever target is nearest them, including other monsters." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Attract.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Attract works in a similar way to confuse, however instead of making monsters behave randomly, it will make them always attack the enemy." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Revive.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Revives the dead monster, raising it up in its living form, but coloured dark gray. Revived monsters retain most of their attributes from life, and deal the same damage, type of damage, attack speed, foot speed, and more. Revives gain a bonus to their hit points, damage, and resistances." });
            result.Add(new SkillEntity { Name = SkillEnumeration.LifeTap.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Life Tap causes huge life leech to flow to any physical damage attacker." });
            result.Add(new SkillEntity { Name = SkillEnumeration.DimVision.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Monsters that have had their vision dimmed no longer see their enemies. They will stand still, or randomly move in short distances, but will fight back against melee attackers." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Decrepify.Name, Class = ClassEnumeration.Necromancer.Name, Description = "This powerful curse lowers movement, attack speed, damage and physical resistance by 50%." });
            result.Add(new SkillEntity { Name = SkillEnumeration.BoneSpirit.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Bone Spirits are slow-moving, homing missiles that will track targets for quite a distance off the screen." });
            result.Add(new SkillEntity { Name = SkillEnumeration.IronGolem.Name, Class = ClassEnumeration.Necromancer.Name, Description = "This golem is created from the item, and takes on properties of the item." });
            result.Add(new SkillEntity { Name = SkillEnumeration.IronMaiden.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Causes the physical, melee damage inflicted by the target to reflect back to themselves. Does not effect non-physical damage, or non-melee attacks." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Weaken.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Lowers the physical damage the target inflicts by 33%." });
            result.Add(new SkillEntity { Name = SkillEnumeration.ClayGolem.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Raises a Golem from the earth to fight for you." });
            result.Add(new SkillEntity { Name = SkillEnumeration.PoisonExplosion.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Like Corpse Explosion, but with poison damage." });
            result.Add(new SkillEntity { Name = SkillEnumeration.SkeletonMastery.Name, Class = ClassEnumeration.Necromancer.Name, Description = "Increases the hit points and damage dealt by Skeletons, Skeleton Mages, and Revived." });

            result.Add(new SkillEntity { Name = SkillEnumeration.ExplodingArrow.Name, Class = ClassEnumeration.Amazon.Name, Description = "Enchants arrows by adding explosive fire damage to them. The flame splashes enough to strike several monsters in a tight cluster, and there is an accuracy bonus as well." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Valkyrie.Name, Class = ClassEnumeration.Amazon.Name, Description = "Valkyries are powerful magical tanks. They spawn with high defense and hit points, and can stand up to a tremendous amount of damage." });
            result.Add(new SkillEntity { Name = SkillEnumeration.SlowMissiles.Name, Class = ClassEnumeration.Amazon.Name, Description = "A curse-like debuff skill that slows the missles of all monsters within the skill's range." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Dodge.Name, Class = ClassEnumeration.Amazon.Name, Description = "Allows the Amazon to dodge melee attacks while standing still or attacking." });
            result.Add(new SkillEntity { Name = SkillEnumeration.CriticalStrike.Name, Class = ClassEnumeration.Amazon.Name, Description = "This extremely powerful skill gives a chance to deal a critical strike, doubling the physical damage of an attack with any sort of weapon." });

            result.Add(new SkillEntity { Name = SkillEnumeration.BattleCommand.Name, Class = ClassEnumeration.Barbarian.Name, Description = "Battle Command adds a +1 to all of the Barbarian's skills, and does the same for all characters and minions in his party." });
            result.Add(new SkillEntity { Name = SkillEnumeration.BattleOrders.Name, Class = ClassEnumeration.Barbarian.Name, Description = "It works on the Barbarian and all friendly players and their minions, increasing everyone's maximum hit points, stamina, and mana by a percentage." });
            result.Add(new SkillEntity { Name = SkillEnumeration.BattleCry.Name, Class = ClassEnumeration.Barbarian.Name, Description = "This one frightens nearby monster reducing their AC and damage." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Whirlwind.Name, Class = ClassEnumeration.Barbarian.Name, Description = "Whirlwind is the Tasmanian Devil of Barbarian skills, turning the character into a spinning death-dealer, capable of passing through huge mobs and hitting dozens of targets with a single use of the skill. There are dangers as well, and a great many details to grasp in order to use this skill expertly." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Frenzy.Name, Class = ClassEnumeration.Barbarian.Name, Description = "Frenzy allows the Barbarian to strike and move much faster, with any skill. Use Frenzy to speed up, then switch to other skills for a hyperfast attack." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Howl.Name, Class = ClassEnumeration.Barbarian.Name, Description = "Howling will cause affected monsters to cease attacking and retreat as a green 'rain' drizzles down on them." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Taunt.Name, Class = ClassEnumeration.Barbarian.Name, Description = "Taunt is set up to get those pesky fleeing monsters to come to you." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Berserk.Name, Class = ClassEnumeration.Barbarian.Name, Description = "Berserk gives the Barbarian a way to deal a huge amount of magical (non-physical) damage with a melee attack, saving him from needing to use elemental damage weapons to kill Stone Skin and Physical Immune monsters." });

            result.Add(new SkillEntity { Name = SkillEnumeration.FrozenOrb.Name, Class = ClassEnumeration.Sorceress.Name, Description = "One of the more awesome spells in the game, Frozen Orb fires out a glowing orb of ice that spins across most of the visible screen, emitting dozens of tiny Ice Bolts in all directions." });
            result.Add(new SkillEntity { Name = SkillEnumeration.ChargedBolt.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Charged bolt is one of the first skills a sorceress can learn, and is one of the few level 1 skills that scales well end game." });
            result.Add(new SkillEntity { Name = SkillEnumeration.ChainLightning.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Chain Lightning jumps from target to target, and can be quite impressive when cast on a cluster of enemies." });
            result.Add(new SkillEntity { Name = SkillEnumeration.StaticField.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Static Field hits every monster in range, instantly chopping 25% off of their current hit points (similar to crushing blow)." });
            result.Add(new SkillEntity { Name = SkillEnumeration.GlacialSpike.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Shoots a large snowball that hits with substantial damage and a large splash effect, freezing the targeted monster and anything within 2.6 yards." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Meteor.Name, Class = ClassEnumeration.Sorceress.Name, Description = "A flaming ball of rock is called down from above, dealing explosive damage to the target and leaving a patch of fiery burning earth behind." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Nova.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Nova casts an expanding ring of lightning that strikes everything in its path, extending nearly to the edge of the screen." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Hydra.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Hydras are three-headed dragons composed of pure flame. The heads each fire a constant stream of Fire Bolts, dealing damage to the target, but not splashing to the sides." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Teleport.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Teleport moves the Sorceress instantly to any valid location she can point her cursor at." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Blaze.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Blaze leaves a trail of fire behind the Sorceress as she walks or runs along, for as long as she keeps the spell active." });
            result.Add(new SkillEntity { Name = SkillEnumeration.FireBall.Name, Class = ClassEnumeration.Sorceress.Name, Description = "A substantial upgrade from Firebolt, Fireballs are larger and more damaging, and they hit with splash damage, burning the target and any nearby monsters too." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Warmth.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Warmth increases the Sorceress' mana regeneration rate." });
            result.Add(new SkillEntity { Name = SkillEnumeration.ChillingArmor.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Chilling Armor provides a slightly smaller defensive bonus than Shiver Armor (but larger than Frozen Armor)." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Blizzard.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Blizzard is an area effect spell, calling down an icy storm that chills and cold damages everything over a wide area." });
            result.Add(new SkillEntity { Name = SkillEnumeration.FrostNova.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Creates and expanding ring of ice that damages enemies with cold damage and slows enemies." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Inferno.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Inferno turns a Sorceress into a human flamethrower, capable of emitting a massive spout of flame for as long as the spell is kept active." });
            result.Add(new SkillEntity { Name = SkillEnumeration.FireBolt.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Shoots a small ball of fire. Fire Bolts hit only one target and have no splash damage." });
            result.Add(new SkillEntity { Name = SkillEnumeration.EnergyShield.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Energy Shield allows the Sorceress to redirect damage from life to mana." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Enchant.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Temporarily grants bonus fire damage and boosts the Attack Rating of any friendly player or minion. Enchant must be cast directly on the recipient." });
            result.Add(new SkillEntity { Name = SkillEnumeration.FireWall.Name, Class = ClassEnumeration.Sorceress.Name, Description = "A wall of flame springs up in both directions from the spot the Sorceress targets for ignition." });
            result.Add(new SkillEntity { Name = SkillEnumeration.IceBlast.Name, Class = ClassEnumeration.Sorceress.Name, Description = "Shoots a large snowball that hits with cold damage, freezing the target." });

            result.Add(new SkillEntity { Name = SkillEnumeration.MindBlast.Name, Class = ClassEnumeration.Assassin.Name, Description = "Focusing her anima, an Assassin using this potent ability can crush the will of a group of enemies. Mind Blast stuns and confuses the feeble minded into attacking their comrades." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Venom.Name, Class = ClassEnumeration.Assassin.Name, Description = "Poison use is another technique an Assassin has to help even the odds when battling demons and their ilk." });
            result.Add(new SkillEntity { Name = SkillEnumeration.Fade.Name, Class = ClassEnumeration.Assassin.Name, Description = "Raises all resistances and resists curses for a period of time." });
            result.Add(new SkillEntity { Name = SkillEnumeration.ClockOfShadows.Name, Class = ClassEnumeration.Assassin.Name, Description = "This spell blocks some monster effects; sand maggots cannot lay eggs, unravelers cannot use their poison breath, venom lords cannot use their Inferno attack etc." });

            return result;
        }
    }

    public class SkillEnumeration : Enumeration
    {
        private static int _count;

        public static SkillEnumeration Fanaticism => new SkillEnumeration(_count++, "Fanaticism");
        public static SkillEnumeration Werebear => new SkillEnumeration(_count++, "Werebear");
        public static SkillEnumeration Lycanthropy => new SkillEnumeration(_count++, "Lycanthropy");
        public static SkillEnumeration SummonGrizzly => new SkillEnumeration(_count++, "Summon Grizzly");
        public static SkillEnumeration CorpseExplosion => new SkillEnumeration(_count++, "Corpse Explosion");
        public static SkillEnumeration BoneArmor => new SkillEnumeration(_count++, "Bone Armor");
        public static SkillEnumeration BoneSpear => new SkillEnumeration(_count++, "Bone Spear");
        public static SkillEnumeration Thorns => new SkillEnumeration(_count++, "Thorns");
        public static SkillEnumeration SpiritOfBarbs => new SkillEnumeration(_count++, "Spirit Of Barbs");
        public static SkillEnumeration AmplifyDamage => new SkillEnumeration(_count++, "Amplify Damage");
        public static SkillEnumeration ExplodingArrow => new SkillEnumeration(_count++, "Exploding Arrow");
        public static SkillEnumeration PoisonNova => new SkillEnumeration(_count++, "Poison Nova");
        public static SkillEnumeration BattleCommand => new SkillEnumeration(_count++, "Battle Command");
        public static SkillEnumeration BattleOrders => new SkillEnumeration(_count++, "Battle Orders");
        public static SkillEnumeration BattleCry => new SkillEnumeration(_count++, "Battle Cry");
        public static SkillEnumeration FrozenOrb => new SkillEnumeration(_count++, "Forzen Orb");
        public static SkillEnumeration ChargedBolt => new SkillEnumeration(_count++, "Charged Bolt");
        public static SkillEnumeration Whirlwind => new SkillEnumeration(_count++, "Whirlwind");
        public static SkillEnumeration ChainLightning => new SkillEnumeration(_count++, "Chain Lightning");
        public static SkillEnumeration StaticField => new SkillEnumeration(_count++, "Static Field");
        public static SkillEnumeration SummonSpiritWolf => new SkillEnumeration(_count++, "Summon Spirit Wolf");
        public static SkillEnumeration GlacialSpike => new SkillEnumeration(_count++, "Glacial Spike");
        public static SkillEnumeration BloodGolem => new SkillEnumeration(_count++, "Blood Golem");
        public static SkillEnumeration MindBlast => new SkillEnumeration(_count++, "Mind Blast");
        public static SkillEnumeration Terror => new SkillEnumeration(_count++, "Terror");
        public static SkillEnumeration Confuse => new SkillEnumeration(_count++, "Confuse");
        public static SkillEnumeration Attract => new SkillEnumeration(_count++, "Attract");
        public static SkillEnumeration Volcano => new SkillEnumeration(_count++, "Volcano");
        public static SkillEnumeration MoltenBoulder => new SkillEnumeration(_count++, "Molten Boulder");
        public static SkillEnumeration Meteor => new SkillEnumeration(_count++, "Meteor");
        public static SkillEnumeration Nova => new SkillEnumeration(_count++, "Nova");
        public static SkillEnumeration HolyFreeze => new SkillEnumeration(_count++, "Holy Freeze");
        public static SkillEnumeration Hydra => new SkillEnumeration(_count++, "Hydra");
        public static SkillEnumeration Venom => new SkillEnumeration(_count++, "Venom");
        public static SkillEnumeration HolyFire => new SkillEnumeration(_count++, "Holy Fire");
        public static SkillEnumeration HolyShock => new SkillEnumeration(_count++, "Holy Shock");
        public static SkillEnumeration Teleport => new SkillEnumeration(_count++, "Teleport");
        public static SkillEnumeration Blaze => new SkillEnumeration(_count++, "Blaze");
        public static SkillEnumeration FireBall => new SkillEnumeration(_count++, "Fire Ball");
        public static SkillEnumeration Warmth => new SkillEnumeration(_count++, "Warmth");
        public static SkillEnumeration Revive => new SkillEnumeration(_count++, "Revive");
        public static SkillEnumeration LifeTap => new SkillEnumeration(_count++, "Life Tap");
        public static SkillEnumeration Defiance => new SkillEnumeration(_count++, "Defiance");
        public static SkillEnumeration ChillingArmor => new SkillEnumeration(_count++, "Chilling Armor");
        public static SkillEnumeration Frenzy => new SkillEnumeration(_count++, "Frenzy");
        public static SkillEnumeration DimVision => new SkillEnumeration(_count++, "Dim Vision");
        public static SkillEnumeration Vigor => new SkillEnumeration(_count++, "Vigor");
        public static SkillEnumeration Valkyrie => new SkillEnumeration(_count++, "Valkyrie");
        public static SkillEnumeration OakSage => new SkillEnumeration(_count++, "Oak Sage");
        public static SkillEnumeration Raven => new SkillEnumeration(_count++, "Raven");
        public static SkillEnumeration Blizzard => new SkillEnumeration(_count++, "Blizzard");
        public static SkillEnumeration FrostNova => new SkillEnumeration(_count++, "FrostNova");
        public static SkillEnumeration Conviction => new SkillEnumeration(_count++, "Conviction");
        public static SkillEnumeration CycloneArmor => new SkillEnumeration(_count++, "CycloneArmor");
        public static SkillEnumeration Meditation => new SkillEnumeration(_count++, "Meditation");
        public static SkillEnumeration Vengeance => new SkillEnumeration(_count++, "Vengeance");
        public static SkillEnumeration Fade => new SkillEnumeration(_count++, "Fade");
        public static SkillEnumeration Might => new SkillEnumeration(_count++, "Might");
        public static SkillEnumeration Decrepify => new SkillEnumeration(_count++, "Decrepify");
        public static SkillEnumeration Sanctuary => new SkillEnumeration(_count++, "Sanctuary");
        public static SkillEnumeration Inferno => new SkillEnumeration(_count++, "Inferno");
        public static SkillEnumeration FireBolt => new SkillEnumeration(_count++, "Fire Bolt");
        public static SkillEnumeration SlowMissiles => new SkillEnumeration(_count++, "Slow Missiles");
        public static SkillEnumeration Dodge => new SkillEnumeration(_count++, "Dodge");
        public static SkillEnumeration CriticalStrike => new SkillEnumeration(_count++, "Critical Strike");
        public static SkillEnumeration EnergyShield => new SkillEnumeration(_count++, "Energy Shield");
        public static SkillEnumeration Howl => new SkillEnumeration(_count++, "Howl");
        public static SkillEnumeration Taunt => new SkillEnumeration(_count++, "Taunt");
        public static SkillEnumeration ClockOfShadows => new SkillEnumeration(_count++, "Clock of Shadows");
        public static SkillEnumeration BoneSpirit => new SkillEnumeration(_count++, "Bone Spirit");
        public static SkillEnumeration HeartOfWolverine => new SkillEnumeration(_count++, "Heart of Wolverine");
        public static SkillEnumeration IronGolem => new SkillEnumeration(_count++, "Iron Golem");
        public static SkillEnumeration Enchant => new SkillEnumeration(_count++, "Enchant");
        public static SkillEnumeration Berserk => new SkillEnumeration(_count++, "Berserk");
        public static SkillEnumeration Zeal => new SkillEnumeration(_count++, "Zeal");
        public static SkillEnumeration Firestorm => new SkillEnumeration(_count++, "Firestorm");
        public static SkillEnumeration Redemption => new SkillEnumeration(_count++, "Redemption");
        public static SkillEnumeration FireWall => new SkillEnumeration(_count++, "Fire Wall");
        public static SkillEnumeration Concentration => new SkillEnumeration(_count++, "Concentration");
        public static SkillEnumeration HolyBolt => new SkillEnumeration(_count++, "Holy Bolt");
        public static SkillEnumeration Twister => new SkillEnumeration(_count++, "Twister");
        public static SkillEnumeration Tornado => new SkillEnumeration(_count++, "Tornado");
        public static SkillEnumeration IronMaiden => new SkillEnumeration(_count++, "Iron Maiden");
        public static SkillEnumeration Weaken => new SkillEnumeration(_count++, "Weaken");
        public static SkillEnumeration ClayGolem => new SkillEnumeration(_count++, "Clay Golem");
        public static SkillEnumeration PoisonExplosion => new SkillEnumeration(_count++, "Poison Explosion");
        public static SkillEnumeration IceBlast => new SkillEnumeration(_count++, "Ice Blast");
        public static SkillEnumeration SkeletonMastery => new SkillEnumeration(_count++, "Skeleton Mastery");

        public SkillEnumeration(int id, string name)
            : base(id, name)
        {

        }
    }
}
