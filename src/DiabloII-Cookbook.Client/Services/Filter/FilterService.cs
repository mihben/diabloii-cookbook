using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Client.Extensions;
using Netension.Request.Abstraction.Senders;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Services
{
    public class FilterService : IFilterService
    {
        private readonly IQuerySender _querySender;

        public FilterService(IQuerySender querySender)
        {
            _querySender = querySender;
        }

        public async Task<IEnumerable<ItemType>> GetItemTypesAsync(CancellationToken cancellationToken)
        {
            return await _querySender.QueryAsync(new GetItemTypesQuery(), cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<string>> GetClassesAsync(CancellationToken cancellationToken)
        {
            return await _querySender.QueryAsync(new GetClassesQuery(), cancellationToken).ConfigureAwait(false);
        }
    }
}
