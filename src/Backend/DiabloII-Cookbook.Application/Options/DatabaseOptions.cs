using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DiabloII_Cookbook.Application.Options
{
    [ExcludeFromCodeCoverage]
    public class DatabaseOptions
    {
        [Required]
        public string Host { get; set; }
        [Required]
        public object Database { get; set; }
        public int Port { get; set; } = 5432;
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
