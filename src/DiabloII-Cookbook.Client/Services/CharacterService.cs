using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Client.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly HttpClient _client;

        public CharacterService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateAsync(string @class, string name, int level, bool isExpansion, bool isLadder, CancellationToken cancellationToken)
        {
            await _client.SendAsync(new CreateCharacterCommand("Mihben#1868", @class, name, level, isLadder, isExpansion), cancellationToken);
        }

        public async Task<Character> GetCharacterAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _client.QueryAsync(new GetCharacterDetailQuery(id), cancellationToken);
        }

        public async Task<IEnumerable<Guid>> GetCharactersAsync(CancellationToken cancellationToken)
        {
            var response = await _client.GetAsync("api/character", cancellationToken);
            return await response.Content.ReadFromJsonAsync<IEnumerable<Guid>>(cancellationToken: cancellationToken);
        }
    }
}
