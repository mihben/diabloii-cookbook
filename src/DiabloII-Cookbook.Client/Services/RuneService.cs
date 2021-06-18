using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Client.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Services
{
    public class RuneService : IRuneService
    {
        private readonly HttpClient _client;

        public RuneService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Rune>> GetRunesAsync(CancellationToken cancellationToken)
        {
            return await _client.QueryAsync(new GetRunesQuery(), cancellationToken);
        }

        public async Task<IEnumerable<RuneWord>> GetRuneWordsAsync(CancellationToken cancellationToken)
        {
            return await _client.QueryAsync(new GetAllRuneWordsQuery(), cancellationToken);
        }
    }
}
