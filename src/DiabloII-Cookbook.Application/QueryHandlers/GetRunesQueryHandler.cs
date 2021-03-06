using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.Application.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.QueryHandlers
{
    public class GetRunesQueryHandler : IQueryHandler<GetRunesQuery, IEnumerable<Rune>>
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<GetRunesQueryHandler> _logger;

        public GetRunesQueryHandler(DatabaseContext context, ILogger<GetRunesQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Rune>> HandleAsync(GetRunesQuery query, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Get all runes");

            await _context.Database.EnsureCreatedAsync(cancellationToken).ConfigureAwait(false);

            return (await _context.Runes.OrderBy(r => r.Order).ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                    .Select(re => re.ToDto());
        }
    }
}
