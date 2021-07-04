using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Client.Extensions;
using Netension.Request.Abstraction.Senders;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Services
{
    public class HttpCharacterService : ICharacterService
    {
        private readonly ICommandSender _commandSender;
        private readonly IQuerySender _querySender;

        public HttpCharacterService(ICommandSender commandSender, IQuerySender querySender)
        {
            _commandSender = commandSender;
            _querySender = querySender;
        }

        public async Task<Guid> CreateAsync(string @class, string name, int level, bool isExpansion, bool isLadder, CancellationToken cancellationToken)
        {
            await _commandSender.SendAsync(new CreateCharacterCommand("Mihben#1868", @class, name, level, isLadder, isExpansion), cancellationToken);

            return Guid.Empty;
        }

        public async Task<Character> GetCharacterAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _querySender.QueryAsync(new GetCharacterDetailQuery(id), cancellationToken);
        }

        public async Task<IEnumerable<Guid>> GetCharactersAsync(CancellationToken cancellationToken)
        {
            return await _querySender.QueryAsync(new GetCharactersQuery("Mihben#1868"), cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _commandSender.SendAsync(new DeleteCharacterCommand(id), cancellationToken);
        }

        public async Task UpdateAsync(Guid id, int level, IEnumerable<Rune> runes, CancellationToken cancellationToken)
        {
            await _commandSender.SendAsync(new UpdateCharacterCommand(id, level, runes), cancellationToken);
        }
    }
}
