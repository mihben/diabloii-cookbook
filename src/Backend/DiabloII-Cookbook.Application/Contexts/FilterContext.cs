using DiabloII_Cookbook.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DiabloII_Cookbook.Application.Contexts
{
    public class FilterContext : DbContext
    {
        public DbSet<ItemTypeEntity> ItemTypes { get; set; }

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
