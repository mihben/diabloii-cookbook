using DiabloII_Cookbook.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DiabloII_Cookbook.Application.Contexts
{
    public class FilterContext : DbContext
    {
        public DbSet<ItemTypeEntity> ItemTypes { get; set; }
        public DbSet<RuneWordEntity> RuneWords { get; set; }

        public FilterContext([NotNull] DbContextOptions<FilterContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
