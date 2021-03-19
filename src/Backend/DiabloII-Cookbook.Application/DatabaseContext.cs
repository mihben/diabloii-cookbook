using DiabloII_Cookbook.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics.CodeAnalysis;

namespace DiabloII_Cookbook.Application
{
    public class DatabaseContext : DbContext
    {
        public DbSet<RuneEntity> Runes { get; set; }

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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
