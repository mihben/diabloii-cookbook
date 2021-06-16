using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Application.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.QueryHandlers
{
    public class GetCharactersQueryHandler : IQueryHandler<GetCharactersQuery, IEnumerable<Guid>>
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ILogger<GetCharactersQueryHandler> _logger;

        public GetCharactersQueryHandler(DatabaseContext databaseContext, ILogger<GetCharactersQueryHandler> logger)
        {
            _databaseContext = databaseContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Guid>> HandleAsync(GetCharactersQuery query, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Get characters");

            var account = await _databaseContext.Accounts
                .Include(ae => ae.Characters)
                .FirstOrDefaultAsync(ae => ae.BattleTag.Equals(query.BattleTag), cancellationToken);
            return account.Characters.Select(c => c.Id).ToList();
        }
    }
}
