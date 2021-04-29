using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Application.Entities;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.IntegrationTest.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<bool> ValidateAsync(this HttpResponseMessage message, CharacterEntity entity)
        {
            var character = await message.Content.ReadFromJsonAsync<Character>();

            return character.Id.Equals(entity.Id) &&
                character.Class.Equals(entity.Class) &&
                character.Name.Equals(entity.Name) &&
                character.IsExpansion.Equals(entity.IsExpansion) &&
                character.IsLadder.Equals(entity.IsLadder) &&
                character.Runes.OrderBy(r => r.Id).Select(r => r.Id).SequenceEqual(entity.Runes.Select(r => r.Rune).OrderBy(r => r.Id).Select(r => r.Id));
        }
    }
}
