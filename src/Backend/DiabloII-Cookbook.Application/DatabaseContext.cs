using DiabloII_Cookbook.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DiabloII_Cookbook.Application
{
    public class DatabaseContext : DbContext
    {
        public DbSet<RuneEntity> Runes { get; set; }
        public DbSet<CharacterEntity> Characters { get; set; }

        public DatabaseContext([NotNull] DbContextOptions options) 
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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

            modelBuilder.Entity<CharacterEntity>()
                .ToTable("characters")
                .HasKey(ce => new { ce.Id });

            modelBuilder.Entity<CharacterEntity>()
                .Property(ce => ce.Id)
                .HasColumnName("id");
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
                .IsRequired();
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

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
