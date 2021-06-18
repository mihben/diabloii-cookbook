using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Client.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Services
{
    public class FilterService : IFilterService
    {
        private readonly HttpClient _client;

        public FilterService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ItemType>> GetItemTypesAsync(CancellationToken cancellationToken)
        {
            return await _client.QueryAsync(new GetItemTypesQuery(), cancellationToken);
        }
    }
}
