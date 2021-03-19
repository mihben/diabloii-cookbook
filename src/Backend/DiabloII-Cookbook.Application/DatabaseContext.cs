using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DiabloII_Cookbook.Application
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext([NotNull] DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Database.EnsureCreated();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
