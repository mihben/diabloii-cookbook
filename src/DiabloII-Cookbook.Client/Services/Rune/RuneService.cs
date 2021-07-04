using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Client.Extensions;
using Netension.Request.Abstraction.Senders;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Services
{
    public class RuneService : IRuneService
    {
        private readonly IQuerySender _querySender;

        public RuneService(IQuerySender querySender)
        {
            _querySender = querySender;
        }

        public async Task<IEnumerable<Rune>> GetRunesAsync(CancellationToken cancellationToken)
        {
            return await _querySender.QueryAsync(new GetRunesQuery(), cancellationToken);
        }

        public async Task<IEnumerable<RuneWord>> GetRuneWordsAsync(CancellationToken cancellationToken)
        {
            return await _querySender.QueryAsync(new GetAllRuneWordsQuery(), cancellationToken);
        }

        public async Task<IEnumerable<RuneWord>> GetRuneWordsAsync(IEnumerable<Rune> runes, IEnumerable<ItemType> itemTypes, CancellationToken cancellationToken)
        {
            return await _querySender.QueryAsync(new GetRuneWordsQuery(itemTypes, runes), cancellationToken);
        }
    }
}
