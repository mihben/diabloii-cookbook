using Blazored.LocalStorage;
using DiabloII_Cookbook.Api.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Services
{
    public class LocalCharacterService : ICharacterService
    {
        private const string KEY = "characters";

        private readonly ILocalStorageService _storage;

        public LocalCharacterService(ILocalStorageService storage)
        {
            _storage = storage;
        }

        public async Task CreateAsync(string @class, string name, int level, bool isExpansion, bool isLadder, CancellationToken cancellationToken)
        {
            var characters = await ReadCharactersAsync(cancellationToken);
            characters.Add(new Character(Guid.NewGuid(), @class, name, level, isLadder, isExpansion, Enumerable.Empty<Rune>()));
            await _storage.SetItemAsync(KEY, characters, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var characters = await ReadCharactersAsync(cancellationToken);
            var character = characters.Single(c => c.Id.Equals(id));
            characters.Remove(character);
            await _storage.SetItemAsync(KEY, characters, cancellationToken);
        }

        public async Task<Character> GetCharacterAsync(Guid id, CancellationToken cancellationToken)
        {
            var characters = await ReadCharactersAsync(cancellationToken);
            return characters.Single(c => c.Id.Equals(id));
        }

        public async Task<IEnumerable<Guid>> GetCharactersAsync(CancellationToken cancellationToken)
        {
            var characters = await ReadCharactersAsync(cancellationToken);
            return characters.Select(c => c.Id);
        }

        public async Task UpdateAsync(Guid id, int level, CancellationToken cancellationToken)
        {
            var characters = await ReadCharactersAsync(cancellationToken);
            var character = characters.Single(c => c.Id.Equals(id));
            characters.Remove(character);
            characters.Add(new Character(id, character.Class, character.Name, level, character.IsLadder, character.IsExpansion, character.Runes));
            await _storage.SetItemAsync(KEY, characters, cancellationToken);
        }

        private async Task<ICollection<Character>> ReadCharactersAsync(CancellationToken cancellationToken)
        {
            return await _storage.GetItemAsync<ICollection<Character>>(KEY, cancellationToken) ?? new List<Character>();
        }
    }
}
