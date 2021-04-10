using DiabloII_Cookbook.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DiabloII_Cookbook.Application.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ItemTypeEntity> ItemTypes { get; set; }
        public DbSet<RuneWordEntity> RuneWords { get; set; }
        public DbSet<RuneEntity> Runes { get; set; }
        public DbSet<CharacterEntity> Characters { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }

        public DatabaseContext([NotNull] DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildAccountEntity();
            modelBuilder.BuildRuneEntity();
            modelBuilder.BuildCharacterEntity();
            modelBuilder.BuildCharacterRuneEntity();
            modelBuilder.BuildItemTypeEntity();
            modelBuilder.BuildRuneWordIngredientEntity();
            modelBuilder.BuildRuneWordEntity();
            modelBuilder.BuildSkillEntity();
            modelBuilder.BuildPropertyEntity();
            modelBuilder.BuildRuneWordItemTypeEntity();

            base.OnModelCreating(modelBuilder);
        }
    }
}
