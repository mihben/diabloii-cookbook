using DiabloII_Cookbook.Api.DataTransferObjects;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Web.Models
{
    public class UpdateCharacter
    {
        public int Level { get; }
        public IEnumerable<Rune> Runes { get; }

        public UpdateCharacter(int level, IEnumerable<Rune> runes)
        {
            Level = level;
            Runes = runes;
        }
    }
}
