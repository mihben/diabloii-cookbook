using DiabloII_Cookbook.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DiabloII_Cookbook.Application.DatabaseContexts
{
    public static class ModelBuilderExtensions
    {
        public static void BuildFilterEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilterEntity>()
                .ToTable("filters")
                .HasKey(fe => new { fe.Id });

            modelBuilder.Entity<FilterEntity>()
                .Property(fe => fe.Id)
                .HasColumnName("id");
            modelBuilder.Entity<FilterEntity>()
                .HasOne(fe => fe.Character)
                .WithMany(ce => ce.Filters)
                .HasForeignKey(fe => fe.CharacterId)
                .HasConstraintName("fk_filter_entity_character");
            modelBuilder.Entity<FilterEntity>()
                .HasOne(fe => fe.ItemType)
                .WithMany(ite => ite.Filters)
                .HasForeignKey(fe => fe.ItemTypeId)
                .HasConstraintName("fk_filter_entity_item_type");
            modelBuilder.Entity<FilterEntity>()
                .Property(fe => fe.CharacterId)
                .HasColumnName("character_id");
            modelBuilder.Entity<FilterEntity>()
                .Property(fe => fe.ItemTypeId)
                .HasColumnName("item_type_id");
        }

        public static void BuildAccountEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEntity>()
                   .ToTable("accounts")
                   .HasKey(re => new { re.Id });

            modelBuilder.Entity<AccountEntity>()
                .Property(re => re.Id)
                .HasColumnName("id")
                .IsConcurrencyToken();
            modelBuilder.Entity<AccountEntity>()
                .Property(re => re.BattleTag)
                .HasColumnName("battle_tag");
            modelBuilder.Entity<AccountEntity>()
                .HasMany(re => re.Characters)
                .WithOne(ce => ce.Account)
                .HasForeignKey(ce => ce.AccountId)
                .IsRequired();
        }

        public static void BuildRuneEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RuneEntity>()
                   .ToTable("runes")
                   .HasKey(re => new { re.Id });

            modelBuilder.Entity<RuneEntity>()
                .Property(re => re.Id)
                .HasColumnName("id");
            modelBuilder.Entity<RuneEntity>()
                .Property(re => re.Name)
                .HasColumnName("name")
                .IsRequired();
            modelBuilder.Entity<RuneEntity>()
                .Property(re => re.Level)
                .HasColumnName("level")
                .IsRequired();
            modelBuilder.Entity<RuneEntity>()
                .Property(re => re.Order)
                .HasColumnName("order")
                .IsRequired();
            modelBuilder.Entity<RuneEntity>()
                .Property(re => re.InWeapon)
                .HasColumnName("in_weapon")
                .IsRequired();
            modelBuilder.Entity<RuneEntity>()
                .Property(re => re.InHelm)
                .HasColumnName("in_helm")
                .IsRequired();
            modelBuilder.Entity<RuneEntity>()
                .Property(re => re.InArmor)
                .HasColumnName("in_armor")
                .IsRequired();
            modelBuilder.Entity<RuneEntity>()
                .Property(re => re.InShield)
                .HasColumnName("in_shield")
                .IsRequired();
        }

        public static void BuildCharacterEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterEntity>()
                .ToTable("characters")
                .HasKey(ce => new { ce.Id });

            modelBuilder.Entity<CharacterEntity>()
                .Property(ce => ce.Id)
                .HasColumnName("id")
                .IsConcurrencyToken();
            modelBuilder.Entity<CharacterEntity>()
                .Property(ce => ce.Class)
                .HasColumnName("class")
                .IsRequired();
            modelBuilder.Entity<CharacterEntity>()
                .Property(ce => ce.Name)
                .HasColumnName("name")
                .IsRequired();
            modelBuilder.Entity<CharacterEntity>()
                .Property(ce => ce.Level)
                .HasColumnName("level")
                .IsRequired()
                .IsConcurrencyToken();
            modelBuilder.Entity<CharacterEntity>()
                .Property(ce => ce.IsLadder)
                .HasColumnName("is_ladder")
                .IsRequired();
            modelBuilder.Entity<CharacterEntity>()
                .Property(ce => ce.IsExpansion)
                .HasColumnName("is_expansion")
                .IsRequired();
            modelBuilder.Entity<CharacterEntity>()
                .HasMany(ce => ce.Runes)
                .WithOne((cre) => cre.Character)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CharacterEntity>()
                .HasOne(ce => ce.Account)
                .WithMany(ae => ae.Characters)
                .HasForeignKey(ce => ce.AccountId)
                .HasConstraintName("fk_character_account")
                .IsRequired();
            modelBuilder.Entity<CharacterEntity>()
                .Property(ce => ce.AccountId)
                .HasColumnName("account_id")
                .IsRequired();
        }

        public static void BuildCharacterRuneEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterRuneEntity>()
                .ToTable("character_rune_switch")
                .HasKey(crse => new { crse.CharacterId, crse.RuneId });

            modelBuilder.Entity<CharacterRuneEntity>()
                 .HasOne(crse => crse.Character)
                 .WithMany(c => c.Runes)
                 .HasForeignKey(crse => crse.CharacterId)
                 .HasConstraintName("fk_character_rune_character_id");
            modelBuilder.Entity<CharacterRuneEntity>()
                 .Property(crse => crse.CharacterId)
                 .HasColumnName("character_id");
            modelBuilder.Entity<CharacterRuneEntity>()
                 .HasOne(crse => crse.Rune)
                 .WithMany(r => r.Characters)
                 .HasForeignKey(crse => crse.RuneId)
                 .HasConstraintName("fk_character_rune_rune_id");
            modelBuilder.Entity<CharacterRuneEntity>()
                 .Property(crse => crse.RuneId)
                 .HasColumnName("rune_id");
        }

        public static void BuildItemTypeEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemTypeEntity>()
                .ToTable("item_types")
                .HasKey(ite => new { ite.Id });

            modelBuilder.Entity<ItemTypeEntity>()
                .Property(ite => ite.Id)
                .HasColumnName("id");
            modelBuilder.Entity<ItemTypeEntity>()
                .Property(ite => ite.Name)
                .HasColumnName("name")
                .IsRequired();
            modelBuilder.Entity<ItemTypeEntity>()
                .Property(ite => ite.Group)
                .HasColumnName("item_group");
        }

        public static void BuildRuneWordIngredientEntity(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RuneWordIngredientEntity>()
                .ToTable("rune_word_ingredients")
                .HasKey(rwie => new { rwie.Id });

            modelBuilder.Entity<RuneWordIngredientEntity>()
                .Property(rwie => rwie.Id)
                .HasColumnName("id");
            modelBuilder.Entity<RuneWordIngredientEntity>()
                .Property(rwie => rwie.Order)
                .HasColumnName("ingredient_order")
                .IsRequired();
            modelBuilder.Entity<RuneWordIngredientEntity>()
                .Property(rwie => rwie.RuneId)
                .HasColumnName("rune_id")
                .IsRequired();
            modelBuilder.Entity<RuneWordIngredientEntity>()
                .HasOne(rwie => rwie.Rune)
                .WithMany(re => re.RuneWords)
                .HasForeignKey(rwie => rwie.RuneId)
                .HasConstraintName("fk_rune_word_ingredients_rune");
            modelBuilder.Entity<RuneWordIngredientEntity>()
                .Property(rwie => rwie.RuneWordId)
                .HasColumnName("rune_word_id")
                .IsRequired();
            modelBuilder.Entity<RuneWordIngredientEntity>()
                .HasOne(rwie => rwie.RuneWord)
                .WithMany(rwe => rwe.Ingredients)
                .HasForeignKey(rwie => rwie.RuneWordId)
                .HasConstraintName("fk_rune_word_ingredients_rune_word");
        }

        public static void BuildRuneWordEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RuneWordEntity>()
                .ToTable("rune_words")
                .HasKey(rwe => new { rwe.Id });

            modelBuilder.Entity<RuneWordEntity>()
                .Property(rwe => rwe.Id)
                .HasColumnName("id");
            modelBuilder.Entity<RuneWordEntity>()
                .Property(rwe => rwe.Name)
                .HasColumnName("name")
                .IsRequired();
            modelBuilder.Entity<RuneWordEntity>()
                .Property(rwe => rwe.Class)
                .HasColumnName("class");
            modelBuilder.Entity<RuneWordEntity>()
                .Property(rwe => rwe.Level)
                .HasColumnName("level")
                .IsRequired();
            modelBuilder.Entity<RuneWordEntity>()
                .Property(rwe => rwe.IsLadder)
                .HasColumnName("is_ladder")
                .IsRequired();
        }

        public static void BuildSkillEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillEntity>()
                .ToTable("skills")
                .HasKey(se => new { se.Id });

            modelBuilder.Entity<SkillEntity>()
                .Property(se => se.Id)
                .HasColumnName("id");
            modelBuilder.Entity<SkillEntity>()
                .Property(se => se.Name)
                .HasColumnName("name")
                .IsRequired();
            modelBuilder.Entity<SkillEntity>()
                .Property(se => se.Class)
                .HasColumnName("class")
                .IsRequired();
            modelBuilder.Entity<SkillEntity>()
                .Property(se => se.Description)
                .HasColumnName("description")
                .IsRequired();
            modelBuilder.Entity<SkillEntity>()
                .HasMany(se => se.Properties)
                .WithOne(pe => pe.Skill);
        }

        public static void BuildPropertyEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RuneWordPropertyEntity>()
                .ToTable("rune_word_properties")
                .HasKey(pe => new { pe.Id });

            modelBuilder.Entity<RuneWordPropertyEntity>()
                .Property(pe => pe.Id)
                .HasColumnName("id");
            modelBuilder.Entity<RuneWordPropertyEntity>()
                .Property(pe => pe.Description)
                .HasColumnName("description")
                .IsRequired();
            modelBuilder.Entity<RuneWordPropertyEntity>()
                .Property(pe => pe.SkillId)
                .HasColumnName("skill_id");
            modelBuilder.Entity<RuneWordPropertyEntity>()
                .HasOne(pe => pe.Skill)
                .WithMany(se => se.Properties)
                .HasForeignKey(pe => pe.SkillId)
                .HasConstraintName("fk_properties_skill_id");
            modelBuilder.Entity<RuneWordPropertyEntity>()
                .Property(pe => pe.RuneWordId)
                .HasColumnName("rune_word_id");
            modelBuilder.Entity<RuneWordPropertyEntity>()
                .HasOne(pe => pe.RuneWord)
                .WithMany(rwe => rwe.Properties)
                .HasForeignKey(pe => pe.RuneWordId)
                .HasConstraintName("fk_properties_rune_word_id");
        }

        public static void BuildRuneWordItemTypeEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RuneWordItemTypeEntity>()
                .ToTable("rune_word_item_type_switch")
                .HasKey(rwite => new { rwite.Id });

            modelBuilder.Entity<RuneWordItemTypeEntity>()
                .Property(rwite => rwite.Id)
                .HasColumnName("id");
            modelBuilder.Entity<RuneWordItemTypeEntity>()
                .Property(rwite => rwite.ItemTypeId)
                .HasColumnName("item_type_id")
                .IsRequired();
            modelBuilder.Entity<RuneWordItemTypeEntity>()
                .Property(rwite => rwite.RuneWordId)
                .HasColumnName("rune_word_id");
            modelBuilder.Entity<RuneWordItemTypeEntity>()
                .HasOne(rwite => rwite.ItemType)
                .WithMany(ite => ite.RuneWords)
                .HasForeignKey(rwite => rwite.ItemTypeId)
                .HasConstraintName("fk_rune_word_item_type_item_type");
            modelBuilder.Entity<RuneWordItemTypeEntity>()
                .HasOne(rwite => rwite.RuneWord)
                .WithMany(rwe => rwe.ItemTypes)
                .HasForeignKey(rwite => rwite.RuneWordId)
                .HasConstraintName("fk_rune_word_item_type_rune_word");
        }
    }

    internal class LastModifiedValueGenerator : ValueGenerator
    {
        public override bool GeneratesTemporaryValues { get; }

        protected override object NextValue([NotNull] EntityEntry entry)
        {
            return DateTime.UtcNow;
        }
    }
}
